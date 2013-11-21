using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 在线状态
    /// </summary>
    [DataContract]
    public enum ImOnlineStatus
    {
        [EnumMember]
        离线 = -1,
        [EnumMember]
        隐身 = 0,
        [EnumMember]
        在线 = 1,
        [EnumMember]
        忙碌 = 2,
    }
}
