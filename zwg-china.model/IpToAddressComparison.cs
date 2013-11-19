using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 网络地址 - 实际地址的对照
    /// </summary>
    public class IpToAddressComparison : RecordingTimeModelBase
    {
        #region 属性

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
        /// 实例化一个新的网络地址 - 实际地址的对照
        /// </summary>
        public IpToAddressComparison()
        {

        }

        /// <summary>
        /// 实例化一个新的网络地址 - 实际地址的对照
        /// </summary>
        /// <param name="ip">网络地址</param>
        /// <param name="address">实际地址</param>
        public IpToAddressComparison(string ip, string address)
        {
            this.Ip = ip;
            this.Address = address;
        }

        #endregion
    }
}
