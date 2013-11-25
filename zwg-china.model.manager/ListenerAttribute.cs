using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model.manager
{
    /// <summary>
    /// 标记改管理者对象将监听信使服务的某些动作
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ListenerAttribute : Attribute
    {
    }
}
