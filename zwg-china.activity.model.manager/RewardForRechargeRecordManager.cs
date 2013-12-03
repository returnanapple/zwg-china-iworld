using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model.manager
{
    /// <summary>
    /// 充值奖励的参与记录的管理者对象
    /// </summary>
    [RegisterToManagerService]
    public class RewardForRechargeRecordManager : ManagerBase<IModelToDbContextOfActivity, RewardForRechargeRecordManager.Actions, RewardForRechargeRecord>
    {
        #region 构造方法

        /// <summary>
        /// 实例化一个新的充值奖励的参与记录的管理者对象
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public RewardForRechargeRecordManager(IModelToDbContextOfActivity db)
            : base(db)
        {

        }

        #endregion

        #region 静态方法

        /// <summary>
        /// 监听：创建帐变明细
        /// </summary>
        /// <param name="info">数据集</param>
        [Listen(typeof(RewardForRechargeRecordManager), RewardForRechargeRecordManager.Actions.Create, ExecutionOrder.After)]
        public static void Monitor_CreateMoneyChangeRecord(InfoOfSendOnManagerService info)
        {
            IModelToDbContextOfActivity db = (IModelToDbContextOfActivity)info.Db;
            RewardForRechargeRecord model = (RewardForRechargeRecord)info.Model;

            if (model.PrizeType == PrizesOfActivityType.人民币)
            {
                MoneyChangeRecordManager.CreateMoneyChangeRecordArgs _args = new MoneyChangeRecordManager.CreateMoneyChangeRecordArgs
                {
                    Type = "充值奖励",
                    Description = "充值奖励",
                    UserId = model.Owner.Id,
                    Income = model.Sum,
                    Expenses = 0
                };
                InfoOfCallOnManagerService _info = new InfoOfCallOnManagerService(db, typeof(MoneyChangeRecordManager), MoneyChangeRecordManager.Services.CreateMoneyChangeRecord, _args);
                ManagerService.Call(_info);
            }
            else
            {
                AuthorManager.ChangeIntegralArgs _args = new AuthorManager.ChangeIntegralArgs
                {
                    UserId = model.Owner.Id,
                    Sum = model.Sum
                };
                InfoOfCallOnManagerService _info = new InfoOfCallOnManagerService(db, typeof(AuthorManager), AuthorManager.Services.ChangeIntegral, _args);
                ManagerService.Call(_info);
            }
        }

        /// <summary>
        /// 监听：创建参与记录
        /// </summary>
        /// <param name="info">数据集</param>
        [Listen(typeof(RebateRecordManager), RebateRecordManager.Actions.Create, ExecutionOrder.After)]
        public static void Monitor_CreateRecordWhenBetClose(InfoOfSendOnManagerService info)
        {
            IModelToDbContextOfActivity db = (IModelToDbContextOfActivity)info.Db;
            RebateRecord model = (RebateRecord)info.Model;
            DateTime now = DateTime.Now;
            RewardForRechargeRecordManager manager = new RewardForRechargeRecordManager(db);

            db.RewardForRechargePlans.Where(x => x.BeginTime < now
                && x.EndTime > now
                && !x.Hide
                && x.Details.Any(d => d.LowerConsumption <= model.Sum && d.CapsConsumption >= model.Sum))
                .ToList()
                .ForEach(plan =>
                {
                    RewardForRechargeSnapshot snapshot = db.RewardForRechargeSnapshots.FirstOrDefault(x => x.Code == plan.Code);
                    if (snapshot == null)
                    {
                        snapshot = new RewardForRechargeSnapshot(plan);
                    }
                    RewardForRechargeRecord record = new RewardForRechargeRecord(model.Owner, snapshot, model.Sum);
                    manager.OnExecuting(Actions.Create, record);
                    db.RewardForRechargeRecords.Add(record);
                    manager.OnExecuted(Actions.Create, record);
                });
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
