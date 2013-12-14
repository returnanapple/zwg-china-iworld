using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.service.backstage
{
    /// <summary>
    /// 统计报表的数据服务
    /// </summary>
    public class ReportService : ServiceBase, IReportService
    {
        #region 获取数据

        /// <summary>
        /// 获取站点报表
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回站点报表</returns>
        public PageResult<SiteReportExpot> GetSiteReports(GetSiteReportsImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                return import.GetSiteReports(db);
            }
            catch (Exception ex)
            {
                return new PageResult<SiteReportExpot>(ex.Message);
            }
        }

        /// <summary>
        /// 获取私人/团队报表
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回私人/团队报表</returns>
        public PageResult<RersonalAndTeamReportExport> GetRersonalAndTeamReports(GetRersonalAndTeamReportsImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                return import.GetRersonalAndTeamReports(db);
            }
            catch (Exception ex)
            {
                return new PageResult<RersonalAndTeamReportExport>(ex.Message);
            }
        }

        #endregion
    }
}
