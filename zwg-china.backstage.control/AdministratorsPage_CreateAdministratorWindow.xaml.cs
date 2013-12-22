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
    public partial class AdministratorsPage_CreateAdministratorWindow : ChildWindow
    {
        AdministratorServiceClient client = new AdministratorServiceClient();

        public AdministratorsPage_CreateAdministratorWindow()
        {
            InitializeComponent();
            this.Loaded += InsertGroups;
            client.GetBasicAdministratorGroupsCompleted += InsertGroups_do;
            client.CreateAdministratorCompleted += ShowCreateAdministratorResult;
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

        #region 填充管理员组下拉选单

        void InsertGroups(object sender, RoutedEventArgs e)
        {
            GetBasicAdministratorGroupsImport import = new GetBasicAdministratorGroupsImport
            {
                Token = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo).Token
            };
            client.GetBasicAdministratorGroupsAsync(import);
        }

        void InsertGroups_do(object sender, GetBasicAdministratorGroupsCompletedEventArgs e)
        {
            if (!e.Result.Success) { return; }
            input_group.ItemsSource = e.Result.Info;
            input_group.SelectedIndex = 0;
        }

        #endregion

        #region 添加管理员

        private void CreateAdministrator(object sender, RoutedEventArgs e)
        {
            int gId = ((BasicAdministratorGroupExport)input_group.SelectedItem).Id;
            CreateAdministratorImport import = new CreateAdministratorImport
            {
                Username = input_Username.Text,
                Password = input_Password.Password,
                GroupId = gId,
                Token = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo).Token
            };
            client.CreateAdministratorAsync(import);
        }

        void ShowCreateAdministratorResult(object sender, CreateAdministratorCompletedEventArgs e)
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

