using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 用户组
    /// </summary>
    public class UserGroup : ModelBase
    {
        #region 属性

        #region 基本信息

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 等级
        /// </summary>
        public int Grade { get; set; }

        /// <summary>
        /// 名称的显示颜色（如为空则显示系统默认颜色）
        /// </summary>
        public UserGroupNameColor ColorOfName { get; set; }

        /// <summary>
        /// 消费量下限
        /// </summary>
        public double LowerOfConsumption { get; set; }

        /// <summary>
        /// 消费量上限
        /// </summary>
        public double GapsOfConsumption { get; set; }

        #endregion

        #endregion
    }
}
