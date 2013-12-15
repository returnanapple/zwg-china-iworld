using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zwg_china.client.framework.AuthorService;

namespace zwg_china.client.framework
{
    /// <summary>
    /// 修改资金密码页的视图模型
    /// </summary>
    public class EditSelfFundsCodeViewModel : ManagerViewModelBase
    {
        #region 私有字段

        string oldFundsCode = "";
        string newFundsCode = "";

        #endregion

        #region 公开属性

        /// <summary>
        /// 用户名
        /// </summary>
        public string OldFundsCode
        {
            get
            {
                return oldFundsCode;
            }
            set
            {
                if (oldFundsCode != value)
                {
                    oldFundsCode = value;
                    OnPropertyChanged("OldFundsCode");
                }
            }
        }

        /// <summary>
        /// 密码
        /// </summary>
        public string NewFundsCode
        {
            get
            {
                return newFundsCode;
            }
            set
            {
                if (newFundsCode != value)
                {
                    newFundsCode = value;
                    OnPropertyChanged("NewFundsCode");
                }
            }
        }

        /// <summary>
        /// 修改的命令
        /// </summary>
        public UniversalCommand EdirCommand { get; set; }

        #endregion

        #region 构造方法

        public EditSelfFundsCodeViewModel()
            : base("个人中心")
        {

        }

        #endregion

        #region 私有方法

        void Edit(object obj)
        {
            EditFundsCodeImport import = new EditFundsCodeImport
            {
                OldFundsCode = this.OldFundsCode,
                NewFundsCode = this.NewFundsCode,
                Token = DataManager.GetValue<string>(DataKey.IWorld_Client_Token)
            };
            AuthorServiceClient client = new AuthorServiceClient();
            client.EditFundsCodeCompleted += ShowEditFundsCodeResult;
            client.EditFundsCodeAsync(import);
        }

        void ShowEditFundsCodeResult(object sender, EditFundsCodeCompletedEventArgs e)
        {
            if (e.Result.Success)
            {
                IPop<string> cw = ViewModelService.GetPop(Pop.ErrorPrompt) as IPop<string>;
                cw.State = "修改密码成功,请重新登陆";
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
            DataManager.RemoveValue(DataKey.IWorld_Client_Setting);
            DataManager.RemoveValue(DataKey.IWorld_Client_Tickets);
            DataManager.RemoveValue(DataKey.IWorld_Client_Token);
            DataManager.RemoveValue(DataKey.IWorld_Client_UserInfo);
            ViewModelService.JumpToDefaultPage();
        }

        #endregion
    }
}
