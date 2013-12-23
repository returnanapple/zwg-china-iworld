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
using zwg_china.backstage.framework;
using zwg_china.backstage.framework.AdministratorService;
using zwg_china.backstage.framework.LotteryService;
using System.Collections.ObjectModel;

namespace zwg_china.backstage.control
{
    public partial class TicketsPage_EditWindow : ChildWindow
    {
        #region 私有字段

        ObservableCollection<EditLotteryTimeImport> editLotteryTimeImports = new ObservableCollection<EditLotteryTimeImport>();
        ObservableCollection<EditPlayTagImport> editPlayTagImports = new ObservableCollection<EditPlayTagImport>();

        #endregion

        public TicketsPage_EditWindow()
        {
            InitializeComponent();
            list_Times.ItemsSource = editLotteryTimeImports;
            list_Tags.ItemsSource = editPlayTagImports;
        }

        #region 错误信息

        /// <summary>
        /// 错误信息
        /// </summary>
        public string Error
        {
            get { return (string)GetValue(ErrorProperty); }
            set { SetValue(ErrorProperty, value); }
        }

        public static readonly DependencyProperty ErrorProperty =
            DependencyProperty.Register("Error", typeof(string), typeof(TicketsPage_EditWindow), new PropertyMetadata(null));

        #endregion

        #region 附加内容

        public LotteryTicketExport State
        {
            get { return (LotteryTicketExport)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }

        public static readonly DependencyProperty StateProperty =
            DependencyProperty.Register("State", typeof(LotteryTicketExport), typeof(TicketsPage_EditWindow)
            , new PropertyMetadata(null, (d, e) =>
            {
                TicketsPage_EditWindow tool = (TicketsPage_EditWindow)d;
                LotteryTicketExport data = (LotteryTicketExport)e.NewValue;

                tool.text_Name.Text = data.Name;
                tool.text_Installments.Text = data.Installments.ToString();
                tool.text_Issue.Text = data.Issue;
                tool.text_LotteryValues.Text = data.LotteryValues;
                tool.text_NextIssue.Text = data.NextIssue;
                tool.input_Hide.SelectedIndex = data.Hide ? 0 : 1;
                tool.input_Order.Text = data.Order.ToString();

                #region 填充开奖时间

                tool.editLotteryTimeImports.Clear();
                data.Times.ForEach(_time =>
                    {
                        EditLotteryTimeImport import = new EditLotteryTimeImport
                        {
                            Issue = _time.Issue,
                            TimeValue = _time.TimeValue
                        };
                        tool.editLotteryTimeImports.Add(import);
                    });

                #endregion

                #region 填充玩法标签和玩法

                tool.editPlayTagImports.Clear();
                data.Tags.ForEach(_tag =>
                    {
                        EditPlayTagImport import = new EditPlayTagImport
                        {
                            Name = _tag.Name,
                            HowToPlays = new List<EditHowToPlayImport>(),
                            Hide = _tag.Hide
                        };

                        _tag.HowToPlays.ForEach(howToplay =>
                            {
                                EditHowToPlayImport _import = new EditHowToPlayImport
                                {
                                    Name = howToplay.Name,
                                    Hide = howToplay.Hide
                                };
                                import.HowToPlays.Add(_import);
                            });

                        tool.editPlayTagImports.Add(import);
                    });

                #endregion
            }));

        #endregion

        #region 修改

        private void Edit(object sender, RoutedEventArgs e)
        {
            EditLotteryTicketImport import = new EditLotteryTicketImport
            {
                Id = this.State.Id,
                Name = this.State.Name,
                Order = Convert.ToInt32(input_Order.Text),
                Hide = input_Hide.SelectedIndex == 0,
                Tags = this.editPlayTagImports.ToList(),
                Times = this.editLotteryTimeImports.ToList(),
                Token = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo).Token
            };
            LotteryServiceClient client = new LotteryServiceClient();
            client.EditLotteryTicketCompleted += ShowEditResult;
            client.EditLotteryTicketAsync(import);
        }

        void ShowEditResult(object sender, EditLotteryTicketCompletedEventArgs e)
        {
            if (!e.Result.Success)
            {
                this.Error = e.Result.Error;
            }
            this.DialogResult = true;
        }

        #endregion

        #region 取消

        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        #endregion
    }
}

