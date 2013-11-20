using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 消费奖励的计划的明细
    /// </summary>
    public class RewardForConsumptionPlanDetail : ModelBase
    {
        #region 属性

        /// <summary>
        /// 最低消费（包含所填数字）
        /// </summary>
        public double LowerConsumption { get; set; }

        /// <summary>
        /// 最高消费（不包含所填数字）
        /// </summary>
        public double CapsConsumption { get; set; }

        /// <summary>
        /// 奖品类型
        /// </summary>
        public PrizesOfActivityType PrizeType { get; set; }

        /// <summary>
        /// 数额
        /// </summary>
        public double Sum { get; set; }

        /// <summary>
        /// 返还方式
        /// </summary>
        public WaysToRewardOfActivity WaysToReward { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的消费奖励的计划的明细
        /// </summary>
        public RewardForConsumptionPlanDetail()
        {

        }

        /// <summary>
        /// 实例化一个新的消费奖励的计划的明细
        /// </summary>
        /// <param name="lowerConsumption">最低消费（包含所填数字）</param>
        /// <param name="capsConsumption">最高消费（不包含所填数字）</param>
        /// <param name="prizeType">奖品类型</param>
        /// <param name="sum">数额</param>
        /// <param name="waysToReward">返还方式</param>
        public RewardForConsumptionPlanDetail(double lowerConsumption, double capsConsumption, PrizesOfActivityType prizeType
            , double sum, WaysToRewardOfActivity waysToReward)
        {
            this.LowerConsumption = lowerConsumption;
            this.CapsConsumption = capsConsumption;
            this.PrizeType = prizeType;
            this.Sum = sum;
            this.WaysToReward = waysToReward;
        }

        #endregion
    }
}
