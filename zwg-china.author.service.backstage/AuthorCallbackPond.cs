using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using zwg_china.logic;
using zwg_china.model;
using zwg_china.model.manager;

namespace zwg_china.service
{
    /// <summary>
    /// 用户模块的回调池
    /// </summary>
    public class AuthorCallbackPond : IRI
    {
        #region 私有字段

        /// <summary>
        /// 已经注册的回调方法的几何
        /// </summary>
        static Dictionary<int, IAuthorCallback> callbacks = new Dictionary<int, IAuthorCallback>();

        #endregion

        #region 静态构造方法

        static AuthorCallbackPond()
        {
            AdministratorLoginInfoPond.Logouting += RemoveTheCallback;
        }

        #endregion

        #region 方法

        /// <summary>
        /// 获取当前程序集
        /// </summary>
        /// <returns></returns>
        public Assembly GetAssembly()
        {
            return Assembly.GetExecutingAssembly();
        }

        #endregion

        #region 静态方法

        /// <summary>
        /// 注册回调
        /// </summary>
        /// <param name="administratorId">管理员的存储指针W</param>
        /// <param name="callback"></param>
        public static void SetIn(int administratorId, IAuthorCallback callback)
        {
            if (callbacks.Any(x => x.Key == administratorId)) { callbacks.Remove(administratorId); }
            callbacks.Add(administratorId, callback);
        }

        /// <summary>
        /// 移除回调
        /// </summary>
        /// <param name="info">数据集</param>
        public static void RemoveTheCallback(AdministratorLoginInfo info)
        {
            if (callbacks.Any(x => x.Key == info.AdministratorId)) { callbacks.Remove(info.AdministratorId); }
        }

        /// <summary>
        /// 触发回调
        /// </summary>
        /// <param name="info">数据集</param>
        [Listen(typeof(WithdrawalsRecordManager), WithdrawalsRecordManager.Actions.Create, ExecutionOrder.After)]
        [Listen(typeof(WithdrawalsRecordManager), WithdrawalsRecordManager.Actions.ChangeStatus, ExecutionOrder.After)]
        public static void Execute(InfoOfSendOnManagerService info)
        {
            IModelToDbContextOfAuthor db = (IModelToDbContextOfAuthor)info.Db;
            WithdrawalsRecord model = (WithdrawalsRecord)info.Model;

            int count = db.WithdrawalsRecords.Count(x => x.Status == WithdrawalsStatus.处理中);
            if (model.Status == WithdrawalsStatus.处理中)
            {
                count++;
            }
            else
            {
                count--;
            }
            lock (callbacks)
            {
                callbacks.Values.ToList().ForEach(callback => callback.SetCountOfWithdrawal(countOfWithdrawal: count));
            }
        }

        #endregion
    }
}
