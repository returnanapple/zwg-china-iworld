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
    [View(page: Page.查看充值记录)]
    public partial class RechargeRecordsPage : UserControl
    {
        public RechargeRecordsPage()
        {
            InitializeComponent();
        }

        #region 添加充值记录

        private void Create(object sender, EventArgs e)
        {
            RechargeRecordsPage_CreateWindow cw = new RechargeRecordsPage_CreateWindow();
            cw.Closed += ShowCreateResult;
            cw.Show();
        }

        void ShowCreateResult(object sender, EventArgs e)
        {
            RechargeRecordsPage_CreateWindow cw = (RechargeRecordsPage_CreateWindow)sender;
            if (cw.DialogResult != true) { return; }
            if (cw.Error == null)
            {
                ErrorPrompt ep = new ErrorPrompt();
                ep.State = "添加充值记录成功";
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
