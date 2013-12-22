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
    public class DateTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return "";
            }
            else
            {
                DateTime time = (DateTime)value;
                return string.Format("{0}/{1}/{2}"
                     , time.Year
                     , time.Month
                     , time.Day);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                string[] ts = value.ToString().Split("-/".ToCharArray());
                DateTime time = new DateTime(System.Convert.ToInt32(ts[0])
                    , System.Convert.ToInt32(ts[1])
                    , System.Convert.ToInt32(ts[2]));
                return time;

            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
