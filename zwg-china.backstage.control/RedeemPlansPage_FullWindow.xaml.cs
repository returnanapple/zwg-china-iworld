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
using zwg_china.backstage.framework.ActicityService;

namespace zwg_china.backstage.control
{
    public partial class RedeemPlansPage_FullWindow : ChildWindow
    {
        public RedeemPlansPage_FullWindow()
        {
            InitializeComponent();
        }

        #region 附加内容

        public RedeemPlanExport State
        {
            get { return (RedeemPlanExport)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }
        public static readonly DependencyProperty StateProperty =
            DependencyProperty.Register("State", typeof(RedeemPlanExport), typeof(RedeemPlansPage_FullWindow)
            , new PropertyMetadata(null, (d, e) =>
            {
                RedeemPlansPage_FullWindow tool = (RedeemPlansPage_FullWindow)d;
                RedeemPlanExport data = (RedeemPlanExport)e.NewValue;
                tool.text_Title.Text = data.Title;
                tool.text_Description.Text = data.Description;
                tool.text_Integral.Text = data.Integral.ToString();
                tool.text_Money.Text = data.Money.ToString("0.00");
                tool.text_BeginTime.Text = data.BeginTime.ToLongDateString();
                tool.text_EndTime.Text = data.EndTime.ToLongDateString();
                tool.text_Hide.Text = data.Hide == false ? "否" : "是";
                tool.text_Status.Text = data.Status.ToString();
            }));

        #endregion

        #region 确认

        private void Enter(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        #endregion
    }
}

