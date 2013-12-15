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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace zwg_china.client
{
    public partial class LotteryButton : RadioButton
    {
        public LotteryButton()
        {
            InitializeComponent();
        }

        #region 重写OnApplyTemplate函数
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            mouseOverImage = (Image)GetTemplateChild("ImageOfMouseOver");
            pressedImage = (Image)GetTemplateChild("ImageOfPressed");
            checkedImage = (Image)GetTemplateChild("ImageOfChecked");
            contentTextBlock = (TextBlock)GetTemplateChild("TextBlockOfContent");
            if (Text != "")
            {
                contentTextBlock.Text = Text;
            }
            if (ImageNameOfBackground != "")
            {
                mouseOverImage.Source = new BitmapImage(new Uri(string.Format("Images/{0}_MouseOver.png", ImageNameOfBackground), UriKind.RelativeOrAbsolute));
                pressedImage.Source = new BitmapImage(new Uri(string.Format("Images/{0}_Pressed.png", ImageNameOfBackground), UriKind.RelativeOrAbsolute));
                checkedImage.Source = new BitmapImage(new Uri(string.Format("Images/{0}_Checked.png", ImageNameOfBackground), UriKind.RelativeOrAbsolute));
            }
        }
        #endregion

        #region 私有变量
        Image mouseOverImage;
        Image pressedImage;
        Image checkedImage;
        TextBlock contentTextBlock;
        #endregion

        #region 依赖属性
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(LotteryButton), new PropertyMetadata("", (d, e) =>
            {
                LotteryButton td = (LotteryButton)d;
                string te = (string)e.NewValue;
                if (td.contentTextBlock != null)
                {
                    td.contentTextBlock.Text = te;
                }
            }));

        public string ImageNameOfBackground
        {
            get { return (string)GetValue(ImageNameOfBackgroundProperty); }
            set { SetValue(ImageNameOfBackgroundProperty, value); }
        }
        public static readonly DependencyProperty ImageNameOfBackgroundProperty =
            DependencyProperty.Register("ImageNameOfBackground", typeof(string), typeof(LotteryButton), new PropertyMetadata("", (d, e) =>
            {
                LotteryButton td = (LotteryButton)d;
                string te = (string)e.NewValue;
                if (td.mouseOverImage != null && td.pressedImage != null && td.checkedImage != null)
                {
                    td.mouseOverImage.Source = new BitmapImage(new Uri(string.Format("Images/{0}_MouseOver.png", te), UriKind.RelativeOrAbsolute));
                    td.pressedImage.Source = new BitmapImage(new Uri(string.Format("Images/{0}_Pressed.png", te), UriKind.RelativeOrAbsolute));
                    td.checkedImage.Source = new BitmapImage(new Uri(string.Format("Images/{0}_Checked.png", te), UriKind.RelativeOrAbsolute));
                }
            }));
        #endregion
    }
}
