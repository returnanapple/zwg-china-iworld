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
    public partial class RedeemPlansPage_CreateWindow : ChildWindow
    {
        public RedeemPlansPage_CreateWindow()
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
            DependencyProperty.Register("Error", typeof(string), typeof(RedeemPlansPage_CreateWindow), new PropertyMetadata(null));

        #endregion

        #region 创建新的注册奖励

        private void Create(object sender, RoutedEventArgs e)
        {
            CreateRedeemPlanImport import = new CreateRedeemPlanImport
            {
                Title = input_Title.Text,
                Description = input_Description.Text,
                Integral = Convert.ToInt32(this.input_Money.Text),
                Money = Math.Round(Convert.ToDouble(this.input_Money.Text), 2),
                BeginTime = (DateTime)input_BeginTime.SelectedDate,
                EndTime = (DateTime)input_EndTime.SelectedDate,
                Hide = input_Hide.SelectedIndex == 0 ? false : true,
                Token = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo).Token
            };
            ActicityServiceClient client = new ActicityServiceClient();
            client.CreateRedeemPlanCompleted += ShowCreateRewardForRegisterPlansResult;
            client.CreateRedeemPlanAsync(import);
        }

        void ShowCreateRewardForRegisterPlansResult(object sender, CreateRedeemPlanCompletedEventArgs e)
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

