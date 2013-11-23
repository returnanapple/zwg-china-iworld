using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace zwg_china.model.manager
{
    /// <summary>
    /// 信使服务
    /// </summary>
    public class ManagerService
    {
        #region 私有字段

        /// <summary>
        /// 监听池
        /// </summary>
        static List<MonitorInfo> monitors = new List<MonitorInfo>();

        /// <summary>
        /// 服务池
        /// </summary>
        static List<ServiceInfo> services = new List<ServiceInfo>();

        #endregion

        #region 注册

        /// <summary>
        /// 注册监听信息
        /// </summary>
        /// <param name="info">监听信息</param>
        public static void RegisterMonitor(MonitorInfo info)
        {
            monitors.Add(info);
        }

        /// <summary>
        /// 注册服务信息
        /// </summary>
        /// <param name="info">服务信息</param>
        public static void RegisterMonitor(ServiceInfo info)
        {
            services.Add(info);
        }

        #endregion

        #region 呼叫

        /// <summary>
        /// 呼叫监听
        /// </summary>
        /// <typeparam name="TDbContext">数据库连接对象的类型</typeparam>
        /// <typeparam name="TActions">方法的标识的类型</typeparam>
        /// <typeparam name="TModel">数据模型的类型</typeparam>
        /// <param name="info">数据集</param>
        public static void Send<TDbContext, TActions, TModel>(InfoOfSendOnManagerService<TDbContext, TActions, TModel> info)
            where TDbContext : IModelToDbContext
            where TActions : struct
            where TModel : ModelBase
        {
            monitors.Where(monitor => monitor is MonitorInfo<TDbContext, TActions, TModel>)
                .Where(monitor => info.Accord(monitor))
                .ToList()
                .ForEach(monitor =>
                {
                    MonitorInfo<TDbContext, TActions, TModel> _monitor = (MonitorInfo<TDbContext, TActions, TModel>)monitor;
                    _monitor.Excite(info);
                });
        }

        /// <summary>
        /// 呼叫监听
        /// </summary>
        /// <typeparam name="TDbContext">数据库连接对象的类型</typeparam>
        /// <typeparam name="TActions">方法的标识的类型</typeparam>
        /// <typeparam name="TModel">数据模型的类型</typeparam>
        /// <typeparam name="TArgs">额外的信息的类型</typeparam>
        /// <param name="info">数据集</param>
        public static void Send<TDbContext, TActions, TModel, TArgs>(InfoOfSendOnManagerService<TDbContext, TActions, TModel, TArgs> info)
            where TDbContext : IModelToDbContext
            where TActions : struct
            where TModel : ModelBase
        {
            monitors.Where(monitor => monitor is MonitorInfo<TDbContext, TActions, TModel, TArgs>)
                .Where(monitor => info.Accord(monitor))
                .ToList()
                .ForEach(monitor =>
                {
                    MonitorInfo<TDbContext, TActions, TModel, TArgs> _monitor = (MonitorInfo<TDbContext, TActions, TModel, TArgs>)monitor;
                    _monitor.Excite(info);
                });
        }

        /// <summary>
        /// 呼叫服务
        /// </summary>
        /// <typeparam name="TDbContext">数据库连接对象的类型</typeparam>
        /// <typeparam name="TServices">服务的标识的类型</typeparam>
        /// <typeparam name="TArgs">传递的信息的类型</typeparam>
        /// <param name="info">数据集</param>
        public static void Call<TDbContext, TServices, TArgs>(InfoOfCallOnManagerService<TDbContext, TServices, TArgs> info)
            where TDbContext : IModelToDbContext
            where TServices : struct
        {
            services.Where(service => services is ServiceInfo<TDbContext, TServices, TArgs>)
                .Where(service => info.Accord(service))
                .ToList()
                .ForEach(service =>
                {
                    ServiceInfo<TDbContext, TServices, TArgs> _service = (ServiceInfo<TDbContext, TServices, TArgs>)service;
                    _service.Excite(info);
                });
        }

        #endregion
    }
}
