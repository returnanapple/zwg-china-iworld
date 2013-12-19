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

namespace zwg_china.backstage.control
{
    public partial class TableTool : UserControl
    {
        public TableTool()
        {
            InitializeComponent();
        }

        #region 列名和列宽定制

        public string ColumnDefinitions
        {
            get { return (string)GetValue(ColumnDefinitionsProperty); }
            set { SetValue(ColumnDefinitionsProperty, value); }
        }

        public static readonly DependencyProperty ColumnDefinitionsProperty =
            DependencyProperty.Register("ColumnDefinitions", typeof(string), typeof(TableTool), new PropertyMetadata(""));

        #endregion

        #region 行数

        public int CountOfRow
        {
            get { return (int)GetValue(CountOfRowProperty); }
            set { SetValue(CountOfRowProperty, value); }
        }

        public static readonly DependencyProperty CountOfRowProperty =
            DependencyProperty.Register("CountOfRow", typeof(int), typeof(TableTool), new PropertyMetadata(0));

        #endregion

        #region 页码和总页数

        public int PageIndex
        {
            get { return (int)GetValue(PageIndexProperty); }
            set { SetValue(PageIndexProperty, value); }
        }

        public static readonly DependencyProperty PageIndexProperty =
            DependencyProperty.Register("PageIndex", typeof(int), typeof(TableTool), new PropertyMetadata(1));



        #endregion
    }
}
