using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model.manager
{
    /// <summary>
    /// 通知的管理者对象
    /// </summary>
    public class NoticeManager : ManagerBase<IModelToDbContextOfMessage, NoticeManager.Actions, Notice>
    {
        #region 构造方法

        /// <summary>
        /// 实例化一个新的/// </summary>
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public NoticeManager(IModelToDbContextOfMessage db)
            : base(db)
        {

        }

        #endregion

        #region 静态方法

        /// <summary>
        /// 创建中奖通知
        /// </summary>
        /// <param name="info">数据集</param>
        [Listen(typeof(BettingManager), BettingManager.Actions.Win, ExecutionOrder.After)]
        public static void CreateNoticeWhenBetWin(InfoOfSendOnManagerService info)
        {
            IModelToDbContextOfMessage db = (IModelToDbContextOfMessage)info.Db;
            Betting model = (Betting)info.Model;

            string m = string.Format("恭喜！{0} 第 {1} 期已经开奖。您的订单号为 {2} 的投注风骚中奖。中奖金额为：{3} 元。"
                , model.HowToPlay.Tag.Ticket.Name
                , model.Issue
                , model.Id.ToString("00000000")
                , model.Bonus);
            Notice notice = new Notice(model.Owner, m, "中奖", model.Id);
            db.Notices.Add(notice);
        }

        /// <summary>
        /// 创建未中奖通知
        /// </summary>
        /// <param name="info">数据集</param>
        [Listen(typeof(BettingManager), BettingManager.Actions.Lost, ExecutionOrder.After)]
        public static void CreateNoticeWhenBetLost(InfoOfSendOnManagerService info)
        {
            IModelToDbContextOfMessage db = (IModelToDbContextOfMessage)info.Db;
            Betting model = (Betting)info.Model;

            string m = string.Format("{0} 第 {1} 期已经开奖。很遗憾您的订单号为 {2} 的投注未能中奖。"
                , model.HowToPlay.Tag.Ticket.Name
                , model.Issue
                , model.Id.ToString("00000000"));
            Notice notice = new Notice(model.Owner, m, "未中奖", model.Id);
            db.Notices.Add(notice);
        }

        /// <summary>
        /// 创建未中奖通知
        /// </summary>
        /// <param name="info">数据集</param>
        [Listen(typeof(RechargeRecordManager), RechargeRecordManager.Actions.ChangeStatus, ExecutionOrder.After)]
        public static void CreateNoticeWhenRecharge(InfoOfSendOnManagerService info)
        {
            IModelToDbContextOfMessage db = (IModelToDbContextOfMessage)info.Db;
            RechargeRecord model = (RechargeRecord)info.Model;
            if (model.Status != RechargeStatus.充值成功) { return; }

            string m = string.Format("您的流水号为 {0} 充值已经到账，到账金额为 {1}元"
                , model.SerialNumber
                , model.Sum);
            Notice notice = new Notice(model.Owner, m, "充值成功", model.Id);
            db.Notices.Add(notice);
        }

        /// <summary>
        /// 创建未中奖通知
        /// </summary>
        /// <param name="info">数据集</param>
        [Listen(typeof(WithdrawalsRecordManager), WithdrawalsRecordManager.Actions.ChangeStatus, ExecutionOrder.After)]
        public static void CreateNoticeWhenWithdrawals(InfoOfSendOnManagerService info)
        {
            IModelToDbContextOfMessage db = (IModelToDbContextOfMessage)info.Db;
            WithdrawalsRecord model = (WithdrawalsRecord)info.Model;
            if (model.Status != WithdrawalsStatus.提现成功) { return; }

            string m = string.Format("您的订单号为 {0} 的提现申请已经到账，到账金额为 {1}元，请注意查收"
                , model.Id.ToString("00000000")
                , model.Sum);
            Notice notice = new Notice(model.Owner, m, "提现成功", model.Id);
            db.Notices.Add(notice);
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
