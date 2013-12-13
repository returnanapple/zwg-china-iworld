using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 数据模型的基类
    /// </summary>
    public abstract class ModelBase
    {
        #region 属性

        /// <summary>
        /// 存储指针
        /// </summary>
        public int Id { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的数据模型
        /// </summary>
        public ModelBase()
        {
        }

        #endregion

        #region 方法

        /// <summary>
        /// 声明改模型已经被修改
        /// </summary>
        public virtual void OnModify()
        {
        }

        #endregion
    }
}
