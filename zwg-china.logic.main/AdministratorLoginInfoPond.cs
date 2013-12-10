using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using zwg_china.model;


namespace zwg_china.logic
{
    /// <summary>
    /// 管理员的登陆信息池
    /// </summary>
    public class AdministratorLoginInfoPond
    {
        #region 私有字段

        /// <summary>
        /// 当前已经登陆的管理员的登陆信息（私有字段）
        /// </summary>
        static List<AdministratorLoginInfo> infos = new List<AdministratorLoginInfo>();

        #endregion

        #region 静态属性

        /// <summary>
        /// 当前已经登陆的管理员的登陆信息
        /// </summary>
        public static List<AdministratorLoginInfo> Infos
        {
            get { return infos; }
        }

        #endregion

        #region 静态方法

        /// <summary>
        /// 声明管理员登入
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        /// <param name="userId">管理员信息的存储指针</param>
        /// <returns>返回身份标识</returns>
        public static string AddInfo(IModelToDbContextOfAdministrator db, int userId)
        {
            lock (infos)
            {
                RemoveInfo(userId);
                AdministratorLoginInfo info = new AdministratorLoginInfo(db, userId);
                CallEvent(Logining, info);
                infos.Add(info);
                CallEvent(Logined, info);
                return info.Token;
            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public static void Initialize()
        {
            Timer timer = new Timer(5000);
            timer.Elapsed += RemoveInfoOnTimeline;
            timer.Start();
        }

        /// <summary>
        /// 保持心跳
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        /// <param name="token">身份标识</param>
        public static void KeepHeartbeat(IModelToDbContextOfAdministrator db, string token)
        {
            AdministratorLoginInfo info = infos.FirstOrDefault(x => x.Token == token);
            if (info == null)
            {
                throw new Exception("指定的身份标识所标示的管理员不存在");
            }
            info.KeepHeartbeat(db);
        }

        /// <summary>
        /// 获取管理员信息
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        /// <param name="token">身份标识</param>
        /// <returns>返回管理员信息</returns>
        public static Administrator GetAdministratorInfo(IModelToDbContextOfAdministrator db, string token)
        {
            AdministratorLoginInfo info = infos.FirstOrDefault(x => x.Token == token);
            if (info == null)
            {
                throw new Exception("指定的身份标识所标示的管理员不存在");
            }
            return info.GetUser(db);
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 移除管理员登陆信息
        /// </summary>
        /// <param name="userId">管理员的存储指针</param>
        static void RemoveInfo(int userId)
        {
            if (!infos.Any(x => x.AdministratorId == userId)) { return; }
            AdministratorLoginInfo info = infos.First(x => x.AdministratorId == userId);
            CallEvent(Logouting, info);
            infos.RemoveAll(x => x.AdministratorId == userId);
            CallEvent(Logouted, info);
        }

        /// <summary>
        /// 定时移除已经超时的管理员登陆信息
        /// </summary>
        /// <param name="sender">触发对象</param>
        /// <param name="e">传递的数据集</param>
        static void RemoveInfoOnTimeline(object sender, ElapsedEventArgs e)
        {
            lock (infos)
            {
                infos.Where(x => x.IsTimeout(e.SignalTime)).ToList()
                    .ForEach(x =>
                    {
                        RemoveInfo(x.AdministratorId);
                    });
            }
        }
        /// <summary>
        /// 触发事件
        /// </summary>
        /// <param name="_event">事件</param>
        /// <param name="info">数据集</param>
        static void CallEvent(Action<AdministratorLoginInfo> _event, AdministratorLoginInfo info)
        {
            if (_event != null)
            {
                _event(info);
            }
        }

        #endregion

        #region 静态事件

        /// <summary>
        /// 声明管理员登录前触发
        /// </summary>
        public static event Action<AdministratorLoginInfo> Logining;

        /// <summary>
        /// 声明管理员登陆后触发
        /// </summary>
        public static event Action<AdministratorLoginInfo> Logined;

        /// <summary>
        /// 声明管理员退出前触发
        /// </summary>
        public static event Action<AdministratorLoginInfo> Logouting;

        /// <summary>
        /// 声明管理员退出后触发
        /// </summary>
        public static event Action<AdministratorLoginInfo> Logouted;

        #endregion
    }
}
