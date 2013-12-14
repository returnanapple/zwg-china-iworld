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

        static List<Type> _types = new List<Type>
        {
            typeof(ActicityService),
            typeof(AuthorService),
            typeof(RecordOfAuthorService),
            typeof(SettingOfAuthorService),
            typeof(AdministratorService),
            typeof(LotteryService),
            typeof(MessageService),
            typeof(ReportService)
        };

        #endregion

        #region 静态方法

        public static void Run()
        {
            Console.WriteLine("后台服务正在启动，请稍候……");
            _types.ForEach(_type =>
                {
                    //ServiceHost host = new ServiceHost(_type);
                    //host.Open();
                });
            System.Threading.Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("后台服务已经运行");
            System.Threading.Thread.Sleep(1000);
            Console.Clear();
        }

        #endregion
    }
}
