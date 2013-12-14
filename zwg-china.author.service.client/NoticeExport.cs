using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.model;

namespace zwg_china.service.client
{
    /// <summary>
    /// 通知信息
    /// </summary>
    [DataContract]
    public class NoticeExport
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
        /// 正文
        /// </summary>
        [DataMember]
        public string Context { get; set; }

        /// <summary>
        /// 来源对象的类型
        /// </summary>
        [DataMember]
        public string SourceType { get; set; }

        /// <summary>
        /// 目标对象的存储指针
        /// </summary>
        [DataMember]
        public int SourceId { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的通知信息
        /// </summary>
        /// <param name="model">通知信息的数据模型</param>
        public NoticeExport(Notice model)
        {
            this.Id = model.Id;
            this.OwnerId = model.Owner.Id;
            this.Context = model.Context;
            this.SourceType = model.SourceType;
            this.SourceId = model.SourceId;
        }

        #endregion
    }
}
