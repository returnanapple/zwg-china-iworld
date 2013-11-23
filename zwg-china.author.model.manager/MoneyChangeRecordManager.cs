using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model.manager
{
    /// <summary>
    /// 帐变记录的管理者对象
    /// </summary>
    public class MoneyChangeRecordManager : ManagerBase<IModelToDbContextOfAuthor, MoneyChangeRecordManager.Actions, MoneyChangeRecord>
    {
        #region 构造方法

        /// <summary>
        /// 实例化一个新的帐变记录的管理者对象
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public MoneyChangeRecordManager(IModelToDbContextOfAuthor db)
            : base(db)
        {

        }

        #endregion

        #region 静态方法

        #region 服务

        /// <summary>
        /// 服务：生成对应的帐变记录
        /// </summary>
        /// <param name="info">数据集</param>
        public static void Service_CreateMoneyChangeRecord(InfoOfCallOnManagerService<IModelToDbContextOfAuthor, Services, CreateMoneyChangeRecordArgs> info)
        {
            Author user = info.Db.Authors.FirstOrDefault(x => x.Id == info.Args.UserId);
            if (user == null)
            {
                throw new Exception("提供的存储指针指向的用户不存在，请检查输入");
            }

            MoneyChangeRecord record = new MoneyChangeRecord(user, info.Args.Type, info.Args.Description, info.Args.Income, info.Args.Expenses);
            MoneyChangeRecordManager manager = new MoneyChangeRecordManager(info.Db);
            manager.OnExecuting(Actions.Create, record);
            info.Db.MoneyChangeRecords.Add(record);
            manager.OnExecuted(Actions.Create, record);
        }

        #endregion

        #region 监听

        #endregion

        #endregion

        #region 内嵌元素

        #region 枚举

        /// <summary>
        /// 动作
        /// </summary>
        public enum Actions
        {
            /// <summary>
            /// 创建新用户
            /// </summary>
            Create,
            /// <summary>
            /// 修改用户信息
            /// </summary>
            Update,
            /// <summary>
            /// 移除用户
            /// </summary>
            Remove
        }

        /// <summary>
        /// 服务
        /// </summary>
        public enum Services
        {
            /// <summary>
            /// 生成对应的帐变记录
            /// </summary>
            CreateMoneyChangeRecord
        }

        #endregion

        #region 类型

        /// <summary>
        /// 用于给生成对应的帐变记录的服务提供数据的数据集
        /// </summary>
        public class CreateMoneyChangeRecordArgs
        {
            /// <summary>
            /// 用户的存储指针
            /// </summary>
            public int UserId { get; set; }

            /// <summary>
            /// 帐变类型
            /// </summary>
            public string Type { get; set; }

            /// <summary>
            /// 描述
            /// </summary>
            public string Description { get; set; }

            /// <summary>
            /// 收入
            /// </summary>
            public double Income { get; set; }

            /// <summary>
            /// 支出
            /// </summary>
            public double Expenses { get; set; }
        }

        #endregion

        #endregion
    }
}
