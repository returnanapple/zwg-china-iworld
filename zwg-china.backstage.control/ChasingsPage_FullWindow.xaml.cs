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
    public partial class ChasingsPage_FullWindow : ChildWindow
    {
        public ChasingsPage_FullWindow()
        {
            InitializeComponent();
        }

        #region 附加内容

        public ChasingExport State
        {
            get { return (ChasingExport)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }

        public static readonly DependencyProperty StateProperty =
            DependencyProperty.Register("State", typeof(ChasingExport), typeof(ChasingsPage_FullWindow)
            , new PropertyMetadata(null, (d, e) =>
            {
                ChasingsPage_FullWindow tool = (ChasingsPage_FullWindow)d;
                ChasingExport data = (ChasingExport)e.NewValue;

                tool.text_Owner.Text = data.Owner;
                tool.text_HowToPlay.Text = data.HowToPlay;
                tool.text_StartIssue.Text = data.StartIssue;
                tool.text_Continuance.Text = data.Continuance.ToString();
                tool.text_Values.Text = data.Values;
                tool.text_Notes.Text = data.Notes.ToString();
                tool.text_Pay.Text = data.Pay.ToString("0.00");
                tool.text_Status.Text = data.Status.ToString();
                tool.text_Bonus.Text = data.Bonus.ToString("0.00");
                tool.text_CreatedTime.Text = string.Format("{0} {1}"
                    , data.CreatedTime.ToLongDateString()
                    , data.CreatedTime.ToShortTimeString());
                tool.list_Bettings.ItemsSource = data.Bettings;
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

