using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model.manager
{
    /// <summary>
    /// 充值记录的管理者对象
    /// </summary>
    [RegisterToManagerService]
    public class RechargeRecordManager : ManagerBase<IModelToDbContextOfAuthor, RechargeRecordManager.Actions, RechargeRecord>
    {
        #region 构造方法

        /// <summary>
        /// 实例化一个新的转账记录的管理者对象
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public RechargeRecordManager(IModelToDbContextOfAuthor db)
            : base(db)
        {

        }

        #endregion

        #region 静态方法

        #region 监听

        /// <summary>
        /// 监听：确认充值
        /// </summary>
        /// <param name="info">数据集</param>
        [Listen(typeof(RechargeRecordManager), RechargeRecordManager.Actions.Create, ExecutionOrder.Before)]
        public static void Monitor_EnterOnCreate(InfoOfSendOnManagerService info)
        {
            IModelToDbContextOfAuthor db = (IModelToDbContextOfAuthor)info.Db;
            RechargeRecord model = (RechargeRecord)info.Model;

            if (model.Status == RechargeStatus.等待银行确认)
            {
                TransferRecord transfer = db.TransferRecords.FirstOrDefault(x => x.ComeFrom == model.ComeFrom
                    && x.SerialNumber == model.SerialNumber
                    && x.Postscript == model.Postscript
                    && x.Status == TransferStatus.用户已经支付);
                if (transfer == null) { return; }

                RechargeRecordManager manager = new RechargeRecordManager(db);
                ChangeStatusArgs args = new ChangeStatusArgs
                {
                    OldStatus = model.Status,
                    NewStatus = RechargeStatus.充值成功
                };
                manager.OnExecuting(Actions.ChangeStatus, model, args);
                model.Sum = transfer.Sum;
                model.Status = RechargeStatus.充值成功;
                manager.OnExecuted(Actions.ChangeStatus, model, args);
            }
        }

        /// <summary>
        /// 监听：确认充值
        /// </summary>
        /// <param name="info">数据集</param>
        [Listen(typeof(TimelineManager), TimelineManager.Actions.SparkEachMinute, ExecutionOrder.Before)]
        public static void Monitor_EnterOnTimeline(InfoOfSendOnManagerService info)
        {
            IModelToDbContextOfAuthor db = (IModelToDbContextOfAuthor)info.Db;
            RechargeRecordManager manager = new RechargeRecordManager(db);

            db.TransferRecords.Where(x => x.Status == TransferStatus.用户已经支付).ToList()
                .ForEach(transfer =>
                {
                    RechargeRecord recharge = db.RechargeRecords.FirstOrDefault(x => x.ComeFrom == transfer.ComeFrom
                        && x.SerialNumber == transfer.SerialNumber
                        && x.Postscript == transfer.Postscript
                        && x.Status == RechargeStatus.等待银行确认);
                    if (recharge == null) { return; }

                    ChangeStatusArgs _args = new ChangeStatusArgs
                    {
                        OldStatus = recharge.Status,
                        NewStatus = RechargeStatus.充值成功
                    };

                    manager.OnExecuting(Actions.ChangeStatus, recharge, _args);
                    recharge.Sum = transfer.Sum;
                    recharge.Status = RechargeStatus.充值成功;
                    manager.OnExecuted(Actions.ChangeStatus, recharge, _args);
                });
            db.SaveChanges();
        }

        /// <summary>
        /// 监听：超时
        /// </summary>
        /// <param name="info">数据集</param>
        [Listen(typeof(TimelineManager), TimelineManager.Actions.SparkEachMinute, ExecutionOrder.Before)]
        public static void Monitor_TimeOut(InfoOfSendOnManagerService info)
        {
            IModelToDbContextOfAuthor db = (IModelToDbContextOfAuthor)info.Db;
            TimelineManager.SparkArgs args = (TimelineManager.SparkArgs)info.Args;
            SettingOfAuthor setting = new SettingOfAuthor(db);
            DateTime limit = args.Now.AddHours(-setting.RechargeRecordTimeout);

            db.RechargeRecords.Where(x => x.Status == RechargeStatus.等待银行确认 && x.CreatedTime > limit).ToList()
                .ForEach(x =>
                {
                    x.Status = RechargeStatus.超时;
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
            /// 创建新的充值记录
            /// </summary>
            Create,
            /// <summary>
            /// 修改充值记录
            /// </summary>
            Update,
            /// <summary>
            /// 移除充值记录
            /// </summary>
            Remove,
            /// <summary>
            /// 改变充值状态
            /// </summary>
            ChangeStatus
        }

        #endregion

        #region 类

        /// <summary>
        /// 改变充值记录方法提供的相关数据
        /// </summary>
        public class ChangeStatusArgs
        {
            /// <summary>
            /// 原状态
            /// </summary>
            public RechargeStatus OldStatus { get; set; }

            /// <summary>
            /// 新状态
            /// </summary>
            public RechargeStatus NewStatus { get; set; }
        }

        #endregion

        #endregion
    }
}
