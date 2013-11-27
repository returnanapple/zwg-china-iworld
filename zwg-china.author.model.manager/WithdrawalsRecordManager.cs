using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model.manager
{
    /// <summary>
    /// 提现记录的管理者对象
    /// </summary>
    public class WithdrawalsRecordManager : ManagerBase<IModelToDbContextOfAuthor, WithdrawalsRecordManager.Actions, WithdrawalsRecord>
    {
        #region 构造方法

        /// <summary>
        /// 实例化一个新的提现记录的管理者对象
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public WithdrawalsRecordManager(IModelToDbContextOfAuthor db)
            : base(db)
        {

        }

        #endregion

        #region 方法

        /// <summary>
        /// 改变提现状态
        /// </summary>
        /// <param name="package">数据集</param>
        public void ChangeStatus(IPackageForChangeStatus package)
        {
            if (package.NewStatus == WithdrawalsStatus.处理中)
            {
                throw new Exception("不允许将提现记录的状态修改为“处理中”，操作无效");
            }
            WithdrawalsRecord record = db.WithdrawalsRecords.Find(package.WithdrawalsId);
            if (record.Status != WithdrawalsStatus.处理中)
            {
                throw new Exception("已经处理过的提现记录不允许重复操作，操作无效");
            }

            ChangeStatusArgs args = new ChangeStatusArgs
            {
                OldStatus = record.Status,
                NewStatus = package.NewStatus
            };
            OnExecuting<ChangeStatusArgs>(Actions.ChangeStatus, record, args);
            record.Status = package.NewStatus;
            OnExecuted<ChangeStatusArgs>(Actions.ChangeStatus, record, args);
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
            /// 创建新的提现记录
            /// </summary>
            Create,
            /// <summary>
            /// 修改提现记录
            /// </summary>
            Update,
            /// <summary>
            /// 移除提现记录
            /// </summary>
            Remove,
            /// <summary>
            /// 改变提现状态
            /// </summary>
            ChangeStatus
        }

        #endregion

        #region 接口

        /// <summary>
        /// 定义用户修改提现状态的数据集
        /// </summary>
        public interface IPackageForChangeStatus
        {
            /// <summary>
            /// 所要修改的提现记录的存储指针
            /// </summary>
            int WithdrawalsId { get; }

            /// <summary>
            /// 新状态
            /// </summary>
            WithdrawalsStatus NewStatus { get; }
        }

        #endregion

        #region 类型

        /// <summary>
        /// 修改提现状态的方法提供的相关数据
        /// </summary>
        public class ChangeStatusArgs
        {
            /// <summary>
            /// 原状态
            /// </summary>
            public WithdrawalsStatus OldStatus { get; set; }

            /// <summary>
            /// 新状态
            /// </summary>
            public WithdrawalsStatus NewStatus { get; set; }
        }

        #endregion

        #endregion
    }
}
