using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using zwg_china.model;

namespace zwg_china.logic
{
    /// <summary>
    /// 用户的登陆信息池
    /// </summary>
    public class AuthorLoginInfoPond
    {
        #region 私有字段

        /// <summary>
        /// 当前已经登陆的用户的登陆信息（私有字段）
        /// </summary>
        static List<AuthorLoginInfo> infos = new List<AuthorLoginInfo>();

        #endregion

        #region 静态属性

        /// <summary>
        /// 当前已经登陆的用户的登陆信息
        /// </summary>
        public static List<AuthorLoginInfo> Infos
        {
            get { return infos; }
        }

        #endregion

        #region 静态方法

        /// <summary>
        /// 声明用户登入
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        /// <param name="userId">用户信息的存储指针</param>
        /// <returns>返回身份标识</returns>
        public static string AddInfo(IModelToDbContextOfAuthor db, int userId)
        {
            lock (infos)
            {
                RemoveInfo(userId);
                AuthorLoginInfo info = new AuthorLoginInfo(db, userId);
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
        public static void KeepHeartbeat(IModelToDbContextOfAuthor db, string token)
        {
            AuthorLoginInfo info = infos.FirstOrDefault(x => x.Token == token);
            if (info == null)
            {
                throw new Exception("指定的身份标识所标示的用户不存在");
            }
            info.KeepHeartbeat(db);
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        /// <param name="token">身份标识</param>
        /// <returns>返回用户信息</returns>
        public static Author GetUserInfo(IModelToDbContextOfAuthor db, string token)
        {
            AuthorLoginInfo info = infos.FirstOrDefault(x => x.Token == token);
            if (info == null)
            {
                throw new Exception("指定的身份标识所标示的用户不存在");
            }
            return info.GetUser(db);
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 移除用户登陆信息
        /// </summary>
        /// <param name="userId">用户的存储指针</param>
        static void RemoveInfo(int userId)
        {
            if (!infos.Any(x => x.UserId == userId)) { return; }
            AuthorLoginInfo info = infos.First(x => x.UserId == userId);
            CallEvent(Logouting, info);
            infos.RemoveAll(x => x.UserId == userId);
            CallEvent(Logouted, info);
        }

        /// <summary>
        /// 定时移除已经超时的用户登陆信息
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
                        RemoveInfo(x.UserId);
                    });
            }
        }
        /// <summary>
        /// 触发事件
        /// </summary>
        /// <param name="_event">事件</param>
        /// <param name="info">数据集</param>
        static void CallEvent(Action<AuthorLoginInfo> _event, AuthorLoginInfo info)
        {
            if (_event != null)
            {
                _event(info);
            }
        }

        #endregion

        #region 静态事件

        /// <summary>
        /// 声明用户登录前触发
        /// </summary>
        public static event Action<AuthorLoginInfo> Logining;

        /// <summary>
        /// 声明用户登陆后触发
        /// </summary>
        public static event Action<AuthorLoginInfo> Logined;

        /// <summary>
        /// 声明用户退出前触发
        /// </summary>
        public static event Action<AuthorLoginInfo> Logouting;

        /// <summary>
        /// 声明用户退出后触发
        /// </summary>
        public static event Action<AuthorLoginInfo> Logouted;

        #endregion
    }
}
