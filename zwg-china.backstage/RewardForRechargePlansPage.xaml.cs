using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using zwg_china.backstage.control;
using zwg_china.backstage.framework;
using zwg_china.backstage.framework.AdministratorService;

namespace zwg_china.backstage
{
    [View(page: Page.查看充值奖励)]
    public partial class RewardForRechargePlansPage : UserControl
    {
        public RewardForRechargePlansPage()
        {
            InitializeComponent();
            this.Loaded += HideMenu;
        }

        void HideMenu(object sender, RoutedEventArgs e)
        {
            AdministratorExport info = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo);
            if (!info.Group.CanEditActivities)
            {
                button_Create.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        #region 创建充值奖励
        private void CreateRewardForRechargePlans(object sender, EventArgs e)
        {
            RewardForRechargePlansPage_CreateWindow cw = new RewardForRechargePlansPage_CreateWindow();
            cw.Closed += CreateRewardForRechargePlansResult;
            cw.Show();
        }

        void CreateRewardForRechargePlansResult(object sender, EventArgs e)
        {
            RewardForRechargePlansPage_CreateWindow cw = (RewardForRechargePlansPage_CreateWindow)sender;
            if (cw.DialogResult != true) { return; }
            if (cw.Error == null)
            {
                ErrorPrompt ep = new ErrorPrompt();
                ep.State = "添加成功";
                ep.Closed += RefreshList;
                ep.Show();
            }
            else
            {
                ErrorPrompt ep = new ErrorPrompt();
                ep.State = cw.Error;
                ep.Show();
            }
        }
        #endregion

        #region 刷新列表

        /// <summary>
        /// 刷新列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void RefreshList(object sender, EventArgs e)
        {
            IShowListViewModel vm = this.DataContext as IShowListViewModel;
            if (vm == null) { return; }
            vm.Refresh();
        }

        #endregion
    }
}
