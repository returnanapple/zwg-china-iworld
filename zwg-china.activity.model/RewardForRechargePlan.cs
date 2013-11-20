using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 充值奖励的计划
    /// </summary>
    public class RewardForRechargePlan : RegularModelBase
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
        public virtual List<RewardForRechargePlanDetail> Details { get; set; }

        /// <summary>
        /// 标识码
        /// </summary>
        public string Code { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的充值奖励的计划
        /// </summary>
        public RewardForRechargePlan()
        {

        }

        /// <summary>
        /// 实例化一个新的充值奖励的计划
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="description">描述</param>
        /// <param name="planType">计划类型</param>
        /// <param name="timescale">时间刻度（只在计划类型为“满就送”时候生效）</param>
        /// <param name="details">明细</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="hide">一个布尔值 标识活动是否暂停（默认为 false）</param>
        public RewardForRechargePlan(string title, string description, RewardPlanType planType, TimescaleOfActivity timescale
            , List<RewardForRechargePlanDetail> details, DateTime beginTime, DateTime endTime, bool hide = false)
            : base(beginTime, endTime, hide)
        {
            this.Title = title;
            this.Description = description;
            this.PlanType = planType;
            this.Timescale = timescale;
            this.Details = details;
            this.Code = Guid.NewGuid().ToString("N");
        }

        #endregion

        #region 方法

        /// <summary>
        /// 声明改模型已经被修改
        /// </summary>
        public override void OnModify()
        {
            base.OnModify();
            this.Code = Guid.NewGuid().ToString("N");
        }

        #endregion
    }
}
