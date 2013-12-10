using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.model;

namespace zwg_china.service
{
    /// <summary>
    /// 操作记录
    /// </summary>
    [DataContract]
    public class OperateRecordExport
    {
        #region 属性

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
        /// 操作
        /// </summary>
        [DataMember]
        public string Operated { get; set; }

        /// <summary>
        /// 时间
        /// </summary>
        [DataMember]
        public DateTime CreatedTime { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的操作记录
        /// </summary>
        public OperateRecordExport()
        {

        }

        /// <summary>
        /// 实例化一个新的操作记录
        /// </summary>
        /// <param name="model">操作记录的存储指针</param>
        public OperateRecordExport(OperateRecord model)
        {
            this.OwnerId = model.Owner.Id;
            this.Owner = model.Owner.Username;
            this.Operated = model.Operated;
            this.CreatedTime = model.CreatedTime;
        }

        #endregion
    }
}
