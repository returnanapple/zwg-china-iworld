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

        #region 初始化

        /// <summary>
        /// 初始化信使服务
        /// </summary>
        /// <param name="assemblies">所有关联的程序集</param>
        public static void Initialize(List<Assembly> assemblies)
        {
            assemblies.ForEach(assembly =>
                {
                    assembly.GetTypes().Where(type => type.GetCustomAttributes().Any(attribute => attribute is ListenerAttribute || attribute is ServerAttribute))
                        .ToList().ForEach(type =>
                        {
                            #region 注册监听

                            type.GetMethods().Where(method => method.GetCustomAttributes().Any(attribute => attribute is ListenAttribute))
                                .ToList().ForEach(method =>
                                {
                                    method.GetCustomAttributes<ListenAttribute>().ToList()
                                        .ForEach(attribute =>
                                        {
                                            MonitorInfo monitor = new MonitorInfo(attribute.ListenTo, attribute.InterestedAction, attribute.InterestedOrder
                                                , (info) =>
                                                {
                                                    object[] objs = new object[] { info };
                                                    method.Invoke(null, objs);
                                                });
                                            monitors.Add(monitor);
                                        });
                                });

                            #endregion

                            #region 注册服务

                            type.GetMethods().Where(method => method.GetCustomAttributes().Any(attribute => attribute is ServerAttribute))
                                .ToList().ForEach(method =>
                                {
                                    OnCallAttribute attribute = method.GetCustomAttributes<OnCallAttribute>().First();
                                    ServiceInfo service = new ServiceInfo(attribute.Supplier, attribute.ServiceName
                                        , (info) =>
                                        {
                                            object[] objs = new object[] { info };
                                            method.Invoke(null, objs);
                                        });
                                    services.Add(service);
                                });

                            #endregion
                        });
                });
        }

        #endregion

        #region 触发

        /// <summary>
        /// 通知监听对象目标动作已经被触发
        /// </summary>
        /// <param name="info">数据集</param>
        public static void Send(InfoOfSendOnManagerService info)
        {
            monitors.Where(monitor => info.Accord(monitor)).ToList().ForEach(monitor => monitor.Excite(info));
        }

        /// <summary>
        /// 调用公开服务
        /// </summary>
        /// <param name="info">数据集</param>
        public static void Call(InfoOfCallOnManagerService info)
        {
            services.Where(service => info.Accord(service)).ToList().ForEach(service => service.Excite(info));
        }

        #endregion
    }
}
