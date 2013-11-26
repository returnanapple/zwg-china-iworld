using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 转账状态
    /// </summary>
    [DataContract]
    public enum TransferStatus
    {
        [EnumMember]
        用户已经支付 = 0,
        [EnumMember]
        充值成功 = 1
    }
}
