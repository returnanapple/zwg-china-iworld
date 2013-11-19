﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 追号记录的当前状态
    /// </summary>
    [DataContract]
    public enum ChasingStatus
    {
        [EnumMember]
        用户中止追号 = -3,
        [EnumMember]
        因为中奖而终止 = -2,
        [EnumMember]
        因为所追号码已经开出而终止 = -1,
        [EnumMember]
        未开始 = 0,
        [EnumMember]
        追号中 = 1,
        [EnumMember]
        追号结束 = 2
    }
}
