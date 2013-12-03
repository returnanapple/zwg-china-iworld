using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using zwg_china.model;

namespace zwg_china.logic
{
    /// <summary>
    /// 数据库连接对象
    /// </summary>
    public class ModelToDbContext : DbContext, IModelToDbContext, IModelToDbContextOfActivity, IModelToDbContextOfAdministrtor
        , IModelToDbContextOfAuthor, IModelToDbContextOfBase, IModelToDbContextOfIm, IModelToDbContextOfLottery, IModelToDbContextOfMessage
        , IModelToDbContextOfReport
    {
        #region 属性

        #region 基础

        /// <summary>
        /// 网络 - 实际地址对照的数据存储区
        /// </summary>
        public DbSet<IpToAddressComparison> IpToAddressComparisons { get; set; }

        /// <summary>
        /// 相关设定的明细的数据存储区
        /// </summary>
        public DbSet<SettingDetail> SettingDetails { get; set; }

        /// <summary>
        /// 图片的数据存储区
        /// </summary>
        public DbSet<Picture> Picture { get; set; }

        #endregion
        #region 用户

        /// <summary>
        /// 用户信息的数据存储区
        /// </summary>
        public DbSet<Author> Authors { get; set; }

        /// <summary>
        /// 系统设定的高点号配额方案的数据存储区
        /// </summary>
        public DbSet<SystemQuota> SystemQuotas { get; set; }

        /// <summary>
        /// 用户组的数据存储区
        /// </summary>
        public DbSet<UserGroup> UserGroups { get; set; }

        /// <summary>
        /// 转账记录的数据存储区
        /// </summary>
        public DbSet<TransferRecord> TransferRecords { get; set; }

        /// <summary>
        /// 充值记录的数据存储区
        /// </summary>
        public DbSet<RechargeRecord> RechargeRecords { get; set; }

        /// <summary>
        /// 提现记录的数据存储区
        /// </summary>
        public DbSet<WithdrawalsRecord> WithdrawalsRecords { get; set; }

        /// <summary>
        /// 帐变记录的数据存储区
        /// </summary>
        public DbSet<MoneyChangeRecord> MoneyChangeRecords { get; set; }

        /// <summary>
        /// 推广记录的数据存储区
        /// </summary>
        public DbSet<SpreadRecord> SpreadRecords { get; set; }

        /// <summary>
        /// 找回密码记录的数据存储区
        /// </summary>
        public DbSet<ForgotPasswordRecord> ForgotPasswordRecords { get; set; }

        /// <summary>
        /// 用户登陆记录的数据存储区
        /// </summary>
        public DbSet<AuthorLandingRecord> AuthorLandingRecords { get; set; }

        /// <summary>
        /// 返点记录的数据存储区
        /// </summary>
        public DbSet<RebateRecord> RebateRecords { get; set; }

        /// <summary>
        /// 佣金记录的数据存储区
        /// </summary>
        public DbSet<CommissionRecord> CommissionRecords { get; set; }

        /// <summary>
        /// 分红记录的数据存储区
        /// </summary>
        public DbSet<DividendRecord> DividendRecords { get; set; }

        /// <summary>
        /// 银行账号的数据存储区
        /// </summary>
        public DbSet<SystemBankAccount> SystemBankAccounts { get; set; }

        #endregion
        #region 管理员

        /// <summary>
        /// 管理员的数据存储区
        /// </summary>
        public DbSet<Administrator> Administrators { get; set; }

        /// <summary>
        /// 管理员用户组的数据存储区
        /// </summary>
        public DbSet<AdministratorGroup> AdministratorGroups { get; set; }

        /// <summary>
        /// 管理员登陆记录的数据存储区
        /// </summary>
        public DbSet<AdministratorLandingRecord> AdministratorLandingRecords { get; set; }

        /// <summary>
        /// 操作记录的数据存储区
        /// </summary>
        public DbSet<OperateRecord> OperateRecords { get; set; }

        #endregion
        #region 彩票

        /// <summary>
        /// 彩票的数据存储区
        /// </summary>
        public DbSet<LotteryTicket> LotteryTickets { get; set; }

        /// <summary>
        /// 玩法标签的数据存储区
        /// </summary>
        public DbSet<PlayTag> PlayTags { get; set; }

        /// <summary>
        /// 玩法的数据存储区
        /// </summary>
        public DbSet<HowToPlay> HowToPlays { get; set; }

        /// <summary>
        /// 开奖记录的数据存储区
        /// </summary>
        public DbSet<Lottery> Lotterys { get; set; }

        /// <summary>
        /// 投注的数据存储区
        /// </summary>
        public DbSet<Betting> Bettings { get; set; }

        /// <summary>
        /// 追号的数据存储区
        /// </summary>
        public DbSet<Chasing> Chasings { get; set; }

        /// <summary>
        /// 投注（追号）的数据存储区
        /// </summary>
        public DbSet<BettingWithChasing> BettingWithChasings { get; set; }

        /// <summary>
        /// 虚拟排行的数据存储区
        /// </summary>
        public DbSet<VirtualBonus> VirtualBonuss { get; set; }

        #endregion
        #region 活动

        /// <summary>
        /// 注册奖励的计划的数据存储区
        /// </summary>
        public DbSet<RewardForRegisterPlan> RewardForRegisterPlans { get; set; }

        /// <summary>
        /// 注册奖励的计划的快照的数据存储区
        /// </summary>
        public DbSet<RewardForRegisterSnapshot> RewardForRegisterSnapshots { get; set; }

        /// <summary>
        /// 注册奖励的参与记录的数据存储区
        /// </summary>
        public DbSet<RewardForRegisterRecord> RewardForRegisterRecords { get; set; }

        /// <summary>
        /// 消费奖励的计划的数据存储区
        /// </summary>
        public DbSet<RewardForConsumptionPlan> RewardForConsumptionPlans { get; set; }

        /// <summary>
        /// 消费奖励的计划的快照的数据存储区
        /// </summary>
        public DbSet<RewardForConsumptionSnapshot> RewardForConsumptionSnapshots { get; set; }

        /// <summary>
        /// 消费奖励的参与记录的数据存储区
        /// </summary>
        public DbSet<RewardForConsumptionRecord> RewardForConsumptionRecords { get; set; }

        /// <summary>
        /// 充值奖励的计划的数据存储区
        /// </summary>
        public DbSet<RewardForRechargePlan> RewardForRechargePlans { get; set; }

        /// <summary>
        /// 充值奖励的计划的快照的数据存储区
        /// </summary>
        public DbSet<RewardForRechargeSnapshot> RewardForRechargeSnapshots { get; set; }

        /// <summary>
        /// 充值奖励的参与记录的数据存储区
        /// </summary>
        public DbSet<RewardForRechargeRecord> RewardForRechargeRecords { get; set; }

        /// <summary>
        /// 积分兑换的计划的数据存储区
        /// </summary>
        public DbSet<RedeemPlan> RedeemPlans { get; set; }

        /// <summary>
        /// 积分兑换的计划的快照的数据存储区
        /// </summary>
        public DbSet<RedeemSnapshot> RedeemSnapshots { get; set; }

        /// <summary>
        /// 积分兑换的参与记录的数据存储区
        /// </summary>
        public DbSet<RedeemRecord> RedeemRecords { get; set; }

        #endregion
        #region 交互信息

        /// <summary>
        /// 公告的数据存储区
        /// </summary>
        public DbSet<Bulletin> Bulletins { get; set; }

        /// <summary>
        /// 通知的数据存储区
        /// </summary>
        public DbSet<Notice> Notices { get; set; }

        #endregion
        #region 报表

        /// <summary>
        /// 单日站点统计的数据库存储区
        /// </summary>
        public DbSet<SiteReportForOneDay> SiteReportForOneDays { get; set; }

        /// <summary>
        /// 单月站点统计的数据库存储区
        /// </summary>
        public DbSet<SiteReportForOneMonth> SiteReportForOneMonths { get; set; }

        /// <summary>
        /// 单日个人统计的数据库存储区
        /// </summary>
        public DbSet<RersonalReportForOneDay> RersonalReportForOneDays { get; set; }

        /// <summary>
        /// 单月个人统计的数据库存储区
        /// </summary>
        public DbSet<RersonalReportForOneMonth> RersonalReportForOneMonths { get; set; }

        /// <summary>
        /// 单日团队统计的数据库存储区
        /// </summary>
        public DbSet<TeamReportForOneDay> TeamReportForOneDays { get; set; }

        /// <summary>
        /// 单月团队统计的数据库存储区
        /// </summary>
        public DbSet<TeamReportForOneMonth> TeamReportForOneMonths { get; set; }

        #endregion
        #region IM

        /// <summary>
        /// 聊天信息（IM）的数据存储区
        /// </summary>
        public DbSet<ImMessage> ImMessages { get; set; }

        /// <summary>
        /// 快捷回复（IM）的数据存储区
        /// </summary>
        public DbSet<ImQuickReply> ImQuickReplys { get; set; }

        #endregion

        #endregion

        #region 重写契约

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region 基本

            #region IpToAddressComparison的契约

            modelBuilder.Entity<IpToAddressComparison>().ToTable("zwg-IpToAddressComparison");
            modelBuilder.Entity<IpToAddressComparison>().HasKey(x => x.Id);

            #endregion
            #region Relative的契约

            modelBuilder.Entity<Relative>().ToTable("zwg-Relative");
            modelBuilder.Entity<Relative>().HasKey(x => x.Id);

            #endregion
            #region SettingDetail的契约

            modelBuilder.Entity<SettingDetail>().ToTable("zwg-SettingDetail");
            modelBuilder.Entity<SettingDetail>().HasKey(x => x.Id);

            #endregion
            #region Picture的契约

            modelBuilder.Entity<Picture>().ToTable("zwg-Picture");
            modelBuilder.Entity<Picture>().HasKey(x => x.Id);

            #endregion

            #endregion
            #region 用户

            #region Author的契约

            modelBuilder.Entity<Author>().ToTable("zwg-Author");
            modelBuilder.Entity<Author>().HasKey(x => x.Id);

            modelBuilder.Entity<Author>().HasOptional(x => x.Binding)
                .WithMany()
                .Map(x => x.MapKey("BindingId"));
            modelBuilder.Entity<Author>().HasOptional(x => x.PlayInfo)
                .WithMany()
                .Map(x => x.MapKey("PlayInfoId"));
            modelBuilder.Entity<Author>().HasMany(x => x.ExtraQuotas)
                .WithMany()
                .Map(x => x.ToTable("zwg-Author-ExtraQuotas"));
            modelBuilder.Entity<Author>().HasMany(x => x.SubordinateOfHighRebate)
                .WithMany()
                .Map(x => x.ToTable("zwg-Author-SubordinateOfHighRebate"));

            #endregion
            #region UserPlayInfo的契约

            modelBuilder.Entity<UserPlayInfo>().ToTable("zwg-UserPlayInfo");
            modelBuilder.Entity<UserPlayInfo>().HasKey(x => x.Id);

            #endregion
            #region UserBinding的契约

            modelBuilder.Entity<UserBinding>().ToTable("zwg-UserBinding");
            modelBuilder.Entity<UserBinding>().HasKey(x => x.Id);

            #endregion
            #region SubordinateData的契约

            modelBuilder.Entity<SubordinateData>().ToTable("zwg-SubordinateData");
            modelBuilder.Entity<SubordinateData>().HasKey(x => x.Id);

            #endregion
            #region ExtraQuota的契约

            modelBuilder.Entity<ExtraQuota>().ToTable("zwg-ExtraQuota");
            modelBuilder.Entity<ExtraQuota>().HasKey(x => x.Id);

            #endregion
            #region SystemQuota的契约

            modelBuilder.Entity<SystemQuota>().ToTable("zwg-SystemQuota");
            modelBuilder.Entity<SystemQuota>().HasKey(x => x.Id);

            modelBuilder.Entity<SystemQuota>().HasMany(x => x.Detail)
                .WithMany()
                .Map(x => x.ToTable("zwg-SystemQuota-Detail"));

            #endregion
            #region SystemQuotaDetail的契约

            modelBuilder.Entity<SystemQuotaDetail>().ToTable("zwg-SystemQuotaDetail");
            modelBuilder.Entity<SystemQuotaDetail>().HasKey(x => x.Id);

            #endregion
            #region UserGroup的契约

            modelBuilder.Entity<UserGroup>().ToTable("zwg-UserGroup");
            modelBuilder.Entity<UserGroup>().HasKey(x => x.Id);

            #endregion
            #region TransferRecord的契约

            modelBuilder.Entity<TransferRecord>().ToTable("zwg-TransferRecord");
            modelBuilder.Entity<TransferRecord>().HasKey(x => x.Id);

            #endregion
            #region RechargeRecord的契约

            modelBuilder.Entity<RechargeRecord>().ToTable("zwg-RechargeRecord");
            modelBuilder.Entity<RechargeRecord>().HasKey(x => x.Id);

            modelBuilder.Entity<RechargeRecord>().HasOptional(x => x.Owner)
                .WithMany()
                .Map(x => x.MapKey("OwnerId"));

            #endregion
            #region WithdrawalsRecord的契约

            modelBuilder.Entity<WithdrawalsRecord>().ToTable("zwg-WithdrawalsRecord");
            modelBuilder.Entity<WithdrawalsRecord>().HasKey(x => x.Id);

            modelBuilder.Entity<WithdrawalsRecord>().HasOptional(x => x.Owner)
                .WithMany()
                .Map(x => x.MapKey("OwnerId"));

            #endregion
            #region MoneyChangeRecord的契约

            modelBuilder.Entity<MoneyChangeRecord>().ToTable("zwg-MoneyChangeRecord");
            modelBuilder.Entity<MoneyChangeRecord>().HasKey(x => x.Id);

            modelBuilder.Entity<MoneyChangeRecord>().HasOptional(x => x.Owner)
                .WithMany()
                .Map(x => x.MapKey("OwnerId"));

            #endregion
            #region SpreadRecord的契约

            modelBuilder.Entity<SpreadRecord>().ToTable("zwg-SpreadRecord");
            modelBuilder.Entity<SpreadRecord>().HasKey(x => x.Id);

            modelBuilder.Entity<SpreadRecord>().HasOptional(x => x.Owner)
                .WithMany()
                .Map(x => x.MapKey("OwnerId"));

            #endregion
            #region ForgotPasswordRecord的契约

            modelBuilder.Entity<ForgotPasswordRecord>().ToTable("zwg-ForgotPasswordRecord");
            modelBuilder.Entity<ForgotPasswordRecord>().HasKey(x => x.Id);

            modelBuilder.Entity<ForgotPasswordRecord>().HasOptional(x => x.Owner)
                .WithMany()
                .Map(x => x.MapKey("OwnerId"));

            #endregion
            #region AuthorLandingRecord的契约

            modelBuilder.Entity<AuthorLandingRecord>().ToTable("zwg-AuthorLandingRecord");
            modelBuilder.Entity<AuthorLandingRecord>().HasKey(x => x.Id);

            modelBuilder.Entity<AuthorLandingRecord>().HasOptional(x => x.Owner)
                .WithMany()
                .Map(x => x.MapKey("OwnerId"));

            #endregion
            #region RebateRecord的契约

            modelBuilder.Entity<RebateRecord>().ToTable("zwg-RebateRecord");
            modelBuilder.Entity<RebateRecord>().HasKey(x => x.Id);

            modelBuilder.Entity<RebateRecord>().HasOptional(x => x.Owner)
                .WithMany()
                .Map(x => x.MapKey("OwnerId"));
            modelBuilder.Entity<RebateRecord>().HasOptional(x => x.Source)
                .WithMany()
                .Map(x => x.MapKey("SourceId"));

            #endregion
            #region CommissionRecord的契约

            modelBuilder.Entity<CommissionRecord>().ToTable("zwg-CommissionRecord");
            modelBuilder.Entity<CommissionRecord>().HasKey(x => x.Id);

            modelBuilder.Entity<CommissionRecord>().HasOptional(x => x.Owner)
                .WithMany()
                .Map(x => x.MapKey("OwnerId"));
            modelBuilder.Entity<CommissionRecord>().HasOptional(x => x.Source)
                .WithMany()
                .Map(x => x.MapKey("SourceId"));

            #endregion
            #region DividendRecord的契约

            modelBuilder.Entity<DividendRecord>().ToTable("zwg-DividendRecord");
            modelBuilder.Entity<DividendRecord>().HasKey(x => x.Id);

            modelBuilder.Entity<DividendRecord>().HasOptional(x => x.Owner)
                .WithMany()
                .Map(x => x.MapKey("OwnerId"));

            #endregion
            #region SystemBankAccount的契约

            modelBuilder.Entity<SystemBankAccount>().ToTable("zwg-SystemBankAccount");
            modelBuilder.Entity<SystemBankAccount>().HasKey(x => x.Id);

            #endregion

            #endregion
            #region 管理员

            #region Administrator的契约

            modelBuilder.Entity<Administrator>().ToTable("zwg-Administrator");
            modelBuilder.Entity<Administrator>().HasKey(x => x.Id);

            modelBuilder.Entity<Administrator>().HasOptional(x => x.Group)
                .WithMany()
                .Map(x => x.MapKey("GroupId"));

            #endregion
            #region AdministratorGroup的契约

            modelBuilder.Entity<AdministratorGroup>().ToTable("zwg-AdministratorGroup");
            modelBuilder.Entity<AdministratorGroup>().HasKey(x => x.Id);

            #endregion
            #region AdministratorLandingRecord的契约

            modelBuilder.Entity<AdministratorLandingRecord>().ToTable("zwg-AdministratorLandingRecord");
            modelBuilder.Entity<AdministratorLandingRecord>().HasKey(x => x.Id);

            modelBuilder.Entity<AdministratorLandingRecord>().HasOptional(x => x.Owner)
                .WithMany()
                .Map(x => x.MapKey("OwnerId"));

            #endregion
            #region OperateRecord的契约

            modelBuilder.Entity<OperateRecord>().ToTable("zwg-OperateRecord");
            modelBuilder.Entity<OperateRecord>().HasKey(x => x.Id);

            modelBuilder.Entity<OperateRecord>().HasOptional(x => x.Owner)
                .WithMany()
                .Map(x => x.MapKey("OwnerId"));

            #endregion

            #endregion
            #region 彩票

            #region LotteryTicket的契约

            modelBuilder.Entity<LotteryTicket>().ToTable("zwg-LotteryTicket");
            modelBuilder.Entity<LotteryTicket>().HasKey(x => x.Id);

            modelBuilder.Entity<LotteryTicket>().HasMany(x => x.Tags)
                .WithMany()
                .Map(x => x.ToTable("zwg-LotteryTicket-Tags"));
            modelBuilder.Entity<LotteryTicket>().HasMany(x => x.Times)
                .WithMany()
                .Map(x => x.ToTable("zwg-LotteryTicket-Times"));

            #endregion
            #region LotteryTime的契约

            modelBuilder.Entity<LotteryTime>().ToTable("zwg-LotteryTime");
            modelBuilder.Entity<LotteryTime>().HasKey(x => x.Id);

            #endregion
            #region PlayTag的契约

            modelBuilder.Entity<PlayTag>().ToTable("zwg-PlayTag");
            modelBuilder.Entity<PlayTag>().HasKey(x => x.Id);

            modelBuilder.Entity<PlayTag>().HasOptional(x => x.Ticket)
                .WithMany()
                .Map(x => x.MapKey("TicketId"));
            modelBuilder.Entity<PlayTag>().HasMany(x => x.HowToPlays)
                .WithMany()
                .Map(x => x.ToTable("zwg-PlayTag-HowToPlays"));

            #endregion
            #region HowToPlay的契约

            modelBuilder.Entity<HowToPlay>().ToTable("zwg-HowToPlay");
            modelBuilder.Entity<HowToPlay>().HasKey(x => x.Id);

            modelBuilder.Entity<HowToPlay>().HasOptional(x => x.Tag)
                .WithMany()
                .Map(x => x.MapKey("TagId"));

            #endregion
            #region Lottery的契约

            modelBuilder.Entity<Lottery>().ToTable("zwg-Lottery");
            modelBuilder.Entity<Lottery>().HasKey(x => x.Id);

            modelBuilder.Entity<Lottery>().HasOptional(x => x.Operator)
                .WithMany()
                .Map(x => x.MapKey("OperatorId"));
            modelBuilder.Entity<Lottery>().HasOptional(x => x.Ticket)
                .WithMany()
                .Map(x => x.MapKey("TicketId"));
            modelBuilder.Entity<Lottery>().HasMany(x => x.Seats)
                .WithMany()
                .Map(x => x.ToTable("zwg-Lottery-Seats"));

            #endregion
            #region LotterySeat的契约

            modelBuilder.Entity<LotterySeat>().ToTable("zwg-LotterySeat");
            modelBuilder.Entity<LotterySeat>().HasKey(x => x.Id);

            #endregion
            #region Betting的契约

            modelBuilder.Entity<Betting>().ToTable("zwg-Betting");
            modelBuilder.Entity<Betting>().HasKey(x => x.Id);

            modelBuilder.Entity<Betting>().HasOptional(x => x.Owner)
                .WithMany()
                .Map(x => x.MapKey("OwnerId"));
            modelBuilder.Entity<Betting>().HasOptional(x => x.HowToPlay)
                .WithMany()
                .Map(x => x.MapKey("HowToPlayId"));
            modelBuilder.Entity<Betting>().HasMany(x => x.Seats)
                .WithMany()
                .Map(x => x.ToTable("zwg-Betting-Seats"));

            #endregion
            #region BettingSeat的契约

            modelBuilder.Entity<BettingSeat>().ToTable("zwg-BettingSeat");
            modelBuilder.Entity<BettingSeat>().HasKey(x => x.Id);

            #endregion
            #region Chasing的契约

            modelBuilder.Entity<Chasing>().ToTable("zwg-Chasing");
            modelBuilder.Entity<Chasing>().HasKey(x => x.Id);

            modelBuilder.Entity<Chasing>().HasOptional(x => x.Owner)
                .WithMany()
                .Map(x => x.MapKey("OwnerId"));
            modelBuilder.Entity<Chasing>().HasOptional(x => x.HowToPlay)
                .WithMany()
                .Map(x => x.MapKey("HowToPlayId"));
            modelBuilder.Entity<Chasing>().HasMany(x => x.Seats)
                .WithMany()
                .Map(x => x.ToTable("zwg-Chasing-Seats"));

            #endregion
            #region ChasingSeat的契约

            modelBuilder.Entity<ChasingSeat>().ToTable("zwg-ChasingSeat");
            modelBuilder.Entity<ChasingSeat>().HasKey(x => x.Id);

            #endregion
            #region BettingWithChasing的契约

            modelBuilder.Entity<BettingWithChasing>().ToTable("zwg-BettingWithChasing");
            modelBuilder.Entity<BettingWithChasing>().HasKey(x => x.Id);

            modelBuilder.Entity<BettingWithChasing>().HasOptional(x => x.Chasing)
                .WithMany()
                .Map(x => x.MapKey("ChasingId"));

            #endregion
            #region VirtualBonus的契约

            modelBuilder.Entity<VirtualBonus>().ToTable("zwg-VirtualBonus");
            modelBuilder.Entity<VirtualBonus>().HasKey(x => x.Id);

            modelBuilder.Entity<VirtualBonus>().HasOptional(x => x.Ticket)
                .WithMany()
                .Map(x => x.MapKey("TicketId"));

            #endregion

            #endregion
            #region 活动

            #region RewardForRegisterPlan的契约

            modelBuilder.Entity<RewardForRegisterPlan>().ToTable("zwg-RewardForRegisterPlan");
            modelBuilder.Entity<RewardForRegisterPlan>().HasKey(x => x.Id);

            #endregion
            #region RewardForRegisterSnapshot的契约

            modelBuilder.Entity<RewardForRegisterSnapshot>().ToTable("zwg-RewardForRegisterSnapshot");
            modelBuilder.Entity<RewardForRegisterSnapshot>().HasKey(x => x.Id);

            #endregion
            #region RewardForRegisterRecord的契约

            modelBuilder.Entity<RewardForRegisterRecord>().ToTable("zwg-RewardForRegisterRecord");
            modelBuilder.Entity<RewardForRegisterRecord>().HasKey(x => x.Id);

            modelBuilder.Entity<RewardForRegisterRecord>().HasOptional(x => x.Owner)
                .WithMany()
                .Map(x => x.MapKey("OwnerId"));
            modelBuilder.Entity<RewardForRegisterRecord>().HasOptional(x => x.Plan)
                .WithMany()
                .Map(x => x.MapKey("PlanId"));

            #endregion

            #region RewardForConsumptionPlan的契约

            modelBuilder.Entity<RewardForConsumptionPlan>().ToTable("zwg-RewardForConsumptionPlan");
            modelBuilder.Entity<RewardForConsumptionPlan>().HasKey(x => x.Id);

            modelBuilder.Entity<RewardForConsumptionPlan>().HasMany(x => x.Details)
                .WithMany()
                .Map(x => x.ToTable("zwg-RewardForConsumptionPlan-Details"));

            #endregion
            #region RewardForConsumptionPlanDetail的契约

            modelBuilder.Entity<RewardForConsumptionPlanDetail>().ToTable("zwg-RewardForConsumptionPlanDetail");
            modelBuilder.Entity<RewardForConsumptionPlanDetail>().HasKey(x => x.Id);

            #endregion
            #region RewardForConsumptionSnapshot的契约

            modelBuilder.Entity<RewardForConsumptionSnapshot>().ToTable("zwg-RewardForConsumptionSnapshot");
            modelBuilder.Entity<RewardForConsumptionSnapshot>().HasKey(x => x.Id);

            modelBuilder.Entity<RewardForConsumptionSnapshot>().HasMany(x => x.Details)
                .WithMany()
                .Map(x => x.ToTable("zwg-RewardForConsumptionSnapshot-Details"));

            #endregion
            #region RewardForConsumptionSnapshotDetail的契约

            modelBuilder.Entity<RewardForConsumptionSnapshotDetail>().ToTable("zwg-RewardForConsumptionSnapshotDetail");
            modelBuilder.Entity<RewardForConsumptionSnapshotDetail>().HasKey(x => x.Id);

            #endregion
            #region RewardForConsumptionRecord的契约

            modelBuilder.Entity<RewardForConsumptionRecord>().ToTable("zwg-RewardForConsumptionRecord");
            modelBuilder.Entity<RewardForConsumptionRecord>().HasKey(x => x.Id);

            modelBuilder.Entity<RewardForConsumptionRecord>().HasOptional(x => x.Owner)
                .WithMany()
                .Map(x => x.MapKey("OwnerId"));
            modelBuilder.Entity<RewardForConsumptionRecord>().HasOptional(x => x.Plan)
                .WithMany()
                .Map(x => x.MapKey("PlanId"));
            modelBuilder.Entity<RewardForConsumptionRecord>().HasOptional(x => x.ValidDetail)
                .WithMany()
                .Map(x => x.MapKey("ValidDetailId"));

            #endregion

            #region RewardForRechargePlan的契约

            modelBuilder.Entity<RewardForRechargePlan>().ToTable("zwg-RewardForRechargePlan");
            modelBuilder.Entity<RewardForRechargePlan>().HasKey(x => x.Id);

            modelBuilder.Entity<RewardForRechargePlan>().HasMany(x => x.Details)
                .WithMany()
                .Map(x => x.ToTable("zwg-RewardForRechargePlan-Details"));

            #endregion
            #region RewardForRechargePlanDetail的契约

            modelBuilder.Entity<RewardForRechargePlanDetail>().ToTable("zwg-RewardForRechargePlanDetail");
            modelBuilder.Entity<RewardForRechargePlanDetail>().HasKey(x => x.Id);

            #endregion
            #region RewardForRechargeSnapshot的契约

            modelBuilder.Entity<RewardForRechargeSnapshot>().ToTable("zwg-RewardForRechargeSnapshot");
            modelBuilder.Entity<RewardForRechargeSnapshot>().HasKey(x => x.Id);

            modelBuilder.Entity<RewardForRechargeSnapshot>().HasMany(x => x.Details)
                .WithMany()
                .Map(x => x.ToTable("zwg-RewardForRechargeSnapshot-Details"));

            #endregion
            #region RewardForRechargeSnapshotDetail的契约

            modelBuilder.Entity<RewardForRechargeSnapshotDetail>().ToTable("zwg-RewardForRechargeSnapshotDetail");
            modelBuilder.Entity<RewardForRechargeSnapshotDetail>().HasKey(x => x.Id);

            #endregion
            #region RewardForRechargeRecord的契约

            modelBuilder.Entity<RewardForRechargeRecord>().ToTable("zwg-RewardForRechargeRecord");
            modelBuilder.Entity<RewardForRechargeRecord>().HasKey(x => x.Id);

            modelBuilder.Entity<RewardForRechargeRecord>().HasOptional(x => x.Owner)
                .WithMany()
                .Map(x => x.MapKey("OwnerId"));
            modelBuilder.Entity<RewardForRechargeRecord>().HasOptional(x => x.Plan)
                .WithMany()
                .Map(x => x.MapKey("PlanId"));
            modelBuilder.Entity<RewardForRechargeRecord>().HasOptional(x => x.ValidDetail)
                .WithMany()
                .Map(x => x.MapKey("ValidDetailId"));

            #endregion

            #region RedeemPlan的契约

            modelBuilder.Entity<RedeemPlan>().ToTable("zwg-RedeemPlan");
            modelBuilder.Entity<RedeemPlan>().HasKey(x => x.Id);

            #endregion
            #region RedeemSnapshot的契约

            modelBuilder.Entity<RedeemSnapshot>().ToTable("zwg-RedeemSnapshot");
            modelBuilder.Entity<RedeemSnapshot>().HasKey(x => x.Id);

            #endregion
            #region RedeemRecord的契约

            modelBuilder.Entity<RedeemRecord>().ToTable("zwg-RedeemRecord");
            modelBuilder.Entity<RedeemRecord>().HasKey(x => x.Id);

            modelBuilder.Entity<RedeemRecord>().HasOptional(x => x.Owner)
                .WithMany()
                .Map(x => x.MapKey("OwnerId"));
            modelBuilder.Entity<RedeemRecord>().HasOptional(x => x.Plan)
                .WithMany()
                .Map(x => x.MapKey("PlanId"));

            #endregion

            #endregion
            #region 交互信息

            #region Bulletin的契约

            modelBuilder.Entity<Bulletin>().ToTable("zwg-Bulletin");
            modelBuilder.Entity<Bulletin>().HasKey(x => x.Id);

            #endregion
            #region Notice的契约

            modelBuilder.Entity<Notice>().ToTable("zwg-Notice");
            modelBuilder.Entity<Notice>().HasKey(x => x.Id);

            modelBuilder.Entity<Notice>().HasOptional(x => x.Owner)
                .WithMany()
                .Map(x => x.MapKey("OwnerId"));

            #endregion

            #endregion
            #region 报表

            #region SiteReportForOneDay的契约

            modelBuilder.Entity<SiteReportForOneDay>().ToTable("zwg-SiteReportForOneDay");
            modelBuilder.Entity<SiteReportForOneDay>().HasKey(x => x.Id);

            #endregion
            #region SiteReportForOneMonth的契约

            modelBuilder.Entity<SiteReportForOneMonth>().ToTable("zwg-SiteReportForOneMonth");
            modelBuilder.Entity<SiteReportForOneMonth>().HasKey(x => x.Id);

            #endregion
            #region RersonalReportForOneDay的契约

            modelBuilder.Entity<RersonalReportForOneDay>().ToTable("zwg-RersonalReportForOneDay");
            modelBuilder.Entity<RersonalReportForOneDay>().HasKey(x => x.Id);

            modelBuilder.Entity<RersonalReportForOneDay>().HasOptional(x => x.Owner)
                .WithMany()
                .Map(x => x.MapKey("OwnerId"));

            #endregion
            #region RersonalReportForOneMonth的契约

            modelBuilder.Entity<RersonalReportForOneMonth>().ToTable("zwg-RersonalReportForOneMonth");
            modelBuilder.Entity<RersonalReportForOneMonth>().HasKey(x => x.Id);

            modelBuilder.Entity<RersonalReportForOneMonth>().HasOptional(x => x.Owner)
                .WithMany()
                .Map(x => x.MapKey("OwnerId"));

            #endregion
            #region TeamReportForOneDay的契约

            modelBuilder.Entity<TeamReportForOneDay>().ToTable("zwg-TeamReportForOneDay");
            modelBuilder.Entity<TeamReportForOneDay>().HasKey(x => x.Id);

            modelBuilder.Entity<TeamReportForOneDay>().HasOptional(x => x.Owner)
                .WithMany()
                .Map(x => x.MapKey("OwnerId"));

            #endregion
            #region TeamReportForOneMonth的契约

            modelBuilder.Entity<TeamReportForOneMonth>().ToTable("zwg-TeamReportForOneMonth");
            modelBuilder.Entity<TeamReportForOneMonth>().HasKey(x => x.Id);

            modelBuilder.Entity<TeamReportForOneMonth>().HasOptional(x => x.Owner)
                .WithMany()
                .Map(x => x.MapKey("OwnerId"));

            #endregion

            #endregion
            #region IM

            #region ImMessage的契约

            modelBuilder.Entity<ImMessage>().ToTable("zwg-ImMessage");
            modelBuilder.Entity<ImMessage>().HasKey(x => x.Id);

            #endregion
            #region ImQuickReply的契约

            modelBuilder.Entity<ImQuickReply>().ToTable("zwg-ImQuickReply");
            modelBuilder.Entity<ImQuickReply>().HasKey(x => x.Id);

            #endregion

            #endregion
        }

        #endregion
    }
}
