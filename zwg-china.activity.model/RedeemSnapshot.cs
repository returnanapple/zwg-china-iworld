using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 积分兑换的计划的快照
    /// </summary>
    public class RedeemSnapshot : RecordingTimeModelBase
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
        /// 积分（用于兑换的单价）
        /// </summary>
        public int Integral { get; set; }

        /// <summary>
        /// 人民币（单次兑换数额）
        /// </summary>
        public double Money { get; set; }

        /// <summary>
        /// 标识码
        /// </summary>
        public string Code { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的积分兑换的计划的快照
        /// </summary>
        public RedeemSnapshot()
        {

        }

        /// <summary>
        /// 实例化一个新的积分兑换的计划的快照
        /// </summary>
        /// <param name="plan">对应的积分兑换的计划</param>
        public RedeemSnapshot(RedeemPlan plan)
        {
            this.Title = plan.Title;
            this.Description = plan.Description;
            this.Integral = plan.Integral;
            this.Money = plan.Money;
            this.Code = plan.Code;
        }

        #endregion
    }
}
