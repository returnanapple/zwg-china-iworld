using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.logic;
using zwg_china.model;
using zwg_china.model.manager;

namespace zwg_china.service
{
    /// <summary>
    /// 彩票模块的用于获取分页列表的参数集的基类
    /// </summary>
    public class GetPageListImportBaseOfLottery : GetPageListImportBase
    {
        /// <summary>
        /// 判定当前用户是否允许执行操作
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public override void CheckAllowExecuteOrNot(ModelToDbContext db)
        {
            Administrator administrator = AdministratorLoginInfoPond.GetAdministratorInfo(db, this.Token);
            if (!administrator.Group.CanViewTickets)
            {
                throw new Exception("没有修彩票的权限，操作无效");
            }
        }
    }
}
