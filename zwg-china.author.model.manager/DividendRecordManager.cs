using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model.manager
{
    /// <summary>
    /// 分红记录的管理者对象
    /// </summary>
    public class DividendRecordManager : ManagerBase<IModelToDbContextOfAuthor, DividendRecordManager.Actions, DividendRecord>
    {
        #region 构造方法

        /// <summary>
        /// 实例化一个新的分红记录的管理者对象
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public DividendRecordManager(IModelToDbContextOfAuthor db)
            : base(db)
        {

        }

        #endregion

        #region 方法

        /// <summary>
        /// 修改分红状态
        /// </summary>
        /// <param name="package">数据集</param>
        public void ChangeStatus(IPackageForChangeStatus package)
        {
            if (package.NewStatus == DividendStatus.已申请)
            {
                throw new Exception("不允许将分红状态修改为“已申请”，操作无效");
            }
            DividendRecord record = db.DividendRecords.Find(package.DividendRecordId);
            if (record.Status != DividendStatus.已申请)
            {
                throw new Exception("已经被操作的分红记录不允许再次修改，操作无效");
            }

            ChangeStatusArgs args = new ChangeStatusArgs
            {
                OldStatus = record.Status,
                NewStatus = package.NewStatus
            };
            OnExecuting(Actions.ChangeStatus, record, args);
            record.Status = package.NewStatus;
            record.Remark = package.Remark;
            OnExecuted(Actions.ChangeStatus, record, args);
            db.SaveChanges();
        }

        #endregion

        #region 内嵌元素

        #region 枚举

        /// <summary>
        /// 动作
        /// </summary>
        public enum Actions
        {
            /// <summary>
            /// 创建新的分红记录
            /// </summary>
            Create,
            /// <summary>
            /// 修改分红记录
            /// </summary>
            Update,
            /// <summary>
            /// 移除分红记录
            /// </summary>
            Remove,
            /// <summary>
            /// 修改分红状态
            /// </summary>
            ChangeStatus
        }

        #endregion

        #region 接口

        /// <summary>
        /// 用于修改分红状态的数据集
        /// </summary>
        public interface IPackageForChangeStatus
        {
            /// <summary>
            /// 分红记录的存储指针
            /// </summary>
            int DividendRecordId { get; }

            /// <summary>
            /// 新状态
            /// </summary>
            DividendStatus NewStatus { get; }

            /// <summary>
            /// 备注
            /// </summary>
            string Remark { get; }
        }

        #endregion

        #region 类型

        /// <summary>
        /// 修改分红状态的方法的相关信息
        /// </summary>
        public class ChangeStatusArgs
        {
            /// <summary>
            /// 原状态
            /// </summary>
            public DividendStatus OldStatus { get; set; }

            /// <summary>
            /// 新状态
            /// </summary>
            public DividendStatus NewStatus { get; set; }
        }

        #endregion

        #endregion
    }
}
