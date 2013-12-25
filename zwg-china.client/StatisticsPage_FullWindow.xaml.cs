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
using zwg_china.client.framework.ReportService;

namespace zwg_china.client
{
    public partial class StatisticsPage_FullWindow : ChildWindow
    {
        public StatisticsPage_FullWindow()
        {
            InitializeComponent();
        }

        #region 附加内容
        public RersonalAndTeamReportExport State
        {
            get { return (RersonalAndTeamReportExport)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }
        public static readonly DependencyProperty StateProperty =
            DependencyProperty.Register("State", typeof(RersonalAndTeamReportExport), typeof(StatisticsPage_FullWindow)
            , new PropertyMetadata(null, (d, e) =>
            {
                StatisticsPage_FullWindow tool = (StatisticsPage_FullWindow)d;
                RersonalAndTeamReportExport data = (RersonalAndTeamReportExport)e.NewValue;
                tool.input_Owner.Text = data.Owner;
                tool.input_Date.Text = data.Date;
                tool.input_TimesOfLogin.Text = data.TimesOfLogin.ToString();
                tool.input_AmountOfBets.Text = data.AmountOfBets.ToString("0.00");
                tool.input_Rebate.Text = data.Rebate.ToString("0.00");
                tool.input_Bonus.Text = data.Bonus.ToString("0.00");
                tool.input_Commission.Text = data.Commission.ToString("0.00");
                tool.input_Reward.Text = data.Reward.ToString("0.00");
                tool.input_Dividend.Text = data.Dividend.ToString("0.00");
                tool.input_Profit.Text = data.Profit.ToString("0.00");
                tool.input_Recharge.Text = data.Recharge.ToString("0.00");
                tool.input_Withdrawal.Text = data.Withdrawal.ToString("0.00");
            }));
        #endregion

        #region 确认
        private void Enter(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
        #endregion
    }
}

