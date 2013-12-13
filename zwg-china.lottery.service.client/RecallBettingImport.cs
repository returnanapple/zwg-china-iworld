using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.aid;
using zwg_china.logic;
using zwg_china.model;
using zwg_china.model.manager;

namespace zwg_china.service
{
    /// <summary>
    /// 用于撤单的数据集合
    /// </summary>
    [DataContract]
    public class RecallBettingImport : ImportBaseOfLottery, BettingManager.IPackageForRecall
    {
        #region 属性

        /// <summary>
        /// 目标投注记录的存储指针
        /// </summary>
        [DataMember]
        public int BettingId { get; set; }

        #endregion
    }
}
