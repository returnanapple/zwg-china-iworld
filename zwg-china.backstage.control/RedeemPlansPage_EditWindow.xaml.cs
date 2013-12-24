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
    public partial class RedeemPlansPage_EditWindow : ChildWindow
    {
        public RedeemPlansPage_EditWindow()
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
            DependencyProperty.Register("Error", typeof(string), typeof(RedeemPlansPage_EditWindow), new PropertyMetadata(null));

        #endregion

        #region 附加内容

        public RedeemPlanExport State
        {
            get { return (RedeemPlanExport)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }
        public static readonly DependencyProperty StateProperty =
            DependencyProperty.Register("State", typeof(RedeemPlanExport), typeof(RedeemPlansPage_EditWindow)
            , new PropertyMetadata(null, (d, e) =>
            {
                RedeemPlansPage_EditWindow tool = (RedeemPlansPage_EditWindow)d;
                RedeemPlanExport data = (RedeemPlanExport)e.NewValue;
                tool.input_Title.Text = data.Title;
                tool.input_Description.Text = data.Description;
                tool.input_Integral.Text = data.Integral.ToString();
                tool.input_Hide.SelectedIndex = data.Hide == false ? 0 : 1;
                tool.input_BeginTime.SelectedDate = data.BeginTime;
                tool.input_EndTime.SelectedDate = data.EndTime;
                tool.input_Money.Text = data.Money.ToString("0.00");

            }));

        #endregion

        #region 修改

        private void Edit(object sender, RoutedEventArgs e)
        {
            EditRedeemPlanImport import = new EditRedeemPlanImport
            {
                Id = this.State.Id,
                Title = input_Title.Text,
                Description = input_Description.Text,
                Integral = Convert.ToInt32(this.input_Integral.Text),
                Money = Math.Round(Convert.ToDouble(this.input_Money.Text), 2),
                BeginTime = (DateTime)input_BeginTime.SelectedDate,
                EndTime = (DateTime)input_EndTime.SelectedDate,
                Hide = input_Hide.SelectedIndex == 0 ? false : true,
                Token = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo).Token
            };
            ActicityServiceClient client = new ActicityServiceClient();
            client.EditRedeemPlanCompleted += ShowEditResult;
            client.EditRedeemPlanAsync(import);
        }

        void ShowEditResult(object sender, EditRedeemPlanCompletedEventArgs e)
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

