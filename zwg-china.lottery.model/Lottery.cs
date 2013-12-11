using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 开奖记录
    /// </summary>
    public class Lottery : RecordingTimeModelBase
    {
        #region 属性

        /// <summary>
        /// 期号
        /// </summary>
        public string Issue { get; set; }

        /// <summary>
        /// 来源
        /// </summary>
        public LotterySources Sources { get; set; }

        /// <summary>
        /// 操作人
        /// </summary>
        public virtual Administrator Operator { get; set; }

        /// <summary>
        /// 彩种
        /// </summary>
        public virtual LotteryTicket Ticket { get; set; }

        /// <summary>
        /// 位
        /// </summary>
        public virtual List<LotterySeat> Seats { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的开奖记录
        /// </summary>
        public Lottery()
        {
        }

        /// <summary>
        /// 实例化一个新的开奖记录
        /// </summary>
        /// <param name="issue">期号</param>
        /// <param name="sources">来源</param>
        /// <param name="_operator">操作人</param>
        /// <param name="ticket">彩种</param>
        /// <param name="seats">位</param>
        public Lottery(string issue, LotterySources sources, Administrator _operator, LotteryTicket ticket, List<LotterySeat> seats)
        {
            this.Issue = issue;
            this.Sources = sources;
            this.Operator = _operator;
            this.Ticket = ticket;
            this.Seats = seats;
        }

        #endregion

        #region 方法

        /// <summary>
        /// 获取下一期期号
        /// </summary>
        /// <returns>返回下一期期号</returns>
        public string GetNextIssue()
        {
            string result = this.Ticket.FormatOfIssue;
            List<string> tF = this.Ticket.FormatOfIssue.ToArray().ToList().ConvertAll(x => x.ToString());
            List<string> tI = this.Issue.ToArray().ToList().ConvertAll(x => x.ToString());
            if (this.Ticket.Installments == 1)
            {
                #region 每天一期

                string _y = "";
                string _i = "";
                for (int i = 0; i < tF.Count(); i++)
                {
                    if (tF[i] == "y")
                    {
                        _y += tI[i];
                    }
                    else if (tF[i] == "i")
                    {
                        _i += tI[i];
                    }
                }
                int year = Convert.ToInt32(_y);
                if (year < 100)
                {
                    year += 2000;
                }
                DateTime tTime = new DateTime(year + 1, 1, 1).AddDays(-1);
                int issue = Convert.ToInt32(_i);
                int nextIssue = issue + 1;
                if (nextIssue > tTime.DayOfYear)
                {
                    nextIssue = 1;
                    year += 1;
                }
                result = result.Replace("yyyy", year.ToString("0000"));
                result = result.Replace("yy", (year - 2000).ToString("00"));
                result = result.Replace("iii", nextIssue.ToString("000"));

                #endregion
            }
            else
            {
                #region 每天多期

                string _y = "";
                string _m = "";
                string _d = "";
                string _i = "";
                for (int i = 0; i < tF.Count(); i++)
                {
                    if (tF[i] == "y")
                    {
                        _y += tI[i];
                    }
                    else if (tF[i] == "m")
                    {
                        _m += tI[i];
                    }
                    else if (tF[i] == "d")
                    {
                        _d += tI[i];
                    }
                    else if (tF[i] == "i")
                    {
                        _i += tI[i];
                    }
                }
                int year = Convert.ToInt32(_y);
                if (year < 100)
                {
                    year += 2000;
                }
                int month = Convert.ToInt32(_m);
                int day = Convert.ToInt32(_d);
                DateTime tTime = new DateTime(year, month, day);
                int issue = Convert.ToInt32(_i);
                int nextIssue = issue + 1;
                if (nextIssue > this.Ticket.Installments)
                {
                    nextIssue = 1;
                    tTime = tTime.AddDays(1);
                }
                result = result.Replace("yyyy", tTime.Year.ToString("0000"));
                result = result.Replace("yy", (tTime.Year - 2000).ToString("00"));
                result = result.Replace("mm", tTime.Month.ToString("00"));
                result = result.Replace("dd", tTime.Day.ToString("00"));
                result = result.Replace("iii", nextIssue.ToString("000"));
                result = result.Replace("ii", nextIssue.ToString("00"));

                #endregion
            }
            return result;
        }

        #endregion
    }
}
