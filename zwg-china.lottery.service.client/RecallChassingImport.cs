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

namespace zwg_china.service.client
{
    /// <summary>
    /// 用于撤单的数据集
    /// </summary>
    [DataContract]
    public class RecallChassingImport : ImportBaseOfLottery, ChasingManager.IPackageForRecall
    {
        /// <summary>
        /// 目标追号记录的存储指针
        /// </summary>
        [DataMember]
        public int ChasingId { get; set; }
    }
}
