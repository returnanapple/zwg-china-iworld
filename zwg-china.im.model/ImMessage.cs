using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 聊天信息（IM）
    /// </summary>
    public class ImMessage : RecordingTimeModelBase
    {
        #region 属性

        /// <summary>
        /// 接受消息用户的用户名
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// 发送消息的用户的用户名
        /// </summary>
        public string ComeFrom { get; set; }

        /// <summary>
        /// 正文
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 一个布尔值 表示该信息是否已经阅读
        /// </summary>
        public bool Readed { get; set; }

        /// <summary>
        /// 一个布尔值 表示该信息是否官方信息
        /// </summary>
        public bool IsOfficial { get; set; }

        /// <summary>
        /// 来源IP
        /// </summary>
        public string Ip { get; set; }

        /// <summary>
        /// 来源地址
        /// </summary>
        public string Address { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的聊天信息
        /// </summary>
        public ImMessage()
        {
        }

        /// <summary>
        /// 实例化一个新的聊天信息（IM）
        /// </summary>
        /// <param name="owner">接受消息用户的用户名</param>
        /// <param name="comeFrom">发送消息的用户的用户名</param>
        /// <param name="content">正文</param>
        /// <param name="ip">来源IP</param>
        /// <param name="address">来源地址</param>
        /// <param name="readed">一个布尔值 表示该信息是否已经阅读</param>
        /// <param name="isOfficial">一个布尔值 表示该信息是否官方信息(默认为 false)</param>
        public ImMessage(string owner, string comeFrom, string content, string ip, string address
            , bool readed, bool isOfficial = false)
        {
            this.Owner = owner;
            this.ComeFrom = comeFrom;
            this.Content = content;
            this.Readed = readed;
            this.IsOfficial = isOfficial;
            this.Ip = ip;
            this.Address = address;
        }

        #endregion
    }
}
