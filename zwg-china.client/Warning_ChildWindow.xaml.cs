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
    public partial class Warning_ChildWindow : ChildWindow
    {
        public Warning_ChildWindow()
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
            DependencyProperty.Register("Text", typeof(string), typeof(Warning_ChildWindow), new PropertyMetadata("", (d, e) =>
            {
                Warning_ChildWindow td = (Warning_ChildWindow)d;
                td.Message.Text = (string)e.NewValue;
            }));
        #endregion

        #region Click事件
        private void OK(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
        #endregion
    }
}

