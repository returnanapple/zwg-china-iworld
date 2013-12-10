using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.model;

namespace zwg_china.service
{
    /// <summary>
    /// 管理员信息
    /// </summary>
    [DataContract]
    public class BasicAdministratorExport
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
        public string Group { get; set; }

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

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的管理员信息
        /// </summary>
        public BasicAdministratorExport()
        {

        }

        /// <summary>
        /// 实例化一个新的管理员信息
        /// </summary>
        /// <param name="model">管理员信息的数据模型</param>
        public BasicAdministratorExport(Administrator model)
        {
            this.Username = model.Username;
            this.Group = model.Group.Name;
            this.CreateTime = model.CreatedTime;
            this.LastLoginTime = model.LastLoginTime;
            this.LastLoginIp = model.LastLoginIp;
            this.LastLoginAddress = model.LastLoginAddress;
        }

        #endregion
    }
}
