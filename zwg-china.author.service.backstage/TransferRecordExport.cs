using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.model;

namespace zwg_china.service
{
    /// <summary>
    /// 转账记录
    /// </summary>
    [DataContract]
    public class TransferRecordExport
    {
        #region 属性

        /// <summary>
        /// 来源银行
        /// </summary>
        [DataMember]
        public Bank ComeFrom { get; set; }

        /// <summary>
        /// 流水号
        /// </summary>
        [DataMember]
        public string SerialNumber { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        [DataMember]
        public double Sum { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [DataMember]
        public TransferStatus Status { get; set; }

        /// <summary>
        /// 时间
        /// </summary>
        [DataMember]
        public DateTime CreatedTime { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的转账记录
        /// </summary>
        public TransferRecordExport()
        {

        }

        /// <summary>
        /// 实例化一个新的转账记录
        /// </summary>
        /// <param name="model">转账记录的数据模型</param>
        public TransferRecordExport(TransferRecord model)
        {
            this.ComeFrom = model.ComeFrom;
            this.SerialNumber = model.SerialNumber;
            this.Sum = model.Sum;
            this.Status = model.Status;
            this.CreatedTime = model.CreatedTime;
        }

        #endregion
    }
}
