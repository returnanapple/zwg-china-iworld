using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.IO.IsolatedStorage;

namespace zwg_china.backstage.framework
{
    /// <summary>
    /// 操作视图的基类
    /// </summary>
    public abstract class ManagerViewModelBase : ViewModelBase
    {
        #region 私有变量

        string username = "";
        bool readedUsername = false;
        string group = "";
        bool readedGroup = false;
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
        }

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
        }

        #endregion
    }
}
