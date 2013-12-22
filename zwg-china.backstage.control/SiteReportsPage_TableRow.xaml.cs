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
    public partial class SiteReportsPage_TableRow : UserControl
    {
        public SiteReportsPage_TableRow()
        {
            InitializeComponent();
        }

        #region 附加内容

        public SiteReportExpot State
        {
            get { return (SiteReportExpot)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }

        public static readonly DependencyProperty StateProperty =
            DependencyProperty.Register("State", typeof(SiteReportExpot), typeof(SiteReportsPage_TableRow)
            , new PropertyMetadata(null, (d, e) =>
            {
                SiteReportsPage_TableRow tool = (SiteReportsPage_TableRow)d;
                SiteReportExpot data = (SiteReportExpot)e.NewValue;

                tool.text_date.Text = data.Date;
                tool.text_CountOfSetUp.Text = data.CountOfSetUp.ToString();
                tool.text_TimesOfLogin.Text = data.TimesOfLogin.ToString();
                tool.text_Recharge.Text = data.Recharge.ToString("0.00");
                tool.text_Withdrawal.Text = data.Withdrawal.ToString("0.00");
            }));

        #endregion

        #region 显示详细窗口

        private void ShowFullWindow(object sender, RoutedEventArgs e)
        {
            SiteReportsPage_FullWindow fw = new SiteReportsPage_FullWindow();
            fw.State = this.State;
            fw.Show();
        }

        #endregion
    }
}
