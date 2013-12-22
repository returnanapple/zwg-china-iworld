using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.aid;
using zwg_china.logic;
using zwg_china.model;
using zwg_china.model.manager;

namespace zwg_china.service.backstage
{
    /// <summary>
    /// 用于修改管理员的管理员组的数据集
    /// </summary>
    [DataContract]
    public class ChangeGroupImport : ImportBaseOfAdministrator, IPackageForUpdateModel<IModelToDbContextOfAdministrator, Administrator>
    {
        #region 私有字段

        AdministratorGroup group = null;

        #endregion

        #region 属性

        /// <summary>
        /// 存储指针
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// 新管理员组的存储指针
        /// </summary>
        [DataMember]
        public int NewGroupId { get; set; }

        #endregion

        #region 方法

        /// <summary>
        /// 检查输入的数据是否合法
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public void CheckData(IModelToDbContextOfAdministrator db)
        {
            this.group = db.AdministratorGroups.Find(this.NewGroupId);
        }

        /// <summary>
        /// 修改数据模型
        /// </summary>
        /// <param name="model">所要修改的数据模型</param>
        public void Update(Administrator model)
        {
            model.Group = this.group;
        }

        #endregion
    }
}
