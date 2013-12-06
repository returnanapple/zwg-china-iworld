using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.model;

namespace zwg_china.service
{
    /// <summary>
    /// 用户登陆记录
    /// </summary>
    [DataContract]
    public class AuthorLandingRecordExport
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
        /// 网络地址
        /// </summary>
        [DataMember]
        public string Ip { get; set; }

        /// <summary>
        /// 实际地址
        /// </summary>
        [DataMember]
        public string Address { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的用户登陆记录
        /// </summary>
        public AuthorLandingRecordExport()
        {

        }

        /// <summary>
        /// 实例化一个新的用户登陆记录
        /// </summary>
        /// <param name="model">用户登陆记录的数据模型</param>
        public AuthorLandingRecordExport(AuthorLandingRecord model)
        {
            this.Id = model.Id;
            this.OwnerId = model.Owner.Id;
            this.Owner = model.Owner.Username;
            this.Ip = model.Ip;
            this.Address = model.Address;
        }

        #endregion
    }
}
