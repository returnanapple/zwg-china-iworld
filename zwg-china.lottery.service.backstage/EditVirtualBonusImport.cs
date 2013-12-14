using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.logic;
using zwg_china.model;
using zwg_china.model.manager;

namespace zwg_china.service.backstage
{
    /// <summary>
    /// 用于修改虚拟排行的数据集
    /// </summary>
    [DataContract]
    public class EditVirtualBonusImport : ImportBaseOfLottery, IPackageForUpdateModel<IModelToDbContextOfLottery, VirtualBonus>
    {
        #region 私有字段

        LotteryTicket ticket = null;

        #endregion

        #region 属性

        /// <summary>
        /// 存储指针
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// 对应的彩票的存储指针
        /// </summary>
        [DataMember]
        public int TicketId { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        [DataMember]
        public double Sum { get; set; }

        #endregion

        #region 方法

        /// <summary>
        /// 检查输入的数据是否合法
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public void CheckData(IModelToDbContextOfLottery db)
        {
            this.ticket = db.LotteryTickets.Find(this.TicketId);
        }

        /// <summary>
        /// 修改数据模型
        /// </summary>
        /// <param name="model">所要修改的数据模型</param>
        public void Update(VirtualBonus model)
        {
            model.Ticket = this.ticket;
            model.Sum = this.Sum;
        }

        #endregion
    }
}
