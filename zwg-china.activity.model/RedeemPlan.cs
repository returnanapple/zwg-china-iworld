using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 积分兑换的计划
    /// </summary>
    public class RedeemPlan : RegularModelBase
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
        /// 实例化一个新的积分兑换的计划
        /// </summary>
        public RedeemPlan()
        {

        }

        /// <summary>
        /// 实例化一个新的积分兑换的计划
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="description">描述</param>
        /// <param name="integral">积分（用于兑换的单价）</param>
        /// <param name="money">人民币（单次兑换数额）</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="hide">一个布尔值 标识活动是否暂停（默认为 false）</param>
        public RedeemPlan(string title, string description, int integral, double money
            , DateTime beginTime, DateTime endTime, bool hide = false)
            : base(beginTime, endTime, hide)
        {
            this.Title = title;
            this.Description = description;
            this.Integral = integral;
            this.Money = money;
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
