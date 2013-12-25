using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using zwg_china.client.framework.LotteryService;
using zwg_china.client.framework.MessageService;
using zwg_china.client.framework.AuthorPushService;
using System.Windows.Threading;

namespace zwg_china.client.framework
{
    /// <summary>
    /// 操作视图的基类
    /// </summary>
    public abstract class ManagerViewModelBase : ViewModelBase
    {
        #region 私有变量

        string pageName = "";
        ObservableCollection<BulletinExport> bulletins = new ObservableCollection<BulletinExport>();
        ObservableCollection<TopBonus> topBonus = new ObservableCollection<TopBonus>();
        bool showingNotice = false;
        string noticeContext = "";

        #endregion

        #region 公开属性

        /// <summary>
        /// 界面名称
        /// </summary>
        public string PageName
        {
            get
            {
                return pageName;
            }
            set
            {
                if (pageName != value)
                {
                    pageName = value;
                    OnPropertyChanged("PageName");
                }
            }
        }

        /// <summary>
        /// 公告列表
        /// </summary>
        public ObservableCollection<BulletinExport> Bulletins
        {
            get
            {
                return bulletins;
            }
            set
            {
                if (bulletins != value)
                {
                    bulletins = value;
                    OnPropertyChanged("Bulletins");
                }
            }
        }

        /// <summary>
        /// 中奖排行
        /// </summary>
        public ObservableCollection<TopBonus> TopBonus
        {
            get
            {
                return topBonus;
            }
            set
            {
                if (topBonus != value)
                {
                    topBonus = value;
                    OnPropertyChanged("TopBonus");
                }
            }
        }

        /// <summary>
        /// 一个布尔值，表示正在显示通知窗口
        /// </summary>
        public bool ShowingNotice
        {
            get
            {
                return showingNotice;
            }
            set
            {
                if (showingNotice != value)
                {
                    showingNotice = value;
                    OnPropertyChanged("ShowingNotice");
                }
            }
        }

        /// <summary>
        /// 通知的正文
        /// </summary>
        public string NoticeContext
        {
            get
            {
                return noticeContext;
            }
            set
            {
                if (noticeContext != value)
                {
                    noticeContext = value;
                    OnPropertyChanged("NoticeContext");
                }
            }
        }

        /// <summary>
        /// 跳转命令
        /// </summary>
        public UniversalCommand JumpCommand { get; set; }

        /// <summary>
        /// 登出命令
        /// </summary>
        public UniversalCommand LogoutCommand { get; set; }

        /// <summary>
        /// 关闭通知窗口的命令
        /// </summary>
        public UniversalCommand CloseNoticeWindowCommand { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的操作视图的基类
        /// </summary>
        /// <param name="selectedButtonName">高亮按键的名称</param>
        public ManagerViewModelBase(string selectedButtonName)
        {
            //初始化参数
            this.PageName = selectedButtonName;

            //初始化命令
            this.JumpCommand = new UniversalCommand(new Action<object>(Jump));
            this.LogoutCommand = new UniversalCommand(new Action<object>(Logout));
            this.CloseNoticeWindowCommand = new UniversalCommand(new Action<object>(CloseNoticeWindow));

            //加载公告列表
            ShowBulletins(2);
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 5);
            timer.Tick += (sender, e) => { ShowBulletins(2); };
            timer.Start();

            DispatcherTimer timer2 = new DispatcherTimer();
            timer2.Interval = new TimeSpan(0, 0, 1);
            timer2.Tick += (sender, e) => { ShowUnreadNotices(); };
            timer2.Start();

            #region 加载中奖排行

            Dictionary<string, List<TopBonus>> tD = DataManager.GetValue<Dictionary<string, List<TopBonus>>>(DataKey.IWorld_Client_TopBouns);
            if (ContrastManager.Contrasts.Any(c => c.ButtonNames.Any(bName => bName == selectedButtonName)))
            {
                if (!tD.Keys.Any(key => key == selectedButtonName))
                {
                    GetTopBonusImport import = new GetTopBonusImport
                    {
                        Notes = 7,
                        TicketId = DataManager.GetValue<List<LotteryService.LotteryTicketExport>>(DataKey.IWorld_Client_Tickets)
                            .First(x => x.Name == selectedButtonName).Id,
                        Token = DataManager.GetValue<string>(DataKey.IWorld_Client_Token)
                    };
                    LotteryServiceClient client = new LotteryServiceClient();
                    client.GetTopBonusCompleted += (sender, e) =>
                    {
                        if (!e.Result.Success) { return; }
                        tD.Add(selectedButtonName, e.Result.Info);
                        DataManager.SetValue(DataKey.IWorld_Client_TopBouns, tD);
                        e.Result.Info.OrderByDescending(x => x.Sum).ToList().ForEach(x => this.TopBonus.Add(x));
                    };
                    client.GetTopBonusAsync(import);
                }
                else
                {
                    tD[selectedButtonName].OrderByDescending(x => x.Sum).ToList().ForEach(x => this.TopBonus.Add(x));
                }
            }
            else
            {
                tD["_all"].OrderByDescending(x => x.Sum).ToList().ForEach(x => this.TopBonus.Add(x));
            }

            #endregion
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
            cw.State = "你想要退出程序吗？";
            cw.Closed += Logout_do;
            cw.Show();
        }
        #region 执行

        void Logout_do(object sender, EventArgs e)
        {
            IPop cw = sender as IPop;
            if (cw.DialogResult == true)
            {
                ClearInfoAndLogout();
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
        /// 关闭通知窗口
        /// </summary>
        /// <param name="parameter">参数</param>
        void CloseNoticeWindow(object parameter)
        {
            this.ShowingNotice = false;
            this.NoticeContext = "";
            ShowUnreadNotices();
        }

        /// <summary>
        /// 加载公告
        /// </summary>
        /// <param name="notes"></param>
        void ShowBulletins(int notes)
        {
            this.Bulletins.Clear();
            List<BulletinExport> bs = DataManager.GetValue<List<BulletinExport>>(DataKey.IWorld_Client_Bulletins);
            if (bs.Count <= notes)
            {
                bs.ForEach(x => this.Bulletins.Add(x));
            }
            else
            {
                for (int i = 0; i < notes; i++)
                {
                    int tIndex = firstBulletinIndex + i;
                    while (tIndex >= notes)
                    {
                        tIndex -= notes;
                    }
                    this.Bulletins.Add(bs[tIndex]);
                }

                firstBulletinIndex++;
                while (firstBulletinIndex >= notes)
                {
                    firstBulletinIndex -= notes;
                }
            }
        }
        #region 附属字段
        int firstBulletinIndex = 0;
        #endregion

        /// <summary>
        /// 显示未读信息
        /// </summary>
        void ShowUnreadNotices()
        {
            List<NoticeExport> notices = DataManager.GetValue<List<NoticeExport>>(DataKey.IWorld_Client_UnReadNotices);
            if (notices.Count > 0)
            {
                this.NoticeContext = notices[0].Context;
                this.ShowingNotice = true;
                notices.RemoveAt(0);
                DataManager.SetValue(DataKey.IWorld_Client_UnReadNotices, notices);
            }
        }

        #endregion

        #region 保护方法

        /// <summary>
        /// 清空缓存并退出到默认界面
        /// </summary>
        protected void ClearInfoAndLogout()
        {
            DataManager.RemoveValue(DataKey.IWorld_Client_Setting);
            DataManager.RemoveValue(DataKey.IWorld_Client_Tickets);
            DataManager.RemoveValue(DataKey.IWorld_Client_Token);
            DataManager.RemoveValue(DataKey.IWorld_Client_UserInfo);
            DataManager.RemoveValue(DataKey.IWorld_Client_Bulletins);
            DataManager.RemoveValue(DataKey.IWorld_Client_TopBouns);
            DataManager.RemoveValue(DataKey.IWorld_Client_UnReadNotices);
            ViewModelService.JumpToDefaultPage();
        }

        #endregion
    }
}
