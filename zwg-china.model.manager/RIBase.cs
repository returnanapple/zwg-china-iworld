using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model.manager
{
    /// <summary>
    /// 注册机的基类
    /// </summary>
    public abstract class RIBase
    {
        /// <summary>
        /// 注册监听信息
        /// </summary>
        /// <typeparam name="TDbContext">所要传递的数据库连接对象的类型</typeparam>
        /// <typeparam name="TActions">所要传递的方法的标识的类型</typeparam>
        /// <typeparam name="TModel">所要传递的数据模型的类型</typeparam>
        /// <param name="listenTo">监听对象</param>
        /// <param name="interestedAction">感兴趣的动作</param>
        /// <param name="interestedOrder">感兴趣的动作的当前执行顺序</param>
        /// <param name="excite">满足监听条件的时候将要激发的方法</param>
        protected void RegisterMonitor<TDbContext, TActions, TModel>(Type listenTo, TActions interestedAction, ExecutionOrder interestedOrder
            , Action<InfoOfSendOnManagerService<TDbContext, TActions, TModel>> excite)
            where TDbContext : IModelToDbContext
            where TActions : struct
            where TModel : ModelBase
        {
            MonitorInfo<TDbContext, TActions, TModel> info
                = new MonitorInfo<TDbContext, TActions, TModel>(listenTo, interestedAction, interestedOrder, excite);
            ManagerService.RegisterMonitor(info);
        }

        /// <summary>
        /// 注册监听信息
        /// </summary>
        /// <typeparam name="TDbContext">所要传递的数据库连接对象的类型</typeparam>
        /// <typeparam name="TActions">所要传递的方法的标识的类型</typeparam>
        /// <typeparam name="TModel">所要传递的数据模型的类型</typeparam>
        /// <param name="listenTo">监听对象</param>
        /// <param name="interestedAction">感兴趣的动作</param>
        /// <param name="interestedOrder">感兴趣的动作的当前执行顺序</param>
        /// <param name="excite">满足监听条件的时候将要激发的方法</param>
        protected void RegisterMonitor<TDbContext, TActions, TModel, TArgs>(Type listenTo, TActions interestedAction, ExecutionOrder interestedOrder
            , Action<InfoOfSendOnManagerService<TDbContext, TActions, TModel, TArgs>> excite)
            where TDbContext : IModelToDbContext
            where TActions : struct
            where TModel : ModelBase
        {
            MonitorInfo<TDbContext, TActions, TModel, TArgs> info
                = new MonitorInfo<TDbContext, TActions, TModel, TArgs>(listenTo, interestedAction, interestedOrder, excite);
            ManagerService.RegisterMonitor(info);
        }

        /// <summary>
        /// 注册服务信息
        /// </summary>
        /// <typeparam name="TDbContext">数据库连接对象的类型</typeparam>
        /// <typeparam name="TServices">服务的标识的类型</typeparam>
        /// <typeparam name="TArgs">传递的信息的类型</typeparam>
        /// <param name="supplier">提供服务的对象</param>
        /// <param name="serviceName">服务名</param>
        /// <param name="excite">调用服务的时候将要执行的方法</param>
        protected void RegisterService<TDbContext, TServices, TArgs>(Type supplier, TServices serviceName
            , Action<InfoOfCallOnManagerService<TDbContext, TServices, TArgs>> excite)
            where TDbContext : IModelToDbContext
            where TServices : struct
        {
            ServiceInfo<TDbContext, TServices, TArgs> info
                = new ServiceInfo<TDbContext, TServices, TArgs>(supplier, serviceName, excite);
            ManagerService.RegisterService(info);
        }

        /// <summary>
        /// 注册
        /// </summary>
        public abstract void Register();
    }
}
