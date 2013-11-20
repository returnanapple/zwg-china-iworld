using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 时间刻度
    /// </summary>
    [DataContract]
    public enum TimescaleOfActivity
    {
        [EnumMember]
        无 = 0,
        [EnumMember]
        日 = 101,
        [EnumMember]
        周 = 102,
        [EnumMember]
        月 = 103,
        [EnumMember]
        年 = 104
    }
}
