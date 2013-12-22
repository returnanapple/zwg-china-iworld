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
using zwg_china.backstage.framework.AuthorService;

namespace zwg_china.backstage.control
{
    public partial class UsersPage_CreateUserWindow : ChildWindow
    {
        public UsersPage_CreateUserWindow()
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
            DependencyProperty.Register("Error", typeof(string), typeof(UsersPage_CreateUserWindow), new PropertyMetadata(null));

        #endregion

        #region 方法

        private void Enter(object sender, RoutedEventArgs e)
        {
            CreateUserImport import = new CreateUserImport
            {
                Username = input_Username.Text,
                Password = input_Password.Password,
                Rebate_Normal = Math.Round(Convert.ToDouble(input_Rebate_Normal.Text), 2),
                Rebate_IndefinitePosition = Math.Round(Convert.ToDouble(input_Rebate_IndefinitePosition.Text), 2),
                Token = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo).Token
            };
            AuthorServiceClient client = new AuthorServiceClient();
            client.CreateUserCompleted += ShowCreateUserResult;
            client.CreateUserAsync(import);
        }
        #region 创建结果

        void ShowCreateUserResult(object sender, CreateUserCompletedEventArgs e)
        {
            if (!e.Result.Success)
            {
                this.Error = e.Result.Error;
            }
            this.DialogResult = true;
        }

        #endregion

        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        #endregion
    }
}

