using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.client.framework
{
    /// <summary>
    /// 按键分组对照
    /// </summary>
    public class ButtonContrast
    {
        /// <summary>
        /// 组名
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// 所从属的按键的名字的集合
        /// </summary>
        public List<string> ButtonNames { get; set; }
    }
}
