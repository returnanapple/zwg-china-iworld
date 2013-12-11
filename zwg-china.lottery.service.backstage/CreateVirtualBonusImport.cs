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
    /// 用于创建虚拟排行的数据集
    /// </summary>
    [DataContract]
    public class CreateVirtualBonusImport : ImportBaseOfLottery, IPackageForCreateModel<IModelToDbContextOfLottery, VirtualBonus>
    {
        #region 属性

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

        #region 构造方法

        /// <summary>
        /// 检查输入的数据是否合法
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public void CheckData(IModelToDbContextOfLottery db)
        {
        }

        /// <summary>
        /// 获取数据模型的实体
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public VirtualBonus GetModel(IModelToDbContextOfLottery db)
        {
            LotteryTicket ticket = db.LotteryTickets.Find(this.TicketId);
            return new VirtualBonus(ticket, this.Sum);
        }

        #endregion
    }
}
