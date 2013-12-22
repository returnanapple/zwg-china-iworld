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
using zwg_china.backstage.framework.AdministratorService;

namespace zwg_china.backstage.control
{
    public partial class AdministratorGroupPage_EditWindow : ChildWindow
    {
        public AdministratorGroupPage_EditWindow()
        {
            InitializeComponent();
        }

        #region 附加内容

        public AdministratorGroupExport State
        {
            get { return (AdministratorGroupExport)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }

        public static readonly DependencyProperty StateProperty =
            DependencyProperty.Register("State", typeof(AdministratorGroupExport), typeof(AdministratorGroupPage_EditWindow)
            , new PropertyMetadata(null, (d, e) =>
            {
                AdministratorGroupPage_EditWindow tool = (AdministratorGroupPage_EditWindow)d;
                AdministratorGroupExport data = (AdministratorGroupExport)e.NewValue;

                tool.input_Name.Text = data.Name;
                tool.input_CanViewUsers.SelectedIndex = data.CanViewUsers ? 0 : 1;
                tool.input_CanEditUsers.SelectedIndex = data.CanEditUsers ? 0 : 1;
                tool.input_CanViewTickets.SelectedIndex = data.CanViewTickets ? 0 : 1;
                tool.input_CanEditTickets.SelectedIndex = data.CanEditTickets ? 0 : 1;
                tool.input_CanViewActivities.SelectedIndex = data.CanViewActivities ? 0 : 1;
                tool.input_CanEditActivities.SelectedIndex = data.CanEditActivities ? 0 : 1;
                tool.input_CanViewDataReports.SelectedIndex = data.CanViewDataReports ? 0 : 1;
                tool.input_CanEditDataReports.SelectedIndex = data.CanEditDataReports ? 0 : 1;
                tool.input_CanViewSettings.SelectedIndex = data.CanViewSettings ? 0 : 1;
                tool.input_CanEditSettings.SelectedIndex = data.CanEditSettings ? 0 : 1;
                tool.input_IsCustomerService.SelectedIndex = data.IsCustomerService ? 0 : 1;
            }));

        #endregion

        #region 错误信息

        /// <summary>
        /// 错误信息
        /// </summary>
        public string Error
        {
            get { return (string)GetValue(ErrorProperty); }
            set { SetValue(ErrorProperty, value); }
        }

        public static readonly DependencyProperty ErrorProperty =
            DependencyProperty.Register("Error", typeof(string), typeof(AdministratorsPage_CreateAdministratorWindow), new PropertyMetadata(null));

        #endregion

        #region 创建管理员用户组

        private void Edit(object sender, RoutedEventArgs e)
        {
            EditAdministratorGroupImport import = new EditAdministratorGroupImport
            {
                Id = this.State.Id,
                Name = input_Name.Text,
                CanViewUsers = input_CanViewUsers.SelectedIndex == 0,
                CanEditUsers = input_CanEditUsers.SelectedIndex == 0,
                CanViewTickets = input_CanViewTickets.SelectedIndex == 0,
                CanEditTickets = input_CanEditTickets.SelectedIndex == 0,
                CanViewActivities = input_CanViewActivities.SelectedIndex == 0,
                CanEditActivities = input_CanEditActivities.SelectedIndex == 0,
                CanViewDataReports = input_CanViewDataReports.SelectedIndex == 0,
                CanEditDataReports = input_CanEditDataReports.SelectedIndex == 0,
                CanViewSettings = input_CanViewSettings.SelectedIndex == 0,
                CanEditSettings = input_CanEditSettings.SelectedIndex == 0,
                IsCustomerService = input_IsCustomerService.SelectedIndex == 0,
                Token = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo).Token
            };
            AdministratorServiceClient client = new AdministratorServiceClient();
            client.EditAdministratorGroupCompleted += ShowEditResult;
            client.EditAdministratorGroupAsync(import);
        }

        void ShowEditResult(object sender, EditAdministratorGroupCompletedEventArgs e)
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

