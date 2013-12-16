using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zwg_china.client.framework.AuthorService;

namespace zwg_china.client.framework
{
    /// <summary>
    /// 修改银行卡信息页的视图模型
    /// </summary>
    public class EditSelfBankInfoViewModel : ManagerViewModelBase
    {
        #region 私有字段

        string holderOfTheCard = "";
        string card = "";
        Bank bankOfTheCard = Bank.无;

        #endregion

        #region 属性

        /// <summary>
        /// 开户人
        /// </summary>
        public string HolderOfTheCard
        {
            get
            {
                return holderOfTheCard;
            }
            set
            {
                if (holderOfTheCard != value)
                {
                    holderOfTheCard = value;
                    OnPropertyChanged("HolderOfTheCard");
                }
            }
        }

        /// <summary>
        /// 银行卡
        /// </summary>
        public string Card
        {
            get
            {
                return card;
            }
            set
            {
                if (card != value)
                {
                    card = value;
                    OnPropertyChanged("Card");
                }
            }
        }

        /// <summary>
        /// 银行
        /// </summary>
        public Bank BankOfTheCard
        {
            get
            {
                return bankOfTheCard;
            }
            set
            {
                if (bankOfTheCard != value)
                {
                    bankOfTheCard = value;
                    OnPropertyChanged("BankOfTheCard");
                }
            }
        }

        /// <summary>
        /// 修改的命令
        /// </summary>
        public UniversalCommand EdirCommand { get; set; }

        #endregion

        #region 构造方法

        public EditSelfBankInfoViewModel()
            : base("个人中心")
        {
            this.EdirCommand = new UniversalCommand(Edit);
        }

        #endregion

        #region 私有方法

        void Edit(object obj)
        {
            EditBankImport import = new EditBankImport
            {
                HolderOfTheCard = this.HolderOfTheCard,
                Card = this.Card,
                BankOfTheCard = this.BankOfTheCard,
                Token = DataManager.GetValue<string>(DataKey.IWorld_Client_Token)
            };
            AuthorServiceClient client = new AuthorServiceClient();
            client.EditBankCompleted += ShowEditPasswordResult;
            client.EditBankAsync(import);
        }

        void ShowEditPasswordResult(object sender, EditBankCompletedEventArgs e)
        {
            if (e.Result.Success)
            {
                IPop<string> cw = ViewModelService.GetPop(Pop.ErrorPrompt) as IPop<string>;
                cw.State = "修改银行账户绑定成功,请重新登陆";
                cw.Closed += Logout;
                cw.Show();
            }
            else
            {
                ShowError(e.Result.Error);
            }
        }

        void Logout(object sender, EventArgs e)
        {
            ClearInfoAndLogout();
        }

        #endregion
    }
}
