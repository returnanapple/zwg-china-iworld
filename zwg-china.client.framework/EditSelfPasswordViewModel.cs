using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zwg_china.client.framework.AuthorService;

namespace zwg_china.client.framework
{
    /// <summary>
    /// 修改密码页的数据模型
    /// </summary>
    public class EditSelfPasswordViewModel : ManagerViewModelBase
    {
        #region 私有字段

        string oldPassword = "";
        string newPassword = "";

        #endregion

        #region 公开属性

        /// <summary>
        /// 用户名
        /// </summary>
        public string OldPassword
        {
            get
            {
                return oldPassword;
            }
            set
            {
                if (oldPassword != value)
                {
                    oldPassword = value;
                    OnPropertyChanged("OldPassword");
                }
            }
        }

        /// <summary>
        /// 密码
        /// </summary>
        public string NewPassword
        {
            get
            {
                return newPassword;
            }
            set
            {
                if (newPassword != value)
                {
                    newPassword = value;
                    OnPropertyChanged("NewPassword");
                }
            }
        }

        /// <summary>
        /// 修改的命令
        /// </summary>
        public UniversalCommand EdirCommand { get; set; }

        #endregion

        #region 构造方法

        public EditSelfPasswordViewModel()
            : base("个人中心")
        {

        }

        #endregion

        #region 私有方法

        void Edit(object obj)
        {
            EditPasswordImport import = new EditPasswordImport
            {
                OldPassword = this.OldPassword,
                NewPassword = this.NewPassword,
                Token = DataManager.GetValue<string>(DataKey.IWorld_Client_Token)
            };
            AuthorServiceClient client = new AuthorServiceClient();
            client.EditPasswordCompleted += ShowEditPasswordResult;
            client.EditPasswordAsync(import);
        }

        void ShowEditPasswordResult(object sender, EditPasswordCompletedEventArgs e)
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
