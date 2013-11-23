using System;
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

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的服务信息
        /// </summary>
        /// <param name="supplier">提供服务的对象</param>
        /// <param name="serviceName">服务名</param>
        public ServiceInfo(Type supplier, object serviceName)
        {
            this.Supplier = supplier;
            this.ServiceName = serviceName;
        }

        #endregion
    }

    /// <summary>
    /// 服务信息
    /// </summary>
    /// <typeparam name="TDbContext">数据库连接对象的类型</typeparam>
    /// <typeparam name="TServices">服务的标识的类型</typeparam>
    /// <typeparam name="TArgs">传递的信息的类型</typeparam>
    public class ServiceInfo<TDbContext, TServices, TArgs> : ServiceInfo
        where TDbContext : IModelToDbContext
        where TServices : struct
    {
        #region 属性

        /// <summary>
        /// 调用服务的时候将要执行的方法
        /// </summary>
        public Action<InfoOfCallOnManagerService<TDbContext, TServices, TArgs>> Excite { get; private set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的服务信息
        /// </summary>
        /// <param name="supplier">提供服务的对象</param>
        /// <param name="serviceName">服务名</param>
        /// <param name="excite">调用服务的时候将要执行的方法</param>
        public ServiceInfo(Type supplier, TServices serviceName
            , Action<InfoOfCallOnManagerService<TDbContext, TServices, TArgs>> excite)
            : base(supplier, serviceName)
        {
            this.Excite = excite;
        }

        #endregion
    }
}
