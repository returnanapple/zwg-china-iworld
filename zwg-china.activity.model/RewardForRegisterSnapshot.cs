using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 注册奖励的计划的快照
    /// </summary>
    public class RewardForRegisterSnapshot : RecordingTimeModelBase
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
        /// 奖品类型
        /// </summary>
        public PrizesOfActivityType PrizeType { get; set; }

        /// <summary>
        /// 数额
        /// </summary>
        public double Sum { get; set; }

        /// <summary>
        /// 标识码
        /// </summary>
        public string Code { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的注册奖励的计划的快照
        /// </summary>
        public RewardForRegisterSnapshot()
        {

        }

        /// <summary>
        /// 实例化一个新的注册奖励的计划的快照
        /// </summary>
        /// <param name="plan">对应的注册奖励的计划</param>
        public RewardForRegisterSnapshot(RewardForRegisterPlan plan)
        {
            this.Title = plan.Title;
            this.Description = plan.Description;
            this.PrizeType = plan.PrizeType;
            this.Sum = plan.Sum;
            this.Code = plan.Code;
        }

        #endregion
    }
}
