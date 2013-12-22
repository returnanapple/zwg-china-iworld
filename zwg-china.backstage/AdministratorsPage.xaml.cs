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

namespace zwg_china.backstage
{
    [View(page: Page.查看管理员列表)]
    public partial class AdministratorsPage : UserControl
    {
        public AdministratorsPage()
        {
            InitializeComponent();
        }

        #region 创建新的管理员

        private void CreateAdministrator(object sender, EventArgs e)
        {
            AdministratorsPage_CreateAdministratorWindow cw = new AdministratorsPage_CreateAdministratorWindow();
            cw.Closed += ShowCreateResult;
            cw.Show();
        }

        void ShowCreateResult(object sender, EventArgs e)
        {
            AdministratorsPage_CreateAdministratorWindow cw = (AdministratorsPage_CreateAdministratorWindow)sender;
            if (cw.DialogResult != true) { return; }
            if (cw.Error == null)
            {
                ErrorPrompt ep = new ErrorPrompt();
                ep.State = "添加管理员成功";
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
