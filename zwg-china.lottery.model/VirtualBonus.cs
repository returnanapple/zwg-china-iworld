using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 虚拟排行
    /// </summary>
    public class VirtualBonus : RecordingTimeModelBase
    {
        #region 属性

        /// <summary>
        /// 对应的彩票
        /// </summary>
        public virtual LotteryTicket Ticket { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public double Sum { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的虚拟排行
        /// </summary>
        public VirtualBonus()
        {
        }

        /// <summary>
        /// 实例化一个新的虚拟排行
        /// </summary>
        /// <param name="ticket">对应的彩票</param>
        /// <param name="issue">期号</param>
        /// <param name="sum">金额</param>
        public VirtualBonus(LotteryTicket ticket, double sum)
        {
            this.Ticket = ticket;
            this.Sum = sum;
        }

        #endregion
    }
}
