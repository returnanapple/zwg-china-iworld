﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model.manager
{
    /// <summary>
    /// 标记该对象将对信使服务提供服务
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ServerAttribute : Attribute
    {
    }
}