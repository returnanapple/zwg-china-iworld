using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.aid;
using zwg_china.model;
using zwg_china.model.manager;

namespace zwg_china.service.backstage
{
    /// <summary>
    /// 用于获取基础的用户组信息的数据集
    /// </summary>
    [DataContract]
    public class GetBasicUserGroupsImport : ImportBaseOfAuthor
    {
        #region 方法

        /// <summary>
        /// 获取基础的用户组信息
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        /// <returns>返回基础的用户组信息</returns>
        public NormalResult<List<BasicUserGroupExport>> GetBasicUserGroups(IModelToDbContextOfAuthor db)
        {
            List<BasicUserGroupExport> tList = db.UserGroups.ToList().ConvertAll(x => new BasicUserGroupExport(x));
            return new NormalResult<List<BasicUserGroupExport>>(tList);
        }

        #endregion
    }
}
