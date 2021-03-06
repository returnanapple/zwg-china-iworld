﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 投注
    /// </summary>
    public class Betting : RecordingTimeModelBase
    {
        #region 属性

        /// <summary>
        /// 投注人
        /// </summary>
        public virtual Author Owner { get; set; }

        /// <summary>
        /// 期号
        /// </summary>
        public string Issue { get; set; }

        /// <summary>
        /// 注数
        /// </summary>
        public int Notes { get; set; }

        /// <summary>
        /// 倍数
        /// </summary>
        public double Multiple { get; set; }

        /// <summary>
        /// 用于转换为赔率的点数
        /// </summary>
        public double Points { get; set; }

        /// <summary>
        /// 玩法
        /// </summary>
        public virtual HowToPlay HowToPlay { get; set; }

        /// <summary>
        /// 位
        /// </summary>
        public virtual List<BettingSeat> Seats { get; set; }

        /// <summary>
        /// 当前状态
        /// </summary>
        public BettingStatus Status { get; set; }

        /// <summary>
        /// 投注金额
        /// </summary>
        public double Pay { get; set; }

        /// <summary>
        /// 中奖金额（未中奖时候为0）
        /// </summary>
        public double Bonus { get; set; }

        /// <summary>
        /// 开奖号码（如果还没开奖则为空）
        /// </summary>
        public string LotteryValues { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的投注
        /// </summary>
        public Betting()
        {
        }

        /// <summary>
        /// 实例化一个新的投注
        /// </summary>
        /// <param name="owner">投注人</param>
        /// <param name="issue">期号</param>
        /// <param name="multiple">倍数</param>
        /// <param name="points">用于转换为赔率的点数</param>
        /// <param name="howToPlay">玩法</param>
        /// <param name="seats">位</param>
        /// <param name="unitPrice">单价</param>
        public Betting(Author owner, string issue, double multiple, double points, HowToPlay howToPlay
            , List<BettingSeat> seats, double unitPrice)
        {
            this.Owner = owner;
            this.Issue = issue;
            this.Multiple = multiple;
            this.Points = points;
            this.HowToPlay = howToPlay;
            this.Seats = seats;
            this.Status = BettingStatus.等待开奖;
            this.Bonus = 0;
            this.LotteryValues = "";

            this.Notes = GetNotes();
            double t = howToPlay.Interface == LotteryInterface.任N不定位
                ? owner.PlayInfo.Rebate_IndefinitePosition
                : owner.PlayInfo.Rebate_Normal;
            t -= this.Points;
            t = (1 - t) / 100;
            this.Pay = Math.Round(unitPrice * this.Notes * this.Multiple * t, 2);
        }

        #endregion

        #region 方法

        /// <summary>
        /// 获取投注内容的字符串显示
        /// </summary>
        /// <returns>返回投注内容的字符串显示</returns>
        public string GetBetStr()
        {
            string result = "";

            if (this.HowToPlay.Interface == LotteryInterface.任N直选
                && this.HowToPlay.IsDuplex == false)
            {
                result = this.Seats.First().Values;
            }
            else if (this.HowToPlay.Interface == LotteryInterface.任N直选)
            {
                result = string.Join(",", this.Seats.ConvertAll(x => string.Join("", x.ValueList.ConvertAll(v => GetTheRealStr(v, this.HowToPlay.Tag.Ticket.CountOfNUm)))));
            }
            else if (this.HowToPlay.Interface == LotteryInterface.任N组选
                || this.HowToPlay.Interface == LotteryInterface.任N不定位)
            {
                result = string.Join("", this.Seats.First().ValueList.ConvertAll(v => GetTheRealStr(v, this.HowToPlay.Tag.Ticket.CountOfNUm)));
            }
            else if (this.HowToPlay.Interface == LotteryInterface.任N定位胆)
            {
                result = string.Join(",", this.Seats.ConvertAll(x =>
                    {
                        string t = x.Values == "" ? "" : string.Join("", x.ValueList.ConvertAll(v => GetTheRealStr(v, this.HowToPlay.Tag.Ticket.CountOfNUm)));
                        return string.Format("{0}：{1}", x.Name, t);
                    }));
            }

            return result;
        }

        /// <summary>
        /// 获取描述
        /// </summary>
        /// <returns>返回描述</returns>
        public string GetDescription()
        {
            string result = string.Format("{0} - {1} - {2}"
                , this.HowToPlay.Tag.Ticket.Name
                , this.HowToPlay.Tag.Name
                , this.HowToPlay.Name);
            return result;
        }

        /// <summary>
        /// 获取中奖注数
        /// </summary>
        /// <param name="lottery">开奖记录</param>
        /// <returns>返回中奖注数</returns>
        public int GetNotesOfWin(Lottery lottery)
        {
            int result = 0;
            if (this.HowToPlay.Tag.Ticket.RealName != lottery.Ticket.RealName)
            {
                throw new Exception("所传入的开奖记录跟当前投注所对应的彩票不一致");
            }
            if (this.Issue != lottery.Issue)
            {
                throw new Exception("所传入的开奖记录跟当前投注所声明的期号不一致");
            }

            switch (this.HowToPlay.Interface)
            {
                case LotteryInterface.任N直选:
                    result = DirectElection(lottery);
                    break;
                case LotteryInterface.任N组选:
                    result = GroupSelection(lottery);
                    break;
                case LotteryInterface.任N不定位:
                    result = DoesNotLocate(lottery);
                    break;
                case LotteryInterface.任N定位胆:
                    result = PositioningBile(lottery);
                    break;
            }

            return result;
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 获取反奖接口为“任N直选”的投注的中奖注数
        /// </summary>
        /// <param name="lottery">开奖记录</param>
        /// <returns>返回中奖注数</returns>
        int DirectElection(Lottery lottery)
        {
            if (this.HowToPlay.Interface != LotteryInterface.任N直选)
            {
                throw new Exception("当前投注的玩法的反奖接口不是【任N直选】，请检查操作");
            }

            int result = 0;
            if (this.HowToPlay.IsDuplex) //复式投注
            {
                if (this.Seats.All(x => lottery.Seats.Any(s => s.Name == x.Name && x.ValueList.Any(v => v == s.Value))))
                {
                    result = 1;
                }
            }
            else //单式投注
            {
                string[] seatNames = this.HowToPlay.ValidSeats.Split(new char[] { ',' });
                List<string> betValues = this.Seats.First().ValueList;
                for (int i = 0; i < betValues.Count; i++)
                {
                    char[] tBettingValues = betValues[i].ToArray();
                    Dictionary<string, string> tSeats = new Dictionary<string, string>();
                    for (int j = 0; j < tBettingValues.Count(); j++)
                    {
                        if (this.HowToPlay.Tag.Ticket.CountOfNUm > 10)
                        {
                            string _str = tBettingValues[2 * j].ToString() + tBettingValues[2 * j + 1].ToString();
                            tSeats.Add(seatNames[j], _str);
                        }
                        else
                        {
                            tSeats.Add(seatNames[j], tBettingValues[j].ToString());
                        }
                    }
                    if (tSeats.All(t => t.Value == lottery.Seats.First(s => s.Name == t.Key).Value))
                    {
                        result = 1;
                        break;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 获取反奖接口为“任N组选”的投注的中奖注数
        /// </summary>
        /// <param name="lottery">开奖记录</param>
        /// <returns>返回中奖注数</returns>
        int GroupSelection(Lottery lottery)
        {
            List<string> betValues = this.Seats.First().ValueList;
            string[] seatNames = this.HowToPlay.ValidSeats.Split(new char[] { ',' });
            List<string> valuesOfWin = lottery.Seats.Where(x => seatNames.Contains(x.Name) && betValues.Contains(x.Value))
                .ToList().ConvertAll(x => x.Value);
            if (valuesOfWin.Count < this.HowToPlay.CountOfSeatsForWin)
            {
                return 0;
            }
            List<string> differentValuesOfWin = valuesOfWin.Distinct().ToList();
            if (differentValuesOfWin.Count >= this.HowToPlay.LowerCountOfDifferentSeatsForWin
                && differentValuesOfWin.Count <= this.HowToPlay.CapsCountOfDifferentSeatsForWin)
            {
                return 1;
            }
            return 0;
        }

        /// <summary>
        /// 获取反奖接口为“任N不定位”的投注的中奖注数
        /// </summary>
        /// <param name="lottery">开奖记录</param>
        /// <returns>返回中奖注数</returns>
        int DoesNotLocate(Lottery lottery)
        {
            List<string> betValues = this.Seats.First().ValueList;
            if (lottery.Seats.Any(x => betValues.Contains(x.Value)))
            {
                return 1;
            }
            return 0;
        }

        /// <summary>
        /// 获取反奖接口为“任N定位胆”的投注的中奖注数
        /// </summary>
        /// <param name="lottery">开奖记录</param>
        /// <returns>返回中奖注数</returns>
        int PositioningBile(Lottery lottery)
        {
            int result = lottery.Seats.Count(x => this.Seats.Any(s => s.Name == x.Name && s.ValueList.Contains(x.Value)));
            return result;
        }

        /// <summary>
        /// 获取投注的注数
        /// </summary>
        /// <returns>返回投注的注数</returns>
        int GetNotes()
        {
            int notes = 0;

            #region 获取实际的注数

            if (this.HowToPlay.Interface == LotteryInterface.任N直选)
            {
                //直选复式
                if (this.HowToPlay.IsDuplex)
                {
                    notes = 1;
                    this.Seats.ForEach(seat => { notes *= seat.ValueList.Count; });
                }
                //直选单式
                else
                {
                    notes = this.Seats.First().ValueList.Count;
                }
            }
            else if (this.HowToPlay.Interface == LotteryInterface.任N组选)
            {
                //二星组选
                if (this.HowToPlay.CountOfSeatsForWin == 2)
                {
                    int t = this.Seats.First().ValueList.Count;
                    List<int> tList = new List<int> 
                    {
                        t,
                        t * (t - 1) 
                    };
                    for (int i = 1; i <= 2; i++)
                    {
                        if (i >= this.HowToPlay.LowerCountOfDifferentSeatsForWin
                            && i <= this.HowToPlay.CapsCountOfDifferentSeatsForWin)
                        {
                            notes += tList[i - 1];
                        }
                    }
                }
                //三星组选
                else if (this.HowToPlay.CountOfSeatsForWin == 3)
                {
                    int t = this.Seats.First().ValueList.Count;
                    List<int> tList = new List<int> 
                    {
                        t,
                        3 * t * (t - 1),
                        t * (t - 1) *(t - 2)
                    };
                    for (int i = 1; i <= 3; i++)
                    {
                        if (i >= this.HowToPlay.LowerCountOfDifferentSeatsForWin
                            && i <= this.HowToPlay.CapsCountOfDifferentSeatsForWin)
                        {
                            notes += tList[i - 1];
                        }
                    }
                }
            }
            else if (this.HowToPlay.Interface == LotteryInterface.任N定位胆)
            {
                //定位胆
                this.Seats.ForEach(seat => { notes += seat.ValueList.Count; });
            }
            else if (this.HowToPlay.Interface == LotteryInterface.任N不定位)
            {
                //不定位
                notes = this.Seats.First().ValueList.Count;
            }

            #endregion

            return notes;
        }

        #endregion

        #region 转换

        string GetTheRealStr(string input, int countOfNum)
        {
            int t = Convert.ToInt32(input);
            if (countOfNum <= 10)
            {
                return t.ToString("0");
            }
            else
            {
                return t.ToString("00");
            }
        }

        #endregion
    }
}
