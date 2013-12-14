using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.model;
using zwg_china.model.manager;

namespace zwg_china.service.client
{
    /// <summary>
    /// 用于获取系统设置的数据集
    /// </summary>
    [DataContract]
    public class GetSettingImport : ImportBaseOfAuthor
    {
        #region 方法

        /// <summary>
        /// 获取系统设置
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        /// <returns>返回系统设置</returns>
        public NormalResult<SettingExport> GetSetting(IModelToDbContextOfAuthor db)
        {
            SettingOfBase settingOfBase = new SettingOfBase(db);
            SettingOfAuthor settingOfAuthor = new SettingOfAuthor(db);
            SettingOfLottery settingOfLottery = new SettingOfLottery(db);

            var s = new SettingExport(settingOfBase, settingOfAuthor, settingOfLottery);
            return new NormalResult<SettingExport>(s);
        }

        #endregion
    }
}
