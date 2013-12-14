using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.model;

namespace zwg_china.service.client
{
    /// <summary>
    /// 公告
    /// </summary>
    [DataContract]
    public class BulletinExport
    {
        #region 属性

        /// <summary>
        /// 存储指针
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        [DataMember]
        public string Title { get; set; }

        /// <summary>
        /// 正文
        /// </summary>
        [DataMember]
        public string Context { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的公告信息
        /// </summary>
        /// <param name="model">公告信息的数据模型</param>
        public BulletinExport(Bulletin model)
        {
            this.Id = model.Id;
            this.Title = model.Title;
            this.Context = model.Context;
        }

        #endregion
    }
}
