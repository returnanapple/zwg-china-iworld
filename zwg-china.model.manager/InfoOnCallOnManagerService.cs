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
        #region 私有字段

        /// <summary>
        /// 提供服务的对象
        /// </summary>
        Type Supplier;

        /// <summary>
        /// 服务名
        /// </summary>
        object ServiceName;

        #endregion

        #region 属性

        /// <summary>
        /// 数据库连接对象
        /// </summary>
        public IModelToDbContext Db { get; set; }

        /// <summary>
        /// 传递的信息
        /// </summary>
        public object Args { get; set; }

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
            this.Db = db;
            this.Supplier = supplier;
            this.ServiceName = serviceName;
            this.Args = args;
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
            return this.Supplier == info.Supplier
                && this.ServiceName.Equals(info.ServiceName);
        }

        #endregion
    }
}
