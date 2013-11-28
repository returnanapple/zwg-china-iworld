using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model.manager
{
    /// <summary>
    /// 分红记录的管理者对象
    /// </summary>
    [RegisterToManagerService]
    public class DividendRecordManager : ManagerBase<IModelToDbContextOfAuthor, DividendRecordManager.Actions, DividendRecord>
    {
        #region 构造方法

        /// <summary>
        /// 实例化一个新的分红记录的管理者对象
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public DividendRecordManager(IModelToDbContextOfAuthor db)
            : base(db)
        {

        }

        #endregion

        #region 方法

        /// <summary>
        /// 修改分红状态
        /// </summary>
        /// <param name="package">数据集</param>
        public void ChangeStatus(IPackageForChangeStatus package)
        {
            if (package.NewStatus == DividendStatus.已申请)
            {
                throw new Exception("不允许将分红状态修改为“已申请”，操作无效");
            }
            DividendRecord record = db.DividendRecords.Find(package.DividendRecordId);
            if (record.Status != DividendStatus.已申请)
            {
                throw new Exception("已经被操作的分红记录不允许再次修改，操作无效");
            }

            ChangeStatusArgs args = new ChangeStatusArgs
            {
                OldStatus = record.Status,
                NewStatus = package.NewStatus
            };
            OnExecuting(Actions.ChangeStatus, record, args);
            record.Status = package.NewStatus;
            record.Remark = package.Remark;
            OnExecuted(Actions.ChangeStatus, record, args);
            db.SaveChanges();
        }

        #endregion

        #region 静态方法

        #region 监听

        /// <summary>
        /// 监听：创建分红记录
        /// </summary>
        /// <param name="info">数据集</param>
        [Listen(typeof(TimelineManager), TimelineManager.Actions.SparkEachHour, ExecutionOrder.Before)]
        public static void Monitor_CreateDividendRecord(InfoOfSendOnManagerService info)
        {
            IModelToDbContextOfAuthor db = (IModelToDbContextOfAuthor)info.Db;
            TimelineManager.SparkArgs args = (TimelineManager.SparkArgs)info.Args;
            if (args.Now.Hour != 2) { return; }
            SettingOfAuthor setting = new SettingOfAuthor(db);
            List<int> tDays = setting.DaysOfDividend.Split(new char[] { ',' }).ToList().ConvertAll(x => Convert.ToInt32(x));
            if (!tDays.Contains(args.Now.Day - 1)) { return; }
            DividendRecordManager manager = new DividendRecordManager(db);

            int beginDay = tDays.Min() == args.Now.Day - 1 ? tDays.Max() : tDays.Where(x => x < args.Now.Day - 1).Max();
            DateTime beginTime = new DateTime(args.Now.Year, args.Now.Month, beginDay);
            if (tDays.Min() == args.Now.Day - 1)
            {
                beginTime.AddMonths(-1);
            }
            DateTime endTime = new DateTime(args.Now.Year, args.Now.Month, args.Now.Day);
            List<string> ignore = new List<string> { "充值", "提现", "分红" };

            db.Authors.Where(x => x.Status == UserStatus.正常 && x.Layer <= 2).ToList()
                .ForEach(user =>
                {
                    var tList = db.MoneyChangeRecords.Where(x => x.Owner.Relatives.Any(r => r.NodeId == user.Id)
                        && x.Owner.Layer > user.Layer
                        && x.CreatedTime >= beginTime
                        && x.CreatedTime < endTime
                        && !ignore.Contains(x.Type))
                        .Select(x => x.Sum);
                    double tSum = tList.Count() == 0 ? 0 : tList.Sum();
                    if (tSum >= 0) { return; }
                    tSum = Math.Abs(tSum);
                    if (tSum < setting.LowerConsumptionForDividend) { return; }
                    double scale = user.PlayInfo.Dividend != 0
                        ? user.PlayInfo.Dividend
                        : user.Layer == 1
                            ? setting.Dividend_A
                            : setting.Dividend_B;
                    double sum = Math.Round(tSum * scale / 100, 2);

                    string title = string.Format("{0} - {1} 分红"
                        , beginTime.ToLongDateString()
                        , endTime.ToLongDateString());
                    DividendRecord record = new DividendRecord(title, user, -tSum, scale, sum);
                    db.DividendRecords.Add(record);
                });
            db.SaveChanges();
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
            /// 创建新的分红记录
            /// </summary>
            Create,
            /// <summary>
            /// 修改分红记录
            /// </summary>
            Update,
            /// <summary>
            /// 移除分红记录
            /// </summary>
            Remove,
            /// <summary>
            /// 修改分红状态
            /// </summary>
            ChangeStatus
        }

        #endregion

        #region 接口

        /// <summary>
        /// 用于修改分红状态的数据集
        /// </summary>
        public interface IPackageForChangeStatus
        {
            /// <summary>
            /// 分红记录的存储指针
            /// </summary>
            int DividendRecordId { get; }

            /// <summary>
            /// 新状态
            /// </summary>
            DividendStatus NewStatus { get; }

            /// <summary>
            /// 备注
            /// </summary>
            string Remark { get; }
        }

        #endregion

        #region 类

        /// <summary>
        /// 修改分红状态的方法的相关信息
        /// </summary>
        public class ChangeStatusArgs
        {
            /// <summary>
            /// 原状态
            /// </summary>
            public DividendStatus OldStatus { get; set; }

            /// <summary>
            /// 新状态
            /// </summary>
            public DividendStatus NewStatus { get; set; }
        }

        #endregion

        #endregion
    }
}
