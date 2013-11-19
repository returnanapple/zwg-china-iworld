using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 通知
    /// </summary>
    public class Notice : RecordingTimeModelBase
    {
        #region 公开属性

        /// <summary>
        /// 接收人
        /// </summary>
        public virtual Author Owner { get; set; }

        /// <summary>
        /// 正文
        /// </summary>
        public string Context { get; set; }

        /// <summary>
        /// 一个布尔值 标识该通知是否已经被阅读
        /// </summary>
        public bool IsReaded { get; set; }

        /// <summary>
        /// 来源对象的类型
        /// </summary>
        public string SourceType { get; set; }

        /// <summary>
        /// 目标对象的存储指针
        /// </summary>
        public int SourceId { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的通知
        /// </summary>
        public Notice()
        {
        }

        /// <summary>
        /// 实例化一个新的通知
        /// </summary>
        /// <param name="owner">接收人</param>
        /// <param name="context">正文</param>
        /// <param name="sourceType">通知类型</param>
        /// <param name="sourceId">目标对象的存储指针</param>
        public Notice(Author owner, string context, string sourceType, int sourceId)
        {
            this.Owner = owner;
            this.Context = context;
            this.IsReaded = false;
            this.SourceType = sourceType;
            this.SourceId = sourceId;
        }

        #endregion
    }
}
