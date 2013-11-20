using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 消费奖励的参与记录
    /// </summary>
    public class RewardForConsumptionRecord : RecordingTimeModelBase
    {
        #region 属性

        /// <summary>
        /// 用户
        /// </summary>
        public virtual Author Owner { get; set; }

        /// <summary>
        /// 对应的计划（快照）
        /// </summary>
        public virtual RewardForConsumptionSnapshot Plan { get; set; }

        /// <summary>
        /// 输入金额
        /// </summary>
        public double PostIn { get; set; }

        /// <summary>
        /// 生效的计划明细
        /// </summary>
        public virtual RewardForConsumptionSnapshotDetail ValidDetail { get; set; }

        /// <summary>
        /// 奖品类型
        /// </summary>
        public PrizesOfActivityType PrizeType { get; set; }

        /// <summary>
        /// 奖励数额
        /// </summary>
        public double Sum { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的消费奖励的参与记录
        /// </summary>
        public RewardForConsumptionRecord()
        {

        }

        /// <summary>
        /// 实例化一个新的消费奖励的参与记录
        /// </summary>
        /// <param name="owner">用户</param>
        /// <param name="plan">对应的计划（快照）</param>
        /// <param name="postIn">输入金额</param>
        public RewardForConsumptionRecord(Author owner, RewardForConsumptionSnapshot plan, double postIn)
        {
            this.Owner = owner;
            this.Plan = plan;
            this.PostIn = postIn;
            this.ValidDetail = plan.Details.First(x => x.LowerConsumption >= this.PostIn && x.CapsConsumption < this.PostIn);
            this.PrizeType = this.ValidDetail.PrizeType;
            this.Sum = this.ValidDetail.WaysToReward == WaysToRewardOfActivity.绝对值
                ? this.ValidDetail.Sum
                : Math.Round(this.PostIn * this.ValidDetail.Sum / 100, 2);
        }

        #endregion
    }
}
