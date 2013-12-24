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
using zwg_china.backstage.framework.ActicityService;

namespace zwg_china.backstage.control
{
    public partial class RewardForConsumptionPlansPage_TableRowOfDetails : UserControl
    {
        public RewardForConsumptionPlansPage_TableRowOfDetails()
        {
            InitializeComponent();
        }

        public event EventHandler DeleteEventHandler;

        #region 删除
        void DelMyself(object sender, RoutedEventArgs e)
        {
            if (DeleteEventHandler != null)
            {
                DeleteEventHandler(this, new EventArgs());
            }
        }
        #endregion

        #region 添加ComboBox选项
        private void AddItemsOfComboBox(object sender, RoutedEventArgs e)
        {
            input_PrizeType.ItemsSource = new List<PrizesOfActivityType> { PrizesOfActivityType.积分, PrizesOfActivityType.人民币 };
            input_WaysToReward.ItemsSource = new List<WaysToRewardOfActivity> { WaysToRewardOfActivity.百分比, WaysToRewardOfActivity.绝对值 };
        }
        #endregion
    }
}
