using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace zwg_china.model
{
    /// <summary>
    /// 定义数据库连接对象
    /// </summary>
    public interface IModelToDbContext
    {
        /// <summary>
        /// 获取指定类型的数据模型的存储区
        /// </summary>
        /// <typeparam name="T">目标数据模型的类型</typeparam>
        /// <returns>返回指定类型的数据模型的存储区</returns>
        DbSet<T> Set<T>() where T : class;

        /// <summary>
        /// 将已经进行的改动持久化到数据库
        /// </summary>
        /// <returns>返回操作结果</returns>
        int SaveChanges();
    }
}
