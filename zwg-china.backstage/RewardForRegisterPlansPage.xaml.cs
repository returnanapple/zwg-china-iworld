﻿using System;
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
        private void CreateRewardForRegisterPlans(object sender, EventArgs e)
        {
            RewardForRegisterPlansPage_CreateWndow cw = new RewardForRegisterPlansPage_CreateWndow();
            cw.Closed += CreateRewardForRegisterPlansResult;
            cw.Show();
        }

        void CreateRewardForRegisterPlansResult(object sender, EventArgs e)
        {
            RewardForRegisterPlansPage_CreateWndow cw = (RewardForRegisterPlansPage_CreateWndow)sender;
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
