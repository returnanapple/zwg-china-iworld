using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace zwg_china.service
{
    /// <summary>
    /// 定义前台用户的推送行为的回调
    /// </summary>
    public interface IAuthorCallback
    {
        /// <summary>
        /// 有新的未读通知的时候触发
        /// </summary>
        [OperationContract(IsOneWay = true)]
        void CallWhenHaveUnreadNotices(List<NoticeExport> notices);

        /// <summary>
        /// 开奖的时候触发
        /// </summary>
        [OperationContract(IsOneWay = true)]
        void CallWhenLottery(List<LotteryTicketExport> tickets);

        /// <summary>
        /// 用户被移除的时候触发
        /// </summary>
        [OperationContract(IsOneWay = true)]
        void CallWhenLeave(string message);
    }
}
