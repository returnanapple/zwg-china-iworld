using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 奖品返还方式
    /// </summary>
    [DataContract]
    public enum WaysToRewardOfActivity
    {
        [EnumMember]
        绝对值 = 1,
        [EnumMember]
        百分比 = 2
    }
}
