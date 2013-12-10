using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.model;

namespace zwg_china.service
{
    /// <summary>
    /// 充值记录
    /// </summary>
    [DataContract]
    public class RechargeRecordExport
    {
        #region 属性

        /// <summary>
        /// 存储指针
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// 用户的存储指针
        /// </summary>
        [DataMember]
        public int OwnerId { get; set; }

        /// <summary>
        /// 用户的用户名
        /// </summary>
        [DataMember]
        public string Owner { get; set; }

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
        public RechargeStatus Status { get; set; }

        /// <summary>
        /// 时间
        /// </summary>
        [DataMember]
        public DateTime CreatedTime { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的充值记录
        /// </summary>
        public RechargeRecordExport()
        {

        }

        /// <summary>
        /// 实例化一个新的充值记录
        /// </summary>
        /// <param name="model">充值记录的数据模型</param>
        public RechargeRecordExport(RechargeRecord model)
        {
            this.Id = model.Id;
            this.OwnerId = model.Owner.Id;
            this.Owner = model.Owner.Username;
            this.ComeFrom = model.ComeFrom;
            this.SerialNumber = model.SerialNumber;
            this.Sum = model.Sum;
            this.Status = model.Status;
            this.CreatedTime = model.CreatedTime;
        }

        #endregion
    }
}
