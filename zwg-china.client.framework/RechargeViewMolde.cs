using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zwg_china.client.framework.RecordOfAuthorService;

namespace zwg_china.client.framework
{
    /// <summary>
    /// 充值界面的视图买模型
    /// </summary>
    public class RechargeViewMolde : ManagerViewModelBase
    {
        #region 私有字段

        public Bank comeFrom = Bank.无;
        public string serialNumber = "";

        #endregion

        #region 属性

        /// <summary>
        /// 来源银行
        /// </summary>
        public Bank ComeFrom
        {
            get
            {
                return comeFrom;
            }
            set
            {
                if (comeFrom != value)
                {
                    comeFrom = value;
                    OnPropertyChanged("ComeFrom");
                }
            }
        }

        /// <summary>
        /// 流水号
        /// </summary>
        public string SerialNumber
        {
            get
            {
                return serialNumber;
            }
            set
            {
                if (serialNumber != value)
                {
                    serialNumber = value;
                    OnPropertyChanged("SerialNumber");
                }
            }
        }

        /// <summary>
        /// 充值命令
        /// </summary>
        public UniversalCommand RechargeCommand { get; set; }

        #endregion

        #region 构造方法

        public RechargeViewMolde()
            : base("资金管理")
        {
            this.RechargeCommand = new UniversalCommand(Recharge);
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 充值
        /// </summary>
        /// <param name="obj"></param>
        void Recharge(object obj)
        {
            IPop<string> cw = ViewModelService.GetPop(Pop.NormalPrompt) as IPop<string>;
            cw.State = string.Format("你确定要提交的转账流水号为 {0} （{1}）的充值申请吗？"
                , this.SerialNumber
                , this.ComeFrom.ToString());
            cw.Closed += Recharge_do;
            cw.Show();
        }
        #region 执行和连锁操作

        void Recharge_do(object sender, EventArgs e)
        {
            IPop cw = sender as IPop;
            if (cw.DialogResult == true)
            {
                RechargeImport import = new RechargeImport
                {
                    ComeFrom = this.ComeFrom,
                    SerialNumber = this.SerialNumber,
                    Token = DataManager.GetValue<string>(DataKey.IWorld_Client_Token)
                };
                RecordOfAuthorServiceClient client = new RecordOfAuthorServiceClient();
                client.RechargeCompleted += ShowRechargeResult;
                this.IsBusy = true;
                client.RechargeAsync(import);
            }
        }

        void ShowRechargeResult(object sender, RechargeCompletedEventArgs e)
        {
            if (e.Result.Success)
            {
                IPop<string> cw = ViewModelService.GetPop(Pop.ErrorPrompt) as IPop<string>;
                cw.State = "添加充值申请成功";
                cw.Closed += JumpToRecordsPage;
                cw.Show();
            }
            else
            {
                this.IsBusy = false;
                ShowError(e.Result.Error);
            }
        }

        void JumpToRecordsPage(object sender, EventArgs e)
        {
            ViewModelService.JumpTo(Page.充值记录);
        }

        #endregion

        #endregion
    }
}
