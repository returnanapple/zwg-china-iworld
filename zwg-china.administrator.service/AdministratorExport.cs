using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using zwg_china.model;

namespace zwg_china.service.backstage
{
    /// <summary>
    /// 管理员信息
    /// </summary>
    [DataContract]
    public class AdministratorExport
    {
        #region 属性

        /// <summary>
        /// 用户名
        /// </summary>
        [DataMember]
        public string Username { get; set; }

        /// <summary>
        /// 用户组
        /// </summary>
        [DataMember]
        public virtual AdministratorGroupExport Group { get; set; }

        /// <summary>
        /// 注册时间
        /// </summary>
        [DataMember]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 上次登录时间
        /// </summary>
        [DataMember]
        public DateTime LastLoginTime { get; set; }

        /// <summary>
        /// 上次登录的网络地址
        /// </summary>
        [DataMember]
        public string LastLoginIp { get; set; }

        /// <summary>
        /// 上次登录的实际地址
        /// </summary>
        [DataMember]
        public string LastLoginAddress { get; set; }

        /// <summary>
        /// 身份标识
        /// </summary>
        [DataMember]
        public string Token { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的管理员信息
        /// </summary>
        public AdministratorExport()
        {

        }

        /// <summary>
        /// 实例化一个新的管理员信息
        /// </summary>
        /// <param name="model">管理员信息的数据模型</param>
        public AdministratorExport(Administrator model, string token)
        {
            this.Username = model.Username;
            this.Group = new AdministratorGroupExport(model.Group);
            this.CreateTime = model.CreatedTime;
            this.LastLoginTime = model.LastLoginTime;
            this.LastLoginIp = model.LastLoginIp;
            this.LastLoginAddress = model.LastLoginAddress;
            this.Token = token;
        }

        #endregion
    }
}
