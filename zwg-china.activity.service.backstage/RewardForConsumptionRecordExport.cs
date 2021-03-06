﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using zwg_china.model;

namespace zwg_china.service.backstage
{
    /// <summary>
    /// 消费奖励的参与记录
    /// </summary>
    [DataContract]
    public class RewardForConsumptionRecordExport
    {
        #region 属性

        /// <summary>
        /// 存储指针
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// 用户的存储指针
        /// </summary>
        [DataMember]
        public int OwnerId { get; set; }

        /// <summary>
        /// 用户的用户名
        /// </summary>
        [DataMember]
        public string Owner { get; set; }

        /// <summary>
        /// 对应的计划（快照）
        /// </summary>
        [DataMember]
        public RewardForConsumptionSnapshotExport Plan { get; set; }

        /// <summary>
        /// 输入金额
        /// </summary>
        [DataMember]
        public double PostIn { get; set; }

        /// <summary>
        /// 生效的计划明细
        /// </summary>
        [DataMember]
        public RewardForConsumptionSnapshotDetailExport ValidDetail { get; set; }

        /// <summary>
        /// 奖品类型
        /// </summary>
        [DataMember]
        public PrizesOfActivityType PrizeType { get; set; }

        /// <summary>
        /// 奖励数额
        /// </summary>
        [DataMember]
        public double Sum { get; set; }

        /// <summary>
        /// 时间
        /// </summary>
        [DataMember]
        public DateTime CreatedTime { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的消费奖励的参与记录
        /// </summary>
        /// <param name="model">消费奖励的参与记录的数据契约</param>
        public RewardForConsumptionRecordExport(RewardForConsumptionRecord model)
        {
            this.Id = model.Id;
            this.OwnerId = model.Owner.Id;
            this.Owner = model.Owner.Username;
            this.Plan = new RewardForConsumptionSnapshotExport(model.Plan);
            this.PostIn = model.PostIn;
            this.ValidDetail = new RewardForConsumptionSnapshotDetailExport(model.ValidDetail);
            this.PrizeType = model.PrizeType;
            this.Sum = model.Sum;
            this.CreatedTime = model.CreatedTime;
        }

        #endregion
    }
}
