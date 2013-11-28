using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model.manager
{
    /// <summary>
    /// 管理员的登录记录的管理者对象
    /// </summary>
    [RegisterToManagerService]
    public class AdministratorLandingRecordManager : ManagerBase<IModelToDbContextOfAdministrtor, AdministratorLandingRecordManager.Actions, AdministratorLandingRecord>
    {
        #region 构造方法

        /// <summary>
        /// 实例化一个新的管理员的登录记录的管理者对象
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public AdministratorLandingRecordManager(IModelToDbContextOfAdministrtor db)
            : base(db)
        {

        }

        #endregion

        #region 静态方法

        public static void Monitor_CreateLandingRecord(InfoOfSendOnManagerService info)
        {
            IModelToDbContextOfAdministrtor db = (IModelToDbContextOfAdministrtor)info.Db;
            Administrator model = (Administrator)info.Model;

            AdministratorLandingRecord landingRecord = new AdministratorLandingRecord(model, model.LastLoginIp, model.LastLoginAddress);
            db.AdministratorLandingRecords.Add(landingRecord);
        }

        #endregion

        #region 内嵌元素

        #region 枚举

        /// <summary>
        /// 方法
        /// </summary>
        public enum Actions
        {
            /// <summary>
            /// 创建一个新的实体
            /// </summary>
            Create,
            /// <summary>
            /// 修改实体数据
            /// </summary>
            Update,
            /// <summary>
            /// 移除实体
            /// </summary>
            Remove
        }

        #endregion

        #endregion
    }
}
