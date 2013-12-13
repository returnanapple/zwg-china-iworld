using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Text;
using zwg_china.aid;
using zwg_china.logic;
using zwg_china.model;
using zwg_china.model.manager;

namespace zwg_china.service
{
    /// <summary>
    /// 用于投注的数据集
    /// </summary>
    [DataContract]
    public class BetImpoert : ImportBaseOfLottery
    {
        #region 属性

        /// <summary>
        /// 期号
        /// </summary>
        [DataMember]
        public string Issue { get; set; }

        /// <summary>
        /// 倍数
        /// </summary>
        [DataMember]
        public double Multiple { get; set; }

        /// <summary>
        /// 所要转换为赔率的返点
        /// </summary>
        [DataMember]
        public double Points { get; set; }

        /// <summary>
        /// 目标玩法的存储指针
        /// </summary>
        [DataMember]
        public int HowToPlayId { get; set; }

        /// <summary>
        /// 投注号码
        /// </summary>
        [DataMember]
        public List<BetSeatImport> Seats { get; set; }

        /// <summary>
        /// 追号明细
        /// </summary>
        [DataMember]
        public List<BettingWithChasingImport> BettingWithChasings { get; set; }

        #endregion

        #region 方法

        /// <summary>
        /// 执行投注动作
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public void DoBet(IModelToDbContextOfLottery db)
        {
            SettingOfLottery settingOfLottery = new SettingOfLottery(db);
            HowToPlay howToPlay = db.HowToPlays.Find(this.HowToPlayId);
            if (this.Issue != howToPlay.Tag.Ticket.NextIssue)
            {
                throw new Exception("投注的期号有无，操作无效");
            }
            if (this.Multiple <= 0)
            {
                throw new Exception("倍数要求必须大于0，操作无效");
            }
            double capsOfPoint = howToPlay.Interface == LotteryInterface.任N不定位
                ? this.Self.PlayInfo.Rebate_IndefinitePosition
                : this.Self.PlayInfo.Rebate_Normal;
            if (this.Points < 0
                || this.Points > capsOfPoint)
            {
                throw new Exception("所要求转换为赔率的返点超过合法范围，操作无效");
            }
            if (this.Seats == null)
            {
                throw new Exception("投注号码为空，操作无效");
            }

            #region 创建投注记录

            List<BettingSeat> bettingSeats = this.Seats.ConvertAll(x => new BettingSeat(x.SeatNmae, x.Values));
            Betting betting = new Betting(this.Self, this.Issue, this.Multiple, this.Points, howToPlay, bettingSeats, settingOfLottery.UnitPrice);
            if (betting.Pay > this.Self.Money)
            {
                throw new Exception("余额不足，操作无效");
            }
            pForCreateBetting pfcb = new pForCreateBetting(betting);
            new BettingManager(db).Create(pfcb);

            #endregion

            #region 创建追号记录（假如需要的话）

            if (this.BettingWithChasings != null)
            {
                double pay = 0;
                this.BettingWithChasings
                    .ForEach(x =>
                    {
                        double payOfMine = x.Multiple * settingOfLottery.UnitPrice * betting.Notes;
                        pay += Math.Round(payOfMine, 2);
                    });
                List<ChasingSeat> chasingSeats = this.Seats.ConvertAll(x => new ChasingSeat(x.SeatNmae, x.Values));
                Chasing chasing = new Chasing(this.Self, this.BettingWithChasings.First().Issue, this.BettingWithChasings.Count, this.Points, howToPlay
                    , chasingSeats, pay);
                if (chasing.Pay > this.Self.Money)
                {
                    throw new Exception("余额不足，操作无效");
                }
                pForCreateChasing pfcc = new pForCreateChasing(chasing);
                new ChasingManager(db).Create(pfcc);

                this.BettingWithChasings
                    .ForEach(x =>
                    {
                        double payOfMine = x.Multiple * settingOfLottery.UnitPrice * betting.Notes;
                        payOfMine = Math.Round(payOfMine, 2);
                        BettingWithChasing b = new BettingWithChasing(x.Issue, this.Multiple, payOfMine, chasing);
                        pForCreateBettingWithChasing pfcbwc = new pForCreateBettingWithChasing(b);
                        new BettingWithChasingManager(db).Create(pfcbwc);
                    });
            }

            #endregion
        }

        #endregion

        #region 内嵌类型

        /// <summary>
        /// 用于创建投注记录的数据集
        /// </summary>
        class pForCreateBetting : IPackageForCreateModel<IModelToDbContextOfLottery, Betting>
        {
            #region 私有字段

            Betting betting = null;

            #endregion

            #region 构造方法

            /// <summary>
            /// 实例化一个新的用于创建投注记录的数据集
            /// </summary>
            /// <param name="betting">所要添加到数据库的投注记录</param>
            public pForCreateBetting(Betting betting)
            {
                this.betting = betting;
            }

            #endregion

            #region 方法

            /// <summary>
            /// 检查输入的数据是否合法
            /// </summary>
            /// <param name="db">数据库连接对象</param>
            public void CheckData(IModelToDbContextOfLottery db)
            {
            }

            /// <summary>
            /// 获取数据模型的实体
            /// </summary>
            /// <param name="db">数据库连接对象</param>
            public Betting GetModel(IModelToDbContextOfLottery db)
            {
                return this.betting;
            }

            #endregion
        }

        /// <summary>
        /// 用于创建追号记录的数据集
        /// </summary>
        class pForCreateChasing : IPackageForCreateModel<IModelToDbContextOfLottery, Chasing>
        {
            #region 私有字段

            Chasing chasing = null;

            #endregion

            #region 构造方法

            /// <summary>
            /// 实例化一个新的用于创建追号记录的数据集
            /// </summary>
            /// <param name="chasing">所要添加到数据库的追号记录</param>
            public pForCreateChasing(Chasing chasing)
            {
                this.chasing = chasing;
            }

            #endregion

            #region 方法

            /// <summary>
            /// 检查输入的数据是否合法
            /// </summary>
            /// <param name="db">数据库连接对象</param>
            public void CheckData(IModelToDbContextOfLottery db)
            {
            }

            /// <summary>
            /// 获取数据模型的实体
            /// </summary>
            /// <param name="db">数据库连接对象</param>
            public Chasing GetModel(IModelToDbContextOfLottery db)
            {
                return this.chasing;
            }

            #endregion
        }

        /// <summary>
        /// 用于创建投注（追号）记录的数据集
        /// </summary>
        class pForCreateBettingWithChasing : IPackageForCreateModel<IModelToDbContextOfLottery, BettingWithChasing>
        {
            #region 私有字段

            BettingWithChasing bettingWithChasing = null;

            #endregion

            #region 构造方法

            /// <summary>
            /// 实例化一个新的用于创建投注（追号）记录的数据集
            /// </summary>
            /// <param name="bettingWithChasing">所要添加到数据库的投注（追号）记录</param>
            public pForCreateBettingWithChasing(BettingWithChasing bettingWithChasing)
            {
                this.bettingWithChasing = bettingWithChasing;
            }

            #endregion

            #region 方法

            /// <summary>
            /// 检查输入的数据是否合法
            /// </summary>
            /// <param name="db">数据库连接对象</param>
            public void CheckData(IModelToDbContextOfLottery db)
            {
            }

            /// <summary>
            /// 获取数据模型的实体
            /// </summary>
            /// <param name="db">数据库连接对象</param>
            public BettingWithChasing GetModel(IModelToDbContextOfLottery db)
            {
                return this.bettingWithChasing;
            }

            #endregion
        }

        #endregion
    }
}
