using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model.manager
{
    /// <summary>
    /// 标记改管理者对象将注册到信使服务的相关服务
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class RegisterToManagerServiceAttribute : Attribute
    {
    }
}
