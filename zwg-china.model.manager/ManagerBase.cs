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

        #region 方法

        /// <summary>
        /// 创建一个新的数据模型
        /// </summary>
        /// <param name="package">所要用于创建新的数据模型的数据集</param>
        /// <returns>返回创建成功并已经持久化到的数据库的数据模型的实例</returns>
        public T Create(IPackageForCreateModel<T> package)
        {
            package.CheckData(db);
            var entity = package.GetEntity();
            if (entity == null)
            {
                throw new Exception("所要添加到数据库的数据模型不能为空，请检查传入的数据集");
            }

            OnExecuting(DefaultAction.Create, entity);
            db.Set<T>().Add(entity);
            OnExecuted(DefaultAction.Create, entity);
            db.SaveChanges();

            return entity;
        }

        /// <summary>
        /// 更新一个已经存在于数据库的数据模型
        /// </summary>
        /// <param name="package">所要用于更新数据模型的数据集</param>
        public void Update(IPackageForUpdateModel<T> package)
        {
            var entity = db.Set<T>().FirstOrDefault(x => x.Id == package.Id);
            if (entity == null)
            {
                throw new Exception("所提供的存储指针指向的数据模型不存在");
            }
            package.CheckData(db);

            OnExecuting(DefaultAction.Update, entity);
            if (package.IsCustom)
            {
                package.Update(entity);
            }
            else
            {
                List<string> ignoreNames = new List<string> { "Id", "IsCustom" };
                var tProperties = typeof(T).GetProperties();
                Func<PropertyInfo, bool> predicate = x => x.CanRead
                    && !ignoreNames.Contains(x.Name)
                    && tProperties.Any(p => p.Name == x.Name && p.CanWrite);

                package.GetType().GetProperties().Where(predicate).ToList()
                    .ForEach(x =>
                    {
                        var value = x.GetValue(package);
                        tProperties.First(p => p.Name == x.Name).SetValue(entity, value);
                    });
            }
            OnExecuted(DefaultAction.Update, entity);
            db.SaveChanges();
        }

        /// <summary>
        /// 移除指定的数据模型
        /// </summary>
        /// <param name="id">所要移除的数据模型的存储指针</param>
        public virtual void Remove(int id)
        {
            var entity = db.Set<T>().FirstOrDefault(x => x.Id == id);
            if (entity == null)
            {
                throw new Exception("所提供的存储指针指向的数据模型不存在");
            }

            OnExecuting(DefaultAction.Remove, entity);
            db.Set<T>().Remove(entity);
            OnExecuted(DefaultAction.Remove, entity);
            db.SaveChanges();
        }

        #endregion
    }
}
