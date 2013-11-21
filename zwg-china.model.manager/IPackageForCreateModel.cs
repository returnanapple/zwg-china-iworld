using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using zwg_china.model;

namespace zwg_china.model.manager
{
    /// <summary>
    /// 用于新建数据模型的数据集
    /// </summary>
    /// <typeparam name="T">所要新建的数据模型的类型</typeparam>
    public interface IPackageForCreateModel<T> where T : ModelBase
    {
        /// <summary>
        /// 检查输入的数据是否合法
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        void CheckData(IModelToDbContext db);

        /// <summary>
        /// 获取数据模型的实体
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        T GetModel(IModelToDbContext db);
    }
}
