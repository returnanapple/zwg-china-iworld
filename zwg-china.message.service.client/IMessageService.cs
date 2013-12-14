using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace zwg_china.service
{
    /// <summary>
    /// 定义交互信息的数据服务
    /// </summary>
    [ServiceContract]
    public interface IMessageService
    {
        #region 获取数据

        /// <summary>
        /// 获取公告列表
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回公告列表</returns>
        [OperationContract]
        NormalResult<List<BulletinExport>> GetBulletins(GetBulletinsImport import);

        #endregion
    }
}
