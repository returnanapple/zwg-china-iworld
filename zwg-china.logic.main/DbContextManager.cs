using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zwg_china.model;

namespace zwg_china.logic
{
    /// <summary>
    /// 数据库连接对象的管理者对象
    /// </summary>
    public class DbContextManager
    {
        public static TDbContext CreateDbContext<TDbContext>()
            where TDbContext : IModelToDbContext
        {
            ModelToDbContext db = new ModelToDbContext();
            if (db is TDbContext)
            {
                object result = db;
                return (TDbContext)result;
            }
            else
            {
                string error = string.Format("未实现 {0} 接口，请检查编码", typeof(TDbContext).FullName);
                throw new Exception(error);
            }
        }
    }
}
