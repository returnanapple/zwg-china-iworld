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

namespace zwg_china.client
{
    public partial class ShowMessage_ChildWindow : ChildWindow
    {
        public ShowMessage_ChildWindow()
        {
            InitializeComponent();
            Style = (Style)Resources["NewChildWindowStyle"];
        }

        #region 依赖属性
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(ShowMessage_ChildWindow), new PropertyMetadata("", (d, e) =>
            {
                ShowMessage_ChildWindow td = (ShowMessage_ChildWindow)d;
                td.Message.Text = (string)e.NewValue;
            }));
        #endregion

        #region Click事件
        private void Exit(object sender, RoutedEventArgs e)
        {
            Close();
        }
        #endregion
    }
}

