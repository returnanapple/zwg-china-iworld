using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using zwg_china.service.client;

namespace zwg_china.host
{
    class HostOfClientManager
    {
        #region 私有字段

        static bool running = false;

        static List<Type> _types = new List<Type>
        {
            typeof(ActicityService),
            typeof(AuthorService),
            typeof(RecordOfAuthorService),
            typeof(AuthorPushService),
            typeof(LotteryService),
            typeof(MessageService),
            typeof(ReportService)
        };

        #endregion

        #region 静态方法

        public static void Run()
        {
            if (running) { return; }
            _types.ForEach(_type =>
            {
                ServiceHost host = new ServiceHost(_type);
                host.Open();
            });
            new AuthorCallbackManager();
            running = true;
        }

        #endregion
    }
}
