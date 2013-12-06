using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.logic;

namespace zwg_china.service
{
    /// <summary>
    /// 参数集的基类
    /// </summary>
    [DataContract]
    public abstract class ImportBase
    {
        /// <summary>
        /// 身份标识
        /// </summary>
        [DataMember]
        public string Token { get; set; }

        /// <summary>
        /// 判定当前用户是否允许执行操作
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        /// <returns>返回一个布尔值，表示当前用户是否允许执行操作</returns>
        public abstract bool AllowExecute(ModelToDbContext db);
    }
}
