using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.model;

namespace zwg_china.service.backstage
{
    /// <summary>
    /// 基础的用户组信息
    /// </summary>
    [DataContract]
    public class BasicUserGroupExport
    {
        #region 属性

        /// <summary>
        /// 存储指针
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        #endregion

        #region 属性

        /// <summary>
        /// 实例化一个新的基础的用户组信息
        /// </summary>
        public BasicUserGroupExport()
        {

        }

        /// <summary>
        /// 实例化一个新的基础的用户组信息
        /// </summary>
        /// <param name="model">用户组信息的数据模型</param>
        public BasicUserGroupExport(UserGroup model)
        {
            this.Id = model.Id;
            this.Name = model.Name;
        }

        #endregion
    }
}
