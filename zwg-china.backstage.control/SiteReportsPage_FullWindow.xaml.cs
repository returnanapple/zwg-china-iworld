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
    public partial class SiteReportsPage_FullWindow : ChildWindow
    {
        public SiteReportsPage_FullWindow()
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
            DependencyProperty.Register("State", typeof(SiteReportExpot), typeof(SiteReportsPage_FullWindow)
            , new PropertyMetadata(null, (d, e) =>
            {
                SiteReportsPage_FullWindow tool = (SiteReportsPage_FullWindow)d;
                SiteReportExpot data = (SiteReportExpot)e.NewValue;

                tool.text_Date.Text = data.Date;
                tool.text_CountOfSetUp.Text = data.CountOfSetUp.ToString();
                tool.text_TimesOfLogin.Text = data.TimesOfLogin.ToString();
                tool.text_AmountOfBets.Text = data.AmountOfBets.ToString("0.00");
                tool.text_Rebate.Text = data.Rebate.ToString("0.00");
                tool.text_Bonus.Text = data.Bonus.ToString("0.00");
                tool.text_Commission.Text = data.Commission.ToString("0.00");
                tool.text_Reward.Text = data.Reward.ToString("0.00");
                tool.text_Dividend.Text = data.Dividend.ToString("0.00");
                tool.text_Profit.Text = data.Profit.ToString("0.00");
                tool.text_Recharge.Text = data.Recharge.ToString("0.00");
                tool.text_Withdrawal.Text = data.Withdrawal.ToString("0.00");
            }));

        #endregion

        #region 确定

        private void Enter(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        #endregion
    }
}

