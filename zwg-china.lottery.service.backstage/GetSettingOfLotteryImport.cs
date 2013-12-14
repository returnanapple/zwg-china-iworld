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
    /// 用于获取彩票模块的系统设置的数据集
    /// </summary>
    [DataContract]
    public class GetSettingOfLotteryImport : GetSettingImport
    {
        #region 方法

        /// <summary>
        /// 获取彩票模块的系统设置
        /// </summary>
        /// <param name="db">数据集</param>
        /// <returns>返回彩票模块的系统设置</returns>
        public NormalResult<SettingOfLotteryExport> GetSettingOfLottery(IModelToDbContextOfLottery db)
        {
            var s = new SettingOfLotteryExport(new SettingOfLottery(db));
            return new NormalResult<SettingOfLotteryExport>(s);
        }

        #endregion
    }
}
