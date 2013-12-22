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
    public partial class AdministratorGroupPage_CreateWindow : ChildWindow
    {
        public AdministratorGroupPage_CreateWindow()
        {
            InitializeComponent();
        }

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

        private void CreateGroup(object sender, RoutedEventArgs e)
        {
            CreateAdministratorGroupImport import = new CreateAdministratorGroupImport
            {
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
            client.CreateAdministratorGroupCompleted += ShowCreateGroupResult;
            client.CreateAdministratorGroupAsync(import);
        }

        void ShowCreateGroupResult(object sender, CreateAdministratorGroupCompletedEventArgs e)
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

