using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 充值状态
    /// </summary>
    [DataContract]
    public enum RechargeStatus
    {
        [EnumMember]
        超时 = -1,
        [EnumMember]
        等待银行确认 = 0,
        [EnumMember]
        充值成功 = 1,
        [EnumMember]
        后台手动添加 = 2
    }
}
