using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.model;
using zwg_china.model.manager;

namespace zwg_china.service
{
    /// <summary>
    /// 用于获取用户模块的系统设置的参数集
    /// </summary>
    [DataContract]
    public class GetSettingOfAuthorImport : GetSettingImport
    {
        /// <summary>
        /// 获取用户模块的系统设置
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        /// <returns>返回用户模块的系统设置</returns>
        public NormalResult<SettingOfAuthorExport> GetSettingOfAuthor(IModelToDbContextOfBase db)
        {
            SettingOfAuthor settingOfAuthor = new SettingOfAuthor(db);
            SettingOfAuthorExport info = new SettingOfAuthorExport(settingOfAuthor);
            return new NormalResult<SettingOfAuthorExport>(info);
        }
    }
}
