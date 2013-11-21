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
        日 = 1,
        [EnumMember]
        月 = 2,
    }
}
