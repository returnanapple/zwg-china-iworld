using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 分红记录
    /// </summary>
    public class DividendRecord : RecordingTimeModelBase
    {
        #region 属性

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 用户
        /// </summary>
        public virtual Author Owner { get; set; }

        /// <summary>
        /// 下线盈亏
        /// </summary>
        public double Profit { get; set; }

        /// <summary>
        /// 分红比例
        /// </summary>
        public double Scale { get; set; }

        /// <summary>
        /// 分红金额
        /// </summary>
        public double Sum { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public DividendStatus Status { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的分红记录
        /// </summary>
        public DividendRecord()
        {

        }

        /// <summary>
        /// 实例化一个新的分红记录
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="owner">用户</param>
        /// <param name="profit">下线盈亏</param>
        public DividendRecord(string title, Author owner, double profit)
        {
            this.Title = title;
            this.Owner = owner;
            this.Profit = profit;
            this.Scale = owner.PlayInfo.Dividend;
            this.Sum = this.Profit > 0 ? 0 : Math.Round(Math.Abs(this.Profit) * this.Scale / 100, 2);
            this.Status = DividendStatus.已申请;
            this.Remark = "";
        }

        #endregion

        #region 方法

        /// <summary>
        /// 获取相关描述
        /// </summary>
        /// <returns>返回相关描述</returns>
        public string GetDescription()
        {
            return this.Title;
        }

        #endregion
    }
}
