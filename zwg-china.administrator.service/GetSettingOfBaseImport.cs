using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.model;
using zwg_china.model.manager;

namespace zwg_china.service.backstage
{
    /// <summary>
    /// 用于获取基础的系统设置的数据集
    /// </summary>
    [DataContract]
    public class GetSettingOfBaseImport : GetSettingImport
    {
        #region 方法

        /// <summary>
        /// 获取基础的系统设置
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        /// <returns>返回基础的系统设置</returns>
        public NormalResult<SettingOfBaseExport> GetSettingOfBase(IModelToDbContextOfAdministrator db)
        {
            var s = new SettingOfBaseExport(new SettingOfBase(db));
            return new NormalResult<SettingOfBaseExport>(s);
        }

        #endregion
    }
}
