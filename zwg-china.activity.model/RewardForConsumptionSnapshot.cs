using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 消费奖励的计划的快照
    /// </summary>
    public class RewardForConsumptionSnapshot : RecordingTimeModelBase
    {
        #region 属性

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 计划类型
        /// </summary>
        public RewardPlanType PlanType { get; set; }

        /// <summary>
        /// 时间刻度（只在计划类型为“满就送”时候生效）
        /// </summary>
        public TimescaleOfActivity Timescale { get; set; }

        /// <summary>
        /// 明细
        /// </summary>
        public virtual List<RewardForConsumptionSnapshotDetail> Details { get; set; }

        /// <summary>
        /// 标识码
        /// </summary>
        public string Code { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的消费奖励的计划的快照
        /// </summary>
        public RewardForConsumptionSnapshot()
        {

        }

        /// <summary>
        /// 实例化一个新的消费奖励的计划的快照
        /// </summary>
        /// <param name="plan">对应的消费奖励的计划</param>
        public RewardForConsumptionSnapshot(RewardForConsumptionPlan plan)
        {
            this.Title = plan.Title;
            this.Description = plan.Description;
            this.PlanType = plan.PlanType;
            this.Timescale = plan.Timescale;
            this.Details = plan.Details.ConvertAll(x => new RewardForConsumptionSnapshotDetail(x));
            this.Code = plan.Code;
        }

        #endregion
    }
}
