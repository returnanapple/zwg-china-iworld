using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.model;

namespace zwg_china.service.backstage
{
    /// <summary>
    /// 用于获取系统设定的高点号配额方案的参数集
    /// </summary>
    [DataContract]
    public class GetSystemQuotaImport : GetSettingImport
    {
        #region 方法

        /// <summary>
        /// 获取系统设定的高点号配额方案
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        /// <returns>返回系统设定的高点号配额方案</returns>
        public NormalResult<List<SystemQuotaExport>> GetSystemQuota(IModelToDbContextOfAuthor db)
        {
            var tlist = db.SystemQuotas.ToList().ConvertAll(x => new SystemQuotaExport(x));
            return new NormalResult<List<SystemQuotaExport>>(tlist);
        }

        #endregion
    }
}
