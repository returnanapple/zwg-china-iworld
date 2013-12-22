using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model.manager
{
    /// <summary>
    /// 投注（追号）的管理者对象
    /// </summary>
    [RegisterToManagerService]
    public class BettingWithChasingManager : ManagerBase<IModelToDbContextOfLottery, BettingWithChasingManager.Actions, BettingWithChasing>
    {
        #region 构造方法

        /// <summary>
        /// 实例化一个新的投注（追号）的管理者对象
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public BettingWithChasingManager(IModelToDbContextOfLottery db)
            : base(db)
        {

        }

        #endregion

        #region 静态方法

        #region 监听

        /// <summary>
        /// 监听：中奖
        /// </summary>
        /// <param name="info">数据集</param>
        [Listen(typeof(BettingWithChasingManager), BettingWithChasingManager.Actions.Win, ExecutionOrder.After)]
        public static void Monitor_CreateMoneyChangeRecordWhenWin(InfoOfSendOnManagerService info)
        {
            IModelToDbContextOfLottery db = (IModelToDbContextOfLottery)info.Db;
            BettingWithChasing model = (BettingWithChasing)info.Model;

            MoneyChangeRecordManager.CreateMoneyChangeRecordArgs _args = new MoneyChangeRecordManager.CreateMoneyChangeRecordArgs
            {
                UserId = model.Chasing.Owner.Id,
                Type = "中奖",
                Description = model.GetDescription(),
                Income = model.Bonus,
                Expenses = 0
            };
            InfoOfCallOnManagerService _info = new InfoOfCallOnManagerService(db, typeof(MoneyChangeRecordManager), MoneyChangeRecordManager.Services.CreateMoneyChangeRecord, _args);
            ManagerService.Call(_info);
        }

        /// <summary>
        /// 监听：更新投注状态
        /// </summary>
        /// <param name="info">数据集</param>
        [Listen(typeof(TimelineManager), TimelineManager.Actions.SparkEachSecond, ExecutionOrder.Before)]
        public static void Monitor_UpdateStatus(InfoOfSendOnManagerService info)
        {
            IModelToDbContextOfLottery db = (IModelToDbContextOfLottery)info.Db;
            TimelineManager.SparkArgs args = (TimelineManager.SparkArgs)info.Args;
            SettingOfLottery setting = new SettingOfLottery(db);
            BettingWithChasingManager manager = new BettingWithChasingManager(db);

            db.LotteryTickets.ToList()
                .ForEach(ticket =>
                {
                    DateTime nextTime = ticket.NextLotteryTime.AddSeconds(-setting.ClosureSingleTime);
                    if (args.Now > nextTime)
                    {
                        db.BettingWithChasings.Where(x => x.Chasing.HowToPlay.Tag.Ticket.Id == ticket.Id
                            && x.Issue == ticket.NextIssue
                            && x.Status == BettingStatus.等待开奖)
                            .ToList()
                            .ForEach(betting =>
                            {
                                manager.OnExecuting(Actions.ClosureSingle, betting);
                                betting.Status = BettingStatus.即将开奖;
                                manager.OnExecuted(Actions.ClosureSingle, betting);
                            });
                    }
                });
            db.SaveChanges();
        }

        /// <summary>
        /// 监听：封单
        /// </summary>
        /// <param name="info">数据集</param>
        [Listen(typeof(BettingWithChasingManager), BettingWithChasingManager.Actions.ClosureSingle, ExecutionOrder.After)]
        public static void Monitor_CreateRebateRecordWhenClosureSingle(InfoOfSendOnManagerService info)
        {
            IModelToDbContextOfLottery db = (IModelToDbContextOfLottery)info.Db;
            BettingWithChasing model = (BettingWithChasing)info.Model;
            Author user = model.Chasing.Owner;
            int t = 1;

            while (user.Layer > 1)
            {
                Author parent = db.Authors.First(x => user.Relatives.Any(r => r.NodeId == x.Id) && x.Layer == user.Layer - 1);
                double sum = model.Chasing.HowToPlay.Interface == LotteryInterface.任N不定位
                    ? (parent.PlayInfo.Rebate_IndefinitePosition - user.PlayInfo.Rebate_IndefinitePosition) * model.Pay / 100
                    : (parent.PlayInfo.Rebate_Normal - user.PlayInfo.Rebate_Normal) * model.Pay / 100;
                sum = Math.Round(sum, 2);

                RebateRecordManager.CreateRebateRecordArgs _args = new RebateRecordManager.CreateRebateRecordArgs
                {
                    Owner = db.Authors.Find(parent.Id),
                    Source = db.Authors.Find(user.Id),
                    GameName = model.GetDescription(),
                    IsImmediate = t == 1,
                    Sum = sum
                };
                InfoOfCallOnManagerService _info = new InfoOfCallOnManagerService(db, typeof(RebateRecordManager), RebateRecordManager.Services.CreateRebateRecord, _args);
                ManagerService.Call(_info);

                user = parent;
                t++;
            }
        }

        /// <summary>
        /// 监控：开奖
        /// </summary>
        /// <param name="info">数据集</param>
        [Listen(typeof(LotteryManager), LotteryManager.Actions.Create, ExecutionOrder.After)]
        public static void Monitor_Lottery(InfoOfSendOnManagerService info)
        {
            IModelToDbContextOfLottery db = (IModelToDbContextOfLottery)info.Db;
            Lottery model = (Lottery)info.Model;
            SettingOfLottery setting = new SettingOfLottery(db);
            BettingWithChasingManager manager = new BettingWithChasingManager(db);

            db.BettingWithChasings.Where(x => x.Chasing.HowToPlay.Tag.Ticket.Id == model.Ticket.Id
                && x.Issue == model.Issue
                && x.Status == BettingStatus.即将开奖)
                .ToList()
                .ForEach(betting =>
                {
                    betting.LotteryValues = string.Format(",", model.Seats.ConvertAll(x => x.Value));
                    int notes = betting.GetNotesOfWin(model);
                    if (notes <= 0)
                    {
                        manager.OnExecuting(Actions.Lost, betting);
                        betting.Status = BettingStatus.未中奖;
                        manager.OnExecuted(Actions.Lost, betting);
                        return;
                    }
                    double bonus = notes * betting.Multiple * betting.Chasing.HowToPlay.Odds * (setting.PayoutBase + betting.Chasing.Points * setting.ConversionRates) / setting.PayoutBase;
                    if (bonus > setting.MaximumPayout)
                    {
                        bonus = setting.MaximumPayout;
                    }
                    bonus = Math.Round(bonus, 2);

                    manager.OnExecuting(Actions.Win, betting);
                    betting.Status = BettingStatus.中奖;
                    betting.Bonus = bonus;
                    manager.OnExecuted(Actions.Win, betting);
                });
        }

        #endregion

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
            /// 反馈开奖结果：中奖
            /// </summary>
            Win,
            /// <summary>
            /// 反馈开奖结果：未中奖
            /// </summary>
            Lost,
            /// <summary>
            /// 封单
            /// </summary>
            ClosureSingle
        }

        #endregion

        #endregion
    }
}
