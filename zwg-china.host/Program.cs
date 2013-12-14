using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using zwg_china.logic;

namespace zwg_china.host
{
    class Program
    {
        static DateTime beginTime;

        static void Main(string[] args)
        {
            Console.WriteLine("正在初始化程序，请稍等...");
            DefaultManager.Load();
            Console.WriteLine("初始化完毕，正在启动后台服务，请稍等...");
            HostOfBackstageManager.Run();
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("后台服务已经启动，正在启动前台服务，请稍等...");
            HostOfClientManager.Run();
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("前台服务已经启动，正在执行第一次伺配优化设置，请稍等...");
            System.Threading.Thread.Sleep(1000);

            beginTime = DateTime.Now;
            Timer timer = new Timer(1000);
            timer.Elapsed += timer_Elapsed;
            timer.Start();

            while (true)
            {
                Console.ReadLine();
            }
        }

        static void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Console.Clear();
            Console.WriteLine("服务正常运行中...");
            string v0 = string.Format("前台在线用户：{0}人，后台在线用户：{1}人",
                AuthorLoginInfoPond.Infos.Count,
                AdministratorLoginInfoPond.Infos.Count);
            Console.WriteLine(v0);
            Console.WriteLine();
            Console.WriteLine("软件名：IWorld系列博彩投注平台");
            Console.WriteLine("开发商：紫微阁工作室");
            Console.WriteLine("版本号：v4.6.0.3703");
            Console.WriteLine();
            Console.WriteLine("当前服务地址：net.tcp://192.168.1.130");
            Console.WriteLine("前台服务端口：4511");
            Console.WriteLine("后台服务端口：4512");
            Console.WriteLine();
            string v1 = string.Format("服务开启时间：{0} {1}"
                , beginTime.ToLongDateString()
                , beginTime.ToLongTimeString());
            Console.WriteLine(v1);
            TimeSpan ts = e.SignalTime - beginTime;
            string v2 = string.Format("已运行：{0} 天 {1} 小时 {2} 分 {3} 秒"
                , Math.Round(ts.TotalDays, 0)
                , ts.Hours
                , ts.Minutes
                , ts.Seconds);
            Console.WriteLine(v2);
        }
    }
}
