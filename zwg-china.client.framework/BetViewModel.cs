using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Media.Animation;
using zwg_china.client.framework.AuthorService;
using zwg_china.client.framework.LotteryService;

namespace zwg_china.client.framework
{
    public class BetViewModel : ManagerViewModelBase
    {
        #region 私有字段

        LotteryServiceClient lotteryClient = new LotteryServiceClient();

        static double poinN = 0;
        static double poinUn = 0;
        double maxPoinN = 0;
        double maxPoinUn = 0;
        string contextOfSelected = "";
        string contextOfMain = "";
        bool isDuplex = true;

        int notes = 0;
        double pay = 0;
        double multiple = 0;
        string contextOfPoinAndOdds = "1700/12.5%";

        string issue = "";
        string nextIssue = "";
        DateTime nextLotteryTime = new DateTime();
        string lotteryValues = "";

        #endregion

        #region 属性

        #region 开奖显示区

        /// <summary>
        /// 当期期号
        /// </summary>
        public string Issue
        {
            get { return issue; }
            set
            {
                if (issue == value) { return; }
                issue = value;
                OnPropertyChanged("Issue");
            }
        }

        /// <summary>
        /// 下期期号
        /// </summary>
        public string NextIssue
        {
            get { return nextIssue; }
            set
            {
                if (nextIssue == value) { return; }
                nextIssue = value;
                OnPropertyChanged("NextIssue");
            }
        }

        /// <summary>
        /// 下期开奖时间
        /// </summary>
        public DateTime NextLotteryTime
        {
            get { return nextLotteryTime; }
            set
            {
                if (nextLotteryTime == value) { return; }
                nextLotteryTime = value;
                OnPropertyChanged("NextLotteryTime");
            }
        }

        /// <summary>
        /// 当期开奖号码
        /// </summary>
        public string LotteryValues
        {
            get { return lotteryValues; }
            set
            {
                if (lotteryValues == value) { return; }
                lotteryValues = value;
                OnPropertyChanged("LotteryValues");
            }
        }

        #endregion

        #region 选号区

        /// <summary>
        /// 彩票
        /// </summary>
        public LotteryTicketExport Ticket { get; set; }

        /// <summary>
        /// 玩法标签
        /// </summary>
        public ObservableCollection<TagOfBet> Tags { get; set; }

        /// <summary>
        /// 选中的玩法的名称
        /// </summary>
        public ObservableCollection<HowToPlayOfBet> HowToPlays { get; set; }

        /// <summary>
        /// 位
        /// </summary>
        public ObservableCollection<SeatOfBet> Seats { get; set; }

        /// <summary>
        /// 用于追号的投注信息
        /// </summary>
        public ObservableCollection<BettingWithChasingInfoOfBet> BettingWithChasings { get; set; }

        /// <summary>
        /// 布尔值，标示该玩法是否是复式玩法
        /// </summary>
        public bool IsDuplex
        {
            get { return isDuplex; }
            set
            {
                if (isDuplex == value) { return; }
                isDuplex = value;
                OnPropertyChanged("IsDuplex");
            }
        }

        #endregion

        #region 信息显示区

        /// <summary>
        /// 最大可转换返点
        /// </summary>
        public double MaxPoint
        {
            get
            {
                HowToPlayOfBet tH = this.HowToPlays.FirstOrDefault(x => x.Selected);
                if (tH == null)
                {
                    return 0;
                }
                HowToPlayExport howToPlay = this.Ticket
                    .Tags.First(x => x.Name == this.Tags.First(t => t.Selected).Name)
                    .HowToPlays.First(x => x.Name == tH.Name);
                if (howToPlay.Interface == LotteryInterface.任N不定位)
                {
                    return maxPoinUn;
                }
                else
                {
                    return maxPoinN;
                }
            }
        }

        /// <summary>
        /// 当前转换放点
        /// </summary>
        public double Point
        {
            get
            {
                HowToPlayOfBet tH = this.HowToPlays.FirstOrDefault(x => x.Selected);
                if (tH == null)
                {
                    return 0;
                }
                HowToPlayExport howToPlay = this.Ticket
                    .Tags.First(x => x.Name == this.Tags.First(t => t.Selected).Name)
                    .HowToPlays.First(x => x.Name == tH.Name);
                if (howToPlay.Interface == LotteryInterface.任N不定位)
                {
                    return poinUn;
                }
                else
                {
                    return poinN;
                }
            }
            set
            {
                HowToPlayOfBet tH = this.HowToPlays.FirstOrDefault(x => x.Selected);
                if (tH == null)
                {
                    return;
                }
                HowToPlayExport howToPlay = this.Ticket
                    .Tags.First(x => x.Name == this.Tags.First(t => t.Selected).Name)
                    .HowToPlays.First(x => x.Name == tH.Name);
                value = Math.Round(value, 2);
                if (howToPlay.Interface == LotteryInterface.任N不定位)
                {
                    if (poinUn == value) { return; }
                    poinUn = value;
                }
                else
                {
                    if (poinN == value) { return; }
                    poinN = value;
                }
                OnPropertyChanged("Point");
                SettingExport setting = DataManager.GetValue<SettingExport>(DataKey.IWorld_Client_Setting);
                double odds = (setting.PayoutBase + this.Point * setting.ConversionRates) / setting.PayoutBase * howToPlay.Odds;
                odds = Math.Round(odds, 0);
                this.ContextOfPoinAndOdds = string.Format("{0}/{1}%", odds, Math.Round(this.MaxPoint - this.Point, 1));
                OnPropertyChanged("Pay");
            }
        }

        /// <summary>
        /// 展示区显示文字
        /// </summary>
        public string ContextOfSelected
        {
            get { return contextOfSelected; }
            set
            {
                if (contextOfSelected == value) { return; }
                contextOfSelected = value;
                OnPropertyChanged("ContextOfSelected");
            }
        }

        /// <summary>
        /// 选号区显示文字
        /// </summary>
        public string ContextOfMain
        {
            get { return contextOfMain; }
            set
            {
                if (contextOfMain == value) { return; }
                contextOfMain = value;
                OnPropertyChanged("ContextOfMain");
            }
        }

        /// <summary>
        /// 赔率返点显示文字
        /// </summary>
        public string ContextOfPoinAndOdds
        {
            get { return contextOfPoinAndOdds; }
            set
            {
                if (contextOfPoinAndOdds == value) { return; }
                contextOfPoinAndOdds = value;
                OnPropertyChanged("ContextOfPoinAndOdds");
            }
        }

        /// <summary>
        /// 注数
        /// </summary>
        public int Notes
        {
            get { return notes; }
            set
            {
                if (notes == value) { return; }
                notes = value;
                OnPropertyChanged("Notes");
            }
        }

        /// <summary>
        /// 总金额
        /// </summary>
        public double Pay
        {
            get { return Math.Round(pay * (1 - (this.MaxPoint - this.Point) / 100), 2); }
            set
            {
                if (pay == value) { return; }
                pay = value;
                OnPropertyChanged("Pay");
            }
        }

        /// <summary>
        /// 注数
        /// </summary>
        public double Multiple
        {
            get { return multiple; }
            set
            {
                if (multiple == value) { return; }
                multiple = value;
                OnPropertyChanged("Multiple");
            }
        }

        #endregion

        #region 列表显示

        /// <summary>
        /// 历史开奖
        /// </summary>
        public ObservableCollection<LotteryExport> Lotteries { get; set; }

        /// <summary>
        /// 投注明细
        /// </summary>
        public ObservableCollection<BettingExport> Bettings { get; set; }

        #endregion

        #region 命令

        /// <summary>
        /// “我选好了”
        /// </summary>
        public UniversalCommand ReadyBetCommand { get; set; }

        /// <summary>
        /// “清理”
        /// </summary>
        public UniversalCommand ClearBetCommand { get; set; }

        /// <summary>
        /// “我要追号”
        /// </summary>
        public UniversalCommand OpenChasingWindowCommand { get; set; }

        /// <summary>
        /// “投注”
        /// </summary>
        public UniversalCommand DoBetWindowCommand { get; set; }

        #endregion

        #endregion

        #region 构造方法

        public BetViewModel(string ticketName)
            : base(ticketName)
        {
            this.ReadyBetCommand = new UniversalCommand(ReadyBet);
            this.ClearBetCommand = new UniversalCommand(ClearBet);
            this.OpenChasingWindowCommand = new UniversalCommand(OpenChasingWindow);
            this.DoBetWindowCommand = new UniversalCommand(DoBetWindow);

            this.Tags = new ObservableCollection<TagOfBet>();
            this.HowToPlays = new ObservableCollection<HowToPlayOfBet>();
            this.Seats = new ObservableCollection<SeatOfBet>();
            this.Lotteries = new ObservableCollection<LotteryExport>();
            this.Bettings = new ObservableCollection<BettingExport>();
            this.BettingWithChasings = new ObservableCollection<BettingWithChasingInfoOfBet>();

            lotteryClient.GetLotteriesCompleted += ShowGetLotteriesResult;
            lotteryClient.GetBettingsCompleted += ShowGetBettingsResult;
            lotteryClient.BetCompleted += ShowBetResult;

            List<LotteryTicketExport> tickets = DataManager.GetValue<List<LotteryTicketExport>>(DataKey.IWorld_Client_Tickets);
            this.Ticket = tickets.First(x => x.Name == ticketName);
            this.Ticket.Tags.ForEach(x =>
            {
                TagOfBet tag = new TagOfBet(x.Name, new UniversalCommand(SelectTag));
                this.Tags.Add(tag);
            });
            this.Tags.First().Selected = true;
            AuthorExport userInfo = DataManager.GetValue<AuthorExport>(DataKey.IWorld_Client_UserInfo);
            this.maxPoinN = userInfo.PlayInfo.Rebate_Normal;
            this.maxPoinUn = userInfo.PlayInfo.Rebate_IndefinitePosition;
            RefreshLotteryInfo();
            RefreshBettings();

            Storyboard s = new Storyboard();
            s.Duration = new System.Windows.Duration(new TimeSpan(0, 0, 1));
            s.Completed += (sender, e) =>
            {
                List<LotteryTicketExport> _tickets = DataManager.GetValue<List<LotteryTicketExport>>(DataKey.IWorld_Client_Tickets);
                LotteryTicketExport _ticket = tickets.First(x => x.Name == ticketName);
                this.Ticket.Issue = _ticket.Issue;
                this.Ticket.NextIssue = _ticket.NextIssue;
                this.Ticket.NextLotteryTime = _ticket.NextLotteryTime;
                this.Ticket.LotteryValues = _ticket.LotteryValues;
                RefreshLotteryInfo();
                RefreshLotteries();

                Storyboard storyboard = (Storyboard)sender;
                storyboard.Begin();
            };
            s.Begin();
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 选中玩法标签
        /// </summary>
        /// <param name="obj"></param>
        void SelectTag(object obj)
        {
            string tagName = obj.ToString();
            PlayTagExport tag = this.Ticket.Tags.First(x => x.Name == tagName);
            this.HowToPlays.Clear();
            tag.HowToPlays.ForEach(x =>
            {
                HowToPlayOfBet howToPlay = new HowToPlayOfBet(x.Name, new UniversalCommand(SelectHowToPlay));
                this.HowToPlays.Add(howToPlay);
            });
            this.HowToPlays.First().Selected = true;
        }

        /// <summary>
        /// 选中玩法
        /// </summary>
        /// <param name="obj"></param>
        void SelectHowToPlay(object obj)
        {
            string howToPlayName = obj.ToString();
            HowToPlayExport howToPlay = this.Ticket
                .Tags.First(x => x.Name == this.Tags.First(t => t.Selected).Name)
                .HowToPlays.First(x => x.Name == howToPlayName);
            this.Seats.Clear();
            this.IsDuplex = (howToPlay.IsDuplex == false && howToPlay.Interface == LotteryInterface.任N直选) ? false : true;
            if (howToPlay.Interface == LotteryInterface.任N直选
                && howToPlay.IsDuplex == false)
            {
                return;
            }
            howToPlay.OptionalSeats.Split(new char[] { ',' }).ToList()
                .ForEach(seatName =>
                {
                    SeatOfBet seat = new SeatOfBet(seatName, this.Ticket.FirstNum, this.Ticket.CountOfNUm, this.ClearBetCommand);
                    this.Seats.Add(seat);
                });
        }

        /// <summary>
        /// 刷新开奖信息
        /// </summary>
        void RefreshLotteryInfo()
        {
            SettingExport setting = DataManager.GetValue<SettingExport>(DataKey.IWorld_Client_Setting);

            this.Issue = this.Ticket.Issue;
            this.NextIssue = this.Ticket.NextIssue;
            this.NextLotteryTime = this.Ticket.NextLotteryTime.AddSeconds(-setting.ClosureSingleTime);
            this.LotteryValues = this.Ticket.LotteryValues;
        }

        /// <summary>
        /// 刷新开奖记录
        /// </summary>
        void RefreshLotteries()
        {
            GetLotteriesImport import = new GetLotteriesImport
            {
                TicketId = this.Ticket.Id,
                Count = 4,
                Token = DataManager.GetValue<string>(DataKey.IWorld_Client_Token)
            };
            lotteryClient.GetLotteriesAsync(import);
        }
        #region 操作列表

        void ShowGetLotteriesResult(object sender, GetLotteriesCompletedEventArgs e)
        {
            if (e.Result.Success)
            {
                this.Lotteries.Clear();
                e.Result.Info.ForEach(x => this.Lotteries.Add(x));
            }
        }

        #endregion

        /// <summary>
        /// 刷新投注记录
        /// </summary>
        void RefreshBettings()
        {
            GetBettingsImport import = new GetBettingsImport
            {
                PageIndex = 1,
                Token = DataManager.GetValue<string>(DataKey.IWorld_Client_Token)
            };
            lotteryClient.GetBettingsAsync(import);
        }
        #region 操作列表

        void ShowGetBettingsResult(object sender, GetBettingsCompletedEventArgs e)
        {
            if (e.Result.Success)
            {
                this.Bettings.Clear();
                e.Result.List.OrderByDescending(x => x.CreatedTime).Take(1).ToList()
                    .ForEach(x => this.Bettings.Add(x));
            }
        }

        #endregion

        #endregion

        #region 命令方法

        List<BetSeatImport> _betSeatImports = new List<BetSeatImport>();

        /// <summary>
        /// 声明投注已经准备好了
        /// </summary>
        /// <param name="obj"></param>
        void ReadyBet(object obj)
        {
            HowToPlayOfBet tH = this.HowToPlays.FirstOrDefault(x => x.Selected);
            if (tH == null)
            {
                return;
            }
            HowToPlayExport howToPlay = this.Ticket
                .Tags.First(x => x.Name == this.Tags.First(t => t.Selected).Name)
                .HowToPlays.First(x => x.Name == tH.Name);
            SettingExport setting = DataManager.GetValue<SettingExport>(DataKey.IWorld_Client_Setting);
            _betSeatImports.Clear();
            #region 显示区
            if (howToPlay.Interface == LotteryInterface.任N直选
                && howToPlay.IsDuplex == false)
            {
                #region 填充选号

                BetSeatImport bsImport = new BetSeatImport
                {
                    SeatNmae = "选号",
                    Values = this.ContextOfSelected
                };
                _betSeatImports.Add(bsImport);

                #endregion
                #region 单式

                string _text = this.ContextOfMain;
                #region 移除/替换冗余字符
                _text = new Regex(@"\r{1,}").Replace(_text, " ");
                _text = new Regex(@"^ {1,}| {1,}$|^,{1,}|,{1,}$|^，{1,}|，{1,}$|^;{1,}|;{1,}$|^；{1,}|；{1,}$|^\r{1,}|\r{1,}$|^\|{1,}|\|{1,}$").Replace(_text, "");
                _text = new Regex(@" {1,}").Replace(_text, " ");
                _text = new Regex(@";{1,}").Replace(_text, " ");
                _text = new Regex(@"；{1,}").Replace(_text, " ");
                _text = new Regex(@",{1,}").Replace(_text, " ");
                _text = new Regex(@"，{1,}").Replace(_text, " ");
                _text = new Regex(@"\|{1,}").Replace(_text, " ");
                #endregion
                List<string> _betValues = _text.Split(" ".ToArray()).ToList();
                List<string> seatNames = howToPlay.OptionalSeats.Split(",".ToArray()).ToList();
                #region 检查合法性

                try
                {
                    foreach (var _betValue in _betValues)
                    {
                        char[] _vd = _betValue.ToArray();
                        int _longOfV = this.Ticket.CountOfNUm > 10 ? seatNames.Count * 2 : seatNames.Count;
                        if (_vd.Count() > _longOfV)
                        {
                            throw new Exception("单注定义的字符串过长");
                        }

                        List<int> vs = new List<int>();
                        for (int i = 0; i < seatNames.Count(); i++)
                        {
                            if (this.Ticket.CountOfNUm > 10)
                            {
                                string _str = _vd[2 * i].ToString() + _vd[2 * i + 1].ToString();
                                vs.Add(Convert.ToInt32(_str));
                            }
                            else
                            {
                                string _str = _vd[i].ToString();
                                vs.Add(Convert.ToInt32(_str));
                            }
                        }

                        int _fV = this.Ticket.FirstNum;
                        int _eV = this.Ticket.FirstNum + this.Ticket.CountOfNUm - 1;
                        if (!vs.All(x => x >= _fV && x <= _eV))
                        {
                            throw new Exception("选号超出设限");
                        }
                    }
                }
                catch (Exception)
                {
                    ShowError("输入的复式选号序列不合法，请检查输入");
                }

                #endregion
                this.ContextOfMain = "";
                this.ContextOfSelected = _text;
                this.Notes = _betValues.Count;
                this.Pay = setting.UnitPrice * this.Notes;

                #endregion

            }
            else
            {
                #region 填充选号

                this.Seats.ToList()
                    .ForEach(seat =>
                    {
                        BetSeatImport _bsImport = new BetSeatImport
                        {
                            SeatNmae = seat.Name,
                            Values = string.Join(",", seat.Nums.Where(x => x.Selected).OrderBy(x => x.Num).Select(x => x.Num).ToList())
                        };
                        _betSeatImports.Add(_bsImport);
                    });

                #endregion
                #region 复式

                if (howToPlay.Interface != LotteryInterface.任N定位胆
                    && this.Seats.Any(s => s.Nums.All(n => n.Selected == false)))
                {
                    ShowError("选号不合法，请检查你的选号。");
                    return;
                }
                string _vs = "";
                howToPlay.OptionalSeats.Split(",".ToArray()).ToList()
                    .ForEach(seatName =>
                    {
                        SeatOfBet s = this.Seats.First(x => x.Name == seatName);
                        List<string> svs = new List<string>();
                        s.Nums.Where(x => x.Selected == true).OrderBy(x => x.Num).Select(x => x.Num).ToList()
                            .ForEach(x =>
                            {
                                svs.Add(GetTheRealStr(x, this.Ticket.CountOfNUm));
                            });
                        if (_vs != "")
                        {
                            _vs += ",";
                        }
                        _vs += string.Join("", svs); ;
                    });
                this.ContextOfSelected = _vs;
                #region 注数
                int _notes = 0;
                #region 获取实际的注数

                if (howToPlay.Interface == LotteryInterface.任N直选)
                {
                    _notes = 1;
                    this.Seats.ToList().ForEach(seat => { _notes *= seat.Nums.Count(x => x.Selected == true); });
                }
                else if (howToPlay.Interface == LotteryInterface.任N组选)
                {
                    //二星组选
                    if (howToPlay.CountOfSeatsForWin == 2)
                    {
                        int t = this.Seats.First().Nums.Count(x => x.Selected == true);
                        List<int> tList = new List<int> 
                    {
                        t,
                        t * (t - 1) 
                    };
                        for (int i = 1; i <= 2; i++)
                        {
                            if (i >= howToPlay.LowerCountOfDifferentSeatsForWin
                                && i <= howToPlay.CapsCountOfDifferentSeatsForWin)
                            {
                                _notes += tList[i - 1];
                            }
                        }
                    }
                    //三星组选
                    else if (howToPlay.CountOfSeatsForWin == 3)
                    {
                        int t = this.Seats.First().Nums.Count(x => x.Selected == true);
                        List<int> tList = new List<int> 
                    {
                        t,
                        3 * t * (t - 1),
                        t * (t - 1) *(t - 2)
                    };
                        for (int i = 1; i <= 3; i++)
                        {
                            if (i >= howToPlay.LowerCountOfDifferentSeatsForWin
                                && i <= howToPlay.CapsCountOfDifferentSeatsForWin)
                            {
                                _notes += tList[i - 1];
                            }
                        }
                    }
                }
                else if (howToPlay.Interface == LotteryInterface.任N定位胆)
                {
                    //定位胆
                    this.Seats.ToList().ForEach(seat => { _notes += seat.Nums.Count(x => x.Selected == true); });
                }
                else if (howToPlay.Interface == LotteryInterface.任N不定位)
                {
                    //不定位
                    _notes = this.Seats.First().Nums.Count(x => x.Selected == true);
                }

                #endregion
                this.Notes = _notes;
                #endregion
                this.Pay = setting.UnitPrice * this.Notes;


                foreach (var seat in this.Seats)
                {
                    seat.Clear(null);
                }

                #endregion
            }
            #endregion
        }

        /// <summary>
        /// 清空已经准备好的投注
        /// </summary>
        /// <param name="obj"></param>
        void ClearBet(object obj)
        {
            this.ContextOfSelected = "";
            this.Notes = 0;
            this.Pay = 0;
            this.Multiple = 1;
            this._betSeatImports.Clear();
            this.BettingWithChasings.Clear();
        }

        /// <summary>
        /// 打开追号窗口
        /// </summary>
        /// <param name="obj"></param>
        void OpenChasingWindow(object obj)
        {
            IPop<ObservableCollection<BettingWithChasingInfoOfBet>> cw = ViewModelService.GetPop(Pop.EditBettingWithChasingWindow)
                as IPop<ObservableCollection<BettingWithChasingInfoOfBet>>;
            cw.State = this.BettingWithChasings;
            cw.Show();
        }

        /// <summary>
        /// 投注
        /// </summary>
        /// <param name="obj"></param>
        void DoBetWindow(object obj)
        {
            if (this._betSeatImports.Count <= 0) { return; }
            HowToPlayOfBet tH = this.HowToPlays.FirstOrDefault(x => x.Selected);
            HowToPlayExport howToPlay = this.Ticket
                .Tags.First(x => x.Name == this.Tags.First(t => t.Selected).Name)
                .HowToPlays.First(x => x.Name == tH.Name);
            #region 追号

            List<BettingWithChasingImport> bws = null;
            if (this.BettingWithChasings.Count > 0)
            {
                bws = new List<BettingWithChasingImport>();
                this.BettingWithChasings.ToList()
                    .ForEach(bettingWithChasing =>
                    {
                        BettingWithChasingImport bw = new BettingWithChasingImport
                        {
                            Issue = bettingWithChasing.Issue,
                            Multiple = bettingWithChasing.Multiple
                        };
                        bws.Add(bw);
                    });
            }

            #endregion
            BetImpoert import = new BetImpoert
            {
                HowToPlayId = howToPlay.Id,
                Issue = this.Ticket.NextIssue,
                Multiple = this.Multiple,
                Points = this.Point,
                Token = DataManager.GetValue<string>(DataKey.IWorld_Client_Token),
                Seats = this._betSeatImports,
                BettingWithChasings = bws
            };

            lotteryClient.BetAsync(import);
        }
        #region 显示投注结果

        void ShowBetResult(object sender, BetCompletedEventArgs e)
        {
            if (e.Result.Success)
            {
                ShowError("投注成功");
            }
            else
            {
                ShowError(e.Result.Error);
            }
            this.ContextOfMain = "";
            this.Seats.ToList().ForEach(x => x.Clear(null));
            ClearBet(null);
        }

        #endregion

        #endregion

        #region 转换

        string GetTheRealStr(int input, int countOfNum)
        {
            if (countOfNum <= 10)
            {
                return input.ToString("0");
            }
            else
            {
                return input.ToString("00");
            }
        }

        #endregion
    }
}
