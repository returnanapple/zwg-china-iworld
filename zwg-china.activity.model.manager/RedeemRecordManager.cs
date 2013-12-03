using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model.manager
{
    /// <summary>
    /// 积分兑换的参与记录
    /// </summary>
    [RegisterToManagerService]
    public class RedeemRecordManager : ManagerBase<IModelToDbContextOfActivity, RedeemRecordManager.Actions, RedeemRecord>
    {
        #region 构造方法

        /// <summary>
        /// 实例化一个新的积分兑换的参与记录
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public RedeemRecordManager(IModelToDbContextOfActivity db)
            : base(db)
        {

        }

        #endregion

        #region 静态方法

        /// <summary>
        /// 监听：创建帐变明细
        /// </summary>
        /// <param name="info">数据集</param>
        [Listen(typeof(RedeemRecordManager), RedeemRecordManager.Actions.Create, ExecutionOrder.After)]
        public static void Monitor_CreateMoneyChangeRecord(InfoOfSendOnManagerService info)
        {
            IModelToDbContextOfActivity db = (IModelToDbContextOfActivity)info.Db;
            RedeemRecord model = (RedeemRecord)info.Model;

            MoneyChangeRecordManager.CreateMoneyChangeRecordArgs _args = new MoneyChangeRecordManager.CreateMoneyChangeRecordArgs
            {
                Type = "积分兑换",
                Description = "积分兑换",
                UserId = model.Owner.Id,
                Income = model.SumOfMoney,
                Expenses = 0
            };
            InfoOfCallOnManagerService _info = new InfoOfCallOnManagerService(db, typeof(MoneyChangeRecordManager), MoneyChangeRecordManager.Services.CreateMoneyChangeRecord, _args);
            ManagerService.Call(_info);
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
