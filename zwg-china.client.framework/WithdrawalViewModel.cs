using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zwg_china.client.framework.RecordOfAuthorService;

namespace zwg_china.client.framework
{
    /// <summary>
    /// 提现界面的试图模型
    /// </summary>
    public class WithdrawalViewModel : ManagerViewModelBase
    {
        #region 私有字段

        public double sum = 0;
        public string fundsCode = "";

        #endregion

        #region 属性

        /// <summary>
        /// 提现金额
        /// </summary>
        public double Sum
        {
            get
            {
                return sum;
            }
            set
            {
                if (sum != value)
                {
                    sum = value;
                    OnPropertyChanged("Sum");
                }
            }
        }

        /// <summary>
        /// 资金密码
        /// </summary>
        public string FundsCode
        {
            get
            {
                return fundsCode;
            }
            set
            {
                if (fundsCode != value)
                {
                    fundsCode = value;
                    OnPropertyChanged("FundsCode");
                }
            }
        }

        public UniversalCommand WithdrawalCommand { get; set; }

        #endregion

        #region 构造方法

        public WithdrawalViewModel()
            : base("资金管理")
        {
            this.WithdrawalCommand = new UniversalCommand(Withdrawal);
        }

        #endregion

        #region 私有方法

        void Withdrawal(object obj)
        {
            IPop<string> cw = ViewModelService.GetPop(Pop.NormalPrompt) as IPop<string>;
            cw.State = string.Format("你确定要提交的额度为 {0} 的提现申请吗？", this.sum);
            cw.Closed += Withdrawal_do;
            cw.Show();
        }

        void Withdrawal_do(object sender, EventArgs e)
        {
            WithdrawImport import = new WithdrawImport
            {
                Sum = this.Sum,
                FundsCode = this.FundsCode,
                Token = DataManager.GetValue<string>(DataKey.IWorld_Client_Token)
            };
            RecordOfAuthorServiceClient client = new RecordOfAuthorServiceClient();
            client.WithdrawCompleted += ShowWithdrawalResult;
        }

        void ShowWithdrawalResult(object sender, WithdrawCompletedEventArgs e)
        {
            if (e.Result.Success)
            {
                IPop<string> cw = ViewModelService.GetPop(Pop.ErrorPrompt) as IPop<string>;
                cw.State = "添加提现申请成功";
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
            ViewModelService.JumpTo(Page.提现记录);
        }

        #endregion
    }
}
