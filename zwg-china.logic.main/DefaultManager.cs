using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Xml.Linq;
using zwg_china.aid;
using zwg_china.model;
using zwg_china.model.manager;
using System.Reflection;

namespace zwg_china.logic
{
    /// <summary>
    /// 默认数据的管理者对象
    /// </summary>
    public class DefaultManager
    {
        #region 静态方法

        /// <summary>
        /// 加载初始化数据
        /// </summary>
        public static void Load()
        {
            using (ModelToDbContext db = new ModelToDbContext())
            {
                if (!db.Database.Exists())
                {

                    #region 管理员/管理员用户组

                    AdministratorGroup administratorGroup1 = new AdministratorGroup(name: "系统管理员", canViewUsers: true, canEditUsers: true, canViewTickets: true
                        , canEditTickets: true, canViewActivities: true, canEditActivities: true, canViewSettings: true, canEditSettings: true, canViewDataReports: true, canEditDataReports: true
                        , canViewAdministrator: true, canEditAdministrator: true, isCustomerService: false);
                    db.AdministratorGroups.Add(administratorGroup1);

                    AdministratorGroup administratorGroup2 = new AdministratorGroup(name: "管理员", canViewUsers: true, canEditUsers: true, canViewTickets: true
                        , canEditTickets: true, canViewActivities: true, canEditActivities: true, canViewSettings: true, canEditSettings: true, canViewDataReports: true, canEditDataReports: true
                        , canViewAdministrator: false, canEditAdministrator: false, isCustomerService: false);
                    db.AdministratorGroups.Add(administratorGroup2);

                    AdministratorGroup administratorGroup3 = new AdministratorGroup(name: "客服", canViewUsers: true, canEditUsers: false, canViewTickets: true
                        , canEditTickets: false, canViewActivities: true, canEditActivities: false, canViewSettings: true, canEditSettings: false, canViewDataReports: true, canEditDataReports: false
                        , canViewAdministrator: false, canEditAdministrator: false, isCustomerService: true);
                    db.AdministratorGroups.Add(administratorGroup3);

                    Administrator administrator = new Administrator(username: "admin", password: EncryptHelper.EncryptByMd5("admin"), group: administratorGroup1);
                    db.Administrators.Add(administrator);

                    #endregion

                    #region 用户组

                    UserGroup userGroup1 = new UserGroup(name: "见习会员", grade: 1, lowerOfConsumption: 0, capsOfConsumption: 5000, timesOfWithdrawal: 0
                       , minimumWithdrawalAmount: 0, maximumWithdrawalAmount: 0);
                    db.UserGroups.Add(userGroup1);

                    UserGroup userGroup2 = new UserGroup(name: "正式会员", grade: 2, lowerOfConsumption: 5000, capsOfConsumption: 100000, timesOfWithdrawal: 0
                       , minimumWithdrawalAmount: 0, maximumWithdrawalAmount: 0);
                    db.UserGroups.Add(userGroup2);

                    UserGroup userGroup3 = new UserGroup(name: "高级会员", grade: 3, lowerOfConsumption: 100000, capsOfConsumption: 500000, timesOfWithdrawal: 0
                       , minimumWithdrawalAmount: 0, maximumWithdrawalAmount: 0);
                    db.UserGroups.Add(userGroup3);

                    UserGroup userGroup4 = new UserGroup(name: "VIP会员", grade: 4, lowerOfConsumption: 500000, capsOfConsumption: 10000000, timesOfWithdrawal: 0
                       , minimumWithdrawalAmount: 0, maximumWithdrawalAmount: 0);
                    db.UserGroups.Add(userGroup4);

                    UserGroup userGroup5 = new UserGroup(name: "黄金VIP会员", grade: 5, lowerOfConsumption: 10000000, capsOfConsumption: 500000000, timesOfWithdrawal: 0
                       , minimumWithdrawalAmount: 0, maximumWithdrawalAmount: 0);
                    db.UserGroups.Add(userGroup5);

                    #endregion

                    #region 彩票/玩法标签/玩法

                    string ticketsDocPath = string.Format("{0}Content/LotteryTickets.xml", AppDomain.CurrentDomain.BaseDirectory);
                    XElement ticketsDoc = XElement.Load(ticketsDocPath);
                    int ticketOrder = 0;
                    ticketsDoc.Elements("Ticket").ToList()
                        .ForEach(eTicket =>
                        {
                            #region 彩票主信息

                            ticketOrder++;
                            List<LotteryTime> times = new List<LotteryTime>();
                            int _issue = 0;
                            eTicket.Element("Times").Value.Split(new char[] { ',', '，' }).ToList()
                                .ForEach(timeValue =>
                                {
                                    _issue++;
                                    LotteryTime _time = new LotteryTime(_issue, timeValue);
                                    times.Add(_time);
                                });
                            LotteryTicket ticket = new LotteryTicket(name: eTicket.Element("Name").Value
                                , installments: _issue
                                , times: times
                                , order: ticketOrder
                                , formatOfIssue: eTicket.Element("FormatOfIssue").Value
                                , seats: eTicket.Element("Seats").Value
                                , firstNum: Convert.ToInt32(eTicket.Element("FirstNum").Value)
                                , countOfNUm: Convert.ToInt32(eTicket.Element("CountOfNUm").Value));
                            db.LotteryTickets.Add(ticket);

                            #endregion

                            #region 玩法标签

                            int tagOrder = 0;
                            eTicket.Element("Tags").Elements("Tag").ToList()
                                .ForEach(eTag =>
                                {
                                    #region 玩法标签主信息

                                    tagOrder++;
                                    PlayTag tag = new PlayTag(name: eTag.Element("Name").Value
                                        , ticket: ticket
                                        , order: tagOrder);
                                    db.PlayTags.Add(tag);
                                    ticket.Tags.Add(tag);

                                    #endregion

                                    #region 玩法

                                    int howToPlayOrder = 0;
                                    eTag.Element("HowToPlays").Elements("HowToPlay").ToList()
                                        .ForEach(eHowToPlay =>
                                        {
                                            howToPlayOrder++;
                                            LotteryInterface _interface = (LotteryInterface)Enum.Parse(typeof(LotteryInterface), eHowToPlay.Element("Interface").Value);
                                            double odds = 0;
                                            double tDatum = 1.7;
                                            string _validSeats = eHowToPlay.Element("ValidSeats").Value;
                                            #region 动态计算赔率

                                            if (_interface == LotteryInterface.任N直选
                                                || _interface == LotteryInterface.任N组选)
                                            {
                                                double t = 1;
                                                _validSeats.Split(new char[] { ',', '，' }).ToList()
                                                    .ForEach(x =>
                                                    {
                                                        t *= ticket.CountOfNUm;
                                                    });
                                                odds = Math.Round(t * tDatum, 2);
                                            }
                                            else if (_interface == LotteryInterface.任N定位胆)
                                            {
                                                odds = Math.Round(ticket.CountOfNUm * tDatum, 2);
                                            }
                                            else if (_interface == LotteryInterface.任N不定位)
                                            {
                                                double t1 = ((double)(ticket.CountOfNUm - 1)) / ((double)ticket.CountOfNUm);
                                                double t2 = 1;
                                                _validSeats.Split(new char[] { ',', '，' }).ToList()
                                                    .ForEach(x =>
                                                    {
                                                        t2 *= t1;
                                                    });
                                                double t = 1 / (1 - t2);
                                                odds = Math.Round(t * tDatum, 2);
                                            }

                                            #endregion
                                            HowToPlay howToPlay = new HowToPlay(name: eHowToPlay.Element("Name").Value
                                                , tag: tag
                                                , lowerSeats: Convert.ToInt32(eHowToPlay.Element("LowerSeats").Value)
                                                , capsSeats: Convert.ToInt32(eHowToPlay.Element("CapsSeats").Value)
                                                , odds: odds
                                                , _interface: _interface
                                                , allowFreeSeats: Convert.ToBoolean(eHowToPlay.Element("AllowFreeSeats").Value)
                                                , validSeats: _validSeats
                                                , optionalSeats: eHowToPlay.Element("OptionalSeats").Value
                                                , isDuplex: Convert.ToBoolean(eHowToPlay.Element("IsDuplex").Value)
                                                , countOfSeatsForWin: Convert.ToInt32(eHowToPlay.Element("CountOfSeatsForWin").Value)
                                                , lowerCountOfDifferentSeatsForWin: Convert.ToInt32(eHowToPlay.Element("LowerCountOfDifferentSeatsForWin").Value)
                                                , capsCountOfDifferentSeatsForWin: Convert.ToInt32(eHowToPlay.Element("CapsCountOfDifferentSeatsForWin").Value)
                                                , order: howToPlayOrder);
                                            db.HowToPlays.Add(howToPlay);
                                            tag.HowToPlays.Add(howToPlay);
                                        });

                                    #endregion
                                });

                            #endregion
                        });

                    #endregion

                    #region 银行账户

                    SystemBankAccount bank1 = new SystemBankAccount(holderOfTheCard: "大厨麦当牛", card: "6213387263443096574", bank: Bank.中国工商银行
                        , remark: "测试账户", order: 1, hide: false);
                    db.SystemBankAccounts.Add(bank1);

                    #endregion

                    #region 高点号配额

                    for (double i = 13; i > 12; i -= 0.1)
                    {
                        SystemQuota sq = new SystemQuota(i, new List<SystemQuotaDetail>());
                        for (double j = 13; j > 12; j -= 0.1)
                        {
                            int t = (int)((i - j) * 10);
                            if (t < 0) { t = 0; }
                            SystemQuotaDetail sqd = new SystemQuotaDetail(j, t);
                            sq.Details.Add(sqd);
                        }
                        db.SystemQuotas.Add(sq);
                    }

                    #endregion

                    db.SaveChanges();
                    new SettingOfBase(db).Save(db);
                    new SettingOfAuthor(db).Save(db);
                    new SettingOfLottery(db).Save(db);
                }
            };
            List<Assembly> assemblies = new List<Assembly>
            {
                new RIOfActivity().GetAssembly(),
                new RIOfAdministrator().GetAssembly(),
                new RIOfAuthor().GetAssembly(),
                new RIOfBase().GetAssembly(),
                new RIOfLottery().GetAssembly(),
                new RIOfMessage().GetAssembly(),
                new RIOfReport().GetAssembly()
            };
            ManagerService.Initialize(assemblies);
            CollectManager.Run();
        }

        #endregion
    }
}
