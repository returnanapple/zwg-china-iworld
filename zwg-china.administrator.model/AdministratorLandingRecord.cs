using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 管理员登陆记录
    /// </summary>
    public class AdministratorLandingRecord : RecordingTimeModelBase
    {
        #region 公开属性

        /// <summary>
        /// 用户
        /// </summary>
        public virtual Administrator Owner { get; set; }

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
        /// 实例化一个新的管理员登录记录
        /// </summary>
        public AdministratorLandingRecord()
        {
        }

        /// <summary>
        /// 实例化一个新的管理员登录记录
        /// </summary>
        /// <param name="owner">用户</param>
        /// <param name="ip">网络地址</param>
        /// <param name="address">实际地址</param>
        public AdministratorLandingRecord(Administrator owner, string ip, string address)
        {
            this.Owner = owner;
            this.Ip = ip;
            this.Address = address;
        }

        #endregion
    }
}
