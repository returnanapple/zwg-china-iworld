﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model.manager
{
    /// <summary>
    /// 单日站点统计的管理者对象
    /// </summary>
    [RegisterToManagerService]
    public class SiteReportForOneDayManager : ManagerBase<IModelToDbContextOfReport, SiteReportForOneDayManager.Actions, SiteReportForOneDay>
    {
        #region 构造方法

        /// <summary>
        /// 实例化一个新的单日站点统计的管理者对象
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public SiteReportForOneDayManager(IModelToDbContextOfReport db)
            : base(db)
        {

        }

        #endregion

        #region 静态方法

        /// <summary>
        /// 每天2点整生成前一天的报表
        /// </summary>
        /// <param name="info">数据集</param>
        [Listen(typeof(TimelineManager), TimelineManager.Actions.SparkEachHour, ExecutionOrder.After)]
        public static void CreateReportOnTimeline(InfoOfSendOnManagerService info)
        {
            IModelToDbContextOfReport db = (IModelToDbContextOfReport)info.Db;
            TimelineManager.SparkArgs args = (TimelineManager.SparkArgs)info.Args;
            if (args.Now.Hour != 2) { return; }
            SiteReportForOneDayManager manager = new SiteReportForOneDayManager(db);

            DateTime tTime = new DateTime(args.Now.Year, args.Now.Month, args.Now.Day).AddDays(-1);
            string date = string.Format("{0}-{1}-{2}"
                        , tTime.Year.ToString("0000")
                        , tTime.Month.ToString("00")
                        , tTime.Day.ToString("00"));
            List<MoneyChangeRecord> mcrList = db.MoneyChangeRecords.Where(x => x.CreatedTime.Year == tTime.Year
                && x.CreatedTime.Month == tTime.Month
                && x.CreatedTime.Day == tTime.Day)
                .ToList();
            int countOfSetIn = db.Authors.Count(x => x.CreatedTime.Year == tTime.Year
                && x.CreatedTime.Month == tTime.Month
                && x.CreatedTime.Day == tTime.Day);
            int timesOfLogin = db.AuthorLandingRecords.Count(x => x.CreatedTime.Year == tTime.Year
                && x.CreatedTime.Month == tTime.Month
                && x.CreatedTime.Day == tTime.Day);
            #region 投注额
            double amountOfBets = 0;
            mcrList.Where(x => x.Type == "投注" || x.Type == "撤单").ToList()
                .ForEach(x =>
                {
                    amountOfBets += x.Sum;
                });
            #endregion
            #region 返点
            double rebate = 0;
            mcrList.Where(x => x.Type == "返点").ToList()
                .ForEach(x =>
                {
                    rebate += x.Sum;
                });
            #endregion
            #region 中奖
            double bonus = 0;
            mcrList.Where(x => x.Type == "中奖").ToList()
                .ForEach(x =>
                {
                    bonus += x.Sum;
                });
            #endregion
            #region 佣金
            double commission = 0;
            mcrList.Where(x => x.Type == "佣金").ToList()
                .ForEach(x =>
                {
                    commission += x.Sum;
                });
            #endregion
            #region 分红
            double dividend = 0;
            mcrList.Where(x => x.Type == "分红").ToList()
                .ForEach(x =>
                {
                    dividend += x.Sum;
                });
            #endregion
            #region 活动奖励
            double reward = 0;
            mcrList.Where(x => x.Type == "充值奖励" || x.Type == "消费奖励" || x.Type == "注册奖励" || x.Type == "积分兑换").ToList()
                .ForEach(x =>
                {
                    reward += x.Sum;
                });
            #endregion
            #region 充值
            double recharge = 0;
            mcrList.Where(x => x.Type == "充值").ToList()
                .ForEach(x =>
                {
                    recharge += x.Sum;
                });
            #endregion
            #region 提现
            double withdrawal = 0;
            mcrList.Where(x => x.Type == "提现").ToList()
                .ForEach(x =>
                {
                    withdrawal += x.Sum;
                });
            #endregion
            SiteReportForOneDay record = new SiteReportForOneDay(date, countOfSetIn, timesOfLogin, amountOfBets, rebate
                , bonus, commission, reward, dividend, recharge, withdrawal);
            manager.OnExecuting(Actions.Create, record);
            db.SiteReportForOneDays.Add(record);
            manager.OnExecuted(Actions.Create, record);

            db.SaveChanges();
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
