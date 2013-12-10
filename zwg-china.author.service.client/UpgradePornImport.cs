using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.model;
using zwg_china.model.manager;

namespace zwg_china.service
{
    [DataContract]
    public class UpgradePornImport : ImportBaseOfAuthor, AuthorManager.IPackageForChangeRebate
    {
        /// <summary>
        /// 用户的存储指针
        /// </summary>
        [DataMember]
        public int UserId { get; set; }

        /// <summary>
        /// 新的普通返点
        /// </summary>
        [DataMember]
        public double NewRebate_Normal { get; set; }

        /// <summary>
        /// 新的不定位返点
        /// </summary>
        [DataMember]
        public double NewRebate_IndefinitePosition { get; set; }
    }
}
