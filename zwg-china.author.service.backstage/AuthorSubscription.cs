using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using zwg_china.logic;
using zwg_china.model;
using zwg_china.model.manager;

namespace zwg_china.service
{
    /// <summary>
    /// 用户模块的反馈服务
    /// </summary>
    public class AuthorSubscription : ServiceBase, IAuthorSubscription
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
                Administrator a = AdministratorLoginInfoPond.GetAdministratorInfo(db, token);
                IAuthorCallback callback = OperationContext.Current.GetCallbackChannel<IAuthorCallback>();
                AuthorCallbackPond.SetIn(a.Id, callback);
                return new NormalResult();
            }
            catch (Exception ex)
            {
                return new NormalResult(ex.Message);
            }
        }
    }
}
