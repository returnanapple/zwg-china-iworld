using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using zwg_china.logic;
using zwg_china.model;

namespace zwg_china.service.client
{
    /// <summary>
    /// 前台用户的回调的管理者对象
    /// </summary>
    public class AuthorCallbackManager
    {
        #region 私有字段

        static Dictionary<int, IAuthorCallback> callbacks = new Dictionary<int, IAuthorCallback>();

        #endregion

        #region 构造方法

        static AuthorCallbackManager()
        {
            AuthorLoginInfoPond.Logouted += RemoveCallback;
            Timer timer = new Timer(10 * 1000);
            timer.Elapsed += CheckLottery;
            timer.Start();
        }
        #region 移除自身

        static void RemoveCallback(AuthorLoginInfo info)
        {
            RemoveCallback(info.UserId);
        }

        #endregion

        #endregion

        #region 方法

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="token">身份标识</param>
        /// <param name="callback">回调</param>
        public static void SetIn(string token, IAuthorCallback callback)
        {
            using (ModelToDbContext db = new ModelToDbContext())
            {
                Author user = AuthorLoginInfoPond.GetUserInfo(db, token);
                lock (callbacks)
                {
                    RemoveCallback(user.Id, "你的账号已经在其他地方登录，你已被迫下线。good luck。");
                    callbacks.Add(user.Id, callback);
                }
            }
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 移除回调
        /// </summary>
        /// <param name="userId">用户的存储指针</param>
        /// <param name="message">所要传递的信息</param>
        static void RemoveCallback(int userId, string message = "令牌超时，请重新登录")
        {
            if (!callbacks.Any(x => x.Key == userId)) { return; }
            lock (callbacks)
            {
                IAuthorCallback callback = callbacks[userId];
                try
                {
                    callbacks[userId].CallWhenLeave(message);
                }
                catch (Exception)
                {

                }
                callbacks.Remove(userId);
            }
        }

        #endregion

        #region 触发回调

        static void CheckLottery(object sender, ElapsedEventArgs e)
        {
            using (ModelToDbContext db = new ModelToDbContext())
            {
                var tickets = db.LotteryTickets.Where(x => x.Hide == false).ToList()
                    .ConvertAll(x => new LotteryTicketExport(x));
                var vKeys = callbacks.Keys.ToList();
                var notices = db.Notices.Where(x => x.IsReaded == false && vKeys.Any(key => key == x.Id)).ToList()
                    .ConvertAll(x => new NoticeExport(x));
                lock (callbacks)
                {
                    callbacks.Keys.ToList()
                        .ForEach(userId =>
                        {
                            try
                            {
                                callbacks[userId].CallWhenLottery(tickets);
                                var myNotices = notices.Where(x => x.OwnerId == userId).ToList();
                                if (myNotices.Count > 0)
                                {
                                    callbacks[userId].CallWhenHaveUnreadNotices(myNotices);
                                    db.Notices.Where(x => myNotices.Any(mn => mn.Id == x.Id)).ToList()
                                        .ForEach(x =>
                                        {
                                            x.IsReaded = true;
                                        });
                                }
                            }
                            catch (Exception)
                            {
                                RemoveCallback(userId);
                            }

                        });
                }
                db.SaveChanges();
            }
        }

        #endregion
    }
}
