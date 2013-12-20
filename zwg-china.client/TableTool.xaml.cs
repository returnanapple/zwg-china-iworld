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
using System.Collections.ObjectModel;
using System.Collections;

namespace zwg_china.client
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
            DependencyProperty.Register("ColumnDefinitions", typeof(string), typeof(TableTool)
            , new PropertyMetadata("", (d, e) =>
            {
                #region 初始化参数

                if (e.NewValue == null) { return; }
                if (e.NewValue.ToString() == "") { return; }
                List<ColumnDefinitionsInfo> tList = new List<ColumnDefinitionsInfo>();
                try
                {
                    e.NewValue.ToString().Split(",".ToArray()).ToList()
                        .ForEach(x =>
                        {
                            ColumnDefinitionsInfo info = new ColumnDefinitionsInfo(x);
                            tList.Add(info);
                        });
                }
                catch (Exception)
                {
                    return;
                }
                if (tList.Count < 1) { return; }

                TableTool tool = (TableTool)d;
                tool.root.Width = tList.Sum(x => x.Width);

                #endregion

                #region 描绘列分割线

                int countOftList = tList.Count - 1;
                for (int i = 0; i < countOftList; i++)
                {

                }

                #endregion

                #region 写标题

                int cIndex = 0;
                tool._title.ColumnDefinitions.Clear();
                tool._title.Children.Clear();
                tList.ForEach(x =>
                {
                    ColumnDefinition cd = new ColumnDefinition();
                    cd.Width = new GridLength(x.Width);
                    tool._title.ColumnDefinitions.Add(cd);

                    TextBlock tb = new TextBlock();
                    tb.Style = tool.Resources["text_titile"] as Style;
                    tb.Text = x.Name;
                    tb.SetValue(Grid.ColumnProperty, cIndex);
                    tool._title.Children.Add(tb);

                    cIndex++;
                });

                #endregion
            }));

        #region 内嵌类型

        class ColumnDefinitionsInfo
        {
            public string Name { get; set; }

            public double Width { get; set; }

            public ColumnDefinitionsInfo(string input)
            {
                string[] t = input.Split(":".ToArray());
                this.Name = t[0];
                this.Width = Convert.ToDouble(t[1]);
            }
        }

        #endregion

        #endregion

        #region 行数

        public int CountOfRow
        {
            get { return (int)GetValue(CountOfRowProperty); }
            set { SetValue(CountOfRowProperty, value); }
        }

        public static readonly DependencyProperty CountOfRowProperty =
            DependencyProperty.Register("CountOfRow", typeof(int), typeof(TableTool)
            , new PropertyMetadata(0, (d, e) =>
            {
                int t = Convert.ToInt32(e.NewValue);
                if (t < 1) { return; }

                TableTool tool = (TableTool)d;
                for (int i = 0; i < t; i++)
                {
                    Grid grid = new Grid();
                    string styleName = i % 2 == 0 ? "bg_single" : "bg_double";
                    grid.Style = tool.Resources[styleName] as Style;
                    tool._bg.Children.Add(grid);
                }
            }));

        #endregion

        #region 页码和总页数

        public int PageIndex
        {
            get { return (int)GetValue(PageIndexProperty); }
            set { SetValue(PageIndexProperty, value); }
        }

        public static readonly DependencyProperty PageIndexProperty =
            DependencyProperty.Register("PageIndex", typeof(int), typeof(TableTool), new PropertyMetadata(1, (d, e) => { ((TableTool)d).ShowPageButtons(); }));

        public int TotalPage
        {
            get { return (int)GetValue(TotalPageProperty); }
            set { SetValue(TotalPageProperty, value); }
        }

        public static readonly DependencyProperty TotalPageProperty =
            DependencyProperty.Register("TotalPage", typeof(int), typeof(TableTool), new PropertyMetadata(1, (d, e) => { ((TableTool)d).ShowPageButtons(); }));

        #region 命令绑定

        public ICommand JumpCommand
        {
            get { return (ICommand)GetValue(JumpCommandProperty); }
            set { SetValue(JumpCommandProperty, value); }
        }

        public static readonly DependencyProperty JumpCommandProperty =
            DependencyProperty.Register("JumpCommand", typeof(ICommand), typeof(TableTool), new PropertyMetadata(null));

        #endregion

        #region 私有方法

        void ShowPageButtons()
        {
            _page.Children.Clear();
            #region 首页和上一页
            if (this.PageIndex > 1
                && this.TotalPage > 1)
            {
                HyperlinkButton hb1 = new HyperlinkButton();
                hb1.Content = "首页";
                hb1.Click += JumpToFirsPage;
                _page.Children.Add(hb1);

                HyperlinkButton hb2 = new HyperlinkButton();
                hb2.Content = "上一页";
                hb2.Click += JumpToPreviousPage;
                _page.Children.Add(hb2);
            }
            else
            {
                TextBlock tb1 = new TextBlock();
                tb1.Text = "首页";
                _page.Children.Add(tb1);

                TextBlock tb2 = new TextBlock();
                tb2.Text = "上一页";
                _page.Children.Add(tb2);
            }
            #endregion
            #region 页码和总页数
            TextBlock tb = new TextBlock();
            int totalPage = this.TotalPage > 0 ? this.TotalPage : 1;
            int pageIndex = this.PageIndex > totalPage ? totalPage : this.PageIndex;
            if (pageIndex < 1)
            {
                pageIndex = 1;
            }
            tb.Text = string.Format("{0}/{1}", pageIndex, totalPage);
            _page.Children.Add(tb);
            #endregion
            #region 下一页和尾页
            if (this.PageIndex < this.TotalPage
                && this.PageIndex > 0)
            {
                HyperlinkButton hb1 = new HyperlinkButton();
                hb1.Content = "下一页";
                hb1.Click += JumpToNextPage;
                _page.Children.Add(hb1);

                HyperlinkButton hb2 = new HyperlinkButton();
                hb2.Content = "尾页";
                hb2.Click += JumpToLastPage;
                _page.Children.Add(hb2);
            }
            else
            {
                TextBlock tb1 = new TextBlock();
                tb1.Text = "下一页";
                _page.Children.Add(tb1);

                TextBlock tb2 = new TextBlock();
                tb2.Text = "尾页";
                _page.Children.Add(tb2);
            }
            #endregion
        }

        void Jump(int pageIndex)
        {
            if (pageIndex < 1)
            {
                pageIndex = 1;
            }
            if (pageIndex > this.TotalPage)
            {
                pageIndex = this.TotalPage;
            }
            if (JumpCommand == null) { return; }
            if (!JumpCommand.CanExecute(pageIndex)) { return; }
            JumpCommand.Execute(pageIndex);
        }

        private void JumpToFirsPage(object sender, RoutedEventArgs e)
        {
            Jump(1);
        }

        private void JumpToPreviousPage(object sender, RoutedEventArgs e)
        {
            Jump(this.PageIndex - 1);
        }

        private void JumpToNextPage(object sender, RoutedEventArgs e)
        {
            Jump(this.PageIndex + 1);
        }

        private void JumpToLastPage(object sender, RoutedEventArgs e)
        {
            Jump(this.TotalPage);
        }

        #endregion

        #endregion

        #region 列表绑定

        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(IEnumerable), typeof(TableTool)
            , new PropertyMetadata(null, (d, e) =>
            {
                TableTool tool = (TableTool)d;
                tool._list.ItemsSource = e.NewValue as IEnumerable;
            }));

        public DataTemplate ItemTemplate
        {
            get { return (DataTemplate)GetValue(ItemTemplateProperty); }
            set { SetValue(ItemTemplateProperty, value); }
        }

        public static readonly DependencyProperty ItemTemplateProperty =
            DependencyProperty.Register("ItemTemplate", typeof(DataTemplate), typeof(TableTool)
            , new PropertyMetadata(null, (d, e) =>
            {
                TableTool tool = (TableTool)d;
                tool._list.ItemTemplate = e.NewValue as DataTemplate;
            }));

        #endregion
    }
}
