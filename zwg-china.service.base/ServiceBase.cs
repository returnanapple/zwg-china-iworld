using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zwg_china.logic;

namespace zwg_china.service
{
    /// <summary>
    /// 服务的基类
    /// </summary>
    public abstract class ServiceBase
    {
        #region 私有字段

        /// <summary>
        /// 数据库连接对象
        /// </summary>
        protected ModelToDbContext db = new ModelToDbContext();

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的服务的基类
        /// </summary>
        public ServiceBase()
        {

        }

        #endregion
    }
}
