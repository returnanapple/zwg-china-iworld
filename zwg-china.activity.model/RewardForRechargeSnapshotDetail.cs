﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 充值奖励的计划的明细的快照
    /// </summary>
    public class RewardForRechargeSnapshotDetail : ModelBase
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
        /// 实例化一个新的充值奖励的计划的明细的快照
        /// </summary>
        public RewardForRechargeSnapshotDetail()
        {

        }

        /// <summary>
        /// 实例化一个新的充值奖励的计划的明细的快照
        /// </summary>
        /// <param name="detail">对应的充值奖励的计划的明细</param>
        public RewardForRechargeSnapshotDetail(RewardForRechargePlanDetail detail)
        {
            this.LowerRecharge = detail.LowerRecharge;
            this.CapsRecharge = detail.CapsRecharge;
            this.PrizeType = detail.PrizeType;
            this.Sum = detail.Sum;
            this.WaysToReward = detail.WaysToReward;
        }

        #endregion
    }
}
