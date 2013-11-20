using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 注册奖励的计划
    /// </summary>
    public class RewardForRegisterPlan : RegularModelBase
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
        /// 实例化一个新的注册奖励的计划
        /// </summary>
        public RewardForRegisterPlan()
        {

        }

        /// <summary>
        /// 实例化一个新的注册奖励的计划
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="description">描述</param>
        /// <param name="prizeType">奖品类型</param>
        /// <param name="sum">数额</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="hide">一个布尔值 标识活动是否暂停（默认为 false）</param>
        public RewardForRegisterPlan(string title, string description, PrizesOfActivityType prizeType, double sum
            , DateTime beginTime, DateTime endTime, bool hide = false)
            : base(beginTime, endTime, hide)
        {
            this.Title = title;
            this.Description = description;
            this.PrizeType = prizeType;
            this.Sum = sum;
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
