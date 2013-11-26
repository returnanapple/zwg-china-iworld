using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model.manager
{
    /// <summary>
    /// 充值记录的管理者对象
    /// </summary>
    public class RechargeRecordManager : ManagerBase<IModelToDbContextOfAuthor, RechargeRecordManager.Actions, RechargeRecord>
    {
        #region 构造方法

        /// <summary>
        /// 实例化一个新的转账记录的管理者对象
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public RechargeRecordManager(IModelToDbContextOfAuthor db)
            : base(db)
        {

        }

        #endregion

        #region 方法

        /// <summary>
        /// 改变充值状态
        /// </summary>
        /// <param name="package"></param>
        public void ChangeStatus(IPackageForChangeStatus package)
        {
            if (package.NewStatus == RechargeStatus.等待银行确认)
            {
                throw new Exception("不允许将充值状态修改为“等待银行确认”，操作无效");
            }
            RechargeRecord record = db.RechargeRecords.Find(package.RechargeRecordId);
            if (record.Status != RechargeStatus.等待银行确认)
            {
                throw new Exception("已经操作的充值记录不允许再次修改，操作无效");
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
            /// 创建新用户
            /// </summary>
            Create,
            /// <summary>
            /// 修改用户信息
            /// </summary>
            Update,
            /// <summary>
            /// 移除用户
            /// </summary>
            Remove,
            /// <summary>
            /// 改变充值状态
            /// </summary>
            ChangeStatus
        }

        #endregion

        #region 接口

        /// <summary>
        /// 定义用于修改充值状态的数据集
        /// </summary>
        public interface IPackageForChangeStatus
        {
            /// <summary>
            /// 充值记录的存储指针
            /// </summary>
            public int RechargeRecordId { get; }

            /// <summary>
            /// 新状态
            /// </summary>
            public RechargeStatus NewStatus { get; }
        }

        #endregion

        #region 类型

        /// <summary>
        /// 改变充值记录方法提供的相关数据
        /// </summary>
        public class ChangeStatusArgs
        {
            /// <summary>
            /// 原状态
            /// </summary>
            public RechargeStatus OldStatus { get; set; }

            /// <summary>
            /// 新状态
            /// </summary>
            public RechargeStatus NewStatus { get; set; }
        }

        #endregion

        #endregion
    }
}
