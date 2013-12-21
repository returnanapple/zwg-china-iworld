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
    public partial class UserGroupsPage_EditWindow : ChildWindow
    {
        public UserGroupsPage_EditWindow()
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
            DependencyProperty.Register("Error", typeof(string), typeof(UserGroupsPage_EditWindow), new PropertyMetadata(null));

        #endregion

        #region 附加内容

        public UserGroupExport State
        {
            get { return (UserGroupExport)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }

        public static readonly DependencyProperty StateProperty =
            DependencyProperty.Register("State", typeof(UserGroupExport), typeof(UserGroupsPage_EditWindow)
            , new PropertyMetadata(null, (d, e) =>
            {
                UserGroupsPage_EditWindow tool = (UserGroupsPage_EditWindow)d;
                UserGroupExport data = (UserGroupExport)e.NewValue;

                tool.input_Name.Text = data.Name;
                tool.input_Grade.Text = data.Grade.ToString();
                tool.input_LowerOfConsumption.Text = data.LowerOfConsumption.ToString("0.00");
                tool.input_CapsOfConsumption.Text = data.CapsOfConsumption.ToString("0.00");
                tool.input_TimesOfWithdrawal.Text = data.TimesOfWithdrawal.ToString();
                tool.input_MinimumWithdrawalAmount.Text = data.MinimumWithdrawalAmount.ToString("0.00");
                tool.input_MaximumWithdrawalAmount.Text = data.MaximumWithdrawalAmount.ToString("0.00");
            }));

        #endregion

        #region 修改

        private void Edit(object sender, RoutedEventArgs e)
        {
            AdministratorExport aInfo = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo);

            EditUserGroupImport import = new EditUserGroupImport
            {
                Id = this.State.Id,
                Name = input_Name.Text,
                Grade = Convert.ToInt32(input_Grade.Text),
                LowerOfConsumption = Math.Round(Convert.ToDouble(input_LowerOfConsumption.Text), 2),
                CapsOfConsumption = Math.Round(Convert.ToDouble(input_CapsOfConsumption.Text), 2),
                TimesOfWithdrawal = Convert.ToInt32(input_TimesOfWithdrawal.Text),
                MinimumWithdrawalAmount = Math.Round(Convert.ToDouble(input_MinimumWithdrawalAmount.Text), 2),
                MaximumWithdrawalAmount = Math.Round(Convert.ToDouble(input_MaximumWithdrawalAmount.Text), 2),
                Token = aInfo.Token
            };
            AuthorServiceClient client = new AuthorServiceClient();
            client.EditUserGroupCompleted += ShowEditUserResult;
            client.EditUserGroupAsync(import);
        }

        void ShowEditUserResult(object sender, EditUserGroupCompletedEventArgs e)
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

