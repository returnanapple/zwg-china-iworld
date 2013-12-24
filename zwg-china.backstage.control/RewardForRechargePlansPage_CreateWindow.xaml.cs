using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class RewardForRechargePlansPage_CreateWindow : ChildWindow
    {
        public RewardForRechargePlansPage_CreateWindow()
        {
            InitializeComponent();
        }
        #region 私有变量
        ObservableCollection<RewardForRechargePlanDetailImport> Details =
            new ObservableCollection<RewardForRechargePlanDetailImport>();
        #endregion

        #region 反馈
        /// <summary>
        /// 错误信息
        /// </summary>
        public string Error
        {
            get { return (string)GetValue(ErrorProperty); }
            set { SetValue(ErrorProperty, value); }
        }
        public static readonly DependencyProperty ErrorProperty =
            DependencyProperty.Register("Error", typeof(string), typeof(RewardForRechargePlansPage_CreateWindow), new PropertyMetadata(null));

        #endregion

        #region 创建新的充值奖励
        private void CreateRewardForRechargePlan(object sender, RoutedEventArgs e)
        {
            CreateRewardForRechargePlanImport import = new CreateRewardForRechargePlanImport 
            {
                Title = input_Tittle.Text,
                Description = input_Description.Text,
                PlanType = (RewardPlanType)Enum.Parse(typeof(RewardPlanType), (input_PlanType.SelectedItem as TextBlock).Text,false),
                Timescale = (TimescaleOfActivity)Enum.Parse(typeof(TimescaleOfActivity),(input_Timescale.SelectedItem as TextBlock).Text,false),
                Details = Details.ToList(),
                BeginTime = (DateTime)input_BeginTime.SelectedDate,
                EndTime = (DateTime)input_EndTime.SelectedDate
            };
            ActicityServiceClient client = new ActicityServiceClient();
            client.CreateRewardForRechargePlanCompleted += ShowCreateRewardForRechargePlanResult;
            client.CreateRewardForRechargePlanAsync(import);
        }

        void ShowCreateRewardForRechargePlanResult(object sender, CreateRewardForRechargePlanCompletedEventArgs e)
        {
            if (!e.Result.Success)
            {
                this.Error = e.Result.Error;
            }
            this.DialogResult = true;
        }
        #endregion

        #region 创建一条充值奖励明细
        private void AddADetail(object sender, RoutedEventArgs e)
        {
            Details.Add(new RewardForRechargePlanDetailImport 
            { PrizeType = PrizesOfActivityType.积分, WaysToReward = WaysToRewardOfActivity.百分比 });
        }
        #endregion

        #region 删除充值明细
        private void DelADetail(object sender, EventArgs e)
        {
            RewardForRechargePlanDetailImport item = (RewardForRechargePlanDetailImport)(sender as RewardForRechargePlansPage_TableRowOfDetails).DataContext;
            Details.Remove(item);
        }
        #endregion

        #region loaded事件
        private void LoadedAction(object sender, RoutedEventArgs e)
        {
            input_Details.ItemsSource = Details;
        }
        #endregion

        #region 取消

        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        #endregion

        


    }
}

