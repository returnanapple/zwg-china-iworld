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

        #region 静态方法

        /// <summary>
        /// 初始化信使服务
        /// </summary>
        public static void Initialize()
        {
            monitors.Clear();
            services.Clear();

            string path = string.Format("{0}/Content/LogicAssemblies.xml", AppDomain.CurrentDomain.BaseDirectory);
            XElement doc = XElement.Load(path);
            doc.Elements("assembliy").ToList().ForEach(x => LoadFormAssembly(x.Value));
        }

        /// <summary>
        /// 呼叫监听
        /// </summary>
        /// <param name="info">数据集</param>
        public static void Send(InfoOfSendOnManagerService info)
        {
        }

        /// <summary>
        /// 呼叫服务
        /// </summary>
        /// <param name="info"></param>
        public static void Call(InfoOfCallOnManagerService info)
        {
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 加载程序中声明的监听和服务
        /// </summary>
        /// <param name="assemblyName">程序集的长名称</param>
        static void LoadFormAssembly(string assemblyName)
        {
            Assembly assembly = Assembly.Load(assemblyName);
            assembly.GetTypes().Where(type => type.GetCustomAttributes().Any(attribute => attribute is ListenerAttribute || attribute is ServerAttribute))
                .ToList().ForEach(type =>
                {
                    #region 注册监听

                    type.GetMethods().Where(method => method.GetCustomAttributes<ListenAttribute>().Count() > 0)
                        .ToList().ForEach(method =>
                        {
                            //ListenAttribute attribute = method.GetCustomAttributes<ListenAttribute>().Single();

                            //MonitorInfo mi = new MonitorInfo(attribute.ListenTo, attribute.InterestedAction, attribute.InterestedOrder
                            //    , (info) =>
                            //    {
                            //        object[] parameters = new object[] { info };
                            //        method.Invoke(null, parameters);
                            //    });
                            //monitors.Add(mi);

                        });

                    #endregion

                    #region 注册服务

                    type.GetMethods().Where(method => method.GetCustomAttributes<OnCallAttribute>().Count() > 0)
                        .ToList().ForEach(method =>
                        {
                            //OnCallAttribute attribute = method.GetCustomAttributes<OnCallAttribute>().Single();

                            //ServiceInfo si = new ServiceInfo(attribute.ListenTo, attribute.InterestedAction
                            //    , (info) =>
                            //    {
                            //        object[] parameters = new object[] { info };
                            //        method.Invoke(null, parameters);
                            //    });
                            //services.Add(si);
                        });

                    #endregion
                });
        }

        #endregion
    }
}
