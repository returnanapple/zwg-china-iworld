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
    public partial class SubPlayTagButton : RadioButton
    {
        public SubPlayTagButton()
        {
            InitializeComponent();
        }

        #region 重写OnApplyTemplate函数
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            contentTextBlock = (TextBlock)GetTemplateChild("TextBlockOfContent");
            contentTextBlock2 = (TextBlock)GetTemplateChild("TextBlock2OfContent");
            if (Text != "")
            {
                contentTextBlock.Text = Text;
                contentTextBlock2.Text = Text;
            }
        }
        #endregion

        #region 私有变量
        TextBlock contentTextBlock;
        TextBlock contentTextBlock2;
        #endregion

        #region 依赖属性
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(SubPlayTagButton), new PropertyMetadata("", (d, e) =>
            {
                SubPlayTagButton td = (SubPlayTagButton)d;
                string te = (string)e.NewValue;
                if (td.contentTextBlock != null && td.contentTextBlock2 != null)
                {
                    td.contentTextBlock.Text = te;
                    td.contentTextBlock2.Text = te;
                }
            }));
        #endregion
    }
}
