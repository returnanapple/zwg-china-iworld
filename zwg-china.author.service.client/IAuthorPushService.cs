using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace zwg_china.service
{
    /// <summary>
    /// 定义前台用户的推送服务
    /// </summary>
    [ServiceContract(CallbackContract = typeof(IAuthorCallback))]
    public interface IAuthorPushService
    {
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="token">身份标识</param>
        /// <returns>返回操作结果</returns>
        [OperationContract]
        NormalResult SetIn(string token);
    }
}
