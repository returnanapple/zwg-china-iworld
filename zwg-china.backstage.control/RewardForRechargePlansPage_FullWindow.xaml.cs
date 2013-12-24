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
    public partial class RewardForRechargePlansPage_FullWindow : ChildWindow
    {
        public RewardForRechargePlansPage_FullWindow()
        {
            InitializeComponent();
        }

        #region 附加内容
        public RewardForRechargePlanExport State
        {
            get { return (RewardForRechargePlanExport)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }
        public static readonly DependencyProperty StateProperty =
            DependencyProperty.Register("State", typeof(RewardForRechargePlanExport), typeof(RewardForRechargePlansPage_FullWindow), new PropertyMetadata(null, (d, e) =>
            {
                RewardForRechargePlansPage_FullWindow tool = (RewardForRechargePlansPage_FullWindow)d;
                RewardForRechargePlanExport data = (RewardForRechargePlanExport)e.NewValue;
                tool.input_Tittle.Text = data.Title;
                tool.input_Description.Text = data.Description;
                tool.input_PlanType.Text = data.PlanType.ToString();
                tool.input_Timescale.Text = data.Timescale.ToString();
                tool.input_Hide.Text = data.Hide == false ? "否" : "是";
                tool.input_BeginTime.Text = data.BeginTime.ToLongDateString();
                tool.input_EndTime.Text = data.EndTime.ToLongDateString();
                tool.input_Details.ItemsSource = null;
                tool.input_Details.ItemsSource = data.Details;
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

