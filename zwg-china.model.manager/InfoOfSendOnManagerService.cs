using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace zwg_china.model.manager
{
    /// <summary>
    /// 用于向信使服务传递信息的数据集
    /// </summary>
    public class InfoOfSendOnManagerService
    {
        #region 属性

        /// <summary>
        /// 数据库连接对象
        /// </summary>
        public DbContext Db { get; private set; }

        /// <summary>
        /// 触发对象
        /// </summary>
        public Type Sender { get; private set; }

        /// <summary>
        /// 当前执行的动作
        /// </summary>
        public object ExecutionAction { get; private set; }

        /// <summary>
        /// 相对于出发动作的操作顺序
        /// </summary>
        public ExecutionOrder ExecutionOrder { get; private set; }

        /// <summary>
        /// 当前操作的数据模型的实例
        /// </summary>
        public object Entity { get; private set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的用于向信使服务传递信息的数据集
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        /// <param name="sender">触发对象</param>
        /// <param name="executionAction">当前执行的动作</param>
        /// <param name="executionOrder">相对于出发动作的操作顺序</param>
        /// <param name="entity">当前操作的数据模型的实例</param>
        public InfoOfSendOnManagerService(DbContext db, Type sender, object executionAction, ExecutionOrder executionOrder
            , object entity)
        {
            this.Db = db;
            this.Sender = sender;
            this.ExecutionAction = executionAction;
            this.ExecutionOrder = executionOrder;
            this.Entity = entity;
        }

        #endregion
    }

    /// <summary>
    /// 用于向信使服务传递信息的数据集泛型实现
    /// </summary>
    /// <typeparam name="T">所要额外传递的数据的类型</typeparam>
    public class InfoOfSendOnManagerService<T> : InfoOfSendOnManagerService
    {
        #region 属性

        /// <summary>
        /// 额外的信息
        /// </summary>
        public T EntityInfo { get; private set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的用于向信使服务传递信息的数据集
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        /// <param name="sender">触发对象</param>
        /// <param name="executionAction">当前执行的动作</param>
        /// <param name="executionOrder">相对于出发动作的操作顺序</param>
        /// <param name="entity">当前操作的数据模型的实例</param>
        /// <param name="entityInfo">额外的信息</param>
        public InfoOfSendOnManagerService(DbContext db, Type sender, object executionAction, ExecutionOrder executionOrder
            , object entity, T entityInfo)
            : base(db, sender, executionAction, executionOrder, entity)
        {
            this.EntityInfo = entityInfo;
        }

        #endregion
    }
}
