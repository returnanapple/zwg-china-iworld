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

namespace zwg_china.backstage.control
{
    public partial class SystemBankAccountsPage_FullWindow : ChildWindow
    {
        public SystemBankAccountsPage_FullWindow()
        {
            InitializeComponent();
        }

        #region 附加内容

        public SystemBankAccountExport State
        {
            get { return (SystemBankAccountExport)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }

        public static readonly DependencyProperty StateProperty =
            DependencyProperty.Register("State", typeof(SystemBankAccountExport), typeof(SystemBankAccountsPage_FullWindow)
            , new PropertyMetadata(null, (d, e) =>
            {
                SystemBankAccountsPage_FullWindow tool = (SystemBankAccountsPage_FullWindow)d;
                SystemBankAccountExport data = (SystemBankAccountExport)e.NewValue;

                tool.text_Card.Text = data.Card;
                tool.text_HolderOfTheCard.Text = data.HolderOfTheCard;
                tool.text_BankOfTheCard.Text = data.BankOfTheCard.ToString();
                tool.text_Remark.Text = data.Remark;
                tool.text_Order.Text = data.Order.ToString();
                tool.text_Hide.Text = data.Hide ? "是" : "否";
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

