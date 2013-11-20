using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 奖励计划的类型
    /// </summary>
    [DataContract]
    public enum RewardPlanType
    {
        [EnumMember]
        当即返还 = 1,
        [EnumMember]
        满就送 = 2,
    }
}
