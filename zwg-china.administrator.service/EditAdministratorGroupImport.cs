using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.aid;
using zwg_china.logic;
using zwg_china.model;
using zwg_china.model.manager;

namespace zwg_china.service
{
    /// <summary>
    /// 用于修改管理员组的数据集
    /// </summary>
    [DataContract]
    public class EditAdministratorGroupImport : ImportBaseOfAdministrator, IPackageForUpdateModel<IModelToDbContextOfAdministrator, AdministratorGroup>
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
        /// 一个布尔值，表示是否客服人员组
        /// </summary>
        [DataMember]
        public bool IsCustomerService { get; set; }

        #endregion

        #region 方法

        /// <summary>
        /// 检查输入的数据是否合法
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public void CheckData(IModelToDbContextOfAdministrator db)
        {
            bool hadUsedName = db.AdministratorGroups.Any(x => x.Name == this.Name && x.Id != this.Id);
            if (hadUsedName)
            {
                string error = string.Format("名称 {0} 已经被使用", this.Name);
                throw new Exception(error);
            }
        }

        /// <summary>
        /// 修改数据模型
        /// </summary>
        /// <param name="model">所要修改的数据模型</param>
        public void Update(AdministratorGroup model)
        {
            model.Name = this.Name;
            model.CanViewUsers = this.CanViewUsers;
            model.CanEditUsers = this.CanEditUsers;
            model.CanViewTickets = this.CanViewTickets;
            model.CanEditTickets = this.CanEditTickets;
            model.CanViewActivities = this.CanViewActivities;
            model.CanEditActivities = this.CanEditActivities;
            model.CanViewSettings = this.CanViewSettings;
            model.CanEditSettings = this.CanEditSettings;
            model.CanViewDataReports = this.CanViewDataReports;
            model.CanEditDataReports = this.CanEditDataReports;
            model.IsCustomerService = this.IsCustomerService;
        }

        #endregion
    }
}
