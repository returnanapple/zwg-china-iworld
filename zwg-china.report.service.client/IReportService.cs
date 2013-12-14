using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace zwg_china.service
{
    /// <summary>
    /// 定义报表的数据服务
    /// </summary>
    [ServiceContract]
    public interface IReportService
    {
        #region 获取数据

        /// <summary>
        /// 获取私人/团队报表
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回私人/团队报表</returns>
        [OperationContract]
        PageResult<RersonalAndTeamReportExport> GetRersonalAndTeamReports(GetRersonalAndTeamReportsImport import);

        #endregion
    }
}
