using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using zwg_china.client.framework.AuthorService;
using zwg_china.client.framework.AuthorPushService;
using zwg_china.client.framework.LotteryService;
using zwg_china.client.framework.MessageService;

namespace zwg_china.client.framework
{
    /// <summary>
    /// 登陆页的视图模型
    /// </summary>
    public class LoginViewModel : ViewModelBase
    {
        #region 私有字段

        string _username = "";
        string _password = "";
        string _loadingMessage = "";

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
                }
            }
        }

        /// <summary>
        /// 加载时的文字显示
        /// </summary>
        public string LoadingMessage
        {
            get
            {
                return _loadingMessage;
            }
            set
            {
                if (_loadingMessage != value)
                {
                    _loadingMessage = value;
                    OnPropertyChanged("LoadingMessage");
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
            this.LoadingMessage = "验证用户名和密码（1/7）...";
            IsBusy = true;

            //登陆
            AuthorServiceClient client = new AuthorServiceClient();
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
                DataManager.SetValue(DataKey.IWorld_Client_Token, e.Result.Info);

                GetSettingImport import = new GetSettingImport { Token = e.Result.Info };
                AuthorServiceClient client = (AuthorServiceClient)sender;
                client.GetSettingCompleted += ShowGetSettingResult;
                this.LoadingMessage = "加载系统设置（2/7）...";
                client.GetSettingAsync(import);
            }
            else
            {
                ShowLoginError(e.Result.Error);
            }
        }

        //处理加载设置集结果
        void ShowGetSettingResult(object sender, GetSettingCompletedEventArgs e)
        {
            if (e.Result.Success)
            {
                DataManager.SetValue(DataKey.IWorld_Client_Setting, e.Result.Info);

                GetUserInfoImpoert import = new GetUserInfoImpoert { Token = DataManager.GetValue<string>(DataKey.IWorld_Client_Token) };
                AuthorServiceClient client = (AuthorServiceClient)sender;
                client.GetUserInfoCompleted += ShowGetUserInfoResult;
                this.LoadingMessage = "加载用户身份标识（3/7）...";
                client.GetUserInfoAsync(import);
            }
            else
            {
                ShowLoginError(e.Result.Error);
            }
        }

        //处理加载用户信息结果
        void ShowGetUserInfoResult(object sender, GetUserInfoCompletedEventArgs e)
        {
            if (e.Result.Success)
            {
                DataManager.SetValue(DataKey.IWorld_Client_UserInfo, e.Result.Info);

                GetTicketsImport import = new GetTicketsImport { Token = DataManager.GetValue<string>(DataKey.IWorld_Client_Token) };
                LotteryServiceClient client = new LotteryServiceClient();
                client.GetTicketsCompleted += ShowGetTicketsResult;
                this.LoadingMessage = "加载彩票玩法信息（4/7）...";
                client.GetTicketsAsync(import);
            }
            else
            {
                ShowLoginError(e.Result.Error);
            }
        }

        //处理加载彩票信息的结果
        void ShowGetTicketsResult(object sender, GetTicketsCompletedEventArgs e)
        {
            if (e.Result.Success)
            {
                DataManager.SetValue(DataKey.IWorld_Client_Tickets, e.Result.Info);

                GetTopBonusImport import = new GetTopBonusImport
                {
                    Notes = 7,
                    Token = DataManager.GetValue<string>(DataKey.IWorld_Client_Token)
                };
                LotteryServiceClient client = (LotteryServiceClient)sender;
                client.GetTopBonusCompleted += ShowGetTopBonusResult;
                this.LoadingMessage = "加载历史记录（5/7）...";
                client.GetTopBonusAsync(import);
            }
            else
            {
                ShowLoginError(e.Result.Error);
            }
        }

        //处理获取中奖排行的结果
        void ShowGetTopBonusResult(object sender, GetTopBonusCompletedEventArgs e)
        {
            if (e.Result.Success)
            {
                Dictionary<string, List<TopBonus>> tD = new Dictionary<string, List<TopBonus>>();
                tD.Add("_all", e.Result.Info);
                DataManager.SetValue(DataKey.IWorld_Client_TopBouns, tD);

                GetBulletinsImport import = new GetBulletinsImport
                {
                    Token = DataManager.GetValue<string>(DataKey.IWorld_Client_Token)
                };
                MessageServiceClient client = new MessageServiceClient();
                client.GetBulletinsCompleted += ShowGetBulletinsResult;
                this.LoadingMessage = "加载系统公告（6/7）...";
                client.GetBulletinsAsync(import);
            }
            else
            {
                ShowLoginError(e.Result.Error);
            }
        }

        //处理获取系统公告的结果
        void ShowGetBulletinsResult(object sender, GetBulletinsCompletedEventArgs e)
        {
            if (e.Result.Success)
            {
                DataManager.SetValue(DataKey.IWorld_Client_Bulletins, e.Result.Info);

                object callback = ViewModelService.Root;
                if (callback is IAuthorPushServiceCallback)
                {
                    AuthorPushServiceClient client = new AuthorPushServiceClient(new InstanceContext(callback));
                    client.SetInCompleted += ShowSetInResult;
                    this.LoadingMessage = "初始化加密信道（7/7）...";
                    client.SetInAsync(DataManager.GetValue<string>(DataKey.IWorld_Client_Token));
                }
                else
                {
                    ShowLoginError("加密信道初始化失败");
                }
            }
            else
            {
                ShowLoginError(e.Result.Error);
            }
        }

        //处理登入结果
        void ShowSetInResult(object sender, SetInCompletedEventArgs e)
        {
            if (e.Result.Success)
            {
                DataManager.SetValue(DataKey.IWorld_Client_UnReadNotices, new List<NoticeExport>());
                List<LotteryService.LotteryTicketExport> tickets = DataManager.GetValue<List<LotteryService.LotteryTicketExport>>(DataKey.IWorld_Client_Tickets);
                ViewModelService.JumpTo(Page.彩票投注, tickets.First().Name);
            }
            else
            {
                ShowLoginError(e.Result.Error);
            }
        }

        #endregion

        #endregion

        #region 私有方法

        void ShowLoginError(string error)
        {
            this.LoadingMessage = error;
            System.Threading.Thread.Sleep(1500);
            this.Username = "";
            this.Password = "";
            IsBusy = false;
        }

        #endregion
    }
}
