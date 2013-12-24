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
using zwg_china.backstage.framework;
using zwg_china.backstage.framework.ActicityService;
using zwg_china.backstage.framework.AdministratorService;

namespace zwg_china.backstage.control
{
    public partial class RewardForConsumptionPlansPage_CreateWindow : ChildWindow
    {
        public RewardForConsumptionPlansPage_CreateWindow()
        {
            InitializeComponent();
        }

        #region 私有变量
        ObservableCollection<RewardForConsumptionPlanDetailImport> Details =
            new ObservableCollection<RewardForConsumptionPlanDetailImport>();
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
            DependencyProperty.Register("Error", typeof(string), typeof(RewardForConsumptionPlansPage_CreateWindow), new PropertyMetadata(null));

        #endregion

        #region 创建新的消费奖励
        private void CreateRewardForConsumptionPlan(object sender, RoutedEventArgs e)
        {
            CreateRewardForConsumptionPlanImport import = new CreateRewardForConsumptionPlanImport
            {
                Title = input_Tittle.Text,
                Description = input_Description.Text,
                PlanType = (RewardPlanType)Enum.Parse(typeof(RewardPlanType), (input_PlanType.SelectedItem as TextBlock).Text, false),
                Timescale = (TimescaleOfActivity)Enum.Parse(typeof(TimescaleOfActivity), (input_Timescale.SelectedItem as TextBlock).Text, false),
                Details = Details.ToList(),
                BeginTime = (DateTime)input_BeginTime.SelectedDate,
                EndTime = (DateTime)input_EndTime.SelectedDate,
                Token = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo).Token
            };
            ActicityServiceClient client = new ActicityServiceClient();
            client.CreateRewardForConsumptionPlanCompleted += ShowCreateRewardForConsumptionPlanResult;
            client.CreateRewardForConsumptionPlanAsync(import);
        }

        void ShowCreateRewardForConsumptionPlanResult(object sender, CreateRewardForConsumptionPlanCompletedEventArgs e)
        {
            if (!e.Result.Success)
            {
                this.Error = e.Result.Error;
            }
            this.DialogResult = true;
        }
        #endregion

        #region 创建一条消费奖励明细
        private void AddADetail(object sender, RoutedEventArgs e)
        {
            Details.Add(new RewardForConsumptionPlanDetailImport { PrizeType = PrizesOfActivityType.积分, WaysToReward = WaysToRewardOfActivity.百分比 });
        }
        #endregion

        #region 删除消费奖励明细
        private void DelADetail(object sender, EventArgs e)
        {
            RewardForConsumptionPlanDetailImport item = (RewardForConsumptionPlanDetailImport)(sender as RewardForConsumptionPlansPage_TableRowOfDetails).DataContext;
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

