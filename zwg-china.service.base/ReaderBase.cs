using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zwg_china.logic;

namespace zwg_china.service
{
    /// <summary>
    /// 阅读者对象的基类
    /// </summary>
    public class ReaderBase
    {
        #region 保护字段

        protected ModelToDbContext db;

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的阅读者对象
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public ReaderBase(ModelToDbContext db)
        {
            this.db = db;
        }

        #endregion
    }
}
