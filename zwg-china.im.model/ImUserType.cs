using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 用户类型
    /// </summary>
    [DataContract]
    public enum ImUserType
    {
        [EnumMember]
        普通用户 = 1,
        [EnumMember]
        客服 = 2
    }
}
