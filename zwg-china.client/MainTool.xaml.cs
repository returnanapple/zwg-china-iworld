﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using zwg_china.client.framework;
using zwg_china.client.framework.AuthorService;
using zwg_china.client.framework.LotteryService;

namespace zwg_china.client
{
    public partial class MainTool : ContentControl
    {
        public MainTool()
        {
            InitializeComponent();
            InitializeList();
            LotteryButtons.ItemsSource = lotteryStateCollection;
            (Resources["GetUserInfo"] as Storyboard).Begin();
        }

        #region 私有字段
        List<LotteryTicketExport> tickets;
        List<ButtonContrast> contrasts;
        ObservableCollection<StateOfLottery> lotteryStateCollection;
        #endregion

        #region 依赖属性
        public string PageName
        {
            get { return (string)GetValue(PageNameProperty); }
            set { SetValue(PageNameProperty, value); }
        }
        public static readonly DependencyProperty PageNameProperty =
            DependencyProperty.Register("PageName", typeof(string), typeof(MainTool), new PropertyMetadata("", (d, e) =>
            {
                MainTool td = (MainTool)d;
                string te = (string)e.NewValue;
                if (te == "个人中心" || te == "资金管理" || te == "投注明细" || te == "数据报表" || te == "会员管理")
                {
                    (td.PanelOfNavigationButton.FindName(te) as NewRadioButton).IsChecked = true;
                    td.PanelOfGameButton.Visibility = Visibility.Collapsed;
                    td.PanelOfLotteryButton.Visibility = Visibility.Collapsed;
                }
                else
                {
                    td.首页.IsChecked = true;
                    if (te == "积分兑换")
                    {
                        td.活动专区.IsChecked = true;
                        td.lotteryStateCollection.First(x => x.Lottery == te).IsChecked = true;
                    }
                    else
                    {
                        string groupName = td.contrasts.First(x => x.ButtonNames.Contains(te)).GroupName;
                        (td.PanelOfGameButton.FindName(groupName) as NewRadioButton).IsChecked = true;
                        td.lotteryStateCollection.First(x => x.Lottery == te).IsChecked = true;
                    }
                    td.PanelOfGameButton.Visibility = Visibility.Visible;
                    td.PanelOfLotteryButton.Visibility = Visibility.Visible;
                }
            }));


        /// <summary>
        /// 页面跳转命令
        /// </summary>
        public ICommand Jump
        {
            get { return (ICommand)GetValue(JumpProperty); }
            set { SetValue(JumpProperty, value); }
        }
        public static readonly DependencyProperty JumpProperty =
            DependencyProperty.Register("Jump", typeof(ICommand), typeof(MainTool), new PropertyMetadata(null));
        #endregion

        #region 函数
        private void LoadedAction(object sender, RoutedEventArgs e)
        {
            App.Current.MainWindow.Width = 1024;
            App.Current.MainWindow.Height = 700;
        }

        #region 初始化列表
        void InitializeList()
        {
            tickets = DataManager.GetValue<List<LotteryTicketExport>>(DataKey.IWorld_Client_Tickets);
            contrasts = ContrastManager.Contrasts.ToList();
            contrasts.ForEach(x =>
            {
                x.ButtonNames.RemoveAll(y => !tickets.Any(z => z.Name == y));
            });
            lotteryStateCollection = new ObservableCollection<StateOfLottery>();
        }
        #endregion

        #region Checked事件
        void SelectMainPage(object sender, RoutedEventArgs e)
        {
            NewRadioButton nrb = (NewRadioButton)sender;
            if (nrb.Name == "首页" && PageName != "个人中心" && PageName != "资金管理"
                && PageName != "投注明细" && PageName != "数据报表" && PageName != "会员管理")
            {
                return;
            }
            else if (nrb.Name == PageName)
            {
                return;
            }
            switch (nrb.Name)
            {
                case "首页":
                    Jump.Execute(tickets.First().Name);
                    break;
                case "个人中心":
                    Jump.Execute("个人信息");
                    break;
                case "资金管理":
                    Jump.Execute("充值记录");
                    break;
                case "投注明细":
                    Jump.Execute("投注明细");
                    break;
                case "数据报表":
                    Jump.Execute("统计数据");
                    break;
                case "会员管理":
                    Jump.Execute("会员管理");
                    break;
                default:
                    break;
            }
        }

        void SelectGame(object sender, RoutedEventArgs e)
        {
            NewRadioButton nrb = (NewRadioButton)sender;
            lotteryStateCollection.Clear();
            if (nrb.Name == "活动专区")
            {
                if (PageName == "积分兑换")
                {
                    lotteryStateCollection.Add(new StateOfLottery("积分兑换", true));
                }
                else
                {
                    lotteryStateCollection.Add(new StateOfLottery("积分兑换", false));
                }
            }
            else
            {
                foreach (ButtonContrast i in contrasts)
                {
                    if (i.GroupName == nrb.Name)
                    {
                        i.ButtonNames.ForEach(x =>
                        {
                            if (x == PageName)
                            {
                                lotteryStateCollection.Add(new StateOfLottery(x, true));
                            }
                            else
                            {
                                lotteryStateCollection.Add(new StateOfLottery(x, false));
                            }
                        });
                        break;
                    }
                }
            }
        }

        void SelectLottery(object sender, RoutedEventArgs e)
        {
            LotteryButton lb = (LotteryButton)sender;
            if (lb.Text == PageName)
            {
                return;
            }
            Jump.Execute(lb.Text);
        }
        #endregion

        #region Click事件
        private void ClickAction(object sender, RoutedEventArgs e)
        {
            NewButton nb = (NewButton)sender;
            switch (nb.ImageNameOfBackground)
            {
                case "提现":
                    Jump.Execute("提现");
                    break;
                case "充值":
                    Jump.Execute("充值");
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region 故事版完成事件
        void ReflashUserInfo(object sender, EventArgs e)
        {
            AuthorExport userInfo = DataManager.GetValue<AuthorExport>(DataKey.IWorld_Client_UserInfo);
            昵称.Text = userInfo.Username;
            余额.Text = userInfo.Money.ToString();
            积分.Text = userInfo.Integral.ToString();
            等级.Text = userInfo.Group.Name;
        }
        #endregion

        #endregion

        #region 内部类
        public class StateOfLottery : INotifyPropertyChanged
        {
            public StateOfLottery(string l, bool i)
            {
                Lottery = l;
                IsChecked = i;
            }
            #region 私有变量
            private string lottery;
            private bool isChecked;
            #endregion

            #region 属性
            public string Lottery
            {
                get
                {
                    return lottery;
                }
                set
                {
                    lottery = value;
                    OnPropertyChanged(this, "Lottery");
                }
            }
            public bool IsChecked
            {
                get
                {
                    return isChecked;
                }
                set
                {
                    isChecked = value;
                    OnPropertyChanged(this, "IsChecked");
                }
            }
            #endregion

            #region 属性改变事件
            public event PropertyChangedEventHandler PropertyChanged;

            public void OnPropertyChanged(object sender, string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(sender, new PropertyChangedEventArgs(propertyName));
                }
            }
            #endregion
        }
        #endregion


    }
}