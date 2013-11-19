using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 转账记录
    /// </summary>
    public class TransferRecord : RecordingTimeModelBase
    {
        #region 属性

        /// <summary>
        /// 来源银行
        /// </summary>
        public Bank ComeFrom { get; set; }

        /// <summary>
        /// 流水号
        /// </summary>
        public string SerialNumber { get; set; }

        /// <summary>
        /// 附言
        /// </summary>
        public string Postscript { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public double Sum { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public TransferStatus Status { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的转账记录
        /// </summary>
        public TransferRecord()
        {
        }

        /// <summary>
        /// 实例化一个新的转账记录
        /// </summary>
        /// <param name="comeFrom">来源银行</param>
        /// <param name="serialNumber">流水号</param>
        /// <param name="postscript">附言</param>
        /// <param name="sum">金额</param>
        public TransferRecord(Bank comeFrom, string serialNumber, string postscript, double sum)
        {
            this.ComeFrom = comeFrom;
            this.SerialNumber = serialNumber;
            this.Postscript = postscript;
            this.Sum = sum;
            this.Status = TransferStatus.用户已经支付;
        }

        #endregion
    }
}
