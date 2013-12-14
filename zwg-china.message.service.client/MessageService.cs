using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.service
{
    /// <summary>
    /// 交互信息的数据服务
    /// </summary>
    public class MessageService : ServiceBase, IMessageService
    {
        #region 获取数据

        /// <summary>
        /// 获取公告列表
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回公告列表</returns>
        public NormalResult<List<BulletinExport>> GetBulletins(GetBulletinsImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                return import.GetBulletins(db);
            }
            catch (Exception ex)
            {
                return new NormalResult<List<BulletinExport>>(null, ex.Message);
            }
        }

        #endregion
    }
}
