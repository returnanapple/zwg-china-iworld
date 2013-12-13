using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using zwg_china.model;

namespace zwg_china.service
{
    /// <summary>
    /// 消费奖励的计划的明细
    /// </summary>
    [DataContract]
    public class RewardForConsumptionPlanDetailExport
    {
        #region 属性

        /// <summary>
        /// 存储指针
        /// </summary>
        [DataMember]
        public int Id { get; set; }

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

        #region 构造方法

        /// <summary>
        /// 实例化一个新的消费奖励的计划的明细
        /// </summary>
        /// <param name="model">消费奖励的计划的明细的数据模型</param>
        public RewardForConsumptionPlanDetailExport(RewardForConsumptionPlanDetail model)
        {
            this.Id = model.Id;
            this.LowerConsumption = model.LowerConsumption;
            this.CapsConsumption = model.CapsConsumption;
            this.PrizeType = model.PrizeType;
            this.Sum = model.Sum;
            this.WaysToReward = model.WaysToReward;
        }

        #endregion
    }
}
