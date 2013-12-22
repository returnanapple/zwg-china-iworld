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
using zwg_china.backstage.framework.AuthorService;
using zwg_china.backstage.framework.AdministratorService;

namespace zwg_china.backstage.control
{
    public partial class UserGroupsPage_CreateUserGroupWindow : ChildWindow
    {
        public UserGroupsPage_CreateUserGroupWindow()
        {
            InitializeComponent();
        }

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
            DependencyProperty.Register("Error", typeof(string), typeof(UserGroupsPage_CreateUserGroupWindow), new PropertyMetadata(null));

        #endregion

        #region 创建新的的用户组

        private void CreateUserGroup(object sender, RoutedEventArgs e)
        {
            CreateUserGroupImport import = new CreateUserGroupImport
            {
                Name = input_Name.Text,
                Grade = Convert.ToInt32(input_Grade.Text),
                LowerOfConsumption = Math.Round(Convert.ToDouble(input_LowerOfConsumption.Text), 2),
                CapsOfConsumption = Math.Round(Convert.ToDouble(input_CapsOfConsumption.Text), 2),
                TimesOfWithdrawal = Convert.ToInt32(input_TimesOfWithdrawal.Text),
                MinimumWithdrawalAmount = Math.Round(Convert.ToDouble(input_MinimumWithdrawalAmount.Text), 2),
                MaximumWithdrawalAmount = Math.Round(Convert.ToDouble(input_MaximumWithdrawalAmount.Text), 2),
                Token = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo).Token
            };
            AuthorServiceClient client = new AuthorServiceClient();
            client.CreateUserGroupCompleted += ShowCreateUserGroupResult;
            client.CreateUserGroupAsync(import);
        }

        void ShowCreateUserGroupResult(object sender, CreateUserGroupCompletedEventArgs e)
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

