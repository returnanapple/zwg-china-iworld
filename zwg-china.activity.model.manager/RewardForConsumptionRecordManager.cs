using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model.manager
{
    /// <summary>
    /// 消费奖励的参与记录的管理者对象
    /// </summary>
    [RegisterToManagerService]
    public class RewardForConsumptionRecordManager : ManagerBase<IModelToDbContextOfActivity, RewardForConsumptionRecordManager.Actions, RewardForConsumptionRecord>
    {
        #region 构造方法

        /// <summary>
        /// 实例化一个新的消费奖励的参与记录的管理者对象
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public RewardForConsumptionRecordManager(IModelToDbContextOfActivity db)
            : base(db)
        {

        }

        #endregion

        #region 静态方法

        /// <summary>
        /// 监听：创建帐变明细
        /// </summary>
        /// <param name="info">数据集</param>
        [Listen(typeof(RewardForConsumptionRecordManager), RewardForConsumptionRecordManager.Actions.Create, ExecutionOrder.After)]
        public static void Monitor_CreateMoneyChangeRecord(InfoOfSendOnManagerService info)
        {
            IModelToDbContextOfActivity db = (IModelToDbContextOfActivity)info.Db;
            RewardForConsumptionRecord model = (RewardForConsumptionRecord)info.Model;

            if (model.PrizeType == PrizesOfActivityType.人民币)
            {
                MoneyChangeRecordManager.CreateMoneyChangeRecordArgs _args = new MoneyChangeRecordManager.CreateMoneyChangeRecordArgs
                {
                    Type = "消费奖励",
                    Description = "消费奖励",
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
        [Listen(typeof(BettingManager), BettingManager.Actions.ClosureSingle, ExecutionOrder.After)]
        public static void Monitor_CreateRecordWhenBetClose(InfoOfSendOnManagerService info)
        {
            IModelToDbContextOfActivity db = (IModelToDbContextOfActivity)info.Db;
            Betting model = (Betting)info.Model;
            DateTime now = DateTime.Now;
            RewardForConsumptionRecordManager manager = new RewardForConsumptionRecordManager(db);

            db.RewardForConsumptionPlans.Where(x => x.BeginTime < now
                && x.EndTime > now
                && !x.Hide
                && x.Details.Any(d => d.LowerConsumption <= model.Pay && d.CapsConsumption >= model.Pay))
                .ToList()
                .ForEach(plan =>
                {
                    RewardForConsumptionSnapshot snapshot = db.RewardForConsumptionSnapshots.FirstOrDefault(x => x.Code == plan.Code);
                    if (snapshot == null)
                    {
                        snapshot = new RewardForConsumptionSnapshot(plan);
                    }
                    RewardForConsumptionRecord record = new RewardForConsumptionRecord(model.Owner, snapshot, model.Pay);
                    manager.OnExecuting(Actions.Create, record);
                    db.RewardForConsumptionRecords.Add(record);
                    manager.OnExecuted(Actions.Create, record);
                });
        }

        /// <summary>
        /// 监听：创建参与记录
        /// </summary>
        /// <param name="info">数据集</param>
        [Listen(typeof(BettingWithChasingManager), BettingWithChasingManager.Actions.ClosureSingle, ExecutionOrder.After)]
        public static void Monitor_CreateRecordWhenBetWithChasingClose(InfoOfSendOnManagerService info)
        {
            IModelToDbContextOfActivity db = (IModelToDbContextOfActivity)info.Db;
            BettingWithChasing model = (BettingWithChasing)info.Model;
            DateTime now = DateTime.Now;
            RewardForConsumptionRecordManager manager = new RewardForConsumptionRecordManager(db);

            db.RewardForConsumptionPlans.Where(x => x.BeginTime < now
                && x.EndTime > now
                && !x.Hide
                && x.Details.Any(d => d.LowerConsumption <= model.Pay && d.CapsConsumption >= model.Pay))
                .ToList()
                .ForEach(plan =>
                {
                    RewardForConsumptionSnapshot snapshot = db.RewardForConsumptionSnapshots.FirstOrDefault(x => x.Code == plan.Code);
                    if (snapshot == null)
                    {
                        snapshot = new RewardForConsumptionSnapshot(plan);
                    }
                    RewardForConsumptionRecord record = new RewardForConsumptionRecord(model.Chasing.Owner, snapshot, model.Pay);
                    manager.OnExecuting(Actions.Create, record);
                    db.RewardForConsumptionRecords.Add(record);
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
