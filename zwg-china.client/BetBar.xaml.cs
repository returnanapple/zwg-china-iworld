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
using zwg_china.client.Classes;

namespace zwg_china.client
{
    public partial class BetBar : UserControl
    {
        public BetBar()
        {
            InitializeComponent();
            MultiSelectNumberButtons.Children.ToList().ForEach(x =>
            {
                NewButton y = (NewButton)x;
                y.Width = 28;
                y.Height = 29;
                y.ImageNameOfBackground = "MultiSelectButtonBg";
                
            });
        }

        #region 依赖属性
        /// <summary>
        /// 位
        /// </summary>
        public string Tittle
        {
            get { return (string)GetValue(TittleProperty); }
            set { SetValue(TittleProperty, value); }
        }
        public static readonly DependencyProperty TittleProperty =
            DependencyProperty.Register("Tittle", typeof(string), typeof(BetBar), new PropertyMetadata("", (d, e) =>
            {
                BetBar td = (BetBar)d;
                string te = (string)e.NewValue;
                td.ImageOfTittle.Source = new BitmapImage(new Uri(string.Format("Images/{0}.png", te), UriKind.RelativeOrAbsolute));
            }));
        #endregion

        
    }
}
