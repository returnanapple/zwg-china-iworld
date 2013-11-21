using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using zwg_china.model;

namespace zwg_china.model.manager
{
    /// <summary>
    /// 数据模型的管理者对象的基类
    /// </summary>
    public class ManagerBase<T> where T : ModelBase
    {
        #region 私有字段

        /// <summary>
        /// 数据库连接对象
        /// </summary>
        DbContext db = null;

        #endregion

        #region 保护方法

        /// <summary>
        /// 在动作执行前呼叫相关连锁动作
        /// </summary>
        /// <param name="executionAction">即将要执行动作的标识</param>
        /// <param name="entity">当前操作的数据模型的实例</param>
        protected void OnExecuting(object executionAction, object entity)
        {
            InfoOfSendOnManagerService info
                = new InfoOfSendOnManagerService(db, this.GetType(), executionAction, ExecutionOrder.Before, entity);
            ManagerService.Send(info);
        }

        /// <summary>
        /// 在动作执行前呼叫相关连锁动作
        /// </summary>
        /// <typeparam name="T">所要附加的信息的类型</typeparam>
        /// <param name="executionAction">即将要执行动作的标识</param>
        /// <param name="entity">当前操作的数据模型的实例</param>
        /// <param name="entityInfo">附加信息</param>
        protected void OnExecuting<T>(object executionAction, object entity, T entityInfo)
        {
            InfoOfSendOnManagerService<T> info
                = new InfoOfSendOnManagerService<T>(db, this.GetType(), executionAction, ExecutionOrder.Before, entity, entityInfo);
            ManagerService.Send(info);
        }

        /// <summary>
        /// 在动作执行完毕之后呼叫相关连锁动作
        /// </summary>
        /// <param name="executionAction">之前执行的动作的标识</param>
        /// <param name="entity">当前操作的数据模型的实例</param>
        protected void OnExecuted(object executionAction, object entity)
        {
            InfoOfSendOnManagerService info
                = new InfoOfSendOnManagerService(db, this.GetType(), executionAction, ExecutionOrder.After, entity);
            ManagerService.Send(info);
        }

        /// <summary>
        /// 在动作执行完毕之后呼叫相关连锁动作
        /// </summary>
        /// <typeparam name="T">之前执行的动作的标识</typeparam>
        /// <param name="executionAction">即将要执行动作的标识</param>
        /// <param name="entity">当前操作的数据模型的实例</param>
        /// <param name="entityInfo">附加信息</param>
        protected void OnExecuted<T>(object executionAction, object entity, T entityInfo)
        {
            InfoOfSendOnManagerService<T> info
                = new InfoOfSendOnManagerService<T>(db, this.GetType(), executionAction, ExecutionOrder.After, entity, entityInfo);
            ManagerService.Send(info);
        }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的数据模型的管理者对象
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public ManagerBase(DbContext db)
        {
            if (db == null)
            {
                throw new Exception("数据库连接对象不能为空");
            }

            this.db = db;
        }

        #endregion
    }
}
