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
    /// <typeparam name="TDbContext">所要采用的数据库连接对象的类型</typeparam>
    public class ManagerBase<TDbContext, TActions, TModel>
        where TDbContext : class, IModelToDbContext
        where TActions : struct
        where TModel : ModelBase
    {
        #region 保护字段

        /// <summary>
        /// 数据库连接对象
        /// </summary>
        protected TDbContext db = null;

        #endregion

        #region 保护方法

        /// <summary>
        /// 在动作执行前呼叫相关连锁动作
        /// </summary>
        /// <param name="executionAction">即将要执行动作的标识</param>
        /// <param name="model">当前操作的数据模型的实例</param>
        protected void OnExecuting(TActions executionAction, TModel model)
        {
            InfoOfSendOnManagerService info
                = new InfoOfSendOnManagerService(db, this.GetType(), executionAction, ExecutionOrder.Before, model);
            ManagerService.Send(info);
        }

        /// <summary>
        /// 在动作执行前呼叫相关连锁动作
        /// </summary>
        /// <typeparam name="TArgs">所要附加的信息的类型</typeparam>
        /// <param name="executionAction">即将要执行动作的标识</param>
        /// <param name="model">当前操作的数据模型的实例</param>
        /// <param name="args">附加信息</param>
        protected void OnExecuting<TArgs>(TActions executionAction, TModel model, TArgs args)
        {
            InfoOfSendOnManagerService info
                = new InfoOfSendOnManagerService(db, this.GetType(), executionAction, ExecutionOrder.Before, model, args);
            ManagerService.Send(info);
        }

        /// <summary>
        /// 在动作执行完毕之后呼叫相关连锁动作
        /// </summary>
        /// <param name="executionAction">之前执行的动作的标识</param>
        /// <param name="model">当前操作的数据模型的实例</param>
        protected void OnExecuted(TActions executionAction, TModel model)
        {
            InfoOfSendOnManagerService info
                = new InfoOfSendOnManagerService(db, this.GetType(), executionAction, ExecutionOrder.After, model);
            ManagerService.Send(info);
        }

        /// <summary>
        /// 在动作执行完毕之后呼叫相关连锁动作
        /// </summary>
        /// <typeparam name="TArgs">之前执行的动作的标识</typeparam>
        /// <param name="executionAction">即将要执行动作的标识</param>
        /// <param name="model">当前操作的数据模型的实例</param>
        /// <param name="args">附加信息</param>
        protected void OnExecuted<TArgs>(TActions executionAction, TModel model, TArgs args)
        {
            InfoOfSendOnManagerService info
                = new InfoOfSendOnManagerService(db, this.GetType(), executionAction, ExecutionOrder.After, model, args);
            ManagerService.Send(info);
        }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的数据模型的管理者对象
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public ManagerBase(TDbContext db)
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
        /// 创建一个新的数据模型并持久化到数据库
        /// </summary>
        /// <param name="package">用于创建新的数据模型的数据集</param>
        /// <returns>返回创建成功并已经持久化到数据库的数据模型的实例</returns>
        public TModel Create(IPackageForCreateModel<TModel> package)
        {
            package.CheckData(db);
            TModel model = package.GetModel(db);
            if (model == null)
            {
                string message = string.Format("数据集返回的结果为Null，请检查数据集 {0}", package.GetType().FullName);
                throw new Exception(message);
            }

            TActions action;
            bool gotAction = Enum.TryParse<TActions>("Create", out action);
            if (!gotAction)
            {
                string message = string.Format("传入的 TActions（{0}）：用于标示当前执行方法的枚举 中不包含”Create“项，请检查编码"
                    , typeof(TActions).FullName);
                throw new Exception();
            }

            OnExecuting(action, model);
            db.Set<TModel>().Add(model);
            OnExecuted(action, model);
            db.SaveChanges();

            return model;
        }

        /// <summary>
        /// 修改一个已经持久化的数据模型
        /// </summary>
        /// <param name="package">用于修改数据模型的数据集</param>
        public void Create(IPackageForUpdateModel<TModel> package)
        {
            TModel model = db.Set<TModel>().FirstOrDefault(x => x.Id == package.Id);
            if (model == null)
            {
                string message = string.Format("数据集提供的存储指针指向的对象为Null，请检查数据集 {0}", package.GetType().FullName);
                throw new Exception(message);
            }
            package.CheckData(db);

            TActions action;
            bool gotAction = Enum.TryParse<TActions>("Update", out action);
            if (!gotAction)
            {
                string message = string.Format("传入的 TActions（{0}）：用于标示当前执行方法的枚举 中不包含”Update“项，请检查编码"
                    , typeof(TActions).FullName);
                throw new Exception();
            }

            OnExecuting(action, model);
            package.Update(model);
            OnExecuted(action, model);
            db.SaveChanges();
        }

        /// <summary>
        /// 移除一个已经持久化的数据模型
        /// </summary>
        /// <param name="id">所要移除的数据模型的存储指针</param>
        public virtual void Remove(int id)
        {
            TModel model = db.Set<TModel>().FirstOrDefault(x => x.Id == id);
            if (model == null)
            {
                throw new Exception("存储指针指向的对象为Null，请检查输入");
            }

            TActions action;
            bool gotAction = Enum.TryParse<TActions>("Remove", out action);
            if (!gotAction)
            {
                string message = string.Format("传入的 TActions（{0}）：用于标示当前执行方法的枚举 中不包含”Remove“项，请检查编码"
                    , typeof(TActions).FullName);
                throw new Exception();
            }

            OnExecuting(action, model);
            db.Set<TModel>().Remove(model);
            OnExecuted(action, model);
            db.SaveChanges();
        }

        #endregion
    }
}
