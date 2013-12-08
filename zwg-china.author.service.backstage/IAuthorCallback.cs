using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace zwg_china.service
{
    /// <summary>
    /// 定义用户模块的回调
    /// </summary>
    public interface IAuthorCallback
    {
        /// <summary>
        /// 设置未处理的提现申请的通知的数量
        /// </summary>
        /// <param name="countOfWithdrawal">未处理的提现申请的通知的数量</param>
        [OperationContract(IsOneWay = true)]
        void SetCountOfWithdrawal(int countOfWithdrawal);
    }
}
