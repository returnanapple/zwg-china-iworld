using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using zwg_china.backstage.framework.SettingOfAuthorService;
using zwg_china.backstage.framework.AdministratorService;

namespace zwg_china.backstage.framework
{
    public class SystemQuotasViewModel : ManagerViewModelBase
    {
        #region 私有字段

        SettingOfAuthorServiceClient client = new SettingOfAuthorServiceClient();

        #endregion

        #region 属性

        /// <summary>
        /// 高点号配额方案
        /// </summary>
        public ObservableCollection<EditSQModel> SystemQuotas { get; set; }

        /// <summary>
        /// 刷新命令
        /// </summary>
        public UniversalCommand RefreshCommand { get; set; }

        /// <summary>
        /// 修改命令
        /// </summary>
        public UniversalCommand EditCommand { get; set; }

        #endregion

        #region 构造方法

        public SystemQuotasViewModel()
            : base("用户管理", "高点号配额方案")
        {
            this.SystemQuotas = new ObservableCollection<EditSQModel>();

            this.RefreshCommand = new UniversalCommand(Refresh);
            this.EditCommand = new UniversalCommand(Edit);

            client.GetSystemQuotasCompleted += ShowSetting;
            client.SetStstemQuotaCompleted += ShowEditResult;
            Refresh();
        }

        #region 显示设置明细

        void ShowSetting(object sender, GetSystemQuotasCompletedEventArgs e)
        {
            if (e.Result.Success)
            {
                this.SystemQuotas.Clear();
                e.Result.Info.ForEach(x =>
                    {
                        this.SystemQuotas.Add(new EditSQModel(x));
                    });
            }
            else
            {
                ShowError(e.Result.Error);
            }
        }

        #endregion

        #endregion

        #region 私有方法

        void Refresh(object obj = null)
        {
            GetSystemQuotaImport import = new GetSystemQuotaImport
            {
                Token = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo).Token
            };
            client.GetSystemQuotasAsync(import);
        }

        void Edit(object obj = null)
        {
            IPop<string> cw = ViewModelService.GetPop(Pop.NormalPrompt) as IPop<string>;
            cw.State = "你确定要修改基础系统设置吗？";
            cw.Closed += Edit_do;
            cw.Show();
        }

        void Edit_do(object sender, EventArgs e)
        {
            IPop cw = (IPop)sender;
            if (cw.DialogResult != true) { return; }

            SetStstemQuotaImport import = new SetStstemQuotaImport
            {
                Quotas = new List<SetStstemQuotaImport.QuotaImport>(),
                Token = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo).Token
            };
            this.SystemQuotas.ToList().ForEach(x =>
                {
                    SetStstemQuotaImport.QuotaImport sq = new SetStstemQuotaImport.QuotaImport
                    {
                        Rebate = x.Rebate,
                        Details = new List<SetStstemQuotaImport.QuotaDetailImport>()
                    };
                    x.Details.ForEach(d =>
                        {
                            sq.Details.Add(new SetStstemQuotaImport.QuotaDetailImport { Rebate = d.Rebate, Sum = d.Sum });
                        });
                    import.Quotas.Add(sq);
                });
            client.SetStstemQuotaAsync(import);
        }
        void ShowEditResult(object sender, SetStstemQuotaCompletedEventArgs e)
        {
            if (e.Result.Success)
            {
                ShowError("修改成功");
                Refresh();
            }
            else
            {
                ShowError(e.Result.Error);
            }
        }

        #endregion
    }
}
