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
using zwg_china.backstage.framework.ReportService;

namespace zwg_china.backstage.control
{
    public partial class RersonalAndTeamReportsPage_TableRow : UserControl
    {
        public RersonalAndTeamReportsPage_TableRow()
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
            DependencyProperty.Register("State", typeof(RersonalAndTeamReportExport), typeof(RersonalAndTeamReportsPage_TableRow)
            , new PropertyMetadata(null, (d, e) =>
            {
                RersonalAndTeamReportsPage_TableRow tool = (RersonalAndTeamReportsPage_TableRow)d;
                RersonalAndTeamReportExport data = (RersonalAndTeamReportExport)e.NewValue;

                tool.text_Owner.Text = data.Owner;
                tool.text_date.Text = data.Date;
                tool.text_TimesOfLogin.Text = data.TimesOfLogin.ToString();
                tool.text_Recharge.Text = data.Recharge.ToString("0.00");
                tool.text_Withdrawal.Text = data.Withdrawal.ToString("0.00");
            }));

        #endregion

        #region 显示详细窗口

        private void ShowFullWindow(object sender, RoutedEventArgs e)
        {
            RersonalAndTeamReportsPage_FullWindow fw = new RersonalAndTeamReportsPage_FullWindow();
            fw.State = this.State;
            fw.Show();
        }

        #endregion
    }
}
