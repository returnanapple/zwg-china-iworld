using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 记录创建时间和最新修改时间的数据模型的基类的拓展
    /// </summary>
    public static class RecordingTimeModelBaseExtensions
    {
        #region 静态方法

        /// <summary>
        /// 声明数据模型已经被修改
        /// </summary>
        /// <param name="model">目标数据模型</param>
        public static void OnModifiy(this RecordingTimeModelBase model)
        {
            model.ModifiedTime = DateTime.Now;
        }

        #endregion
    }
}
