using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 反奖接口
    /// </summary>
    [DataContract]
    public enum LotteryInterface
    {
        [EnumMember]
        任N直选 = 1,
        [EnumMember]
        任N组选 = 2,
        [EnumMember]
        任N不定位 = 3,
        [EnumMember]
        任N定位胆 = 4,
    }
}
