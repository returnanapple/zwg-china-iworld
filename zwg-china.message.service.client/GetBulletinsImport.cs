using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.aid;
using zwg_china.logic;
using zwg_china.model;
using zwg_china.model.manager;

namespace zwg_china.service
{
    /// <summary>
    /// 用于获取公告列表的数据集
    /// </summary>
    [DataContract]
    public class GetBulletinsImport : GetPageListImportBaseOfMessage
    {
        #region 方法

        /// <summary>
        /// 获取公告列表
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        /// <returns>返回公告列表</returns>
        public NormalResult<List<BulletinExport>> GetBulletins(IModelToDbContextOfMessage db)
        {
            List<BulletinExport> tList = db.Bulletins.Where(x => x.BeginTime < DateTime.Now
                && x.EndTime > DateTime.Now
                && x.Hide == false)
                .ToList()
                .ConvertAll(x => new BulletinExport(x));
            return new NormalResult<List<BulletinExport>>(tList);
        }

        #endregion
    }
}
