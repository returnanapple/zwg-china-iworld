using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace zwg_china.service
{
    /// <summary>
    /// 用于获取分页列表的参数集的基类
    /// </summary>
    [DataContract]
    public abstract class GetPageListImportBase : ImportBase
    {
        /// <summary>
        /// 页码
        /// </summary>
        [DataMember]
        public int PageIndex { get; set; }
    }
}
