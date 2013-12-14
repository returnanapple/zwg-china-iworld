using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zwg_china.logic;

namespace zwg_china.host
{
    class Program
    {
        static void Main(string[] args)
        {
            DefaultManager.Load();
            HostOfBackstageManager.Run();
            HostOfClientManager.Run();
            Console.WriteLine("服务正常运行中，如需关闭请直接关闭窗口");
            while (true)
            {
                Console.ReadKey();
            }
        }
    }
}
