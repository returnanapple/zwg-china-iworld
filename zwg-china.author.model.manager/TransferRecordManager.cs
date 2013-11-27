using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model.manager
{
    /// <summary>
    /// 转账记录的管理者对象
    /// </summary>
    [RegisterToManagerService]
    public class TransferRecordManager : ManagerBase<IModelToDbContextOfAuthor, TransferRecordManager.Actions, TransferRecord>
    {
        #region 构造方法

        /// <summary>
        /// 实例化一个新的转账记录的管理者对象
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public TransferRecordManager(IModelToDbContextOfAuthor db)
            : base(db)
        {

        }

        #endregion

        #region 静态方法

        #region 监听

        /// <summary>
        /// 监听：使用充值记录
        /// </summary>
        /// <param name="info">数据集</param>
        [Listen(typeof(RechargeRecordManager), RechargeRecordManager.Actions.ChangeStatus, ExecutionOrder.After)]
        public static void Monitor_Use(InfoOfSendOnManagerService info)
        {
            IModelToDbContextOfAuthor db = (IModelToDbContextOfAuthor)info.Db;
            RechargeRecord model = (RechargeRecord)info.Model;

            if (model.Status == RechargeStatus.充值成功)
            {
                TransferRecord record = db.TransferRecords.FirstOrDefault(x => x.ComeFrom == model.ComeFrom
                    && x.SerialNumber == model.SerialNumber
                    && x.Postscript == model.Postscript
                    && x.Status == TransferStatus.用户已经支付);
                if (record == null)
                {
                    string error = string.Format("致命错误：试图声明为“充值成功”的编号为{0}的充值记录没有对应的转账记录"
                        , model.Id);
                }
                record.Status = TransferStatus.充值成功;
            }
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
            /// 创建新的转账记录
            /// </summary>
            Create,
            /// <summary>
            /// 修改转账记录
            /// </summary>
            Update,
            /// <summary>
            /// 移除转账记录
            /// </summary>
            Remove
        }

        #endregion

        #endregion
    }
}
