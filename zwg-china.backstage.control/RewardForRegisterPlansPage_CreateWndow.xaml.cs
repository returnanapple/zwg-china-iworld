using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class RewardForRegisterPlansPage_CreateWndow : ChildWindow
    {
        public RewardForRegisterPlansPage_CreateWndow()
        {
            InitializeComponent();
        }
        #region 依赖属性
        /// <summary>
        /// 错误信息
        /// </summary>
        public string Error
        {
            get { return (string)GetValue(ErrorProperty); }
            set { SetValue(ErrorProperty, value); }
        }
        public static readonly DependencyProperty ErrorProperty =
            DependencyProperty.Register("Error", typeof(string), typeof(RewardForRegisterPlansPage_CreateWndow), new PropertyMetadata(null));
        #endregion

        #region 创建新的注册奖励
        private void CreateRewardForRegisterPlans(object sender, RoutedEventArgs e)
        {
            CreateRewardForRegisterPlanImport import = new CreateRewardForRegisterPlanImport
            {
                Title = input_Tittle.Text,
                Description = input_Description.Text,
                PrizeType = (PrizesOfActivityType)Enum.Parse(typeof(PrizesOfActivityType), (input_PrizeType.SelectedItem as TextBlock).Text, false),
                Sum = Math.Round(Convert.ToDouble(input_Sum.Text), 2),
                BeginTime = (DateTime)input_BeginTime.SelectedDate,
                EndTime = (DateTime)input_EndTime.SelectedDate,
                Hide = input_Hide.SelectedIndex == 0 ? false : true,
                Token = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo).Token
            };
            ActicityServiceClient client = new ActicityServiceClient();
            client.CreateRewardForRegisterPlanCompleted += ShowCreateRewardForRegisterPlansResult;
            client.CreateRewardForRegisterPlanAsync(import);
        }

        void ShowCreateRewardForRegisterPlansResult(object sender, CreateRewardForRegisterPlanCompletedEventArgs e)
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

