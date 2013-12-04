using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Timers;
using zwg_china.model;
using zwg_china.model.manager;

namespace zwg_china.logic
{
    /// <summary>
    /// 数据采集的管理者对象
    /// </summary>
    public class CollectManager
    {
        #region 静态方法

        /// <summary>
        /// 运行
        /// </summary>
        public static void Run()
        {
            Timer timer = new Timer(1000);
            timer.Elapsed += Collect;
            timer.Start();
        }

        /// <summary>
        /// 采集开奖信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void Collect(object sender, ElapsedEventArgs e)
        {
            using (ModelToDbContext db = new ModelToDbContext())
            {
                string key = string.Format("[{0}]CollectionRunning"
                    , typeof(SettingOfBase).FullName);
                SettingDetail sd = db.SettingDetails.FirstOrDefault(x => x.Key == key);
                bool running = sd == null
                    ? false
                    : Convert.ToBoolean(sd.Value);
                if (!running) { return; }
            }

            new Action(CollectCQSSC).BeginInvoke(null, null);
            new Action(CollectJXSSC).BeginInvoke(null, null);
            new Action(CollectXJSSC).BeginInvoke(null, null);
            new Action(CollectGD11X5).BeginInvoke(null, null);
            new Action(Collect11DYJ).BeginInvoke(null, null);
            new Action(CollectFC3D).BeginInvoke(null, null);
            new Action(CollectPL3).BeginInvoke(null, null);
            new Action(CollectSHSSL).BeginInvoke(null, null);
            new Action(CollectJSK3).BeginInvoke(null, null);
            new Action(Collect5FSSC).BeginInvoke(null, null);
            new Action(Collect5F11X5).BeginInvoke(null, null);
        }

        #region 重庆时时彩

        /// <summary>
        /// 采集重庆时时彩的开奖信息
        /// </summary>
        static void CollectCQSSC()
        {
            string ticketName = "重庆时时彩";
            if (CollectingCQSSC) { return; }
            CollectingCQSSC = true;

            string html = GetHtml("http://baidu.lecai.com/lottery/draw/view/200");
            Regex reg = new Regex(@"(\d+)期，开奖结果：(\d+)。");
            Match m = reg.Match(html);
            string issue = m.Groups[1].Value;
            string values = string.Join(",", m.Groups[2].Value.ToArray());
            CreateLoeetry(issue, ticketName, values);

            CollectingCQSSC = false;
        }
        static bool CollectingCQSSC = false;

        #endregion
        #region 江西时时彩

        /// <summary>
        /// 采集江西时时彩的开奖信息
        /// </summary>
        static void CollectJXSSC()
        {
            string ticketName = "江西时时彩";
            if (CollectingJXSSC) { return; }
            CollectingJXSSC = true;

            string html = GetHtml("http://baidu.lecai.com/lottery/draw/view/202");
            Regex reg = new Regex(@"(\d+)期，开奖结果：(\d+)。");
            Match m = reg.Match(html);
            string issue = m.Groups[1].Value;
            string values = string.Join(",", m.Groups[2].Value.ToArray());
            CreateLoeetry(issue, ticketName, values);

            CollectingJXSSC = false;
        }
        static bool CollectingJXSSC = false;

        #endregion
        #region 新疆时时彩

        /// <summary>
        /// 采集新疆时时彩的开奖信息
        /// </summary>
        static void CollectXJSSC()
        {
            string ticketName = "新疆时时彩";
            if (CollectingXJSSC) { return; }
            CollectingXJSSC = true;

            string html = GetHtml("http://www.xjflcp.com/ssc/");
            Regex reg1 = new Regex("<td><a href=\"javascript:detatilssc\\('(\\d+)'\\);");
            string issue = reg1.Match(html).Groups[1].Value;
            Regex reg2 = new Regex("<td class=\"red\"><p>([0-9 ]+)</p></td>");
            string _str = reg2.Match(html).Groups[1].Value;
            string values = string.Join(",", _str.Split(new char[] { ' ' }));
            CreateLoeetry(issue, ticketName, values);

            CollectingXJSSC = false;
        }
        static bool CollectingXJSSC = false;

        #endregion
        #region 广东十一选五

        /// <summary>
        /// 采集广东十一选五的开奖信息
        /// </summary>
        static void CollectGD11X5()
        {
            string ticketName = "广东十一选五";
            if (CollectingGD11X5) { return; }
            CollectingGD11X5 = true;

            string html = GetHtml("http://baidu.lecai.com/lottery/draw/view/23");
            Regex reg = new Regex(@"5(\d+)期，开奖结果：(\d+)。");
            Match m = reg.Match(html);
            string issue = m.Groups[1].Value;
            char[] tVs = m.Groups[2].Value.ToArray();
            List<string> tvList = new List<string>();
            for (int i = 1; i < tVs.Count(); i += 2)
            {
                string t = tVs[i - 1].ToString() + tVs[i].ToString();
                t = Convert.ToInt32(t).ToString();
                tvList.Add(t);
            }
            string values = string.Join(",", tvList);
            CreateLoeetry(issue, ticketName, values);

            CollectingGD11X5 = false;
        }
        static bool CollectingGD11X5 = false;

        #endregion
        #region 十一夺运金

        /// <summary>
        /// 采集十一夺运金的开奖信息
        /// </summary>
        static void Collect11DYJ()
        {
            string ticketName = "十一夺运金";
            if (Collecting11DYJ) { return; }
            Collecting11DYJ = true;

            string html = GetHtml("http://baidu.lecai.com/lottery/draw/view/20");
            Regex reg = new Regex(@"(\d+)期，开奖结果：(\d+)。");
            Match m = reg.Match(html);
            string issue = m.Groups[1].Value;
            char[] tVs = m.Groups[2].Value.ToArray();
            List<string> tvList = new List<string>();
            for (int i = 1; i < tVs.Count(); i += 2)
            {
                string t = tVs[i - 1].ToString() + tVs[i].ToString();
                t = Convert.ToInt32(t).ToString();
                tvList.Add(t);
            }
            string values = string.Join(",", tvList);
            CreateLoeetry(issue, ticketName, values);

            Collecting11DYJ = false;
        }
        static bool Collecting11DYJ = false;

        #endregion
        #region 福彩3D

        /// <summary>
        /// 采集福彩3D的开奖信息
        /// </summary>
        static void CollectFC3D()
        {
            string ticketName = "福彩3D";
            if (CollectingFC3D) { return; }
            CollectingFC3D = true;

            string html = GetHtml("http://baidu.lecai.com/lottery/draw/view/52");
            Regex reg = new Regex(@"3D(\d+)期，开奖结果：(\d+)。");
            Match m = reg.Match(html);
            string issue = m.Groups[1].Value;
            string values = string.Join(",", m.Groups[2].Value.ToArray());
            CreateLoeetry(issue, ticketName, values);

            CollectingFC3D = false;
        }
        static bool CollectingFC3D = false;

        #endregion
        #region 排列三

        /// <summary>
        /// 采集排列三的开奖信息
        /// </summary>
        static void CollectPL3()
        {
            string ticketName = "排列三";
            if (CollectingPL3) { return; }
            CollectingPL3 = true;

            string html = GetHtml("http://baidu.lecai.com/lottery/draw/view/3");
            Regex reg = new Regex(@"3(\d+)期，开奖结果：(\d+)。");
            Match m = reg.Match(html);
            string issue = m.Groups[1].Value;
            string values = string.Join(",", m.Groups[2].Value.ToArray());
            CreateLoeetry(issue, ticketName, values);

            CollectingPL3 = false;
        }
        static bool CollectingPL3 = false;

        #endregion
        #region 上海时时乐

        /// <summary>
        /// 采集上海时时乐的开奖信息
        /// </summary>
        static void CollectSHSSL()
        {
            string ticketName = "上海时时乐";
            if (CollectingSHSSL) { return; }
            CollectingSHSSL = true;

            string html = GetHtml("http://baidu.lecai.com/lottery/draw/view/201");
            Regex reg = new Regex(@"(\d+)期，开奖结果：(\d+)。");
            Match m = reg.Match(html);
            string issue = m.Groups[1].Value;
            string values = string.Join(",", m.Groups[2].Value.ToArray());
            CreateLoeetry(issue, ticketName, values);

            CollectingSHSSL = false;
        }
        static bool CollectingSHSSL = false;

        #endregion
        #region 江苏快三

        /// <summary>
        /// 采集江苏快三的开奖信息
        /// </summary>
        static void CollectJSK3()
        {
            string ticketName = "江苏快三";
            if (CollectingJSK3) { return; }
            CollectingJSK3 = true;

            string html = GetHtml("http://baidu.lecai.com/lottery/draw/view/564");
            Regex reg = new Regex(@"3(\d+)期，开奖结果：(\d+)。");
            Match m = reg.Match(html);
            string issue = m.Groups[1].Value;
            string values = string.Join(",", m.Groups[2].Value.ToArray());
            CreateLoeetry(issue, ticketName, values);

            CollectingJSK3 = false;
        }
        static bool CollectingJSK3 = false;

        #endregion
        #region 五分时时彩

        /// <summary>
        /// 采集五分时时彩数据
        /// </summary>
        private static void Collect5FSSC()
        {
            string ticketName = "五分时时彩";
            DateTime time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            int tP = 0;
            while (time <= DateTime.Now)
            {
                tP++;
                time = time.AddMinutes(5);
            }
            string issue = string.Format("{0}{1}{2}{3}"
                , time.Year.ToString("0000")
                , time.Month.ToString("00")
                , time.Day.ToString("00")
                , tP.ToString("000"));

            List<int> vs = new List<int>();
            Random r = new Random();
            for (int i = 0; i < 5; i++)
            {
                vs.Add(r.Next(0, 9));
            }
            string values = string.Join(",", vs);
            CreateLoeetry(issue, ticketName, values);
        }

        #endregion
        #region 五分十一选五

        /// <summary>
        /// 采集五分十一选五彩数据
        /// </summary>
        private static void Collect5F11X5()
        {
            string ticketName = "五分十一选五";
            DateTime time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            int tP = 0;
            while (time <= DateTime.Now)
            {
                tP++;
                time = time.AddMinutes(5);
            }
            string issue = string.Format("{0}{1}{2}{3}"
                , time.Year.ToString("0000")
                , time.Month.ToString("00")
                , time.Day.ToString("00")
                , tP.ToString("000"));

            List<int> vs = new List<int>();
            Random r = new Random();
            for (int i = 0; i < 5; i++)
            {
                vs.Add(r.Next(1, 11));
            }
            string values = string.Join(",", vs);
            CreateLoeetry(issue, ticketName, values);
        }

        #endregion

        #endregion

        #region 私有方法

        static string GetHtml(string url)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Method = "GET";
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.0)";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream, Encoding.UTF8);
            string html = reader.ReadToEnd();
            stream.Close();

            return html;
        }

        /// <summary>
        /// 创建开奖记录
        /// </summary>
        /// <param name="issue"></param>
        /// <param name="ticketName"></param>
        /// <param name="values"></param>
        static void CreateLoeetry(string issue, string ticketName, string values)
        {
            using (ModelToDbContext db = new ModelToDbContext())
            {
                bool haveTicket = db.LotteryTickets.Any(x => x.RealName == ticketName);
                if (!haveTicket)
                {
                    return;
                }
                bool hadLotteried = db.Lotterys.Any(x => x.Ticket.RealName == ticketName && x.Issue == issue);
                if (hadLotteried)
                {
                    return;
                }

                PackageForCreateLottery package = new PackageForCreateLottery(issue, ticketName, values);
                LotteryManager manager = new LotteryManager(db);
                manager.Create(package);
            }
        }

        #endregion

        #region 内嵌元素

        #region 类

        /// <summary>
        /// 用于新建开奖记录的数据集
        /// </summary>
        class PackageForCreateLottery : IPackageForCreateModel<Lottery>
        {
            #region 属性

            /// <summary>
            /// 期号
            /// </summary>
            public string Issue { get; set; }

            /// <summary>
            /// 彩种
            /// </summary>
            public string TicketName { get; set; }

            /// <summary>
            /// 位
            /// </summary>
            public string Values { get; set; }

            #endregion

            #region 构造方法

            /// <summary>
            /// 实例化一个新的用于新建开奖记录的数据集
            /// </summary>
            /// <param name="issue">期号</param>
            /// <param name="ticketName">彩种</param>
            /// <param name="values">位</param>
            public PackageForCreateLottery(string issue, string ticketName, string values)
            {
                this.Issue = issue;
                this.TicketName = ticketName;
                this.Values = values;
            }

            #endregion

            #region 方法

            /// <summary>
            /// 检查输入的数据是否合法
            /// </summary>
            /// <param name="db">数据库连接对象</param>
            public void CheckData(IModelToDbContext db)
            {
            }

            /// <summary>
            /// 获取数据模型的实体
            /// </summary>
            /// <param name="_db">数据库连接对象</param>
            public Lottery GetModel(IModelToDbContext _db)
            {
                IModelToDbContextOfLottery db = (IModelToDbContextOfLottery)_db;
                LotteryTicket ticket = db.LotteryTickets.FirstOrDefault(x => x.RealName == this.TicketName);
                if (ticket == null)
                {
                    throw new Exception("致命错误，不存在指定的彩票：" + this.TicketName);
                }
                var tSeatNames = ticket.Seats.Split(new char[] { ',' }).ToList();
                var tValues = this.Values.Split(new char[] { ',' }).ToList();
                if (tSeatNames.Count != tValues.Count)
                {
                    string error = string.Format("致命错误，采集到的彩票 {0} 的开奖号码（{1}）于标记的位无法保持一致（{2}）"
                        , this.TicketName
                        , this.Values
                        , ticket.Seats);
                    throw new Exception(error);
                }
                List<LotterySeat> seats = new List<LotterySeat>();
                for (int i = 0; i < tSeatNames.Count; i++)
                {
                    LotterySeat seat = new LotterySeat(tSeatNames[i], tValues[i]);
                    seats.Add(seat);
                }
                return new Lottery(this.Issue, LotterySources.系统采集, null, ticket, seats);
            }

            #endregion
        }

        #endregion

        #endregion
    }
}
