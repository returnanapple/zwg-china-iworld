using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 位（投注记录）
    /// </summary>
    public class BettingSeat : ModelBase
    {
        #region 公开属性

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 对应的号码的集合
        /// </summary>
        public string Values { get; set; }

        /// <summary>
        /// 对应的号码的集合的列表（只读）
        /// </summary>
        public List<string> ValueList
        {
            get
            {
                if (this.Values == "")
                {
                    return new List<string>();
                }
                return this.Values.Split(new char[] { ',', ' ' }).ToList();
            }
        }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的位（投注记录）
        /// </summary>
        public BettingSeat()
        {
        }

        /// <summary>
        /// 实例化一个新的位（投注记录）
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="values">对应的号码的集合</param>
        public BettingSeat(string name, string values)
        {
            this.Name = name;
            this.Values = values;
        }

        #endregion
    }
}
