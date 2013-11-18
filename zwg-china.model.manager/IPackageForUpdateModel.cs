using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using zwg_china.model;

namespace zwg_china.model.manager
{
    /// <summary>
    /// 定义用于修改
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPackageForUpdateModel<T> where T : ModelBase
    {
        /// <summary>
        /// 存储指针
        /// </summary>
        int Id { get; }

        /// <summary>
        /// 一个布尔值，表示改数据集是否自定义修改数据模型的方法
        /// </summary>
        bool IsCustom { get; }

        /// <summary>
        /// 检查输入的数据是否合法
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        void CheckData(DbContext db);

        /// <summary>
        /// 修改数据模型
        /// </summary>
        /// <param name="model">所要修改的数据模型</param>
        void Update(T model);
    }
}
