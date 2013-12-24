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
using zwg_china.backstage.framework.LotteryService;
using zwg_china.backstage.framework.AdministratorService;

namespace zwg_china.backstage.control
{
    public partial class BettingsPage_TableRow : UserControl
    {
        public BettingsPage_TableRow()
        {
            InitializeComponent();
        }

        #region 附加内容

        public BettingExport State
        {
            get { return (BettingExport)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }

        public static readonly DependencyProperty StateProperty =
            DependencyProperty.Register("State", typeof(BettingExport), typeof(BettingsPage_TableRow)
            , new PropertyMetadata(null, (d, e) =>
            {
                BettingsPage_TableRow tool = (BettingsPage_TableRow)d;
                BettingExport data = (BettingExport)e.NewValue;

                tool.text_HowToPlay.Text = data.HowToPlay;
                tool.text_Issue.Text = data.Issue;
                tool.text_Owner.Text = data.Owner;
                tool.text_Pay.Text = data.Pay.ToString("0.00");
                tool.text_Status.Text = data.Status.ToString();
            }));

        #endregion

        #region 显示详细信息

        private void ShowFullWindow(object sender, RoutedEventArgs e)
        {
            BettingsPage_FullWindow fw = new BettingsPage_FullWindow();
            fw.State = this.State;
            fw.Show();
        }

        #endregion
    }
}
