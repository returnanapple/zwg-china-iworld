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
    public partial class ChasingsPage_TableRow : UserControl
    {
        public ChasingsPage_TableRow()
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
            DependencyProperty.Register("State", typeof(ChasingExport), typeof(ChasingsPage_TableRow)
            , new PropertyMetadata(null, (d, e) =>
            {
                ChasingsPage_TableRow tool = (ChasingsPage_TableRow)d;
                ChasingExport data = (ChasingExport)e.NewValue;

                tool.text_HowToPlay.Text = data.HowToPlay;
                tool.text_StartIssue.Text = data.StartIssue;
                tool.text_Owner.Text = data.Owner;
                tool.text_Pay.Text = data.Pay.ToString("0.00");
                tool.text_Status.Text = data.Status.ToString();
            }));

        #endregion

        #region 显示详细信息

        private void ShowFullWindow(object sender, RoutedEventArgs e)
        {
            ChasingsPage_FullWindow fw = new ChasingsPage_FullWindow();
            fw.State = this.State;
            fw.Show();
        }

        #endregion
    }
}
