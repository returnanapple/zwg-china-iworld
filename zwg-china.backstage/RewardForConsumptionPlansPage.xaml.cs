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
    [View(page: Page.查看消费奖励)]
    public partial class RewardForConsumptionPlansPage : UserControl
    {
        
        public RewardForConsumptionPlansPage()
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

        #region 创建消费奖励
        private void CreateRewardForConsumptionPlans(object sender, EventArgs e)
        {
            RewardForConsumptionPlansPage_CreateWindow cw = new RewardForConsumptionPlansPage_CreateWindow();
            cw.Closed += CreateRewardForConsumptionPlansResult;
            cw.Show();
        }

        void CreateRewardForConsumptionPlansResult(object sender, EventArgs e)
        {
            RewardForConsumptionPlansPage_CreateWindow cw = (RewardForConsumptionPlansPage_CreateWindow)sender;
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
