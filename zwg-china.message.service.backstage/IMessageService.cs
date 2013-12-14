using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace zwg_china.service.backstage
{
    /// <summary>
    /// 定义交互信息的数据服务
    /// </summary>
    [ServiceContract]
    public interface IMessageService
    {
        #region 获取数据

        /// <summary>
        /// 获取公告信息的分页列表
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回公告信息的分页列表</returns>
        [OperationContract]
        PageResult<BulletinExport> GetBulletins(GetBulletinsImport import);

        #endregion

        #region 操作

        /// <summary>
        /// 创建公告信息
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        [OperationContract]
        NormalResult CreateBullein(CreateBulleinImport import);

        /// <summary>
        /// 修改公告信息
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        [OperationContract]
        NormalResult EditBullein(EditBulleinImport import);

        /// <summary>
        /// 删除公告信息
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        [OperationContract]
        NormalResult RemoveBullein(RemoveBulleinImport import);

        #endregion
    }
}
