using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 公告
    /// </summary>
    public class Bulletin : RegularModelBase
    {
        #region 公开属性

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 正文
        /// </summary>
        public string Context { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的公告
        /// </summary>
        public Bulletin()
        {
        }

        /// <summary>
        /// 实例化一个新的公告
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="context">正文</param>
        /// <param name="beginTime">开始公示时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="hide">一个布尔值 标识活动是否暂停（默认为 false）</param>
        public Bulletin(string title, string context, DateTime beginTime, DateTime endTime, bool hide = false)
            : base(beginTime, endTime, hide)
        {
            this.Title = title;
            this.Context = context;
        }

        #endregion
    }
}
