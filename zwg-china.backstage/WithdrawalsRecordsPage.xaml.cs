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

namespace zwg_china.backstage
{
    [View(page: Page.查看提现记录)]
    public partial class WithdrawalsRecordsPage : UserControl
    {
        public WithdrawalsRecordsPage()
        {
            InitializeComponent();
        }

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
