using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using zwg_china.backstage.framework.AdministratorService;

namespace zwg_china.backstage.framework
{
    /// <summary>
    /// 登陆页的视图模型
    /// </summary>
    public class LoginViewModel : ViewModelBase
    {
        #region 私有字段

        string _username = "";
        string _password = "";
        bool _rememberMe = false;
        string _error = "";

        #endregion

        #region 公开属性

        /// <summary>
        /// 用户名
        /// </summary>
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                if (_username != value)
                {
                    _username = value;
                    OnPropertyChanged("Username");
                    RememberMe = false;
                }
            }
        }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged("Password");
                    RememberMe = false;
                }
            }
        }

        /// <summary>
        /// 一个布尔值 标识是否记住密码
        /// </summary>
        public bool RememberMe
        {
            get
            {
                return _rememberMe;
            }
            set
            {
                if (_rememberMe != value)
                {
                    _rememberMe = value;
                    OnPropertyChanged("RememberMe");
                }
            }
        }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string Error
        {
            get
            {
                return _error;
            }
            protected set
            {
                if (_error != value)
                {
                    _error = value;
                    OnPropertyChanged("Error");
                }
            }
        }

        /// <summary>
        /// 登陆通知
        /// </summary>
        public UniversalCommand LoginCommand { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的登陆页的视图模型
        /// </summary>
        public LoginViewModel()
        {
            this.LoginCommand = new UniversalCommand(Login);

            bool hadRememberMe = DataManager.HaveValue<LoginPackage>(DataKey.IWorld_Backstage_RememberMe);
            if (hadRememberMe)
            {
                LoginPackage package = DataManager.GetValue<LoginPackage>(DataKey.IWorld_Backstage_RememberMe);
                this.Username = package.Username;
                this.Password = package.Password;
                this.RememberMe = true;
            }
        }

        #endregion

        #region 私有方法

        //登陆
        void Login(object parameter)
        {
            if (IsBusy)
            {
                return;
            }
            IsBusy = true;

            //重置提示栏
            this.Error = "";

            #region 记住密码

            if (this.RememberMe == true)
            {
                LoginPackage package = new LoginPackage(this.Username, this.Password);
                DataManager.SetValue(DataKey.IWorld_Backstage_RememberMe, package);
            }
            else
            {
                DataManager.RemoveValue(DataKey.IWorld_Backstage_RememberMe);
            }

            #endregion

            //登陆
            AdministratorServiceClient client = new AdministratorServiceClient();
            client.LoginCompleted += ShowLoginResult;
            LoginImport import = new LoginImport
            {
                Username = this.Username,
                Password = this.Password
            };
            client.LoginAsync(import);
        }
        #region 登陆结果

        //处理登陆结果
        void ShowLoginResult(object sender, LoginCompletedEventArgs e)
        {
            if (e.Result.Success)
            {
                DataManager.SetValue(DataKey.IWorld_Backstage_AdministratorInfo, e.Result.Info);
                ViewModelService.JumpTo(Page.首页);
            }
            else
            {
                this.Error = e.Result.Error;

                DataManager.RemoveValue(DataKey.IWorld_Backstage_AdministratorInfo);
                DataManager.RemoveValue(DataKey.IWorld_Backstage_RememberMe);
                this.RememberMe = false;
                IsBusy = false;
            }
        }

        #endregion

        #endregion

        #region 内置类型

        /// <summary>
        /// 用户登陆信息的封装
        /// </summary>
        [DataContract]
        public class LoginPackage
        {
            #region 属性

            /// <summary>
            /// 用户名
            /// </summary>
            [DataMember]
            public string Username { get; set; }

            /// <summary>
            /// 密码
            /// </summary>
            [DataMember]
            public string Password { get; set; }

            #endregion

            #region 构造方法

            /// <summary>
            /// 实例化一个用户登陆信息的封装
            /// </summary>
            /// <param name="username">用户名</param>
            /// <param name="password">密码</param>
            public LoginPackage(string username, string password)
            {
                this.Username = username;
                this.Password = password;
            }

            #endregion
        }

        #endregion
    }
}
