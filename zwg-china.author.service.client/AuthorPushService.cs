using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.service.client
{
    public class AuthorPushService : ServiceBase, IAuthorPushService
    {
        public NormalResult SetIn(string token)
        {
            try
            {
                return new NormalResult();
            }
            catch (Exception ex)
            {
                return new NormalResult(ex.Message);
            }
        }
    }
}
