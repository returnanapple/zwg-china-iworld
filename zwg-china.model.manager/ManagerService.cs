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
            monitors.ForEach(x => x.OnSend(info));
        }

        /// <summary>
        /// 呼叫服务
        /// </summary>
        /// <param name="info"></param>
        public static void Call(InfoOnCallOnManagerService info)
        {
            services.ForEach(x => x.OnSend(info));
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
                            ListenAttribute attribute = method.GetCustomAttributes<ListenAttribute>().Single();

                            MonitorInfo mi = new MonitorInfo(attribute.ListenTo, attribute.InterestedAction, attribute.InterestedOrder
                                , (info) =>
                                {
                                    object[] parameters = new object[] { info };
                                    method.Invoke(null, parameters);
                                });
                            monitors.Add(mi);

                        });

                    #endregion

                    #region 注册服务

                    type.GetMethods().Where(method => method.GetCustomAttributes<OnCallAttribute>().Count() > 0)
                        .ToList().ForEach(method =>
                        {
                            OnCallAttribute attribute = method.GetCustomAttributes<OnCallAttribute>().Single();

                            ServiceInfo si = new ServiceInfo(attribute.ListenTo, attribute.InterestedAction
                                , (info) =>
                                {
                                    object[] parameters = new object[] { info };
                                    method.Invoke(null, parameters);
                                });
                            services.Add(si);
                        });

                    #endregion
                });
        }

        #endregion

        #region 内嵌类型

        /// <summary>
        /// 监听信息
        /// </summary>
        class MonitorInfo
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
            /// 满足监听条件的时候所要执行的方法
            /// </summary>
            public Action<InfoOfSendOnManagerService> Execution { get; private set; }

            #endregion

            #region 构造方法

            /// <summary>
            /// 实例化一个新的监听信息
            /// </summary>
            /// <param name="listenTo">监听对象</param>
            /// <param name="interestedAction">感兴趣的动作</param>
            /// <param name="interestedOrder">感兴趣的动作的当前执行顺序</param>
            /// <param name="execution">满足监听条件的时候所要执行的方法</param>
            public MonitorInfo(Type listenTo, object interestedAction, ExecutionOrder interestedOrder, Action<InfoOfSendOnManagerService> execution)
            {
                this.ListenTo = listenTo;
                this.InterestedAction = interestedAction;
                this.InterestedOrder = interestedOrder;
                this.Execution = execution;
            }

            #endregion

            #region 方法

            /// <summary>
            /// 在管理者对象呼叫信使服务的时候将触发
            /// </summary>
            /// <param name="info">传递的数据集</param>
            public void OnSend(InfoOfSendOnManagerService info)
            {
                if (!Accord(info)) { return; }
                if (this.Execution == null) { return; }
                this.Execution(info);
            }

            #endregion

            #region 私有方法

            /// <summary>
            /// 判断目标动作是否符合监听条件
            /// </summary>
            /// <param name="info">数据集</param>
            /// <returns>返回一个布尔值，表示目标动作是否符合监听条件</returns>
            bool Accord(InfoOfSendOnManagerService info)
            {
                bool result = info.Sender == this.ListenTo
                    && info.ExecutionAction == this.InterestedAction
                    && info.ExecutionOrder == this.InterestedOrder;
                return result;
            }

            #endregion
        }

        /// <summary>
        /// 服务信息
        /// </summary>
        class ServiceInfo
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
            /// 满足监听条件的时候所要执行的方法
            /// </summary>
            public Action<InfoOnCallOnManagerService> Execution { get; private set; }

            #endregion

            #region 构造方法

            /// <summary>
            /// 实例化一个新的服务信息
            /// </summary>
            /// <param name="listenTo">监听对象</param>
            /// <param name="interestedAction">感兴趣的动作</param>
            /// <param name="execution">满足监听条件的时候所要执行的方法</param>
            public ServiceInfo(Type listenTo, object interestedAction, Action<InfoOnCallOnManagerService> execution)
            {
                this.ListenTo = listenTo;
                this.InterestedAction = interestedAction;
                this.Execution = execution;
            }

            #endregion

            #region 方法

            /// <summary>
            /// 在管理者对象呼叫信使服务的时候将触发
            /// </summary>
            /// <param name="info">传递的数据集</param>
            public void OnSend(InfoOnCallOnManagerService info)
            {
                if (!Accord(info)) { return; }
                if (this.Execution == null) { return; }
                this.Execution(info);
            }

            #endregion

            #region 私有方法

            /// <summary>
            /// 判断目标动作是否符合监听条件
            /// </summary>
            /// <param name="info">数据集</param>
            /// <returns>返回一个布尔值，表示目标动作是否符合监听条件</returns>
            bool Accord(InfoOnCallOnManagerService info)
            {
                bool result = info.Sender == this.ListenTo
                    && info.ExecutionAction == this.InterestedAction;
                return result;
            }

            #endregion
        }

        #endregion
    }
}
