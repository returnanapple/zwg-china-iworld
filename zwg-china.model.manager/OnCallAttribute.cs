using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model.manager
{
    /// <summary>
    /// 标记该方法将注册到信使服务的服务池
    /// </summary>
    /// <typeparam name="TDbContext">数据库连接对象的类型</typeparam>
    /// <typeparam name="TActions">方法的标识的类型</typeparam>
    /// <typeparam name="TModel">数据模型的类型</typeparam>
    [AttributeUsage(AttributeTargets.Method)]
    public class OnCallAttribute<TDbContext, TActions, TModel> : Attribute
        where TDbContext : IModelToDbContext
        where TActions : struct
        where TModel : ModelBase
    {
        #region 私有字段

        Type listenTo;
        TActions interestedAction;

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的服务信息
        /// </summary>
        /// <param name="listenTo">监听对象</param>
        /// <param name="interestedAction">感兴趣的动作</param>
        public OnCallAttribute(Type listenTo, TActions interestedAction)
        {
            this.listenTo = listenTo;
            this.interestedAction = interestedAction;
        }

        #endregion

        #region 方法

        /// <summary>
        /// 获取对应的服务信息
        /// </summary>
        /// <param name="excite">满足服务条件的时候将要激发的方法</param>
        /// <returns>返回对应的服务信息</returns>
        public ServiceInfo<TDbContext, TActions, TModel> GetMonitorInfo(Action<InfoOfCallOnManagerService<TDbContext, TActions, TModel>> excite)
        {
            ServiceInfo<TDbContext, TActions, TModel> info
                = new ServiceInfo<TDbContext, TActions, TModel>(this.listenTo, this.interestedAction, excite);
            return info;
        }

        #endregion
    }

    /// <summary>
    /// 标记该方法将注册到信使服务的服务池
    /// </summary>
    /// <typeparam name="TDbContext">数据库连接对象的类型</typeparam>
    /// <typeparam name="TActions">方法的标识的类型</typeparam>
    /// <typeparam name="TModel">数据模型的类型</typeparam>
    /// <typeparam name="TArgs">额外附加的信息的类型</typeparam>
    [AttributeUsage(AttributeTargets.Method)]
    public class OnCallAttribute<TDbContext, TActions, TModel, TArgs> : Attribute
        where TDbContext : IModelToDbContext
        where TActions : struct
        where TModel : ModelBase
    {
        #region 私有字段

        Type listenTo;
        TActions interestedAction;

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的服务信息
        /// </summary>
        /// <param name="listenTo">监听对象</param>
        /// <param name="interestedAction">感兴趣的动作</param>
        public OnCallAttribute(Type listenTo, TActions interestedAction)
        {
            this.listenTo = listenTo;
            this.interestedAction = interestedAction;
        }

        #endregion

        #region 方法

        /// <summary>
        /// 获取对应的服务信息
        /// </summary>
        /// <param name="excite">满足服务条件的时候将要激发的方法</param>
        /// <returns>返回对应的服务信息</returns>
        public ServiceInfo<TDbContext, TActions, TModel, TArgs> GetMonitorInfo(Action<InfoOfCallOnManagerService<TDbContext, TActions, TModel, TArgs>> excite)
        {
            ServiceInfo<TDbContext, TActions, TModel, TArgs> info
                = new ServiceInfo<TDbContext, TActions, TModel, TArgs>(this.listenTo, this.interestedAction, excite);
            return info;
        }

        #endregion
    }
}
