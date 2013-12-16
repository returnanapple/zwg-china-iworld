using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using zwg_china.client.framework.LotteryService;
using zwg_china.client.framework.MessageService;

namespace zwg_china.client.framework
{
    /// <summary>
    /// 操作视图的基类
    /// </summary>
    public abstract class ManagerViewModelBase : ViewModelBase
    {
        #region 私有变量

        string selectedButtonName = "";
        ObservableCollection<BulletinExport> bulletins = new ObservableCollection<BulletinExport>();
        ObservableCollection<TopBonus> topBonus = new ObservableCollection<TopBonus>();

        #endregion

        #region 公开属性

        /// <summary>
        /// 高亮按键的名称
        /// </summary>
        public string SelectedButtonName
        {
            get
            {
                return selectedButtonName;
            }
            set
            {
                if (selectedButtonName != value)
                {
                    selectedButtonName = value;
                    OnPropertyChanged("SelectedButtonName");
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
        /// 跳转命令
        /// </summary>
        public UniversalCommand JumpCommand { get; set; }

        /// <summary>
        /// 登出命令
        /// </summary>
        public UniversalCommand LogoutCommand { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的操作视图的基类
        /// </summary>
        /// <param name="selectedButtonName">高亮按键的名称</param>
        public ManagerViewModelBase(string selectedButtonName)
        {
            //初始化参数
            this.SelectedButtonName = selectedButtonName;

            //初始化命令
            this.JumpCommand = new UniversalCommand(new Action<object>(Jump));
            this.LogoutCommand = new UniversalCommand(new Action<object>(Logout));

            //加载公告列表
            DataManager.GetValue<List<BulletinExport>>(DataKey.IWorld_Client_Bulletins).ForEach(x => this.Bulletins.Add(x));
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
