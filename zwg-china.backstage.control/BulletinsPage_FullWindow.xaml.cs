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
using zwg_china.backstage.framework.MessageService;

namespace zwg_china.backstage.control
{
    public partial class BulletinsPage_FullWindow : ChildWindow
    {
        public BulletinsPage_FullWindow()
        {
            InitializeComponent();
        }

        #region 附加内容

        public BulletinExport State
        {
            get { return (BulletinExport)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }

        public static readonly DependencyProperty StateProperty =
            DependencyProperty.Register("State", typeof(BulletinExport), typeof(BulletinsPage_FullWindow)
            , new PropertyMetadata(null, (d, e) =>
            {
                BulletinsPage_FullWindow tool = (BulletinsPage_FullWindow)d;
                BulletinExport data = (BulletinExport)e.NewValue;

                tool.text_Title.Text = data.Title;
                tool.text_Context.Text = data.Context;
                tool.text_BeginTime.Text = data.BeginTime.ToLongDateString();
                tool.text_EndTime.Text = data.EndTime.AddDays(-1).ToLongDateString();
                tool.text_Hide.Text = data.Hide ? "是" : "否";
                tool.text_Status.Text = data.Status.ToString();
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