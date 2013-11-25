using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace zwg_china.model.manager
{
    /// <summary>
    /// 用于向信使服务传递信息的数据集（监听）
    /// </summary>
    public class InfoOfSendOnManagerService
    {
        #region 私有字段

        /// <summary>
        /// 触发对象
        /// </summary>
        Type Sender;

        /// <summary>
        /// 当前执行的动作
        /// </summary>
        object ActionName;

        /// <summary>
        /// 相对于出发动作的操作顺序
        /// </summary>
        ExecutionOrder Order;

        #endregion

        #region 属性

        /// <summary>
        /// 数据库连接对象
        /// </summary>
        public IModelToDbContext Db { get; set; }

        /// <summary>
        /// 当前操作的数据模型的实例
        /// </summary>
        public object Model { get; set; }

        /// <summary>
        /// 额外的信息
        /// </summary>
        public object Args { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的用于向信使服务传递信息的数据集（监听）
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        /// <param name="sender">触发对象</param>
        /// <param name="actionName">当前执行的动作</param>
        /// <param name="order">相对于出发动作的操作顺序</param>
        /// <param name="model">当前操作的数据模型的实例</param>
        /// <param name="args">额外传递的信息</param>
        public InfoOfSendOnManagerService(IModelToDbContext db, Type sender, object actionName, ExecutionOrder order
            , object model, object args = null)
        {
            this.Db = db;
            this.Sender = sender;
            this.ActionName = actionName;
            this.Order = order;
            this.Model = model;
            this.Args = args;
        }

        #endregion

        #region 方法

        /// <summary>
        /// 判断给定的监听条件是否相符
        /// </summary>
        /// <param name="info">所要进行判断的监听信息</param>
        /// <returns>返回一个布尔值，表示给定的监听条件是否相符</returns>
        public bool Accord(MonitorInfo info)
        {
            return this.Sender == info.ListenTo
                && this.ActionName.Equals(info.InterestedAction)
                && this.Order.Equals(info.InterestedOrder);
        }

        #endregion
    }
}
