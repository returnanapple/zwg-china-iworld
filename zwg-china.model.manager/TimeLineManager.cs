using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace zwg_china.model.manager
{
    /// <summary>
    /// 时间线的管理者对象
    /// </summary>
    public class TimelineManager : ManagerBase<IModelToDbContext, TimelineManager.Actions, ModelBase>
    {
        #region 构造方法

        /// <summary>
        /// 实例化一个新的时间线的管理者对象
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public TimelineManager(IModelToDbContext db)
            : base(db)
        {

        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 触发时间线任务
        /// </summary>
        /// <param name="sender">触发对象</param>
        /// <param name="e">传递的数据</param>
        void Spark(object sender, ElapsedEventArgs e)
        {
            SparkEachSecond(e.SignalTime);
            SparkEachMinute(e.SignalTime);
            SparkEachHour(e.SignalTime);
        }

        /// <summary>
        /// 每秒触发
        /// </summary>
        /// <param name="now">当前时间</param>
        void SparkEachSecond(DateTime now)
        {
            SparkArgs args = new SparkArgs { Now = now };
            OnExecuting(Actions.SparkEachSecond, null, args);
            OnExecuted(Actions.SparkEachSecond, null, args);
        }

        /// <summary>
        /// 整分触发
        /// </summary>
        /// <param name="now">当前时间</param>
        void SparkEachMinute(DateTime now)
        {
            if (now.Second != 0) { return; }
            SparkArgs args = new SparkArgs { Now = now };
            OnExecuting(Actions.SparkEachMinute, null, args);
            OnExecuted(Actions.SparkEachMinute, null, args);
        }

        /// <summary>
        /// 整点触发
        /// </summary>
        /// <param name="now">当前时间</param>
        void SparkEachHour(DateTime now)
        {
            if (now.Second != 0 || now.Minute != 0) { return; }
            SparkArgs args = new SparkArgs { Now = now };
            OnExecuting(Actions.SparkEachHour, null, args);
            OnExecuted(Actions.SparkEachHour, null, args);
        }

        #endregion

        #region 方法

        /// <summary>
        /// 初始化
        /// </summary>
        public void Initialize()
        {
            Timer timer = new Timer(1000);
            timer.Elapsed += Spark;
            timer.Start();
        }

        #endregion

        #region 内嵌元素

        #region 枚举

        /// <summary>
        /// 方法
        /// </summary>
        public enum Actions
        {
            /// <summary>
            /// 每秒触发
            /// </summary>
            SparkEachSecond,
            /// <summary>
            /// 整分触发
            /// </summary>
            SparkEachMinute,
            /// <summary>
            /// 整点触发
            /// </summary>
            SparkEachHour
        }

        #endregion

        #region 类

        /// <summary>
        /// 触发时间线时间的相关数据
        /// </summary>
        public class SparkArgs
        {
            /// <summary>
            /// 触发时间
            /// </summary>
            public DateTime Now { get; set; }
        }

        #endregion

        #endregion
    }
}
