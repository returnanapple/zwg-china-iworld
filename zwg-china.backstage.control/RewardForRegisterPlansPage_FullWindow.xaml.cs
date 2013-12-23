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
    public partial class RewardForRegisterPlansPage_FullWindow : ChildWindow
    {
        public RewardForRegisterPlansPage_FullWindow()
        {
            InitializeComponent();
        }

        #region 附加内容


        public RewardForRegisterPlanExport State
        {
            get { return (RewardForRegisterPlanExport)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }
        public static readonly DependencyProperty StateProperty =
            DependencyProperty.Register("State", typeof(RewardForRegisterPlanExport), typeof(RewardForRegisterPlansPage_FullWindow), new PropertyMetadata(null, (d, e) =>
            {
                RewardForRegisterPlansPage_FullWindow tool = (RewardForRegisterPlansPage_FullWindow)d;
                RewardForRegisterPlanExport data = (RewardForRegisterPlanExport)e.NewValue;
                tool.text_Title.Text = data.Title;
                tool.text_Description.Text = data.Description;
                tool.text_PrizeType.Text = data.PrizeType.ToString();
                tool.text_Sum.Text = data.Sum.ToString("0.00");
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

