using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.IO.IsolatedStorage;
using zwg_china.backstage.framework.AdministratorService;

namespace zwg_china.backstage.framework
{
    /// <summary>
    /// 操作视图的基类
    /// </summary>
    public abstract class ManagerViewModelBase : ViewModelBase
    {
        #region 私有变量

        string username = null;
        string group = null;
        string selectedText_Menu = "";
        string selectedText_Page = "";

        #endregion

        #region 公开属性

        /// <summary>
        /// 用户名
        /// </summary>
        public string Username
        {
            get
            {
                if (username == null)
                {
                    try
                    {
                        AdministratorExport administratorInfo = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo);
                        username = administratorInfo.Username;
                    }
                    catch (Exception)
                    {
                        username = "";
                    }
                }
                return username;
            }
        }

        /// <summary>
        /// 用户组
        /// </summary>
        public string Group
        {
            get
            {
                if (group == null)
                {
                    try
                    {
                        AdministratorExport administratorInfo = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo);
                        group = administratorInfo.Group.Name;
                    }
                    catch (Exception)
                    {
                        group = "";
                    }
                }
                return group;
            }
        }

        /// <summary>
        /// 导航选择文本
        /// </summary>
        public string SelectedText_Menu
        {
            get
            {
                return selectedText_Menu;
            }
            protected set
            {
                if (selectedText_Menu != value)
                {
                    selectedText_Menu = value;
                    OnPropertyChanged("SelectedText_Menu");
                }
            }
        }

        /// <summary>
        /// 页面选择文本
        /// </summary>
        public string SelectedText_Page
        {
            get
            {
                return selectedText_Page;
            }
            protected set
            {
                if (selectedText_Page != value)
                {
                    selectedText_Page = value;
                    OnPropertyChanged("SelectedText_Page");
                }
            }
        }

        /// <summary>
        /// 跳转命令
        /// </summary>
        public UniversalCommand JumpCommand { get; set; }

        /// <summary>
        /// 编辑账户命令
        /// </summary>
        public UniversalCommand EditAccountCommand { get; set; }

        /// <summary>
        /// 登出命令
        /// </summary>
        public UniversalCommand LogoutCommand { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的操作视图的基类
        /// </summary>
        /// <param name="selectedText_Menu">导航选择文本</param>
        /// <param name="selectedText_Page">页面选择文本</param>
        public ManagerViewModelBase(string selectedText_Menu, string selectedText_Page)
        {
            //初始化属性
            SelectedText_Menu = selectedText_Menu;
            SelectedText_Page = selectedText_Page;

            //初始化命令
            JumpCommand = new UniversalCommand(new Action<object>(Jump));
            EditAccountCommand = new UniversalCommand(new Action<object>(EditAccount));
            LogoutCommand = new UniversalCommand(new Action<object>(Logout));
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 登出
        /// </summary>
        /// <param name="parameter"></param>
        void Logout(object parameter)
        {
            IPop<string> cw = ViewModelService.GetPop(Pop.NormalPrompt) as IPop<string>;
            cw.State = "你想要退出后台管理吗？";
            cw.Closed += Logout_do;
            cw.Show();
        }
        #region 执行

        void Logout_do(object sender, EventArgs e)
        {
            IPop cw = sender as IPop;
            if (cw.DialogResult == true)
            {
                DataManager.RemoveValue(DataKey.IWorld_Backstage_AdministratorInfo);
                ViewModelService.JumpToDefaultPage();
            }
        }

        #endregion

        /// <summary>
        /// 跳转
        /// </summary>
        /// <param name="parameter">参数</param>
        void Jump(object parameter)
        {
            if (IsBusy)
            {
                return;
            }
            IsBusy = true;
            string pageName = parameter.ToString();
            ViewModelService.JumpTo(pageName);
        }

        /// <summary>
        /// 修改账户信息
        /// </summary>
        /// <param name="parameter">参数</param>
        void EditAccount(object parameter)
        {
            IPop cw = ViewModelService.GetPop(Pop.EditAccounTool);
            cw.Closed += EditAccount_do;
            cw.Show();
        }
        #region 执行

        void EditAccount_do(object sender, EventArgs e)
        {
            IPop<ManagerViewModelBase.EditEditAccounPackage> cw = sender as IPop<ManagerViewModelBase.EditEditAccounPackage>;
            if (cw.DialogResult == true)
            {
                ManagerViewModelBase.EditEditAccounPackage package = cw.State;
                if (package.NewPassword != package.NewPassword2)
                {
                    ShowError("两次输入的新密码不一致");
                }
                AdministratorExport self = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo);
                EditPasswordImport import = new EditPasswordImport
                {
                    OldPassowrd = package.OldPassword,
                    NewPassowrd = package.NewPassword,
                    Token = self.Token
                };
                AdministratorServiceClient client = new AdministratorServiceClient();
                client.EditPasswordCompleted += ShowEditAccountResult;
                client.EditPasswordAsync(import);
            }
        }

        #endregion
        #region 执行结果

        void ShowEditAccountResult(object sender, EditPasswordCompletedEventArgs e)
        {
            if (e.Result.Success)
            {
                IPop<string> cw = ViewModelService.GetPop(Pop.ErrorPrompt) as IPop<string>;
                cw.State = "修改密码成功，请重新登录";
                cw.Closed += Logout_do;
                cw.Show();
            }
            else
            {
                ShowError(e.Result.Error);
            }
        }

        #endregion

        #endregion

        #region 内嵌类型

        /// <summary>
        /// 用于修改账号密码的数据集
        /// </summary>
        public class EditEditAccounPackage
        {
            /// <summary>
            /// 原密码
            /// </summary>
            public string OldPassword { get; set; }

            /// <summary>
            /// 新密码
            /// </summary>
            public string NewPassword { get; set; }

            /// <summary>
            /// 新密码第二次
            /// </summary>
            public string NewPassword2 { get; set; }
        }

        #endregion
    }
}
