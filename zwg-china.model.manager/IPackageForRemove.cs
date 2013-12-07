using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model.manager
{
    /// <summary>
    /// 定义用于移除数据模型的数据集
    /// </summary>
    /// <typeparam name="TDbContext">数据库连接对象的类型</typeparam>
    public interface IPackageForRemove<TDbContext>
        where TDbContext : IModelToDbContext
    {
        /// <summary>
        /// 存储指针
        /// </summary>
        int Id { get; }

        /// <summary>
        /// 检查输入的数据是否合法
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        void CheckData(TDbContext db);
    }
}
