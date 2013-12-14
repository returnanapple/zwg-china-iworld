using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Threading.Tasks;
using zwg_china.service;

namespace zwg_china.host.backstage
{
    public class HostManager
    {
        #region 私有字段

        List<Type> serviceTypes = new List<Type> { 
            typeof(ActicityService_Backstage),
            typeof(AdministratorService),
            typeof(AuthorService_Backstage), 
            typeof(LotteryService),
            typeof(MessageService),
            typeof(ReportService),};

        #endregion

        #region 方法

        public void Go()
        {
            serviceTypes.ForEach(_type =>
                {
                    ServiceHost host = new ServiceHost(_type);
                    host.Open();
                });
        }

        #endregion
    }
}
