﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace zwg_china.service.client
{
    [DataContract]
    public enum TeamOrSelf
    {
        [EnumMember]
        Team,
        [EnumMember]
        Self
    }
}
