using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model.manager
{
    /// <summary>
    /// 追号的管理者记录
    /// </summary>
    [RegisterToManagerService]
    public class ChasingManager : ManagerBase<IModelToDbContextOfLottery, ChasingManager.Actions, Chasing>
    {
        #region 构造方法

        /// <summary>
        /// 实例化一个新的追号的管理者记录
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public ChasingManager(IModelToDbContextOfLottery db)
            : base(db)
        {

        }

        #endregion

        #region 方法

        /// <summary>
        /// 撤单
        /// </summary>
        /// <param name="package">数据集</param>
        public void Recall(IPackageForRecall package)
        {
            Chasing chasing = db.Chasings.Find(package.ChasingId);
            List<ChasingStatus> tStatus = new List<ChasingStatus> { ChasingStatus.未开始, ChasingStatus.追号中 };
            if (!tStatus.Contains(chasing.Status))
            {
                throw new Exception("已经终止的追号无法撤单，操作无效");
            }

            OnExecuting(Actions.Recall, chasing);
            double tRepay = 0;
            db.BettingWithChasings.Where(x => x.Chasing.Id == chasing.Id
                && x.Status == BettingStatus.等待开奖)
                .ToList()
                .ForEach(betting =>
                {
                    betting.Status = BettingStatus.用户撤单;
                    tRepay += betting.Pay;
                });
            chasing.Repay = tRepay;
            chasing.Status = ChasingStatus.用户中止追号;
            OnExecuted(Actions.Recall, chasing);

            db.SaveChanges();
        }

        #endregion

        #region 静态方法

        /// <summary>
        /// 监听：投注
        /// </summary>
        /// <param name="info">数据集</param>
        [Listen(typeof(ChasingManager), ChasingManager.Actions.Create, ExecutionOrder.After)]
        public static void Monitor_CreateMoneyChangeWhenBet(InfoOfSendOnManagerService info)
        {
            IModelToDbContextOfLottery db = (IModelToDbContextOfLottery)info.Db;
            Chasing model = (Chasing)info.Model;

            MoneyChangeRecordManager.CreateMoneyChangeRecordArgs _args = new MoneyChangeRecordManager.CreateMoneyChangeRecordArgs
            {
                UserId = model.Owner.Id,
                Type = "投注",
                Description = model.GetDescription(),
                Income = 0,
                Expenses = model.Pay
            };
            InfoOfCallOnManagerService _info = new InfoOfCallOnManagerService(db, typeof(MoneyChangeRecordManager), MoneyChangeRecordManager.Services.CreateMoneyChangeRecord, _args);
            ManagerService.Call(_info);
        }

        /// <summary>
        /// 监听：撤单
        /// </summary>
        /// <param name="info">数据集</param>
        [Listen(typeof(ChasingManager), ChasingManager.Actions.Recall, ExecutionOrder.After)]
        public static void Monitor_CreateMoneyChangeRecordWhenRecall(InfoOfSendOnManagerService info)
        {
            IModelToDbContextOfLottery db = (IModelToDbContextOfLottery)info.Db;
            Chasing model = (Chasing)info.Model;

            MoneyChangeRecordManager.CreateMoneyChangeRecordArgs _args = new MoneyChangeRecordManager.CreateMoneyChangeRecordArgs
            {
                UserId = model.Owner.Id,
                Type = "撤单",
                Description = model.GetDescription(),
                Income = model.Repay,
                Expenses = 0
            };
            InfoOfCallOnManagerService _info = new InfoOfCallOnManagerService(db, typeof(MoneyChangeRecordManager), MoneyChangeRecordManager.Services.CreateMoneyChangeRecord, _args);
            ManagerService.Call(_info);
        }

        /// <summary>
        /// 监听：开始追号
        /// </summary>
        /// <param name="info">数据集</param>
        [Listen(typeof(BettingWithChasingManager), BettingWithChasingManager.Actions.ClosureSingle, ExecutionOrder.After)]
        public static void Monitor_UpdateStatus(InfoOfSendOnManagerService info)
        {
            IModelToDbContextOfLottery db = (IModelToDbContextOfLottery)info.Db;
            BettingWithChasing model = (BettingWithChasing)info.Model;
            Chasing chasing = db.Chasings.Find(model.Chasing.Id);
            if (chasing.Status == ChasingStatus.未开始)
            {
                chasing.Status = ChasingStatus.追号中;
            }
            else if (chasing.Gone == chasing.Continuance - 1)
            {
                chasing.Status = ChasingStatus.即将结束;
            }
        }

        /// <summary>
        /// 监听：追号结束
        /// </summary>
        /// <param name="info">数据集</param>
        [Listen(typeof(BettingWithChasingManager), BettingWithChasingManager.Actions.Win, ExecutionOrder.After)]
        [Listen(typeof(BettingWithChasingManager), BettingWithChasingManager.Actions.Lost, ExecutionOrder.After)]
        public static void Monitor_EndChasing(InfoOfSendOnManagerService info)
        {
            IModelToDbContextOfLottery db = (IModelToDbContextOfLottery)info.Db;
            BettingWithChasing model = (BettingWithChasing)info.Model;
            Chasing chasing = db.Chasings.Find(model.Chasing.Id);
            chasing.Gone++;
            if (chasing.Gone == chasing.Continuance)
            {
                chasing.Status = ChasingStatus.追号结束;
            }
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
            Remove,
            /// <summary>
            /// 撤单
            /// </summary>
            Recall
        }

        #endregion

        #region 接口

        /// <summary>
        /// 定义用于撤单的数据集
        /// </summary>
        public interface IPackageForRecall
        {
            /// <summary>
            /// 追号记录的存储指针
            /// </summary>
            int ChasingId { get; }
        }

        #endregion

        #endregion
    }
}
