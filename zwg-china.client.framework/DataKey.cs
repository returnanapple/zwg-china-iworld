using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.client.framework
{
    /// <summary>
    /// 数据存储的键值
    /// </summary>
    public enum DataKey
    {
        /// <summary>
        /// 身份标识
        /// </summary>
        IWorld_Client_Token = 101,
        /// <summary>
        /// 用户信息
        /// </summary>
        IWorld_Client_UserInfo = 102,
        /// <summary>
        /// 彩票信息
        /// </summary>
        IWorld_Client_Tickets = 103,
        /// <summary>
        /// 系统设置
        /// </summary>
        IWorld_Client_Setting = 104
    }
}
