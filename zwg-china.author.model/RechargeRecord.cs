using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 充值记录
    /// </summary>
    public class RechargeRecord : RecordingTimeModelBase
    {
        #region 属性

        /// <summary>
        /// 用户
        /// </summary>
        public virtual Author Owner { get; set; }

        /// <summary>
        /// 来源银行
        /// </summary>
        public Bank ComeFrom { get; set; }

        /// <summary>
        /// 流水号
        /// </summary>
        public string SerialNumber { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public double Sum { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public RechargeStatus Status { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的充值记录
        /// </summary>
        public RechargeRecord()
        {

        }

        /// <summary>
        /// 实例化一个新的充值记录
        /// </summary>
        /// <param name="owner">用户</param>
        /// <param name="comeFrom">来源银行</param>
        /// <param name="serialNumber">流水号</param>
        public RechargeRecord(Author owner, Bank comeFrom, string serialNumber)
        {
            this.Owner = owner;
            this.ComeFrom = comeFrom;
            this.SerialNumber = serialNumber;
            this.Sum = 0;
            this.Status = RechargeStatus.等待银行确认;
        }

        #endregion
    }
}
