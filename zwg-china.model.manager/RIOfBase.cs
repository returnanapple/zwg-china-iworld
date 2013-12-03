using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace zwg_china.model.manager
{
    /// <summary>
    /// 基本库的注册机
    /// </summary>
    public class RIOfBase : IRI
    {
        /// <summary>
        /// 获取当前程序集
        /// </summary>
        /// <returns></returns>
        public Assembly GetAssembly()
        {
            return Assembly.GetExecutingAssembly();
        }
    }
}
