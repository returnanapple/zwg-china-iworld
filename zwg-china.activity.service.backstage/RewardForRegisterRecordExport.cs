using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using zwg_china.model;

namespace zwg_china.service
{
    /// <summary>
    /// 注册奖励的参与记录
    /// </summary>
    [DataContract]
    public class RewardForRegisterRecordExport
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
        public RewardForRegisterSnapshotExport Plan { get; set; }

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
        /// 实例化一个新的注册奖励的参与记录
        /// </summary>
        /// <param name="model">奖励的参与记录的数据模型</param>
        public RewardForRegisterRecordExport(RewardForRegisterRecord model)
        {
            this.Id = model.Id;
            this.OwnerId = model.Owner.Id;
            this.Owner = model.Owner.Username;
            this.Plan = new RewardForRegisterSnapshotExport(model.Plan);
            this.PrizeType = model.PrizeType;
            this.Sum = model.Sum;
            this.CreatedTime = model.CreatedTime;
        }

        #endregion
    }
}
