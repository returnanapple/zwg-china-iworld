﻿using System;
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
        IWorld_Client_Token,
        /// <summary>
        /// 用户信息
        /// </summary>
        IWorld_Client_UserInfo,
        /// <summary>
        /// 彩票信息
        /// </summary>
        IWorld_Client_Tickets,
        /// <summary>
        /// 系统设置
        /// </summary>
        IWorld_Client_Setting,
        /// <summary>
        /// 公告
        /// </summary>
        IWorld_Client_Bulletins,
        /// <summary>
        /// 中奖排行
        /// </summary>
        IWorld_Client_TopBouns,
        /// <summary>
        /// 未读通知
        /// </summary>
        IWorld_Client_UnReadNotices
    }
}
