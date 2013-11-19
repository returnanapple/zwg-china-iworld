using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 投注（追号）
    /// </summary>
    public class BettingWithChasing : ModelBase
    {
        #region 公开属性

        /// <summary>
        /// 期号
        /// </summary>
        public string Issue { get; set; }

        /// <summary>
        /// 倍数
        /// </summary>
        public double Multiple { get; set; }

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
        /// 所从属的追号记录
        /// </summary>
        public virtual Chasing Chasing { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的投注记录（追号）
        /// </summary>
        public BettingWithChasing()
        {
        }

        /// <summary>
        /// 实例化一个新的投注记录（追号）
        /// </summary>
        /// <param name="issue">期号</param>
        /// <param name="multiple">倍数</param>
        /// <param name="pay">投注金额</param>
        /// <param name="chasing">所从属的追号记录</param>
        public BettingWithChasing(string issue, double multiple, double pay, Chasing chasing)
        {
            this.Issue = issue;
            this.Multiple = multiple;
            this.Pay = pay;
            this.Status = BettingStatus.等待开奖;
            this.Bonus = 0;
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

            if (this.Chasing.HowToPlay.Interface == LotteryInterface.任N直选
                && this.Chasing.HowToPlay.IsDuplex == false)
            {
                result = this.Chasing.Seats.First().Values;
            }
            else if (this.Chasing.HowToPlay.Interface == LotteryInterface.任N直选)
            {
                result = string.Join(",", this.Chasing.Seats.ConvertAll(x => string.Join(" ", x.ValueList)));
            }
            else if (this.Chasing.HowToPlay.Interface == LotteryInterface.任N组选
                || this.Chasing.HowToPlay.Interface == LotteryInterface.任N不定位)
            {
                result = string.Join(" ", this.Chasing.Seats.First().ValueList);
            }
            else if (this.Chasing.HowToPlay.Interface == LotteryInterface.任N定位胆)
            {
                result = string.Join(",", this.Chasing.Seats.ConvertAll(x =>
                {
                    string t = x.Values == "" ? "" : string.Join(" ", x.ValueList);
                    return string.Format("{0}：", x.Name, t);
                }));
            }

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
            if (this.Chasing.HowToPlay.Tag.Ticket.RealName != lottery.Ticket.RealName)
            {
                throw new Exception("所传入的开奖记录跟当前投注所对应的彩票不一致");
            }
            if (this.Issue != lottery.Issue)
            {
                throw new Exception("所传入的开奖记录跟当前投注所声明的期号不一致");
            }

            switch (this.Chasing.HowToPlay.Interface)
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
            if (this.Chasing.HowToPlay.Interface != LotteryInterface.任N直选)
            {
                throw new Exception("当前投注的玩法的反奖接口不是【任N直选】，请检查操作");
            }

            int result = 0;
            if (this.Chasing.HowToPlay.IsDuplex) //复式投注
            {
                if (this.Chasing.Seats.All(x => lottery.Seats.Any(s => s.Name == x.Name && x.ValueList.Any(v => v == s.Value))))
                {
                    result = 1;
                }
            }
            else //单式投注
            {
                string[] seatNames = this.Chasing.HowToPlay.ValidSeats.Split(new char[] { ',' });
                List<string> betValues = this.Chasing.Seats.First().ValueList;
                for (int i = 0; i < betValues.Count; i++)
                {
                    char[] tBettingValues = betValues[i].ToArray();
                    Dictionary<string, string> tSeats = new Dictionary<string, string>();
                    for (int j = 0; j < tBettingValues.Count(); j++)
                    {
                        tSeats.Add(seatNames[j], tBettingValues[j].ToString());
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
            List<string> betValues = this.Chasing.Seats.First().ValueList;
            string[] seatNames = this.Chasing.HowToPlay.ValidSeats.Split(new char[] { ',' });
            List<string> valuesOfWin = lottery.Seats.Where(x => seatNames.Contains(x.Name) && betValues.Contains(x.Value))
                .ToList().ConvertAll(x => x.Value);
            if (valuesOfWin.Count < this.Chasing.HowToPlay.CountOfSeatsForWin)
            {
                return 0;
            }
            List<string> differentValuesOfWin = valuesOfWin.Distinct().ToList();
            if (differentValuesOfWin.Count >= this.Chasing.HowToPlay.LowerCountOfDifferentSeatsForWin
                && differentValuesOfWin.Count <= this.Chasing.HowToPlay.CapsCountOfDifferentSeatsForWin)
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
            List<string> betValues = this.Chasing.Seats.First().ValueList;
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
            int result = lottery.Seats.Count(x => this.Chasing.Seats.Any(s => s.Name == x.Name && s.ValueList.Contains(x.Value)));
            return result;
        }

        #endregion
    }
}
