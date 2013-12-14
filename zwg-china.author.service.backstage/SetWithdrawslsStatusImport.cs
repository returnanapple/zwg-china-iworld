using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.model;
using zwg_china.model.manager;

namespace zwg_china.service.backstage
{
    /// <summary>
    /// 用于设置提现记录的新状态的数据集
    /// </summary>
    [DataContract]
    public class SetWithdrawslsStatusImport : ImportBaseOfAuthor, WithdrawalsRecordManager.IPackageForChangeStatus
    {
        /// <summary>
        /// 所要修改的提现记录的存储指针
        /// </summary>
        [DataMember]
        public int WithdrawalsId { get; set; }

        /// <summary>
        /// 新状态
        /// </summary>
        [DataMember]
        public WithdrawalsStatus NewStatus { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        public string Remark { get; set; }
    }
}
