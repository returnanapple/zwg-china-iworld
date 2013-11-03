﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 定期活动状态
    /// </summary>
    [DataContract]
    public enum RegularStatus
    {
        [EnumMember]
        暂停 = -1,
        [EnumMember]
        未开始 = 0,
        [EnumMember]
        正常 = 1,
        [EnumMember]
        已过期 = 2
    }
}
