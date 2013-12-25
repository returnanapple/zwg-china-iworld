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
    public partial class TableLabelTool : UserControl
    {
        public TableLabelTool()
        {
            InitializeComponent();
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(TableLabelTool), new PropertyMetadata("", (d, e) =>
            {
                TableLabelTool td = (TableLabelTool)d;
                td.Label.Text = (string)e.NewValue;
            }));
    }
}
