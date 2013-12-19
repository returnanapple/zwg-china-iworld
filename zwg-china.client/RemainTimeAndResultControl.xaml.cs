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
    public partial class RemainTimeAndResultControl : UserControl
    {
        public RemainTimeAndResultControl()
        {
            InitializeComponent();
            (this.Resources["FlickerAndDescending"] as Storyboard).Begin();
        }

        #region 依赖属性
        /// <summary>
        /// 下期期号
        /// </summary>
        public string NextIssue
        {
            get { return (string)GetValue(NextIssueProperty); }
            set { SetValue(NextIssueProperty, value); }
        }
        public static readonly DependencyProperty NextIssueProperty =
            DependencyProperty.Register("NextIssue", typeof(string), typeof(RemainTimeAndResultControl), new PropertyMetadata(""));
        /// <summary>
        /// 截止时间
        /// </summary>
        public DateTime EndTime
        {
            get { return (DateTime)GetValue(EndTimeProperty); }
            set { SetValue(EndTimeProperty, value); }
        }
        public static readonly DependencyProperty EndTimeProperty =
            DependencyProperty.Register("EndTime", typeof(DateTime), typeof(RemainTimeAndResultControl), new PropertyMetadata(new DateTime()));
        /// <summary>
        /// 当前期号
        /// </summary>
        public string CurrentIssue
        {
            get { return (string)GetValue(CurrentIssueProperty); }
            set { SetValue(CurrentIssueProperty, value); }
        }
        public static readonly DependencyProperty CurrentIssueProperty =
            DependencyProperty.Register("CurrentIssue", typeof(string), typeof(RemainTimeAndResultControl), new PropertyMetadata(""));
        /// <summary>
        /// 当前结果
        /// </summary>
        public string CurrentResult
        {
            get { return (string)GetValue(CurrentResultProperty); }
            set { SetValue(CurrentResultProperty, value); }
        }
        public static readonly DependencyProperty CurrentResultProperty =
            DependencyProperty.Register("CurrentResult", typeof(string), typeof(RemainTimeAndResultControl), new PropertyMetadata(""));
        #endregion

        #region 动画结束事件
        void FlickerAndDescendingCompleted(object sender, EventArgs e)
        {
            TimeSpan remainTime = EndTime - DateTime.Now;
            NextIssueTextBlock.Text = NextIssue;
            if (remainTime.TotalSeconds > 0)
            {
                CurrentIssueTextBlock.Text = "第" + CurrentIssue + "期";

                List<string> sl = CurrentResult.Split(new char[] { ',' }).ToList();
                sl.ForEach(x => 
                {
                    x = string.Format("Images/结果{0}.png",x);
                });
                CurrentResultItemsControl.ItemsSource = null;
                CurrentResultItemsControl.ItemsSource = sl;

                remainTime = remainTime - new TimeSpan(0, 0, 1);
                if (remainTime.Hours == 0)
                {
                    ThousandImage.Source = new BitmapImage(new Uri(string.Format("Images/led{0}.png", Convert.ToString((remainTime.Minutes) / 10)), UriKind.RelativeOrAbsolute));
                    HundredImage.Source = new BitmapImage(new Uri(string.Format("Images/led{0}.png", Convert.ToString((remainTime.Minutes) % 10)), UriKind.RelativeOrAbsolute));
                    TenImage.Source = new BitmapImage(new Uri(string.Format("Images/led{0}.png", Convert.ToString((remainTime.Seconds) / 10)), UriKind.RelativeOrAbsolute));
                    OneImage.Source = new BitmapImage(new Uri(string.Format("Images/led{0}.png", Convert.ToString((remainTime.Seconds) % 10)), UriKind.RelativeOrAbsolute));
                }
                else
                {
                    ThousandImage.Source = new BitmapImage(new Uri(string.Format("Images/led{0}.png", Convert.ToString((remainTime.Hours) / 10)), UriKind.RelativeOrAbsolute));
                    HundredImage.Source = new BitmapImage(new Uri(string.Format("Images/led{0}.png", Convert.ToString((remainTime.Hours) % 10)), UriKind.RelativeOrAbsolute));
                    TenImage.Source = new BitmapImage(new Uri(string.Format("Images/led{0}.png", Convert.ToString((remainTime.Minutes) / 10)), UriKind.RelativeOrAbsolute));
                    OneImage.Source = new BitmapImage(new Uri(string.Format("Images/led{0}.png", Convert.ToString((remainTime.Minutes) % 10)), UriKind.RelativeOrAbsolute));
                }

            }
            else
            {
                CurrentIssueTextBlock.Text = "正在努力开奖中...";

                List<string> sl = new List<string> 
                { "Images/结果-.png", "Images/结果-.png", "Images/结果-.png", "Images/结果-.png", "Images/结果-.png" };
                CurrentResultItemsControl.ItemsSource = null;
                CurrentResultItemsControl.ItemsSource = sl;

                ThousandImage.Source = new BitmapImage(new Uri("Images/led0.png", UriKind.RelativeOrAbsolute));
                HundredImage.Source = new BitmapImage(new Uri("Images/led0.png", UriKind.RelativeOrAbsolute));
                TenImage.Source = new BitmapImage(new Uri("Images/led0.png", UriKind.RelativeOrAbsolute));
                OneImage.Source = new BitmapImage(new Uri("Images/led0.png", UriKind.RelativeOrAbsolute));
            }
            (this.Resources["FlickerAndDescending"] as Storyboard).Begin();

        }
        #endregion
    }
}
