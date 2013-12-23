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
using zwg_china.backstage.framework;
using zwg_china.backstage.framework.ActicityService;
using zwg_china.backstage.framework.AdministratorService;

namespace zwg_china.backstage.control
{
    public partial class RewardForRegisterPlansPage_EditWindow : ChildWindow
    {
        public RewardForRegisterPlansPage_EditWindow()
        {
            InitializeComponent();
        }
        #region 错误信息
        public string Error
        {
            get { return (string)GetValue(ErrorProperty); }
            set { SetValue(ErrorProperty, value); }
        }
        public static readonly DependencyProperty ErrorProperty =
            DependencyProperty.Register("Error", typeof(string), typeof(RewardForRegisterPlansPage_EditWindow), new PropertyMetadata(null));
        #endregion

        #region 附加内容


        public RewardForRegisterPlanExport State
        {
            get { return (RewardForRegisterPlanExport)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }
        public static readonly DependencyProperty StateProperty =
            DependencyProperty.Register("State", typeof(RewardForRegisterPlanExport), typeof(RewardForRegisterPlansPage_EditWindow), new PropertyMetadata(null, (d, e) =>
            {
                RewardForRegisterPlansPage_EditWindow tool = (RewardForRegisterPlansPage_EditWindow)d;
                RewardForRegisterPlanExport data = (RewardForRegisterPlanExport)e.NewValue;
                tool.input_Title.Text = data.Title;
                tool.input_Description.Text = data.Description;
                (tool.input_PrizeType.SelectedItem as TextBlock).Text = data.PrizeType.ToString();
                (tool.input_Hide.SelectedItem as TextBlock).Text = data.Hide == false ? "否" : "是";
                tool.input_BeginTime.SelectedDate = data.BeginTime;
                tool.input_EndTime.SelectedDate = data.EndTime;
                tool.input_Sum.Text = data.Sum.ToString("0.00");

            }));


        #endregion

        #region 修改
        private void Edit(object sender, RoutedEventArgs e)
        {
            EditRewardForRegisterPlanImport import = new EditRewardForRegisterPlanImport 
            {
                Id = this.State.Id,
                Title = input_Title.Text,
                Description = input_Description.Text,
                PrizeType = (PrizesOfActivityType)Enum.Parse(typeof(PrizesOfActivityType), (input_PrizeType.SelectedItem as TextBlock).Text, false),
                Sum = Math.Round(Convert.ToDouble(input_Sum.Text), 2),
                BeginTime = (DateTime)input_BeginTime.SelectedDate,
                EndTime = (DateTime)input_EndTime.SelectedDate,
                Hide = input_Hide.SelectedIndex == 0 ? false : true,
                Token = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo).Token
            };
            ActicityServiceClient client = new ActicityServiceClient();
            client.EditRewardForRegisterPlanCompleted += ShowEditRewardForRegisterPlanResult;
            client.EditRewardForRegisterPlanAsync(import);
        }

        void ShowEditRewardForRegisterPlanResult(object sender, EditRewardForRegisterPlanCompletedEventArgs e)
        {
            if (!e.Result.Success)
            {
                this.Error = e.Result.Error;
            }
            this.DialogResult = true;
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

