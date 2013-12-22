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
using zwg_china.backstage.framework;
using zwg_china.backstage.framework.AdministratorService;

namespace zwg_china.backstage
{
    [View(page: Page.查看注册奖励)]
    public partial class RewardForRegisterPlansPage : UserControl
    {
        public RewardForRegisterPlansPage()
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

        #region 创建注册奖励

        private void Create(object sender, EventArgs e)
        {

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
