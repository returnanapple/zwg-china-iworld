using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Threading.Tasks;
using zwg_china.service.backstage;

namespace zwg_china.host
{
    public class HostOfBackstageManager
    {
        #region 私有字段

        static bool running = false;

        static List<Type> _types = new List<Type>
        {
            typeof(ActicityService),
            typeof(AuthorService),
            typeof(RecordOfAuthorService),
            typeof(SettingOfAuthorService),
            typeof(AdministratorService),
            typeof(LotteryService),
            typeof(MessageService),
            typeof(ReportService),
            //跨域服务
            typeof(DomainService)
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
            running = true;
        }

        #endregion
    }
}
