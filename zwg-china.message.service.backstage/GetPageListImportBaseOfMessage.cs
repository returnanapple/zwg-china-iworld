using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.logic;
using zwg_china.model;

namespace zwg_china.service
{
    [DataContract]
    public class GetPageListImportBaseOfMessage : GetPageListImportBase
    {
        /// <summary>
        /// 判定当前用户是否允许执行操作
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public override void CheckAllowExecuteOrNot(ModelToDbContext db)
        {
            Administrator administrator = AdministratorLoginInfoPond.GetAdministratorInfo(db, this.Token);
            if (!administrator.Group.CanViewSettings)
            {
                throw new Exception("没有查看交互信息设置的权限，操作无效");
            }
        }
    }
}
