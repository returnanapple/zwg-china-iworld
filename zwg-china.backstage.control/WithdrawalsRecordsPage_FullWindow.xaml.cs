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
using zwg_china.backstage.framework.RecordOfAuthorService;

namespace zwg_china.backstage.control
{
    public partial class WithdrawalsRecordsPage_FullWindow : ChildWindow
    {
        public WithdrawalsRecordsPage_FullWindow()
        {
            InitializeComponent();
        }

        #region 附加内容

        public WithdrawalsRecordExport State
        {
            get { return (WithdrawalsRecordExport)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }

        public static readonly DependencyProperty StateProperty =
            DependencyProperty.Register("State", typeof(WithdrawalsRecordExport), typeof(WithdrawalsRecordsPage_FullWindow)
            , new PropertyMetadata(null, (d, e) =>
            {
                WithdrawalsRecordsPage_FullWindow tool = (WithdrawalsRecordsPage_FullWindow)d;
                WithdrawalsRecordExport data = (WithdrawalsRecordExport)e.NewValue;

                tool.text_Owner.Text = data.Owner;
                tool.text_Sum.Text = data.Sum.ToString("0.00");
                tool.text_Card.Text = data.Card;
                tool.text_HolderOfTheCard.Text = data.HolderOfTheCard;
                tool.text_BankOfTheCard.Text = data.BankOfTheCard.ToString();
                tool.text_Status.Text = data.Status.ToString();
                tool.text_Remark.Text = data.Remark;
                tool.text_CreatedTime.Text = string.Format("{0} {1}"
                    , data.CreatedTime.ToLongDateString()
                    , data.CreatedTime.ToShortTimeString());

                if (data.Status == WithdrawalsStatus.处理中) { return; }
                AdministratorExport aInfo = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo);
                if (aInfo.Group.CanEditSettings) { return; }

                tool.button_Confirm.Visibility = Visibility.Collapsed;
                tool.button_Veto.Visibility = Visibility.Collapsed;
            }));

        #endregion

        #region 操作标识

        /// <summary>
        /// 一个布尔值 表示是否同意提现申请
        /// </summary>
        public bool Agree
        {
            get { return (bool)GetValue(AgreeProperty); }
            set { SetValue(AgreeProperty, value); }
        }

        public static readonly DependencyProperty AgreeProperty =
            DependencyProperty.Register("Agree", typeof(bool), typeof(WithdrawalsRecordsPage_FullWindow), new PropertyMetadata(true));

        #endregion

        #region 返回

        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        #endregion

        #region 确认

        private void Confirm(object sender, RoutedEventArgs e)
        {
            this.Agree = true;
            this.DialogResult = true;
        }

        #endregion

        #region 否决

        private void Veto(object sender, RoutedEventArgs e)
        {
            this.Agree = false;
            this.DialogResult = true;
        }

        #endregion
    }
}

