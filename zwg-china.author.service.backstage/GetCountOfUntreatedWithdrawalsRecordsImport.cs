using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.model;

namespace zwg_china.service
{
    /// <summary>
    /// 用于获取未处理的提现记录的数据集
    /// </summary>
    [DataContract]
    public class GetCountOfUntreatedWithdrawalsRecordsImport : ImportBaseOfAuthor
    {
        #region 方法

        /// <summary>
        /// 获取未处理的提现记录
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        /// <returns>返回</returns>
        public NormalResult<int> GetCountOfUntreatedWithdrawalsRecords(IModelToDbContextOfAuthor db)
        {
            int count = db.WithdrawalsRecords.Count(x => x.Status == WithdrawalsStatus.处理中);
            return new NormalResult<int>(count);
        }

        #endregion
    }
}
