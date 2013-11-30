using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model.manager
{
    /// <summary>
    /// 注册奖励的参与记录的管理者对象
    /// </summary>
    public class RewardForRegisterRecordManager : ManagerBase<IModelToDbContextOfActivity, RewardForRegisterRecordManager.Actions, RewardForRegisterRecord>
    {
        #region 构造方法

        /// <summary>
        /// 实例化一个新的注册奖励的参与记录的管理者对象
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public RewardForRegisterRecordManager(IModelToDbContextOfActivity db)
            : base(db)
        {

        }

        #endregion

        #region 静态方法

        /// <summary>
        /// 监听：创建帐变明细
        /// </summary>
        /// <param name="info">数据集</param>
        [Listen(typeof(RewardForRegisterRecordManager), RewardForRegisterRecordManager.Actions.Create, ExecutionOrder.After)]
        public static void Monitor_CreateMoneyChangeRecord(InfoOfSendOnManagerService info)
        {
            IModelToDbContextOfActivity db = (IModelToDbContextOfActivity)info.Db;
            RewardForRegisterRecord model = (RewardForRegisterRecord)info.Model;

            if (model.PrizeType == PrizesOfActivityType.人民币)
            {
                MoneyChangeRecordManager.CreateMoneyChangeRecordArgs _args = new MoneyChangeRecordManager.CreateMoneyChangeRecordArgs
                {
                    Type = "注册奖励",
                    Description = "注册奖励",
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
        [Listen(typeof(AuthorManager), AuthorManager.Actions.Create, ExecutionOrder.After)]
        public static void Monitor_CreateRecord(InfoOfSendOnManagerService info)
        {
            IModelToDbContextOfActivity db = (IModelToDbContextOfActivity)info.Db;
            Author model = (Author)info.Model;
            DateTime now = DateTime.Now;
            RewardForRegisterRecordManager manager = new RewardForRegisterRecordManager(db);

            db.RewardForRegisterPlans.Where(x => x.BeginTime < now
                && x.EndTime > now
                && !x.Hide)
                .ToList()
                .ForEach(plan =>
                {
                    RewardForRegisterSnapshot snapshot = db.RewardForRegisterSnapshots.FirstOrDefault(x => x.Code == plan.Code);
                    if (snapshot == null)
                    {
                        snapshot = new RewardForRegisterSnapshot(plan);
                    }
                    RewardForRegisterRecord record = new RewardForRegisterRecord(model, snapshot);

                    manager.OnExecuting(Actions.Create, record);
                    db.RewardForRegisterRecords.Add(record);
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
