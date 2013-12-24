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
using zwg_china.backstage.framework.LotteryService;

namespace zwg_china.backstage.control
{
    public partial class BettingsPage_FullWindow : ChildWindow
    {
        public BettingsPage_FullWindow()
        {
            InitializeComponent();
        }

        #region 附加内容

        public BettingExport State
        {
            get { return (BettingExport)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }

        public static readonly DependencyProperty StateProperty =
            DependencyProperty.Register("State", typeof(BettingExport), typeof(BettingsPage_FullWindow)
            , new PropertyMetadata(null, (d, e) =>
            {
                BettingsPage_FullWindow tool = (BettingsPage_FullWindow)d;
                BettingExport data = (BettingExport)e.NewValue;

                tool.text_Owner.Text = data.Owner;
                tool.text_HowToPlay.Text = data.HowToPlay;
                tool.text_Issue.Text = data.Issue;
                tool.text_Values.Text = data.Values;
                tool.text_Notes.Text = data.Notes.ToString();
                tool.text_Multiple.Text = data.Multiple.ToString("0.00");
                tool.text_Pay.Text = data.Pay.ToString("0.00");
                tool.text_Status.Text = data.Status.ToString();
                tool.text_Bonus.Text = data.Bonus.ToString("0.00");
                tool.text_CreatedTime.Text = string.Format("{0} {}"
                    , data.CreatedTime.ToLongDateString()
                    , data.CreatedTime.ToShortTimeString());
                tool.text_LotteryValue.Text = data.LotteryValue;
            }));

        #endregion

        #region 确定

        private void Enter(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        #endregion
    }
}

