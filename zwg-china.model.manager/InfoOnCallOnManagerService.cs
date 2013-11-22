using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace zwg_china.model.manager
{
    /// <summary>
    /// 用于向信使服务传递信息的数据集（服务）
    /// </summary>
    public class InfoOfCallOnManagerService
    {
        #region 保护字段

        /// <summary>
        /// 数据库连接对象
        /// </summary>
        protected IModelToDbContext db;
        /// <summary>
        /// 触发对象
        /// </summary>
        protected Type sender;
        /// <summary>
        /// 当前执行的动作
        /// </summary>
        protected object executionAction;
        /// <summary>
        /// 当前操作的数据模型的实例
        /// </summary>
        protected object model;
        /// <summary>
        /// 额外的信息
        /// </summary>
        protected object args;

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的用于向信使服务传递信息的数据集（服务）
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        /// <param name="sender">触发对象</param>
        /// <param name="executionAction">当前执行的动作</param>
        /// <param name="model">当前操作的数据模型的实例</param>
        /// <param name="args">额外的信息</param>
        public InfoOfCallOnManagerService(IModelToDbContext db, Type sender, object executionAction, object model, object args)
        {
            this.db = db;
            this.sender = sender;
            this.executionAction = executionAction;
            this.model = model;
            this.args = args;
        }

        #endregion

        #region 方法

        /// <summary>
        /// 判断给定的服务条件是否相符
        /// </summary>
        /// <param name="info">所要进行判断的服务信息</param>
        /// <returns>返回一个布尔值，表示给定的服务条件是否相符</returns>
        public bool Accord(ServiceInfo info)
        {
            return this.sender == info.ListenTo
                && this.executionAction.Equals(info.InterestedAction);
        }

        #endregion
    }

    /// <summary>
    /// 用于向信使服务传递信息的数据集（服务）
    /// </summary>
    /// <typeparam name="TDbContext">所要传递的数据库连接对象的类型</typeparam>
    public class InfoOfCallOnManagerService<TDbContext, TActions, TModel> : InfoOfCallOnManagerService
        where TDbContext : IModelToDbContext
        where TActions : struct
        where TModel : ModelBase
    {
        #region 属性

        /// <summary>
        /// 数据库连接对象
        /// </summary>
        public TDbContext Db
        {
            get { return (TDbContext)db; }
        }

        /// <summary>
        /// 触发对象
        /// </summary>
        public Type Sender
        {
            get { return sender; }
        }

        /// <summary>
        /// 当前执行的动作
        /// </summary>
        public TActions ExecutionAction
        {
            get { return (TActions)executionAction; }
        }

        /// <summary>
        /// 当前操作的数据模型的实例
        /// </summary>
        public TModel Model
        {
            get { return (TModel)model; }
        }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的用于向信使服务传递信息的数据集（服务）
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        /// <param name="sender">触发对象</param>
        /// <param name="executionAction">当前执行的动作</param>
        /// <param name="model">当前操作的数据模型的实例</param>
        /// <param name="args">额外的信息</param>
        public InfoOfCallOnManagerService(TDbContext db, Type sender, TActions executionAction, TModel model, object args = null)
            : base(db, sender, executionAction, model, args)
        {
        }

        #endregion
    }

    /// <summary>
    /// 用于向信使服务传递信息的数据集泛型实现（服务）
    /// </summary>
    /// <typeparam name="TDbContext">所要传递的数据库连接对象的类型</typeparam>
    /// <typeparam name="TArgs">所要额外传递的数据的类型</typeparam>
    public class InfoOfCallOnManagerService<TDbContext, TActions, TModel, TArgs> : InfoOfCallOnManagerService<TDbContext, TActions, TModel>
        where TDbContext : IModelToDbContext
        where TActions : struct
        where TModel : ModelBase
    {
        #region 属性

        /// <summary>
        /// 额外的信息
        /// </summary>
        public TArgs Args
        {
            get { return (TArgs)args; }
        }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的用于向信使服务传递信息的数据集（服务）
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        /// <param name="sender">触发对象</param>
        /// <param name="executionAction">当前执行的动作</param>
        /// <param name="executionOrder">相对于出发动作的操作顺序</param>
        /// <param name="entity">当前操作的数据模型的实例</param>
        /// <param name="args">额外的信息</param>
        public InfoOfCallOnManagerService(TDbContext db, Type sender, TActions executionAction, TModel entity, TArgs args)
            : base(db, sender, executionAction, entity, args)
        {
        }

        #endregion
    }
}
