using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model.manager
{
    /// <summary>
    /// 佣金记录的管理者对象
    /// </summary>
    [RegisterToManagerService]
    public class CommissionRecordManager : ManagerBase<IModelToDbContextOfAuthor, CommissionRecordManager.Actions, CommissionRecord>
    {
        #region 构造方法

        /// <summary>
        /// 实例化一个新的佣金记录的管理者对象
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public CommissionRecordManager(IModelToDbContextOfAuthor db)
            : base(db)
        {

        }

        #endregion

        #region 静态方法

        #region 监听

        /// <summary>
        /// 监听：生成佣金记录
        /// </summary>
        /// <param name="info"></param>
        [Listen(typeof(TimelineManager), TimelineManager.Actions.SparkEachHour, ExecutionOrder.Before)]
        public static void Monitor_CreateCommissionRecord(InfoOfSendOnManagerService info)
        {
            IModelToDbContextOfAuthor db = (IModelToDbContextOfAuthor)info.Db;
            TimelineManager.SparkArgs args = (TimelineManager.SparkArgs)info.Args;
            if (args.Now.Hour != 2) { return; }
            DateTime tTime = args.Now.AddDays(-1);
            SettingOfAuthor setting = new SettingOfAuthor(db);
            CommissionRecordManager manager = new CommissionRecordManager(db);

            db.Authors.Where(x => x.Status == UserStatus.正常 && x.Layer > 1).ToList()
                .ForEach(user =>
                {
                    //判断消费量是否达标
                    var tList = db.MoneyChangeRecords.Where(x => x.Owner.Id == user.Id
                        && x.Expenses > 0
                        && x.Income == 0
                        && x.CreatedTime.Year == tTime.Year
                        && x.CreatedTime.Month == tTime.Month
                        && x.CreatedTime.Day == tTime.Day)
                        .Select(x => x.Expenses);
                    double tConsumption = tList.Count() == 0 ? 0 : Math.Abs(tList.Sum());
                    if (tConsumption < setting.LowerConsumptionForCommission) { return; }

                    //一级佣金
                    Author parent = db.Authors.First(x => user.Relatives.Any(r => r.NodeId == x.Id) && x.Layer == user.Layer - 1);
                    double tCommission_A = parent.PlayInfo.Commission_A == 0 ? setting.Commission_A : parent.PlayInfo.Commission_A;
                    CommissionRecord record_A = new CommissionRecord(parent, user, true, tCommission_A);
                    manager.OnExecuting(Actions.Create, record_A);
                    db.CommissionRecords.Add(record_A);
                    manager.OnExecuted(Actions.Create, record_A);

                    //二级佣金
                    if (user.Layer <= 2) { return; }
                    Author grandParent = db.Authors.First(x => user.Relatives.Any(r => r.NodeId == x.Id) && x.Layer == user.Layer - 2);
                    double tCommission_B = grandParent.PlayInfo.Commission_B == 0 ? setting.Commission_B : grandParent.PlayInfo.Commission_B;
                    CommissionRecord record_B = new CommissionRecord(grandParent, parent, false, tCommission_B);
                    manager.OnExecuting(Actions.Create, record_B);
                    db.CommissionRecords.Add(record_B);
                    manager.OnExecuted(Actions.Create, record_B);
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
            /// 创建新的佣金记录
            /// </summary>
            Create,
            /// <summary>
            /// 修改佣金记录
            /// </summary>
            Update,
            /// <summary>
            /// 移除佣金记录
            /// </summary>
            Remove
        }

        #endregion

        #endregion
    }
}
