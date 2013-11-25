using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model.manager
{
    /// <summary>
    /// 标记这个方法将注册到信使服务的服务池
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class OnCallAttribute : Attribute
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

        #endregion

        #region 构造方法

        /// <summary>
        /// 标记这个方法将注册到信使服务的服务池
        /// </summary>
        /// <param name="supplier">提供服务的对象</param>
        /// <param name="serviceName">服务名</param>
        public OnCallAttribute(Type supplier, object serviceName)
        {
            this.Supplier = supplier;
            this.ServiceName = serviceName;
        }

        #endregion
    }
}
