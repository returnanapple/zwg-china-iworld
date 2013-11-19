using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 开奖记录的来源
    /// </summary>
    [DataContract]
    public enum LotterySources
    {
        [EnumMember]
        系统采集 = 101,
        [EnumMember]
        手动 = 201
    }
}
