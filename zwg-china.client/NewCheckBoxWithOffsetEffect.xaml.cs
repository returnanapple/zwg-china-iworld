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
    public partial class NewCheckBoxWithOffsetEffect : CheckBox
    {
        public NewCheckBoxWithOffsetEffect()
        {
            InitializeComponent();
            Style = (Style)this.Resources["StyleOfNewCheckBoxWithOffsetEffect"];
        }

        #region 重写OnApplyTemplate函数
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            normalImage = (Image)GetTemplateChild("ImageOfNormal");
            pressedImage = (Image)GetTemplateChild("ImageOfPressed");
            checkedImage = (Image)GetTemplateChild("ImageOfChecked");
            contentImage = (Image)GetTemplateChild("IamgeOfContent");
            if (ImageNameOfContent != "")
            {

                contentImage.Source = new BitmapImage(new Uri(string.Format("Images/{0}.png", ImageNameOfContent), UriKind.RelativeOrAbsolute));
            }
            if (ImageNameOfBackground != "")
            {
                normalImage.Source = new BitmapImage(new Uri(string.Format("Images/{0}_Normal.png", ImageNameOfBackground), UriKind.RelativeOrAbsolute));
                pressedImage.Source = new BitmapImage(new Uri(string.Format("Images/{0}_Pressed.png", ImageNameOfBackground), UriKind.RelativeOrAbsolute));
                checkedImage.Source = new BitmapImage(new Uri(string.Format("Images/{0}_Checked.png", ImageNameOfBackground), UriKind.RelativeOrAbsolute));
            }
        }
        #endregion

        #region 私有变量
        Image normalImage;
        Image pressedImage;
        Image checkedImage;
        Image contentImage;
        #endregion

        #region 依赖属性
        public string ImageNameOfContent
        {
            get { return (string)GetValue(ImageNameOfContentProperty); }
            set { SetValue(ImageNameOfContentProperty, value); }
        }
        public static readonly DependencyProperty ImageNameOfContentProperty =
            DependencyProperty.Register("ImageNameOfContent", typeof(string), typeof(NewCheckBoxWithOffsetEffect), new PropertyMetadata("", (d, e) =>
            {
                NewCheckBoxWithOffsetEffect td = (NewCheckBoxWithOffsetEffect)d;
                string te = (string)e.NewValue;
                if (td.contentImage != null)
                {
                    td.contentImage.Source = new BitmapImage(new Uri(string.Format("Images/{0}.png", te), UriKind.RelativeOrAbsolute));
                }
            }));

        public string ImageNameOfBackground
        {
            get { return (string)GetValue(ImageNameOfBackgroundProperty); }
            set { SetValue(ImageNameOfBackgroundProperty, value); }
        }
        public static readonly DependencyProperty ImageNameOfBackgroundProperty =
            DependencyProperty.Register("ImageNameOfBackground", typeof(string), typeof(NewCheckBoxWithOffsetEffect), new PropertyMetadata("", (d, e) =>
            {
                NewCheckBoxWithOffsetEffect td = (NewCheckBoxWithOffsetEffect)d;
                string te = (string)e.NewValue;
                if (td.normalImage != null && td.pressedImage != null && td.checkedImage != null)
                {
                    td.normalImage.Source = new BitmapImage(new Uri(string.Format("Images/{0}_Normal.png", te), UriKind.RelativeOrAbsolute));
                    td.pressedImage.Source = new BitmapImage(new Uri(string.Format("Images/{0}_Pressed.png", te), UriKind.RelativeOrAbsolute));
                    td.checkedImage.Source = new BitmapImage(new Uri(string.Format("Images/{0}_Checked.png", te), UriKind.RelativeOrAbsolute));
                }
            }));


        #endregion
    }
}
