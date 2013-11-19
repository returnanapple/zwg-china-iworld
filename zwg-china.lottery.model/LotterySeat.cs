using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 位（开奖记录）
    /// </summary>
    public class LotterySeat : ModelBase
    {
        #region 公开属性

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 对应的号码
        /// </summary>
        public string Value { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的位（开奖记录）
        /// </summary>
        public LotterySeat()
        {
        }

        /// <summary>
        /// 实例化一个新的位（开奖记录）
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="value">对应的号码</param>
        public LotterySeat(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }

        #endregion
    }
}
