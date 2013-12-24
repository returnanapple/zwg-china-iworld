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
    public partial class RewardForConsumptionPlansPage_EditWindow : ChildWindow
    {
        public RewardForConsumptionPlansPage_EditWindow()
        {
            InitializeComponent();
        }

        #region 私有变量
        ObservableCollection<RewardForConsumptionPlanDetailImport> details =
            new ObservableCollection<RewardForConsumptionPlanDetailImport>();
        #endregion

        #region 错误信息
        public string Error
        {
            get { return (string)GetValue(ErrorProperty); }
            set { SetValue(ErrorProperty, value); }
        }
        public static readonly DependencyProperty ErrorProperty =
            DependencyProperty.Register("Error", typeof(string), typeof(RewardForConsumptionPlansPage_EditWindow), new PropertyMetadata(null));
        #endregion

        #region 附加内容
        public RewardForConsumptionPlanExport State
        {
            get { return (RewardForConsumptionPlanExport)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }
        public static readonly DependencyProperty StateProperty =
            DependencyProperty.Register("State", typeof(RewardForConsumptionPlanExport), typeof(RewardForConsumptionPlansPage_EditWindow), new PropertyMetadata(null, (d, e) =>
            {
                RewardForConsumptionPlansPage_EditWindow tool = (RewardForConsumptionPlansPage_EditWindow)d;
                RewardForConsumptionPlanExport data = (RewardForConsumptionPlanExport)e.NewValue;
                tool.input_Tittle.Text = data.Title;
                tool.input_Description.Text = data.Description;
                tool.input_PlanType.SelectedIndex = data.PlanType == RewardPlanType.当即返还 ? 0 : 1;
                switch (data.Timescale)
                {
                    case TimescaleOfActivity.无:
                        tool.input_Timescale.SelectedIndex = 0;
                        break;
                    case TimescaleOfActivity.日:
                        tool.input_Timescale.SelectedIndex = 1;
                        break;
                    case TimescaleOfActivity.月:
                        tool.input_Timescale.SelectedIndex = 2;
                        break;
                    default:
                        break;
                }
                tool.input_Hide.SelectedIndex = data.Hide == false ? 0 : 1;
                tool.input_BeginTime.SelectedDate = data.BeginTime;
                tool.input_EndTime.SelectedDate = data.EndTime;
                tool.details.Clear();
                data.Details.ForEach(x =>
                {
                    tool.details.Add(new RewardForConsumptionPlanDetailImport
                    {
                        LowerConsumption = x.LowerConsumption,
                        CapsConsumption = x.CapsConsumption,
                        PrizeType = x.PrizeType,
                        Sum = x.Sum,
                        WaysToReward = x.WaysToReward
                    });
                });
            }));
        #endregion

        #region 修改
        private void Edit(object sender, RoutedEventArgs e)
        {
            EditRewardForConsumptionPlanImport import = new EditRewardForConsumptionPlanImport
            {
                Id = this.State.Id,
                Title = input_Tittle.Text,
                Description = input_Description.Text,
                PlanType = (RewardPlanType)Enum.Parse(typeof(RewardPlanType), (input_PlanType.SelectedItem as TextBlock).Text, false),
                Timescale = (TimescaleOfActivity)Enum.Parse(typeof(TimescaleOfActivity), (input_Timescale.SelectedItem as TextBlock).Text, false),
                Details = details.ToList(),
                BeginTime = (DateTime)input_BeginTime.SelectedDate,
                EndTime = (DateTime)input_EndTime.SelectedDate,
                Hide = input_Hide.SelectedIndex == 0 ? false : true,
                Token = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo).Token,
            };
            ActicityServiceClient client = new ActicityServiceClient();
            client.EditRewardForConsumptionPlanCompleted += ShowEditRewardForConsumptionPlanResult;
            client.EditRewardForConsumptionPlanAsync(import);
        }

        void ShowEditRewardForConsumptionPlanResult(object sender, EditRewardForConsumptionPlanCompletedEventArgs e)
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
            details.Add(new RewardForConsumptionPlanDetailImport { PrizeType = PrizesOfActivityType.积分, WaysToReward = WaysToRewardOfActivity.百分比 });
        }
        #endregion

        #region 删除消费奖励明细
        private void DelADetail(object sender, EventArgs e)
        {
            RewardForConsumptionPlanDetailImport item = (RewardForConsumptionPlanDetailImport)(sender as RewardForConsumptionPlansPage_TableRowOfDetails).DataContext;
            details.Remove(item);
        }
        #endregion

        #region loaded事件
        private void LoadedAction(object sender, RoutedEventArgs e)
        {
            input_Details.ItemsSource = details;
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

