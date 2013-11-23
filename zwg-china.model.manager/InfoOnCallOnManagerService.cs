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
        /// 提供服务的对象
        /// </summary>
        protected Type supplier;
        /// <summary>
        /// 服务名
        /// </summary>
        protected object serviceName;
        /// <summary>
        /// 传递的信息
        /// </summary>
        protected object agrs;

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的用于向信使服务传递信息的数据集（服务）
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        /// <param name="supplier">提供服务的对象</param>
        /// <param name="serviceName">服务名</param>
        /// <param name="args">传递的信息</param>
        public InfoOfCallOnManagerService(IModelToDbContext db, Type supplier, object serviceName, object args)
        {
            this.db = db;
            this.supplier = supplier;
            this.serviceName = serviceName;
            this.agrs = args;
        }

        #endregion

        #region 方法

        /// <summary>
        /// 判断给定的服务签名是否相符
        /// </summary>
        /// <param name="info">所要进行判断的服务信息</param>
        /// <returns>返回一个布尔值，表示给定的服务签名是否相符</returns>
        public bool Accord(ServiceInfo info)
        {
            return this.supplier == info.Supplier
                && this.serviceName.Equals(info.ServiceName);
        }

        #endregion
    }

    /// <summary>
    /// 用于向信使服务传递信息的数据集（服务）
    /// </summary>
    /// <typeparam name="TDbContext">数据库连接对象的类型</typeparam>
    /// <typeparam name="TActions">服务的标识的类型</typeparam>
    /// <typeparam name="TArgs">传递的信息的类型</typeparam>
    public class InfoOfCallOnManagerService<TDbContext, TServices, TArgs> : InfoOfCallOnManagerService
        where TDbContext : IModelToDbContext
        where TServices : struct
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
        /// 提供服务的对象
        /// </summary>
        public Type Supplier
        {
            get { return supplier; }
        }

        /// <summary>
        /// 服务名
        /// </summary>
        public TServices ServiceName
        {
            get { return (TServices)serviceName; }
        }

        /// <summary>
        /// 传递的信息
        /// </summary>
        public TArgs Args
        {
            get { return (TArgs)agrs; }
        }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的用于向信使服务传递信息的数据集（服务）
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        /// <param name="sender">提供服务的对象</param>
        /// <param name="serviceName">服务名</param>
        /// <param name="args">传递的信息</param>
        public InfoOfCallOnManagerService(TDbContext db, Type sender, TServices serviceName, object args)
            : base(db, sender, serviceName, args)
        {
        }

        #endregion
    }
}
