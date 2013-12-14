using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.logic;
using zwg_china.model;

namespace zwg_china.service
{
    /// <summary>
    /// 报表模块的用于获取分页列表的参数集的基类
    /// </summary>
    [DataContract]
    public class GetPageListImportBaseOfReport : GetPageListImportBase
    {
        /// <summary>
        /// 自身
        /// </summary>
        public Author Self { get; set; }

        /// <summary>
        /// 判定当前用户是否允许执行操作
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public override void CheckAllowExecuteOrNot(ModelToDbContext db)
        {
            this.Self = AuthorLoginInfoPond.GetUserInfo(db, this.Token);
        }
    }
}
