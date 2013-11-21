using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 定义管理员模块的数据库连接对象
    /// </summary>
    public interface IModelToDbContextOfAdministrtor
    {
        /// <summary>
        /// 管理员的数据存储器
        /// </summary>
        DbSet<Administrator> Administrators { get; set; }

        /// <summary>
        /// 管理员用户组的数据存储器
        /// </summary>
        DbSet<AdministratorGroup> AdministratorGroups { get; set; }

        /// <summary>
        /// 管理员登陆记录的数据存储器
        /// </summary>
        DbSet<AdministratorLandingRecord> AdministratorLandingRecords { get; set; }

        /// <summary>
        /// 操作记录的数据存储器
        /// </summary>
        DbSet<OperateRecord> OperateRecords { get; set; }
    }
}
