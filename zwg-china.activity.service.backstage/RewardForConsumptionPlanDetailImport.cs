using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.model;

namespace zwg_china.service.backstage
{
    /// <summary>
    /// 用于创建/修改消费奖励的计划的明细的数据集
    /// </summary>
    [DataContract]
    public class RewardForConsumptionPlanDetailImport
    {
        #region 属性

        /// <summary>
        /// 最低消费（包含所填数字）
        /// </summary>
        [DataMember]
        public double LowerConsumption { get; set; }

        /// <summary>
        /// 最高消费（不包含所填数字）
        /// </summary>
        [DataMember]
        public double CapsConsumption { get; set; }

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
