using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 相关设定的明细项目
    /// </summary>
    public class SettingDetail : ModelBase
    {
        #region 属性

        /// <summary>
        /// 键
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public string Value { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的相关设定的明细项目
        /// </summary>
        public SettingDetail()
        {

        }

        /// <summary>
        /// 实例化一个新的相关设定的明细项目
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public SettingDetail(string key, string value)
        {
            this.Key = key;
            this.Value = value;
        }

        #endregion
    }
}
