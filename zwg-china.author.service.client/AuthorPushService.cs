using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace zwg_china.service.client
{
    /// <summary>
    /// 前台用户的推送服务
    /// </summary>
    public class AuthorPushService : ServiceBase, IAuthorPushService
    {
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="token">身份标识</param>
        /// <returns>返回操作结果</returns>
        public NormalResult SetIn(string token)
        {
            try
            {
                IAuthorCallback callback = OperationContext.Current.GetCallbackChannel<IAuthorCallback>();
                AuthorCallbackManager.SetIn(token, callback);
                return new NormalResult();
            }
            catch (Exception ex)
            {
                return new NormalResult(ex.Message);
            }
        }
    }
}
