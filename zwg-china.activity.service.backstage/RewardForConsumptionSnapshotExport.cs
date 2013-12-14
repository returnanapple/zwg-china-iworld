using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using zwg_china.model;

namespace zwg_china.service.backstage
{
    /// <summary>
    /// 消费奖励的计划的快照
    /// </summary>
    [DataContract]
    public class RewardForConsumptionSnapshotExport
    {
        #region 属性

        /// <summary>
        /// 存储指针
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        [DataMember]
        public string Title { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// 计划类型
        /// </summary>
        [DataMember]
        public RewardPlanType PlanType { get; set; }

        /// <summary>
        /// 时间刻度（只在计划类型为“满就送”时候生效）
        /// </summary>
        [DataMember]
        public TimescaleOfActivity Timescale { get; set; }

        /// <summary>
        /// 明细
        /// </summary>
        [DataMember]
        public List<RewardForConsumptionSnapshotDetailExport> Details { get; set; }

        /// <summary>
        /// 标识码
        /// </summary>
        [DataMember]
        public string Code { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的消费奖励的计划的快照
        /// </summary>
        /// <param name="model">消费奖励的计划的快照的数据模型</param>
        public RewardForConsumptionSnapshotExport(RewardForConsumptionSnapshot model)
        {
            this.Id = model.Id;
            this.Title = model.Title;
            this.Description = model.Description;
            this.PlanType = model.PlanType;
            this.Timescale = model.Timescale;
            this.Details = model.Details.ConvertAll(x => new RewardForConsumptionSnapshotDetailExport(x));
            this.Code = model.Code;
        }

        #endregion
    }
}
