using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace zwg_china.model
{
    /// <summary>
    /// 奖品类型
    /// </summary>
    [DataContract]
    public enum PrizesOfActivityType
    {
        [EnumMember]
        积分 = 101,
        [EnumMember]
        人民币 = 201,
    }
}
