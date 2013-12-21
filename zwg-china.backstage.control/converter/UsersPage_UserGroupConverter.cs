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

namespace zwg_china.backstage.control
{
    public class UsersPage_UserGroupConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            if (value == null && System.Convert.ToInt32(parameter) == 0)
            {
                return true;
            }
            else if (System.Convert.ToInt32(value) == System.Convert.ToInt32(parameter))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((bool)value == true)
            {
                int t = System.Convert.ToInt32(parameter);
                if (t <= 0)
                {
                    return null;
                }
                else
                {
                    return t;
                }
            }
            else
            {
                return -1;
            }
        }
    }
}
