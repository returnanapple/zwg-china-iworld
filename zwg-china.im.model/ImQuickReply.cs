using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 快捷回复
    /// </summary>
    public class ImQuickReply : ModelBase
    {
        #region 属性

        /// <summary>
        /// 所属用户的存储指针（如为0则为公用）
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 正文
        /// </summary>
        public string Context { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的快捷回复
        /// </summary>
        public ImQuickReply()
        {
        }

        /// <summary>
        /// 实例化一个新的快捷回复
        /// </summary>
        /// <param name="userId">所属用户的存储指针（如为0则为公用）</param>
        /// <param name="context">正文</param>
        public ImQuickReply(int userId, string context)
        {
            this.UserId = userId;
            this.Context = context;
        }

        #endregion
    }
}
