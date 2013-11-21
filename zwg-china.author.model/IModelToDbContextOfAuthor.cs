using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 定义用户模块的数据库连接对象
    /// </summary>
    public interface IModelToDbContextOfAuthor
    {
        /// <summary>
        /// 用户信息
        /// </summary>
        DbSet<Author> Authors { get; set; }

        /// <summary>
        /// 系统设定的高点号配额方案
        /// </summary>
        DbSet<SystemQuota> SystemQuotas { get; set; }

        /// <summary>
        /// 用户组
        /// </summary>
        DbSet<UserGroup> UserGroups { get; set; }

        /// <summary>
        /// 转账记录
        /// </summary>
        DbSet<TransferRecord> TransferRecords { get; set; }

        /// <summary>
        /// 充值记录
        /// </summary>
        DbSet<RechargeRecord> RechargeRecords { get; set; }

        /// <summary>
        /// 提现记录
        /// </summary>
        DbSet<WithdrawalsRecord> WithdrawalsRecords { get; set; }

        /// <summary>
        /// 帐变记录
        /// </summary>
        DbSet<MoneyChangeRecord> MoneyChangeRecords { get; set; }

        /// <summary>
        /// 用于自动清理用户的条件
        /// </summary>
        DbSet<ConditionOfClearTheUser> ConditionOfClearTheUsers { get; set; }

        /// <summary>
        /// 推广记录
        /// </summary>
        DbSet<SpreadRecord> SpreadRecords { get; set; }

        /// <summary>
        /// 找回密码记录
        /// </summary>
        DbSet<ForgotPasswordRecord> ForgotPasswordRecords { get; set; }

        /// <summary>
        /// 用户登陆记录
        /// </summary>
        DbSet<AuthorLandingRecord> AuthorLandingRecords { get; set; }

        /// <summary>
        /// 返点记录
        /// </summary>
        DbSet<RebateRecord> RebateRecords { get; set; }

        /// <summary>
        /// 佣金记录
        /// </summary>
        DbSet<CommissionRecord> CommissionRecords { get; set; }

        /// <summary>
        /// 分红记录
        /// </summary>
        DbSet<DividendRecord> DividendRecords { get; set; }
    }
}
