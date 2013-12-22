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
    public partial class SystemBankAccountsPage_EditWindow : ChildWindow
    {
        public SystemBankAccountsPage_EditWindow()
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
            DependencyProperty.Register("Error", typeof(string), typeof(SystemBankAccountsPage_EditWindow), new PropertyMetadata(null));

        #endregion

        #region 附加内容

        public SystemBankAccountExport State
        {
            get { return (SystemBankAccountExport)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }

        public static readonly DependencyProperty StateProperty =
            DependencyProperty.Register("State", typeof(SystemBankAccountExport), typeof(SystemBankAccountsPage_EditWindow)
            , new PropertyMetadata(null, (d, e) =>
            {
                SystemBankAccountsPage_EditWindow tool = (SystemBankAccountsPage_EditWindow)d;
                SystemBankAccountExport data = (SystemBankAccountExport)e.NewValue;

                tool.input_Card.Text = data.Card;
                tool.input_HolderOfTheCard.Text = data.HolderOfTheCard;
                switch (data.BankOfTheCard)
                {
                    case Bank.无:
                        tool.input_BankOfTheCard.SelectedIndex = 0;
                        break;
                    case Bank.中国工商银行:
                        tool.input_BankOfTheCard.SelectedIndex = 1;
                        break;
                    case Bank.中国农业银行:
                        tool.input_BankOfTheCard.SelectedIndex = 2;
                        break;
                    case Bank.中国银行:
                        tool.input_BankOfTheCard.SelectedIndex = 3;
                        break;
                    case Bank.中国建设银行:
                        tool.input_BankOfTheCard.SelectedIndex = 4;
                        break;
                    case Bank.交通银行:
                        tool.input_BankOfTheCard.SelectedIndex = 5;
                        break;
                    case Bank.招商银行:
                        tool.input_BankOfTheCard.SelectedIndex = 6;
                        break;
                    case Bank.民生银行:
                        tool.input_BankOfTheCard.SelectedIndex = 7;
                        break;
                    case Bank.邮政存储:
                        tool.input_BankOfTheCard.SelectedIndex = 8;
                        break;
                    case Bank.财付通:
                        tool.input_BankOfTheCard.SelectedIndex = 9;
                        break;
                }
                tool.input_Remark.Text = data.Remark;
                tool.input_Order.Text = data.Order.ToString();
                tool.input_Hide.SelectedIndex = data.Hide ? 0 : 1;
            }));

        #endregion

        #region 修改

        private void Edit(object sender, RoutedEventArgs e)
        {
            AdministratorExport aInfo = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo);
            Bank bankOfCard = (Bank)Enum.Parse(typeof(Bank), (input_BankOfTheCard.SelectedItem as TextBlock).Text, false);

            EditSystemBankAccountImport import = new EditSystemBankAccountImport
            {
                Id = this.State.Id,
                Card = input_Card.Text,
                HolderOfTheCard = input_HolderOfTheCard.Text,
                BankOfTheCard = bankOfCard,
                Remark = input_Remark.Text,
                Order = Convert.ToInt32(input_Order.Text),
                Hide = input_Hide.SelectedIndex == 0,
                Token = aInfo.Token
            };
            SettingOfAuthorServiceClient client = new SettingOfAuthorServiceClient();
            client.EditSystemBankAccountCompleted += ShowEditUserResult;
            client.EditSystemBankAccountAsync(import);
        }

        void ShowEditUserResult(object sender, EditSystemBankAccountCompletedEventArgs e)
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

