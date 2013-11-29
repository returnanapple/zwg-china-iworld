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
            return this.Chasing.GetBetStr();
        }

        /// <summary>
        /// 获取描述
        /// </summary>
        /// <returns>返回描述</returns>
        public string GetDescription()
        {
            return this.Chasing.GetDescription();
        }

        /// <summary>
        /// 获取中奖注数
        /// </summary>
        /// <param name="lottery">开奖记录</param>
        /// <returns>返回中奖注数</returns>
        public int GetNotesOfWin(Lottery lottery)
        {
            if (this.Issue != lottery.Issue)
            {
                throw new Exception("所传入的开奖记录跟当前投注所声明的期号不一致");
            }

            return this.Chasing.GetNotesOfWin(lottery);
        }

        #endregion
    }
}
