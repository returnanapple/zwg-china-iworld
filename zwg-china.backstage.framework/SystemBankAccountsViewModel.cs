using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zwg_china.backstage.framework.AdministratorService;
using zwg_china.backstage.framework.SettingOfAuthorService;

namespace zwg_china.backstage.framework
{
    /// <summary>
    /// 银行帐号设置页的视图模型
    /// </summary>
    public class SystemBankAccountsViewModel : ShowListViewModelBase<SystemBankAccountExport, SettingOfAuthorServiceClient>
    {
        #region 构造方法

        public SystemBankAccountsViewModel()
            : base("系统设置", "银行帐号设置")
        {
        }

        #endregion

        #region 保护方法

        protected override void Refresh(object obj)
        {
            int _pageIndex = obj == null ? this.PageIndex : Convert.ToInt32(obj);
            GetSystemBankAccountsImport import = new GetSystemBankAccountsImport
            {
                PageIndex = _pageIndex,
                Token = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo).Token
            };
            client.GetSystemBankAccountsAsync(import);
        }

        protected override void Reset(object obj)
        {
            this.PageIndex = 1;
            Refresh(null);
        }

        void ShowList(object sender, GetSystemBankAccountsCompletedEventArgs e)
        {
            if (e.Result.Success)
            {
                this.PageIndex = e.Result.PageIndex;
                this.TotalPage = e.Result.CountOfPage;
                UpdateLsit(e.Result.List);
            }
            else
            {
                ShowError(e.Result.Error);
            }
        }


        #endregion
    }
}
