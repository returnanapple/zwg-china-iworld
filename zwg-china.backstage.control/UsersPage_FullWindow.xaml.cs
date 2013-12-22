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
using zwg_china.backstage.framework.AuthorService;
using zwg_china.backstage.framework.AdministratorService;

namespace zwg_china.backstage.control
{
    public partial class UsersPage_FullWindow : ChildWindow
    {
        public UsersPage_FullWindow()
        {
            InitializeComponent();
        }

        #region 附加内容

        public AuthorExport State
        {
            get { return (AuthorExport)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }

        public static readonly DependencyProperty StateProperty =
            DependencyProperty.Register("State", typeof(AuthorExport), typeof(UsersPage_FullWindow)
            , new PropertyMetadata(null, (d, e) =>
            {
                UsersPage_FullWindow tool = (UsersPage_FullWindow)d;
                AuthorExport data = (AuthorExport)e.NewValue;

                tool.text_Username.Text = data.Username;
                tool.text_Group.Text = data.Group.Name;
                tool.text_Status.Text = data.Status.ToString();
                tool.text_CreatedTime.Text = data.CreatedTime.ToLongDateString();
                tool.text_LastLoginTime.Text = data.LastLoginTime.ToLongDateString();
                tool.text_LstLoginIp.Text = data.LastLoginIp;
                tool.text_LastLoginAddress.Text = data.LastLoginAddress;
                tool.text_parent.Text = data.Parent;

                tool.text_Money.Text = data.Money.ToString("0.00");
                tool.text_Money_Frozen.Text = data.Money_Frozen.ToString("0.00");
                tool.text_Consumption.Text = data.Consumption.ToString("0.00");
                tool.text_Integral.Text = data.Integral.ToString();
                tool.text_Subordinate.Text = data.Subordinate.ToString();

                tool.text_Rebate_Normal.Text = string.Format("{0}%", data.PlayInfo.Rebate_Normal.ToString("0.0"));
                tool.text_Rebate_IndefinitePosition.Text = string.Format("{0}%", data.PlayInfo.Rebate_IndefinitePosition.ToString("0.0"));
                tool.text_Commission_A.Text = data.PlayInfo.Commission_A == 0 ? "默认" : data.PlayInfo.Commission_A.ToString("0.00");
                tool.text_Commission_B.Text = data.PlayInfo.Commission_B == 0 ? "默认" : data.PlayInfo.Commission_B.ToString("0.00");
                tool.text_Dividend.Text = data.Layer > 2 ? "无" :
                    data.PlayInfo.Dividend == 0 ? "默认" : string.Format("{0}%", data.PlayInfo.Dividend.ToString("0.00"));

                if (data.Binding.AlreadyBindingCard)
                {
                    tool.text_Card.Text = data.Binding.Card;
                    tool.text_HolderOfTheCard.Text = data.Binding.HolderOfTheCard;
                    tool.text_BankOfTheCard.Text = data.Binding.BankOfTheCard.ToString();
                }
                else
                {
                    tool.text_Card.Text = "未绑定";
                    tool.text_HolderOfTheCard.Text = "未绑定";
                    tool.text_BankOfTheCard.Text = "未绑定";
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

        #region 确认

        private void Enter(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        #endregion
    }
}

