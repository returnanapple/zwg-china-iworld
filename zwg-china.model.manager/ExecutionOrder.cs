using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model.manager
{
    /// <summary>
    /// 执行顺序
    /// </summary>
    public enum ExecutionOrder
    {
        /// <summary>
        /// 在目标方法执行之前执行
        /// </summary>
        Before,
        /// <summary>
        /// 在目标方法执行之后执行
        /// </summary>
        After
    }
}
