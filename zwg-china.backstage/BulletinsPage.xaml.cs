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
    [View(page: Page.系统公告设置)]
    public partial class BulletinsPage : UserControl
    {
        public BulletinsPage()
        {
            InitializeComponent();
            this.Loaded += HideMenu;
        }

        void HideMenu(object sender, RoutedEventArgs e)
        {
            AdministratorExport info = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo);
            if (!info.Group.CanEditSettings)
            {
                menu_fir.Height = 155;
                menu_sec.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        #region 创建

        private void Create(object sender, EventArgs e)
        {
            BulletinsPage_CreateWindow cw = new BulletinsPage_CreateWindow();
            cw.Closed += ShowCreateResult;
            cw.Show();
        }

        void ShowCreateResult(object sender, EventArgs e)
        {
            BulletinsPage_CreateWindow cw = (BulletinsPage_CreateWindow)sender;
            if (cw.DialogResult != true) { return; }
            if (cw.Error == null)
            {
                ErrorPrompt ep = new ErrorPrompt();
                ep.State = "添加公告成功";
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
