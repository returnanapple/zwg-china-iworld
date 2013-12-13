using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.model;

namespace zwg_china.service
{
    /// <summary>
    /// 用于创建/修改充值奖励的计划的明细的数据集
    /// </summary>
    [DataContract]
    public class RewardForRechargePlanDetailImport
    {
        #region 属性

        /// <summary>
        /// 最低充值（包含所填数字）
        /// </summary>
        [DataMember]
        public double LowerRecharge { get; set; }

        /// <summary>
        /// 最高充值（不包含所填数字）
        /// </summary>
        [DataMember]
        public double CapsRecharge { get; set; }

        /// <summary>
        /// 奖品类型
        /// </summary>
        [DataMember]
        public PrizesOfActivityType PrizeType { get; set; }

        /// <summary>
        /// 数额
        /// </summary>
        [DataMember]
        public double Sum { get; set; }

        /// <summary>
        /// 返还方式
        /// </summary>
        [DataMember]
        public WaysToRewardOfActivity WaysToReward { get; set; }

        #endregion
    }
}
