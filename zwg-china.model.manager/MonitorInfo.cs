using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model.manager
{
    /// <summary>
    /// 监听信息
    /// </summary>
    public class MonitorInfo
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

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的监听信息
        /// </summary>
        /// <param name="listenTo">监听对象</param>
        /// <param name="interestedAction">感兴趣的动作</param>
        /// <param name="interestedOrder">感兴趣的动作的当前执行顺序</param>
        public MonitorInfo(Type listenTo, object interestedAction, ExecutionOrder interestedOrder)
        {
            this.ListenTo = listenTo;
            this.InterestedAction = interestedAction;
            this.InterestedOrder = interestedOrder;
        }

        #endregion
    }

    /// <summary>
    /// 监听信息
    /// </summary>
    /// <typeparam name="TDbContext">数据库连接对象的类型</typeparam>
    /// <typeparam name="TActions">方法的标识的类型</typeparam>
    /// <typeparam name="TModel">数据模型的类型</typeparam>
    public class MonitorInfo<TDbContext, TActions, TModel> : MonitorInfo
        where TDbContext : IModelToDbContext
        where TActions : struct
        where TModel : ModelBase
    {
        #region 属性

        /// <summary>
        /// 满足监听条件的时候将要激发的方法
        /// </summary>
        public Action<InfoOfSendOnManagerService<TDbContext, TActions, TModel>> Excite { get; private set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的监听信息
        /// </summary>
        /// <param name="listenTo">监听对象</param>
        /// <param name="interestedAction">感兴趣的动作</param>
        /// <param name="interestedOrder">感兴趣的动作的当前执行顺序</param>
        /// <param name="excite">满足监听条件的时候将要激发的方法</param>
        public MonitorInfo(Type listenTo, TActions interestedAction, ExecutionOrder interestedOrder
            , Action<InfoOfSendOnManagerService<TDbContext, TActions, TModel>> excite)
            : base(listenTo, interestedAction, interestedOrder)
        {
            this.Excite = excite;
        }

        #endregion
    }

    /// <summary>
    /// 监听信息
    /// </summary>
    /// <typeparam name="TDbContext">数据库连接对象的类型</typeparam>
    /// <typeparam name="TActions">方法的标识的类型</typeparam>
    /// <typeparam name="TModel">数据模型的类型</typeparam>
    /// <typeparam name="TArgs">额外附加的信息的类型</typeparam>
    public class MonitorInfo<TDbContext, TActions, TModel, TArgs> : MonitorInfo
        where TDbContext : IModelToDbContext
        where TActions : struct
        where TModel : ModelBase
    {
        #region 属性

        /// <summary>
        /// 满足监听条件的时候将要激发的方法
        /// </summary>
        public Action<InfoOfSendOnManagerService<TDbContext, TActions, TModel, TArgs>> Excite { get; private set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的监听信息
        /// </summary>
        /// <param name="listenTo">监听对象</param>
        /// <param name="interestedAction">感兴趣的动作</param>
        /// <param name="interestedOrder">感兴趣的动作的当前执行顺序</param>
        /// <param name="excite">满足监听条件的时候将要激发的方法</param>
        public MonitorInfo(Type listenTo, TActions interestedAction, ExecutionOrder interestedOrder
            , Action<InfoOfSendOnManagerService<TDbContext, TActions, TModel, TArgs>> excite)
            : base(listenTo, interestedAction, interestedOrder)
        {
            this.Excite = excite;
        }

        #endregion
    }
}
