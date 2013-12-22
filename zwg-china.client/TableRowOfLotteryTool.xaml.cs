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
using zwg_china.client.framework.LotteryService;

namespace zwg_china.client
{
    public partial class TableRowOfLotteryTool : UserControl
    {
        public TableRowOfLotteryTool()
        {
            InitializeComponent();
        }

        private void ReBet(object sender, RoutedEventArgs e)
        {
            TableRowOfLotteryTool_ChildWindow cw = new TableRowOfLotteryTool_ChildWindow();
            cw.BetInfo = (BettingExport)DataContext;
            cw.Show();
        }
    }
}
