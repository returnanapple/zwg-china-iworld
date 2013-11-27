using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model.manager
{
    /// <summary>
    /// 帐变记录的管理者对象
    /// </summary>
    [RegisterToManagerService]
    public class MoneyChangeRecordManager : ManagerBase<IModelToDbContextOfAuthor, MoneyChangeRecordManager.Actions, MoneyChangeRecord>
    {
        #region 构造方法

        /// <summary>
        /// 实例化一个新的帐变记录的管理者对象
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public MoneyChangeRecordManager(IModelToDbContextOfAuthor db)
            : base(db)
        {

        }

        #endregion

        #region 静态方法

        #region 服务

        /// <summary>
        /// 服务：生成对应的帐变记录
        /// </summary>
        /// <param name="info">数据集</param>
        [OnCall(typeof(MoneyChangeRecordManager), Services.CreateMoneyChangeRecord)]
        public static void Service_CreateMoneyChangeRecord(InfoOfCallOnManagerService info)
        {
            IModelToDbContextOfAuthor db = (IModelToDbContextOfAuthor)info.Db;
            CreateMoneyChangeRecordArgs args = (CreateMoneyChangeRecordArgs)info.Args;

            Author user = db.Authors.FirstOrDefault(x => x.Id == args.UserId);
            if (user == null)
            {
                throw new Exception("提供的存储指针指向的用户不存在，请检查输入");
            }

            MoneyChangeRecord record = new MoneyChangeRecord(user, args.Type, args.Description, args.Income, args.Expenses);
            MoneyChangeRecordManager manager = new MoneyChangeRecordManager(db);
            manager.OnExecuting(Actions.Create, record);
            db.MoneyChangeRecords.Add(record);
            manager.OnExecuted(Actions.Create, record);
        }

        #endregion

        #region 监听

        /// <summary>
        /// 监听：充值成功
        /// </summary>
        /// <param name="info">数据集</param>
        [Listen(typeof(RechargeRecordManager), RechargeRecordManager.Actions.Create, ExecutionOrder.After)]
        [Listen(typeof(RechargeRecordManager), RechargeRecordManager.Actions.ChangeStatus, ExecutionOrder.After)]
        public static void Monitor_CreateWhenRecharge(InfoOfSendOnManagerService info)
        {
            IModelToDbContextOfAuthor db = (IModelToDbContextOfAuthor)info.Db;
            RechargeRecord model = (RechargeRecord)info.Model;

            if (model.Status == RechargeStatus.后台手动添加
                || model.Status == RechargeStatus.充值成功)
            {
                MoneyChangeRecordManager manager = new MoneyChangeRecordManager(db);
                MoneyChangeRecord record = new MoneyChangeRecord(model.Owner
                    , "充值"
                    , model.Status.ToString()
                    , model.Sum
                    , 0);
                manager.OnExecuting(Actions.Create, record);
                db.MoneyChangeRecords.Add(record);
                manager.OnExecuted(Actions.Create, record);
            }
        }

        /// <summary>
        /// 监听：提现成功
        /// </summary>
        /// <param name="info">数据集</param>
        [Listen(typeof(WithdrawalsRecordManager), WithdrawalsRecordManager.Actions.ChangeStatus, ExecutionOrder.After)]
        public static void Monitor_CreateWhenWithdrawals(InfoOfSendOnManagerService info)
        {
            IModelToDbContextOfAuthor db = (IModelToDbContextOfAuthor)info.Db;
            WithdrawalsRecord model = (WithdrawalsRecord)info.Model;

            if (model.Status == WithdrawalsStatus.提现成功)
            {
                MoneyChangeRecord record = new MoneyChangeRecord(model.Owner
                    , "提现"
                    , model.Status.ToString()
                    , 0
                    , model.Sum);
                db.MoneyChangeRecords.Add(record);
            }
        }

        /// <summary>
        /// 监听：返点
        /// </summary>
        /// <param name="info">数据集</param>
        [Listen(typeof(RebateRecordManager), RebateRecordManager.Actions.Create, ExecutionOrder.After)]
        public static void Monitor_CreateWhenRebate(InfoOfSendOnManagerService info)
        {
            IModelToDbContextOfAuthor db = (IModelToDbContextOfAuthor)info.Db;
            RebateRecord model = (RebateRecord)info.Model;

            MoneyChangeRecordManager manager = new MoneyChangeRecordManager(db);
            MoneyChangeRecord record = new MoneyChangeRecord(model.Owner
                , "返点"
                , model.GetDescription()
                , model.Sum
                , 0);
            manager.OnExecuting(Actions.Create, record);
            db.MoneyChangeRecords.Add(record);
            manager.OnExecuted(Actions.Create, record);
        }

        /// <summary>
        /// 监听：佣金
        /// </summary>
        /// <param name="info">数据集</param>
        [Listen(typeof(CommissionRecordManager), CommissionRecordManager.Actions.Create, ExecutionOrder.After)]
        public static void Monitor_CreateWhenCommission(InfoOfSendOnManagerService info)
        {
            IModelToDbContextOfAuthor db = (IModelToDbContextOfAuthor)info.Db;
            CommissionRecord model = (CommissionRecord)info.Model;

            MoneyChangeRecordManager manager = new MoneyChangeRecordManager(db);
            MoneyChangeRecord record = new MoneyChangeRecord(model.Owner
                , "佣金"
                , model.GetDescription()
                , model.Sum
                , 0);
            manager.OnExecuting(Actions.Create, record);
            db.MoneyChangeRecords.Add(record);
            manager.OnExecuted(Actions.Create, record);
        }

        /// <summary>
        /// 监听：分红
        /// </summary>
        /// <param name="info">数据集</param>
        [Listen(typeof(DividendRecordManager), DividendRecordManager.Actions.ChangeStatus, ExecutionOrder.After)]
        public static void Monitor_CreateWhenDividend(InfoOfSendOnManagerService info)
        {
            IModelToDbContextOfAuthor db = (IModelToDbContextOfAuthor)info.Db;
            DividendRecord model = (DividendRecord)info.Model;

            if (model.Status == DividendStatus.已支付)
            {
                MoneyChangeRecordManager manager = new MoneyChangeRecordManager(db);
                MoneyChangeRecord record = new MoneyChangeRecord(model.Owner
                    , "佣金"
                    , model.GetDescription()
                    , model.Sum
                    , 0);
                manager.OnExecuting(Actions.Create, record);
                db.MoneyChangeRecords.Add(record);
                manager.OnExecuted(Actions.Create, record);
            }
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
            /// 创建新的帐变记录
            /// </summary>
            Create,
            /// <summary>
            /// 修改帐变记录
            /// </summary>
            Update,
            /// <summary>
            /// 移除帐变记录
            /// </summary>
            Remove
        }

        /// <summary>
        /// 服务
        /// </summary>
        public enum Services
        {
            /// <summary>
            /// 生成对应的帐变记录
            /// </summary>
            CreateMoneyChangeRecord
        }

        #endregion

        #region 类型

        /// <summary>
        /// 用于给生成对应的帐变记录的服务提供数据的数据集
        /// </summary>
        public class CreateMoneyChangeRecordArgs
        {
            /// <summary>
            /// 用户的存储指针
            /// </summary>
            public int UserId { get; set; }

            /// <summary>
            /// 帐变类型
            /// </summary>
            public string Type { get; set; }

            /// <summary>
            /// 描述
            /// </summary>
            public string Description { get; set; }

            /// <summary>
            /// 收入
            /// </summary>
            public double Income { get; set; }

            /// <summary>
            /// 支出
            /// </summary>
            public double Expenses { get; set; }
        }

        #endregion

        #endregion
    }
}
