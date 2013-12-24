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
    public partial class StatisticsPage_TableRow : UserControl
    {
        public StatisticsPage_TableRow()
        {
            InitializeComponent();
        }

        #region 附属信息

        public RersonalAndTeamReportExport State
        {
            get { return (RersonalAndTeamReportExport)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }

        public static readonly DependencyProperty StateProperty =
            DependencyProperty.Register("State", typeof(RersonalAndTeamReportExport), typeof(StatisticsPage_TableRow)
            , new PropertyMetadata(null, (d, e) =>
            {
                StatisticsPage_TableRow tool = (StatisticsPage_TableRow)d;
                RersonalAndTeamReportExport data = (RersonalAndTeamReportExport)e.NewValue;

                tool.text_Owner.Text = data.Owner;
                tool.text_date.Text = data.Date;
                tool.text_TimesOfLogin.Text = data.TimesOfLogin.ToString();
                tool.text_Recharge.Text = data.Recharge.ToString("0.00");
                tool.text_Withdrawal.Text = data.Withdrawal.ToString("0.00");
            }));

        #endregion

        #region 显示详细弹窗

        private void ShowFullWindow(object sender, RoutedEventArgs e)
        {

        }

        #endregion
    }
}
