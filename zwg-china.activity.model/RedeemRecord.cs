using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 积分兑换的参与记录
    /// </summary>
    public class RedeemRecord : RecordingTimeModelBase
    {
        #region 属性

        /// <summary>
        /// 用户
        /// </summary>
        public virtual Author Owner { get; set; }

        /// <summary>
        /// 对应的计划（快照）
        /// </summary>
        public virtual RedeemSnapshot Plan { get; set; }

        /// <summary>
        /// 兑换数量
        /// </summary>
        public int Sum { get; set; }

        /// <summary>
        /// 单次单个兑换所需要消耗的积分
        /// </summary>
        public int PriceOfIntegral { get; set; }

        /// <summary>
        /// 单次单个兑换所能获得的人民币
        /// </summary>
        public double PriceOfMoney { get; set; }

        /// <summary>
        /// 总计消耗的积分
        /// </summary>
        public int SumOfIntegral { get; set; }

        /// <summary>
        /// 总计获得的人民币
        /// </summary>
        public double SumOfMoney { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的积分兑换的参与记录
        /// </summary>
        public RedeemRecord()
        {

        }

        /// <summary>
        /// 实例化一个新的积分兑换的参与记录
        /// </summary>
        /// <param name="owner">用户</param>
        /// <param name="plan">对应的计划（快照）</param>
        /// <param name="sum">兑换数量</param>
        public RedeemRecord(Author owner, RedeemSnapshot plan, int sum)
        {
            this.Owner = owner;
            this.Plan = plan;
            this.Sum = sum;
            this.PriceOfIntegral = plan.Integral;
            this.PriceOfMoney = plan.Money;
            this.SumOfIntegral = this.PriceOfIntegral * this.Sum;
            this.SumOfMoney = Math.Round(this.PriceOfMoney * this.Sum, 2);
        }

        #endregion
    }
}
