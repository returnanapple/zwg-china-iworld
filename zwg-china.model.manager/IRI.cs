using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace zwg_china.model.manager
{
    /// <summary>
    /// 定义注册机
    /// </summary>
    public interface IRI
    {
        /// <summary>
        /// 获取当前程序集
        /// </summary>
        /// <returns></returns>
        Assembly GetAssembly();
    }
}
