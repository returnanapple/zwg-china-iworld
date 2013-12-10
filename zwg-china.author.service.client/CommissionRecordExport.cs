using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.model;

namespace zwg_china.service
{
    /// <summary>
    /// 佣金记录
    /// </summary>
    [DataContract]
    public class CommissionRecordExport
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
        /// 来源用户的存储指针
        /// </summary>
        [DataMember]
        public int SourceId { get; set; }

        /// <summary>
        /// 来源用户的用户名
        /// </summary>
        [DataMember]
        public string Source { get; set; }

        /// <summary>
        /// 一个布尔值，表示该返点记录是否由直属下级触发
        /// </summary>
        [DataMember]
        public bool IsImmediate { get; set; }

        /// <summary>
        /// 返点金额
        /// </summary>
        [DataMember]
        public double Sum { get; set; }

        /// <summary>
        /// 时间
        /// </summary>
        [DataMember]
        public DateTime CreatedTime { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的佣金记录
        /// </summary>
        public CommissionRecordExport()
        {

        }

        /// <summary>
        /// 实例化一个新的佣金记录
        /// </summary>
        /// <param name="model">佣金记录的数据模型</param>
        public CommissionRecordExport(CommissionRecord model)
        {
            this.Id = model.Id;
            this.OwnerId = model.Owner.Id;
            this.Owner = model.Owner.Username;
            this.SourceId = model.Source.Id;
            this.Source = model.Source.Username;
            this.IsImmediate = model.IsImmediate;
            this.Sum = model.Sum;
            this.CreatedTime = model.CreatedTime;
        }

        #endregion
    }
}
