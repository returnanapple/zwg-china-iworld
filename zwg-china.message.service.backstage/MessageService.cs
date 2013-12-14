using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zwg_china.model.manager;

namespace zwg_china.service.backstage
{
    /// <summary>
    /// 交互信息的数据服务
    /// </summary>
    public class MessageService : ServiceBase, IMessageService
    {
        #region 获取数据

        /// <summary>
        /// 获取公告信息的分页列表
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回公告信息的分页列表</returns>
        public PageResult<BulletinExport> GetBulletins(GetBulletinsImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                return import.GetBulletins(db);
            }
            catch (Exception ex)
            {
                return new PageResult<BulletinExport>(ex.Message);
            }
        }

        #endregion

        #region 操作

        /// <summary>
        /// 创建公告信息
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        public NormalResult CreateBullein(CreateBulleinImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                new BulletinManager(db).Create(import);
                return new NormalResult();
            }
            catch (Exception ex)
            {
                return new NormalResult(ex.Message);
            }
        }

        /// <summary>
        /// 修改公告信息
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        public NormalResult EditBullein(EditBulleinImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                new BulletinManager(db).Update(import);
                return new NormalResult();
            }
            catch (Exception ex)
            {
                return new NormalResult(ex.Message);
            }
        }

        /// <summary>
        /// 删除公告信息
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        public NormalResult RemoveBullein(RemoveBulleinImport import)
        {
            try
            {
                import.CheckAllowExecuteOrNot(db);
                new BulletinManager(db).Remove(import);
                return new NormalResult();
            }
            catch (Exception ex)
            {
                return new NormalResult(ex.Message);
            }
        }

        #endregion
    }
}
