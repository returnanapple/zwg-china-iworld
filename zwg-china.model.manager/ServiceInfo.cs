﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model.manager
{
    /// <summary>
    /// 服务信息
    /// </summary>
    public class ServiceInfo
    {
        #region 属性

        /// <summary>
        /// 提供服务的对象
        /// </summary>
        public Type Supplier { get; private set; }

        /// <summary>
        /// 服务名
        /// </summary>
        public object ServiceName { get; private set; }

        /// <summary>
        /// 满足条件时候将要激发的动作
        /// </summary>
        public Action<InfoOfCallOnManagerService> Excite { get; private set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的服务信息
        /// </summary>
        /// <param name="supplier">提供服务的对象</param>
        /// <param name="serviceName">服务名</param>
        /// <param name="excite">满足条件时候将要激发的动作</param>
        public ServiceInfo(Type supplier, object serviceName, Action<InfoOfCallOnManagerService> excite)
        {
            this.Supplier = supplier;
            this.ServiceName = serviceName;
            this.Excite = excite;
        }

        #endregion
    }
}
