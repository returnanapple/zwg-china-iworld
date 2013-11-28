using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 分红状态
    /// </summary>
    [DataContract]
    public enum DividendStatus
    {
        [EnumMember]
        过期 = -2,
        [EnumMember]
        拒绝支付 = -1,
        [EnumMember]
        开放申请 = 0,
        [EnumMember]
        已申请 = 1,
        [EnumMember]
        已支付 = 2
    }
}
