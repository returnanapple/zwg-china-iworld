using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using zwg_china.model;

namespace zwg_china.service
{
    /// <summary>
    /// 充值奖励的计划的明细的快照
    /// </summary>
    [DataContract]
    public class RewardForRechargeSnapshotDetailExport
    {
        #region 属性

        /// <summary>
        /// 存储指针
        /// </summary>
        [DataMember]
        public int Id { get; set; }

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

        #region 构造方法

        /// <summary>
        /// 实例化一个新的充值奖励的计划的明细的快照
        /// </summary>
        /// <param name="model">充值奖励的计划的明细的快照的数据模型</param>
        public RewardForRechargeSnapshotDetailExport(RewardForRechargeSnapshotDetail model)
        {
            this.Id = model.Id;
            this.LowerRecharge = model.LowerRecharge;
            this.CapsRecharge = model.CapsRecharge;
            this.PrizeType = model.PrizeType;
            this.Sum = model.Sum;
            this.WaysToReward = model.WaysToReward;
        }

        #endregion
    }
}
