using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 用户登陆记录
    /// </summary>
    public class AuthorLandingRecord : RecordingTimeModelBase
    {
        #region 属性

        /// <summary>
        /// 用户
        /// </summary>
        public virtual Author Owner { get; set; }

        /// <summary>
        /// 网络地址
        /// </summary>
        public string Ip { get; set; }

        /// <summary>
        /// 实际地址
        /// </summary>
        public string Address { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的用户登陆记录
        /// </summary>
        public AuthorLandingRecord()
        {
        }

        /// <summary>
        /// 实例化一个新的用户登陆记录
        /// </summary>
        /// <param name="owner">用户</param>
        /// <param name="ip">网络地址</param>
        /// <param name="address">实际地址</param>
        public AuthorLandingRecord(Author owner, string ip, string address)
        {
            this.Owner = owner;
            this.Ip = ip;
            this.Address = address;
        }

        #endregion
    }
}
