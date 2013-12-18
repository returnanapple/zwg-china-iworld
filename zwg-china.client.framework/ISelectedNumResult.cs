using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.client.framework
{
    /// <summary>
    /// 定义选号集合
    /// </summary>
    public interface ISelectedNumResult
    {
        /// <summary>
        /// 标题
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// 选中的值
        /// </summary>
        List<int> Data { get; set; }
    }
}
