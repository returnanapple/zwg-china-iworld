using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace zwg_china.model.manager
{
    /// <summary>
    /// 彩票模块的注册机
    /// </summary>
    public class RIOfLottery : IRI
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
