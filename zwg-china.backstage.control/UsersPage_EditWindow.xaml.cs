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
    public partial class UsersPage_EditWindow : ChildWindow
    {
        public UsersPage_EditWindow()
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
            DependencyProperty.Register("Error", typeof(string), typeof(UsersPage_EditWindow), new PropertyMetadata(null));

        #endregion

        #region 附加内容

        public AuthorExport State
        {
            get { return (AuthorExport)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }

        public static readonly DependencyProperty StateProperty =
            DependencyProperty.Register("State", typeof(AuthorExport), typeof(UsersPage_EditWindow)
            , new PropertyMetadata(null, (d, e) =>
            {
                UsersPage_EditWindow tool = (UsersPage_EditWindow)d;
                AuthorExport data = (AuthorExport)e.NewValue;

                tool.text_Username.Text = data.Username;
                tool.text_Group.Text = data.Group.Name;
                switch (data.Status)
                {
                    case UserStatus.未激活:
                        tool.input_Status.SelectedIndex = 0;
                        break;
                    case UserStatus.正常:
                        tool.input_Status.SelectedIndex = 1;
                        break;
                    case UserStatus.禁止访问:
                        tool.input_Status.SelectedIndex = 2;
                        break;
                }
                tool.text_CreatedTime.Text = data.CreatedTime.ToLongDateString();
                tool.text_LastLoginTime.Text = data.LastLoginTime.ToLongDateString();
                tool.text_LstLoginIp.Text = data.LastLoginIp;
                tool.text_LastLoginAddress.Text = data.LastLoginAddress;

                tool.text_Money.Text = data.Money.ToString("0.00");
                tool.text_Money_Frozen.Text = data.Money_Frozen.ToString("0.00");
                tool.text_Consumption.Text = data.Consumption.ToString("0.00");
                tool.text_Integral.Text = data.Integral.ToString();
                tool.text_Subordinate.Text = data.Subordinate.ToString();

                tool.input_Rebate_Normal.Text = data.PlayInfo.Rebate_Normal.ToString("0.0");
                tool.input_Rebate_IndefinitePosition.Text = data.PlayInfo.Rebate_IndefinitePosition.ToString("0.0");
                tool.input_Commission_A.Text = data.PlayInfo.Commission_A.ToString("0.00");
                tool.input_Commission_B.Text = data.PlayInfo.Commission_B.ToString("0.00");
                tool.input_Dividend.Text = data.PlayInfo.Dividend.ToString("0.00");

                tool.input_Card.Text = data.Binding.Card;
                tool.input_HolderOfTheCard.Text = data.Binding.HolderOfTheCard;
                switch (data.Binding.BankOfTheCard)
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

                tool.text_UserQuotas_130.Text = data.UserQuotas.FirstOrDefault(x => x.Rebate == 13.0) == null ? "0"
                    : data.UserQuotas.FirstOrDefault(x => x.Rebate == 13.0).Surplus.ToString();
                tool.text_UserQuotas_129.Text = data.UserQuotas.FirstOrDefault(x => x.Rebate == 13.0) == null ? "0"
                    : data.UserQuotas.FirstOrDefault(x => x.Rebate == 12.9).Surplus.ToString();
                tool.text_UserQuotas_128.Text = data.UserQuotas.FirstOrDefault(x => x.Rebate == 13.0) == null ? "0"
                    : data.UserQuotas.FirstOrDefault(x => x.Rebate == 12.8).Surplus.ToString();
                tool.text_UserQuotas_127.Text = data.UserQuotas.FirstOrDefault(x => x.Rebate == 13.0) == null ? "0"
                    : data.UserQuotas.FirstOrDefault(x => x.Rebate == 12.7).Surplus.ToString();
                tool.text_UserQuotas_126.Text = data.UserQuotas.FirstOrDefault(x => x.Rebate == 13.0) == null ? "0"
                    : data.UserQuotas.FirstOrDefault(x => x.Rebate == 12.6).Surplus.ToString();
                tool.text_UserQuotas_125.Text = data.UserQuotas.FirstOrDefault(x => x.Rebate == 13.0) == null ? "0"
                    : data.UserQuotas.FirstOrDefault(x => x.Rebate == 12.5).Surplus.ToString();
                tool.text_UserQuotas_124.Text = data.UserQuotas.FirstOrDefault(x => x.Rebate == 13.0) == null ? "0"
                    : data.UserQuotas.FirstOrDefault(x => x.Rebate == 12.4).Surplus.ToString();
                tool.text_UserQuotas_123.Text = data.UserQuotas.FirstOrDefault(x => x.Rebate == 13.0) == null ? "0"
                    : data.UserQuotas.FirstOrDefault(x => x.Rebate == 12.3).Surplus.ToString();
                tool.text_UserQuotas_122.Text = data.UserQuotas.FirstOrDefault(x => x.Rebate == 13.0) == null ? "0"
                    : data.UserQuotas.FirstOrDefault(x => x.Rebate == 12.2).Surplus.ToString();
                tool.text_UserQuotas_121.Text = data.UserQuotas.FirstOrDefault(x => x.Rebate == 13.0) == null ? "0"
                    : data.UserQuotas.FirstOrDefault(x => x.Rebate == 12.1).Surplus.ToString();
            }));

        #endregion

        #region 修改

        private void Edit(object sender, RoutedEventArgs e)
        {
            AdministratorExport aInfo = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo);
            UserStatus status = (UserStatus)Enum.Parse(typeof(UserStatus), (input_Status.SelectedItem as TextBlock).Text, false);
            Bank bankOfCard = (Bank)Enum.Parse(typeof(Bank), (input_BankOfTheCard.SelectedItem as TextBlock).Text, false);

            EditUserImport import = new EditUserImport
            {
                Id = this.State.Id,
                Status = status,
                Card = input_Card.Text,
                HolderOfTheCard = input_HolderOfTheCard.Text,
                BankOfTheCard = bankOfCard,
                Rebate_Normal = Convert.ToDouble(input_Rebate_Normal.Text),
                Rebate_IndefinitePosition = Convert.ToDouble(input_Rebate_IndefinitePosition.Text),
                Commission_A = Convert.ToDouble(input_Commission_A.Text),
                Commission_B = Convert.ToDouble(input_Commission_B.Text),
                Dividend = Convert.ToDouble(input_Dividend.Text),
                Token = aInfo.Token
            };
            AuthorServiceClient client = new AuthorServiceClient();
            client.EditUserCompleted += ShowEditUserResult;
            client.EditUserAsync(import);
        }

        void ShowEditUserResult(object sender, EditUserCompletedEventArgs e)
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

