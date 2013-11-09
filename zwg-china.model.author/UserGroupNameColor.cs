using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 用户组名称的显示颜色
    /// </summary>
    [DataContract]
    public enum UserGroupNameColor
    {
        [EnumMember]
        默认 = 0
    }
}
