using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model.manager
{
    /// <summary>
    /// 标记改方法将注册到信使服务的监听池
    /// </summary>
    /// <typeparam name="TDbContext">数据库连接对象的类型</typeparam>
    /// <typeparam name="TActions">方法的标识的类型</typeparam>
    /// <typeparam name="TModel">数据模型的类型</typeparam>
    [AttributeUsage(AttributeTargets.Method)]
    public class ListenAttribute<TDbContext, TActions, TModel> : Attribute
        where TDbContext : IModelToDbContext
        where TActions : struct
        where TModel : ModelBase
    {
        #region 私有字段

        Type listenTo;
        TActions interestedAction;
        ExecutionOrder interestedOrder;

        #endregion

        #region 构造方法

        /// <summary>
        /// 标记改方法将注册到信使服务的监听池
        /// </summary>
        /// <param name="listenTo">监听对象</param>
        /// <param name="interestedAction">感兴趣的动作</param>
        /// <param name="interestedOrder">感兴趣的动作的当前执行顺序</param>
        public ListenAttribute(Type listenTo, TActions interestedAction, ExecutionOrder interestedOrder)
        {
            this.listenTo = listenTo;
            this.interestedAction = interestedAction;
            this.interestedOrder = interestedOrder;
        }

        #endregion

        #region 方法

        /// <summary>
        /// 获取对应的监听信息
        /// </summary>
        /// <param name="excite">满足监听条件的时候将要激发的方法</param>
        /// <returns>返回对应的监听信息</returns>
        public MonitorInfo<TDbContext, TActions, TModel> GetMonitorInfo(Action<InfoOfSendOnManagerService<TDbContext, TActions, TModel>> excite)
        {
            MonitorInfo<TDbContext, TActions, TModel> info
                = new MonitorInfo<TDbContext, TActions, TModel>(this.listenTo, this.interestedAction, this.interestedOrder, excite);
            return info;
        }

        #endregion
    }

    /// <summary>
    /// 标记改方法将注册到信使服务的监听池
    /// </summary>
    /// <typeparam name="TDbContext">数据库连接对象的类型</typeparam>
    /// <typeparam name="TActions">方法的标识的类型</typeparam>
    /// <typeparam name="TModel">数据模型的类型</typeparam>
    /// <typeparam name="TArgs">额外的信息的类型</typeparam>
    [AttributeUsage(AttributeTargets.Method)]
    public class ListenAttribute<TDbContext, TActions, TModel, TArgs> : Attribute
        where TDbContext : IModelToDbContext
        where TActions : struct
        where TModel : ModelBase
    {
        #region 私有字段

        Type listenTo;
        TActions interestedAction;
        ExecutionOrder interestedOrder;

        #endregion

        #region 构造方法

        /// <summary>
        /// 标记改方法将注册到信使服务的监听池
        /// </summary>
        /// <param name="listenTo">监听对象</param>
        /// <param name="interestedAction">感兴趣的动作</param>
        /// <param name="interestedOrder">感兴趣的动作的当前执行顺序</param>
        public ListenAttribute(Type listenTo, TActions interestedAction, ExecutionOrder interestedOrder)
        {
            this.listenTo = listenTo;
            this.interestedAction = interestedAction;
            this.interestedOrder = interestedOrder;
        }

        #endregion

        #region 方法

        /// <summary>
        /// 获取对应的监听信息
        /// </summary>
        /// <param name="excite">满足监听条件的时候将要激发的方法</param>
        /// <returns>返回对应的监听信息</returns>
        public MonitorInfo<TDbContext, TActions, TModel, TArgs> GetMonitorInfo(Action<InfoOfSendOnManagerService<TDbContext, TActions, TModel, TArgs>> excite)
        {
            MonitorInfo<TDbContext, TActions, TModel, TArgs> info
                = new MonitorInfo<TDbContext, TActions, TModel, TArgs>(this.listenTo, this.interestedAction, this.interestedOrder, excite);
            return info;
        }

        #endregion
    }
}
