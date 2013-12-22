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
using zwg_china.backstage.framework.SettingOfAuthorService;
using zwg_china.backstage.framework.AdministratorService;
using zwg_china.backstage.framework;

namespace zwg_china.backstage.control
{
    public partial class SystemBankAccountsPage_CreateWindow : ChildWindow
    {
        public SystemBankAccountsPage_CreateWindow()
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
            DependencyProperty.Register("Error", typeof(string), typeof(SystemBankAccountsPage_CreateWindow), new PropertyMetadata(null));

        #endregion

        #region 创建

        private void Create(object sender, RoutedEventArgs e)
        {
            AdministratorExport aInfo = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo);
            Bank bankOfCard = (Bank)Enum.Parse(typeof(Bank), (input_BankOfTheCard.SelectedItem as TextBlock).Text, false);
            CreateSystemBankAccountImport import = new CreateSystemBankAccountImport
            {
                Card = input_Card.Text,
                HolderOfTheCard = input_HolderOfTheCard.Text,
                BankOfTheCard = bankOfCard,
                Remark = input_Remark.Text,
                Order = Convert.ToInt32(input_Order.Text),
                Hide = input_Hide.SelectedIndex == 0,
                Token = aInfo.Token
            };
            SettingOfAuthorServiceClient client = new SettingOfAuthorServiceClient();
            client.CreateSystemBankAccountCompleted += ShowCreateResult;
            client.CreateSystemBankAccountAsync(import);
        }

        void ShowCreateResult(object sender, CreateSystemBankAccountCompletedEventArgs e)
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

