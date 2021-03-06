﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model.manager
{
    /// <summary>
    /// 监听信息
    /// </summary>
    public class MonitorInfo
    {
        #region 属性

        /// <summary>
        /// 监听对象
        /// </summary>
        public Type ListenTo { get; private set; }

        /// <summary>
        /// 感兴趣的动作
        /// </summary>
        public object InterestedAction { get; private set; }

        /// <summary>
        /// 感兴趣的动作的当前执行顺序
        /// </summary>
        public ExecutionOrder InterestedOrder { get; private set; }

        /// <summary>
        /// 满足条件时候将要激发的动作
        /// </summary>
        public Action<InfoOfSendOnManagerService> Excite { get; private set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的监听信息
        /// </summary>
        /// <param name="listenTo">监听对象</param>
        /// <param name="interestedAction">感兴趣的动作</param>
        /// <param name="interestedOrder">感兴趣的动作的当前执行顺序</param>
        /// <param name="excite">满足条件时候将要激发的动作</param>
        public MonitorInfo(Type listenTo, object interestedAction, ExecutionOrder interestedOrder
            , Action<InfoOfSendOnManagerService> excite)
        {
            this.ListenTo = listenTo;
            this.InterestedAction = interestedAction;
            this.InterestedOrder = interestedOrder;
            this.Excite = excite;
        }

        #endregion
    }
}
