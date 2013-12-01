using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 定义报表模块的数据库连接对象
    /// </summary>
    public interface IModelToDbContextOfReport : IModelToDbContextOfAuthor
    {
        /// <summary>
        /// 单日站点统计的数据库存储区
        /// </summary>
        DbSet<SiteReportForOneDay> SiteReportForOneDays { get; set; }

        /// <summary>
        /// 单月站点统计的数据库存储区
        /// </summary>
        DbSet<SiteReportForOneMonth> SiteReportForOneMonths { get; set; }

        /// <summary>
        /// 单日个人统计的数据库存储区
        /// </summary>
        DbSet<RersonalReportForOneDay> RersonalReportForOneDays { get; set; }

        /// <summary>
        /// 单月个人统计的数据库存储区
        /// </summary>
        DbSet<RersonalReportForOneMonth> RersonalReportForOneMonths { get; set; }

        /// <summary>
        /// 单日团队统计的数据库存储区
        /// </summary>
        DbSet<TeamReportForOneDay> TeamReportForOneDays { get; set; }

        /// <summary>
        /// 单月团队统计的数据库存储区
        /// </summary>
        DbSet<TeamReportForOneMonth> TeamReportForOneMonths { get; set; }
    }
}
