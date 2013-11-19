using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 管理员用户组
    /// </summary>
    public class AdministratorGroup : ModelBase
    {
        #region 公开属性

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 允许查看前台用户列表
        /// </summary>
        public bool CanViewUsers { get; set; }

        /// <summary>
        /// 允许修改前台用户信息
        /// </summary>
        public bool CanEditUsers { get; set; }

        /// <summary>
        /// 允许查看彩票信息
        /// </summary>
        public bool CanViewTickets { get; set; }

        /// <summary>
        /// 允许修改彩票信息
        /// </summary>
        public bool CanEditTickets { get; set; }

        /// <summary>
        /// 允许查看活动信息
        /// </summary>
        public bool CanViewActivities { get; set; }

        /// <summary>
        /// 允许修改活动信息
        /// </summary>
        public bool CanEditActivities { get; set; }

        /// <summary>
        /// 允许查看系统设置
        /// </summary>
        public bool CanViewSettings { get; set; }

        /// <summary>
        /// 允修改系统设置
        /// </summary>
        public bool CanEditSettings { get; set; }

        /// <summary>
        /// 允许查看数据报表
        /// </summary>
        public bool CanViewDataReports { get; set; }

        /// <summary>
        /// 允许对相关数据报表进行操作
        /// </summary>
        public bool CanEditDataReports { get; set; }

        /// <summary>
        /// 允许查看管理员信息
        /// </summary>
        public bool CanViewAdministrator { get; set; }

        /// <summary>
        /// 允许修改管理员信息
        /// </summary>
        public bool CanEditAdministrator { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的管理员用户组
        /// </summary>
        public AdministratorGroup()
        {
        }

        /// <summary>
        /// 实例化一个新的管理员用户组
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="canViewUsers">允许查看前台用户列表</param>
        /// <param name="canEditUsers">允许修改前台用户信息</param>
        /// <param name="canViewTickets">允许查看彩票信息</param>
        /// <param name="canEditTickets">允许修改彩票信息</param>
        /// <param name="canViewActivities">允许查看活动信息</param>
        /// <param name="canEditActivities">允许修改活动信息</param>
        /// <param name="canViewSettings">允许查看系统设置</param>
        /// <param name="canEditSettings">允修改系统设置</param>
        /// <param name="canViewDataReports">允许查看数据报表</param>
        /// <param name="canEditDataReports">允许对相关数据报表进行操作</param>
        /// <param name="canViewAdministrator">允许查看管理员信息</param>
        /// <param name="canEditAdministrator">允许修改管理员信息</param>
        public AdministratorGroup(string name, bool canViewUsers, bool canEditUsers, bool canViewTickets, bool canEditTickets, bool canViewActivities, bool canEditActivities
            , bool canViewSettings, bool canEditSettings, bool canViewDataReports, bool canEditDataReports, bool canViewAdministrator, bool canEditAdministrator)
        {
            this.Name = name;
            this.CanViewUsers = canViewUsers;
            this.CanEditUsers = canEditUsers;
            this.CanViewTickets = canViewTickets;
            this.CanEditTickets = canEditTickets;
            this.CanViewActivities = canViewActivities;
            this.CanEditActivities = canEditActivities;
            this.CanViewSettings = canViewSettings;
            this.CanEditSettings = canEditSettings;
            this.CanViewDataReports = canViewDataReports;
            this.CanEditDataReports = canEditDataReports;
            this.CanViewAdministrator = canViewAdministrator;
            this.CanEditAdministrator = canEditAdministrator;
        }

        #endregion
    }
}
