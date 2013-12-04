using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace zwg_china.model
{
    /// <summary>
    /// 彩票
    /// </summary>
    public class LotteryTicket : ModelBase
    {
        #region 公开属性

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 真实名称
        /// </summary>
        public string RealName { get; set; }

        /// <summary>
        /// 每日开奖期数
        /// </summary>
        public int Installments { get; set; }

        /// <summary>
        /// 当前期号
        /// </summary>
        public string Issue { get; set; }

        /// <summary>
        /// 当期开奖记录
        /// </summary>
        public string LotteryValues { get; set; }

        /// <summary>
        /// 下一期的期号
        /// </summary>
        public string NextIssue { get; set; }

        /// <summary>
        /// 下一期开奖时间
        /// </summary>
        public DateTime NextLotteryTime
        {
            get { return GetNextLotteryTime(); }
        }

        /// <summary>
        /// 下辖的玩法标签
        /// </summary>
        public virtual List<PlayTag> Tags { get; set; }

        /// <summary>
        /// 开奖时间
        /// </summary>
        public virtual List<LotteryTime> Times { get; set; }

        /// <summary>
        /// 一个布尔值，表示该彩票是否对前台客户隐藏
        /// </summary>
        public bool Hide { get; set; }

        /// <summary>
        /// 排序系数
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// 期号的格式（例如“yymmddiii”）
        /// </summary>
        public string FormatOfIssue { get; set; }

        /// <summary>
        /// 位
        /// </summary>
        public string Seats { get; set; }

        /// <summary>
        /// 初始选号
        /// </summary>
        public int FirstNum { get; set; }

        /// <summary>
        /// 选号个数
        /// </summary>
        public int CountOfNUm { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的彩票
        /// </summary>
        public LotteryTicket()
        {

        }

        /// <summary>
        /// 实例化一个新的彩票
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="installments">每日开奖期数</param>
        /// <param name="times">开奖时间</param>
        /// <param name="order">排序系数</param>
        /// <param name="formatOfIssue">期号的格式（例如“yymmddiii”）</param>
        /// <param name="seats">位</param>
        /// <param name="firstNum">初始选号</param>
        /// <param name="countOfNUm">选号个数</param>
        public LotteryTicket(string name, int installments, List<LotteryTime> times, int order, string formatOfIssue
            , string seats, int firstNum, int countOfNUm)
        {
            this.Name = name;
            this.RealName = name;
            this.Installments = installments;
            this.Issue = "从未开奖";
            this.LotteryValues = "从未开奖";
            this.NextIssue = "";
            this.Tags = new List<PlayTag>();
            this.Times = times;
            this.Hide = false;
            this.Order = order;
            this.FormatOfIssue = formatOfIssue;
            this.Seats = seats;
            this.FirstNum = firstNum;
            this.CountOfNUm = countOfNUm;
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 获取下一期的开奖时间
        /// </summary>
        /// <returns>返回下一期的开奖时间</returns>
        DateTime GetNextLotteryTime()
        {
            #region 如果下期期号为空，直接返回 DateTime 的原始记录

            if (this.NextIssue == "")
            {
                return new DateTime();
            };

            #endregion

            #region 如果每日只有一期，返回相应时间

            if (this.Times.Count == 1)
            {
                return DateTime.Now > this.Times.First().Time
                    ? this.Times.First().Time.AddDays(1)
                    : this.Times.First().Time;
            }

            #endregion

            #region 确认期号

            int issue = 1;
            if (this.Installments > 1)
            {
                string t = "";
                char[] tArray = this.FormatOfIssue.ToArray();
                char[] issueArray = this.NextIssue.ToArray();

                for (int i = 0; i < tArray.Count(); i++)
                {
                    if (tArray[i] == 'i')
                    {
                        t += issueArray[i];
                    }
                }

                issue = Convert.ToInt32(t);
            }

            #endregion

            #region 获取开奖时间列表中跟期号对应的时间

            if (!this.Times.Any(x => x.Issue == issue))
            {
                return new DateTime();
            }

            DateTime _time = this.Times.First(x => x.Issue == issue).Time;
            if (_time == this.Times.Min(x => x.Time)
                && DateTime.Now > this.Times.Max(x => x.Time))
            {
                _time.AddDays(1);
            }
            return _time;

            #endregion
        }

        #endregion
    }
}
