using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace zwg_china.client.Classes
{
    public class HowToPlayConverter:IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool v = (bool)value;
            string p = (string)parameter;
            if (v == false)
            {
                switch (p)
                {
                    case "单式":
                        return Visibility.Visible;
                    case "复式":
                        return Visibility.Collapsed;
                    default:
                        throw new Exception("无效参数");
                }
            }
            else
            {
                switch (p)
                {
                    case "单式":
                        return Visibility.Collapsed;
                    case "复式":
                        return Visibility.Visible;
                    default:
                        throw new Exception("无效参数");
                }
            }
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new Exception("单向绑定");
        }
    }
}
