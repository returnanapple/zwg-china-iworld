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
        /// 一个布尔值，表示该分红记录是否已经兑现
        /// </summary>
        public bool HadHonored { get; set; }

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
        /// <param name="owner">用户</param>
        /// <param name="profit">下线盈亏</param>
        public DividendRecord(Author owner, double profit)
        {
            this.Owner = owner;
            this.Profit = profit;
            this.Scale = owner.PlayInfo.Dividend;
            this.Sum = this.Profit > 0 ? 0 : Math.Round(Math.Abs(this.Profit) * this.Scale / 100, 2);
            this.HadHonored = false;
        }

        #endregion
    }
}
