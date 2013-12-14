using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.model;
using zwg_china.model.manager;

namespace zwg_china.service.client
{
    /// <summary>
    /// 用于获取基本的自身数据信息的数据集
    /// </summary>
    [DataContract]
    public class GetBasicSelfInfoImport : ImportBaseOfAuthor
    {
        /// <summary>
        /// 获取基本的自身数据信息
        /// </summary>
        /// <returns>返回基本的自身数据信息</returns>
        public NormalResult<BasicSelfInfoExport> GetBasicSelfInfo()
        {
            BasicSelfInfoExport result = new BasicSelfInfoExport(this.Self);
            return new NormalResult<BasicSelfInfoExport>(result);
        }
    }
}
