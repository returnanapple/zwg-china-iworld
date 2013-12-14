using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.model;

namespace zwg_china.service.backstage
{
    /// <summary>
    /// 管理员用户组信息
    /// </summary>
    [DataContract]
    public class AdministratorGroupExport
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

        /// <summary>
        /// 一个布尔值，表示是否允许查看前台用户列表
        /// </summary>
        [DataMember]
        public bool CanViewUsers { get; set; }

        /// <summary>
        /// 一个布尔值，表示是否允许修改前台用户信息
        /// </summary>
        [DataMember]
        public bool CanEditUsers { get; set; }

        /// <summary>
        /// 一个布尔值，表示是否允许查看彩票信息
        /// </summary>
        [DataMember]
        public bool CanViewTickets { get; set; }

        /// <summary>
        /// 一个布尔值，表示是否允许修改彩票信息
        /// </summary>
        [DataMember]
        public bool CanEditTickets { get; set; }

        /// <summary>
        /// 一个布尔值，表示是否允许查看活动信息
        /// </summary>
        [DataMember]
        public bool CanViewActivities { get; set; }

        /// <summary>
        /// 一个布尔值，表示是否允许修改活动信息
        /// </summary>
        [DataMember]
        public bool CanEditActivities { get; set; }

        /// <summary>
        /// 一个布尔值，表示是否允许查看系统设置
        /// </summary>
        [DataMember]
        public bool CanViewSettings { get; set; }

        /// <summary>
        /// 一个布尔值，表示是否允许修改系统设置
        /// </summary>
        [DataMember]
        public bool CanEditSettings { get; set; }

        /// <summary>
        /// 一个布尔值，表示是否允许查看数据报表
        /// </summary>
        [DataMember]
        public bool CanViewDataReports { get; set; }

        /// <summary>
        /// 一个布尔值，表示是否允许对相关数据报表进行操作
        /// </summary>
        [DataMember]
        public bool CanEditDataReports { get; set; }

        /// <summary>
        /// 一个布尔值，表示是否允许查看管理员信息
        /// </summary>
        [DataMember]
        public bool CanViewAdministrator { get; set; }

        /// <summary>
        /// 一个布尔值，表示是否允许修改管理员信息
        /// </summary>
        [DataMember]
        public bool CanEditAdministrator { get; set; }

        /// <summary>
        /// 一个布尔值，表示是否客服人员组
        /// </summary>
        [DataMember]
        public bool IsCustomerService { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的管理员用户组信息
        /// </summary>
        public AdministratorGroupExport()
        {

        }

        /// <summary>
        /// 实例化一个新的管理员用户组信息
        /// </summary>
        /// <param name="model">管理员用户组信息的数据模型</param>
        public AdministratorGroupExport(AdministratorGroup model)
        {
            this.Id = model.Id;
            this.Name = model.Name;
            this.CanViewUsers = model.CanViewUsers;
            this.CanEditUsers = model.CanEditUsers;
            this.CanViewTickets = model.CanViewTickets;
            this.CanEditTickets = model.CanEditTickets;
            this.CanViewActivities = model.CanViewActivities;
            this.CanEditActivities = model.CanEditActivities;
            this.CanViewSettings = model.CanViewSettings;
            this.CanEditSettings = model.CanEditSettings;
            this.CanViewDataReports = model.CanViewDataReports;
            this.CanEditDataReports = model.CanEditDataReports;
            this.CanViewAdministrator = model.CanViewAdministrator;
            this.CanEditAdministrator = model.CanEditAdministrator;
            this.IsCustomerService = model.IsCustomerService;
        }

        #endregion
    }
}
