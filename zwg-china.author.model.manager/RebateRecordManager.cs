using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model.manager
{
    /// <summary>
    /// 返点记录的管理者对象
    /// </summary>
    [RegisterToManagerService]
    public class RebateRecordManager : ManagerBase<IModelToDbContextOfAuthor, RebateRecordManager.Actions, RebateRecord>
    {
        #region 构造方法

        /// <summary>
        /// 实例化一个新的返点记录的管理者对象
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public RebateRecordManager(IModelToDbContextOfAuthor db)
            : base(db)
        {

        }

        #endregion

        #region 静态方法

        #region 服务

        /// <summary>
        /// 服务：创建新的返点记录
        /// </summary>
        /// <param name="info">数据集</param>
        [OnCall(typeof(RebateRecordManager), RebateRecordManager.Services.CreateRebateRecord)]
        public static void Serivce_CreateRebateRecord(InfoOfCallOnManagerService info)
        {
            IModelToDbContextOfAuthor db = (IModelToDbContextOfAuthor)info.Db;
            CreateRebateRecordArgs args = (CreateRebateRecordArgs)info.Args;

            RebateRecordManager manager = new RebateRecordManager(db);
            RebateRecord record = new RebateRecord(args.Owner, args.Source, args.IsImmediate, args.GameName, args.Sum);
            manager.OnExecuting(Actions.Create, record);
            db.RebateRecords.Add(record);
            manager.OnExecuted(Actions.Create, record);
        }

        #endregion

        #endregion

        #region 内嵌元素

        #region 枚举

        /// <summary>
        /// 动作
        /// </summary>
        public enum Actions
        {
            /// <summary>
            /// 创建新的返点记录
            /// </summary>
            Create,
            /// <summary>
            /// 修改返点记录
            /// </summary>
            Update,
            /// <summary>
            /// 移除返点记录
            /// </summary>
            Remove
        }

        /// <summary>
        /// 服务
        /// </summary>
        public enum Services
        {
            /// <summary>
            /// 创建一个新的返点记录
            /// </summary>
            CreateRebateRecord
        }

        #endregion

        #region 类

        /// <summary>
        /// 用于给创建返点记录的服务提供数据的数据集
        /// </summary>
        public class CreateRebateRecordArgs
        {

            /// <summary>
            /// 用户
            /// </summary>
            public virtual Author Owner { get; set; }

            /// <summary>
            /// 来源
            /// </summary>
            public virtual Author Source { get; set; }

            /// <summary>
            /// 一个布尔值，表示该返点记录是否由直属下级触发
            /// </summary>
            public bool IsImmediate { get; set; }

            /// <summary>
            /// 游戏
            /// </summary>
            public string GameName { get; set; }

            /// <summary>
            /// 返点金额
            /// </summary>
            public double Sum { get; set; }
        }

        #endregion

        #endregion
    }
}
