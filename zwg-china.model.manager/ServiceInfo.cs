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
        /// 服务对象
        /// </summary>
        public Type ListenTo { get; private set; }

        /// <summary>
        /// 感兴趣的动作
        /// </summary>
        public object InterestedAction { get; private set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的服务信息
        /// </summary>
        /// <param name="listenTo">服务对象</param>
        /// <param name="interestedAction">感兴趣的动作</param>
        /// <param name="execution">满足服务条件的时候所要执行的方法</param>
        public ServiceInfo(Type listenTo, object interestedAction)
        {
            this.ListenTo = listenTo;
            this.InterestedAction = interestedAction;
        }

        #endregion
    }

    /// <summary>
    /// 服务信息
    /// </summary>
    /// <typeparam name="TDbContext">数据库连接对象的类型</typeparam>
    /// <typeparam name="TActions">方法的标识的类型</typeparam>
    /// <typeparam name="TModel">数据模型的类型</typeparam>
    public class ServiceInfo<TDbContext, TActions, TModel> : ServiceInfo
        where TDbContext : IModelToDbContext
        where TActions : struct
        where TModel : ModelBase
    {
        #region 属性

        /// <summary>
        /// 满足服务条件的时候将要激发的方法
        /// </summary>
        public Action<InfoOfCallOnManagerService<TDbContext, TActions, TModel>> Excite { get; private set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的服务信息
        /// </summary>
        /// <param name="listenTo">服务对象</param>
        /// <param name="interestedAction">感兴趣的动作</param>
        /// <param name="excite">满足服务条件的时候将要激发的方法</param>
        public ServiceInfo(Type listenTo, object interestedAction
            , Action<InfoOfCallOnManagerService<TDbContext, TActions, TModel>> excite)
            : base(listenTo, interestedAction)
        {
            this.Excite = excite;
        }

        #endregion
    }

    /// <summary>
    /// 服务信息
    /// </summary>
    /// <typeparam name="TDbContext">数据库连接对象的类型</typeparam>
    /// <typeparam name="TActions">方法的标识的类型</typeparam>
    /// <typeparam name="TModel">数据模型的类型</typeparam>
    /// <typeparam name="TArgs">额外附加的信息的类型</typeparam>
    public class ServiceInfo<TDbContext, TActions, TModel, TArgs> : ServiceInfo
        where TDbContext : IModelToDbContext
        where TActions : struct
        where TModel : ModelBase
    {
        #region 属性

        /// <summary>
        /// 满足服务条件的时候将要激发的方法
        /// </summary>
        public Action<InfoOfCallOnManagerService<TDbContext, TActions, TModel, TArgs>> Excite { get; private set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的服务信息
        /// </summary>
        /// <param name="listenTo">服务对象</param>
        /// <param name="interestedAction">感兴趣的动作</param>
        /// <param name="excite">满足服务条件的时候将要激发的方法</param>
        public ServiceInfo(Type listenTo, object interestedAction
            , Action<InfoOfCallOnManagerService<TDbContext, TActions, TModel, TArgs>> excite)
            : base(listenTo, interestedAction)
        {
            this.Excite = excite;
        }

        #endregion
    }
}
