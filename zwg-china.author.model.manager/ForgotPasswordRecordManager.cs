﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model.manager
{
    /// <summary>
    /// 找回密码记录的管理者对象
    /// </summary>
    public class ForgotPasswordRecordManager : ManagerBase<IModelToDbContextOfAuthor, ForgotPasswordRecordManager.Actions, ForgotPasswordRecord>
    {
        #region 构造方法

        /// <summary>
        /// 实例化一个新的找回密码记录的管理者对象
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public ForgotPasswordRecordManager(IModelToDbContextOfAuthor db)
            : base(db)
        {

        }

        #endregion

        #region 方法

        /// <summary>
        /// 声明一个找回密码记录已经被使用
        /// </summary>
        /// <param name="package">存储指针</param>
        public void Use(IPackageForUse package)
        {
            ForgotPasswordRecord record = db.ForgotPasswordRecords.Find(package.ForgotPasswordRecordId);
            if (record.HadUsed) { return; }
            record.HadUsed = true;
            db.SaveChanges();
        }

        #endregion

        #region 内嵌元素

        #region 枚举

        /// <summary>
        /// 动作
        /// </summary>
        public enum Actions
        {
            /// <summary>
            /// 创建新的找回密码记录
            /// </summary>
            Create,
            /// <summary>
            /// 修改找回密码记录
            /// </summary>
            Update,
            /// <summary>
            /// 移除找回密码记录
            /// </summary>
            Remove
        }

        #endregion

        #region 接口

        /// <summary>
        /// 定义用于声明一个找回密码记录已经被使用的数据集
        /// </summary>
        public interface IPackageForUse
        {
            /// <summary>
            /// 所要操作的找回密码记录的存储指针
            /// </summary>
            int ForgotPasswordRecordId { get; }
        }

        #endregion

        #endregion
    }
}
