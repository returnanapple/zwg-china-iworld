﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 充值奖励的计划的明细
    /// </summary>
    public class RewardForRechargePlanDetail : ModelBase
    {
        #region 属性

        /// <summary>
        /// 最低充值（包含所填数字）
        /// </summary>
        public double LowerRecharge { get; set; }

        /// <summary>
        /// 最高充值（不包含所填数字）
        /// </summary>
        public double CapsRecharge { get; set; }

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
        /// 实例化一个新的充值奖励的计划的明细
        /// </summary>
        public RewardForRechargePlanDetail()
        {

        }

        /// <summary>
        /// 实例化一个新的充值奖励的计划的明细
        /// </summary>
        /// <param name="lowerConsumption">最低充值（包含所填数字）</param>
        /// <param name="capsConsumption">最高充值（不包含所填数字）</param>
        /// <param name="prizeType">奖品类型</param>
        /// <param name="sum">数额</param>
        /// <param name="waysToReward">返还方式</param>
        public RewardForRechargePlanDetail(double lowerConsumption, double capsConsumption, PrizesOfActivityType prizeType
            , double sum, WaysToRewardOfActivity waysToReward)
        {
            this.LowerRecharge = lowerConsumption;
            this.CapsRecharge = capsConsumption;
            this.PrizeType = prizeType;
            this.Sum = sum;
            this.WaysToReward = waysToReward;
        }

        #endregion
    }
}
