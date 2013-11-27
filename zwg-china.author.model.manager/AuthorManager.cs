using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using zwg_china.aid;

namespace zwg_china.model.manager
{
    /// <summary>
    /// 用户的管理者对象
    /// </summary>
    [RegisterToManagerService]
    public class AuthorManager : ManagerBase<IModelToDbContextOfAuthor, AuthorManager.Actions, Author>
    {
        #region 构造方法

        /// <summary>
        /// 实例化一个新的用户的管理者对象
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public AuthorManager(IModelToDbContextOfAuthor db)
            : base(db)
        {

        }

        #endregion

        #region 方法

        /// <summary>
        /// 用户登人
        /// </summary>
        /// <param name="package">用于登陆的数据集</param>
        /// <returns>返回用户的实例</returns>
        public Author Login(PackageForLogin package)
        {
            string username = VerifyHelper.EliminateSpaces(package.Username);
            string password = VerifyHelper.EliminateSpaces(package.Password);
            VerifyHelper.Check(username, VerifyHelper.Key.Nickname);
            VerifyHelper.Check(password, VerifyHelper.Key.Password);
            password = EncryptHelper.EncryptByMd5(password);
            Author user = db.Authors.FirstOrDefault(x => x.Username == package.Username && x.Password == password);
            if (user == null)
            {
                throw new Exception("用户名或密码错误，请重新输入");
            }
            if (user.Status == UserStatus.禁止访问)
            {
                throw new Exception("黑名单，你懂的。");
            }

            OnExecuting(Actions.Login, user);
            user.OnLogin(package.Ip, package.Address);
            OnExecuted(Actions.Login, user);
            db.SaveChanges();

            return user;
        }

        /// <summary>
        /// 修改用户返点
        /// </summary>
        /// <param name="package">数据集</param>
        public void ChangeRebate(PackageForChangeRebate package)
        {
            SettingOfAuthor setting = new SettingOfAuthor(db);

            #region 检查所要设置的新的返点是否超出合法界限

            if (package.NewRebate_Normal < setting.LowerRebate
                || package.NewRebate_Normal > setting.CapsRebate)
            {
                string error = string.Format("设置的普通返点（{0}）超出合法界限，正确的设置范围是：{1} - {2}"
                    , package.NewRebate_Normal.ToString("0.0")
                    , setting.LowerRebate.ToString("0.0")
                    , setting.CapsRebate.ToString("0.0"));
            }
            if (package.NewRebate_IndefinitePosition < setting.LowerRebate
                || package.NewRebate_Normal > setting.CapsRebate)
            {
                string error = string.Format("设置的不定位返点（{0}）超出合法界限，正确的设置范围是：{1} - {2}"
                    , package.NewRebate_IndefinitePosition.ToString("0.0")
                    , setting.LowerRebate.ToString("0.0")
                    , setting.CapsRebate.ToString("0.0"));
            }

            #endregion

            Author user = db.Authors.FirstOrDefault(x => x.Id == package.UserId);
            if (user == null)
            {
                throw new Exception("提供的存储指针指向的用户不存在，请检查输入");
            }

            #region 如果当前要设置的用户不是顶级用户，验证要设置的新的返点是否超过上级用户的返点，并验证其上级用户是否拥有相应配额

            if (user.Layer > 1)
            {
                Author parent = db.Authors.FirstOrDefault(x => user.Relatives.Any(r => r.NodeId == x.Id) && x.Layer == user.Layer - 1);
                if (parent == null)
                {
                    string error = string.Format("致命错误，非顶级用户（用户名：{0}，层级：{1}）没有上级用户"
                        , user.Username
                        , user.Layer);
                    throw new Exception(error);
                }
                if (package.NewRebate_Normal > parent.PlayInfo.Rebate_Normal)
                {
                    string error = string.Format("所要设置的普通返点（{0}）大于上级用户的普通返点（{1}），设置无效"
                        , package.NewRebate_Normal.ToString("0.0")
                        , parent.PlayInfo.Rebate_Normal.ToString("0.0"));
                    throw new Exception(error);
                }
                if (package.NewRebate_IndefinitePosition > parent.PlayInfo.Rebate_IndefinitePosition)
                {
                    string error = string.Format("所要设置的不定位返点（{0}）大于上级用户的不定位返点（{1}），设置无效"
                        , package.NewRebate_IndefinitePosition.ToString("0.0")
                        , parent.PlayInfo.Rebate_IndefinitePosition.ToString("0.0"));
                    throw new Exception(error);
                }

                //当要设置的返点符合“高点号”定义时判断配额
                if (package.NewRebate_Normal >= setting.LowerRebateOfHigh)
                {
                    SystemQuota sq = db.SystemQuotas.FirstOrDefault(x => x.Rebate == parent.PlayInfo.Rebate_Normal);
                    if (sq == null) { sq = new SystemQuota(parent.PlayInfo.Rebate_Normal, new List<SystemQuotaDetail>()); }
                    SystemQuotaDetail sqDetail = sq.Detail.FirstOrDefault(x => x.Rebate == package.NewRebate_Normal);
                    int quota = sqDetail == null ? 0 : sqDetail.Sum;
                    ExtraQuota eq = parent.ExtraQuotas.FirstOrDefault(x => x.Rebate == package.NewRebate_Normal);
                    if (eq != null) { quota += eq.Sum; }
                    SubordinateData sd = parent.SubordinateOfHighRebate.FirstOrDefault(x => x.Rebate == package.NewRebate_Normal);
                    int quota_used = sd == null ? 0 : sd.Sum;
                    if (quota < quota_used + 1)
                    {
                        string error = string.Format("当前操作将导致目标用户的上级用户（用户名：{0}，层级：{1}）的高点号配额：【返点：{2}，配额：{3}】的值小于0，操作无效"
                            , parent.Username
                            , parent.Layer
                            , package.NewRebate_Normal.ToString("0.0")
                            , quota - quota_used);
                        throw new Exception(error);
                    }
                }
            }

            #endregion

            OnExecuting(Actions.ChangeRebate, user);
            user.PlayInfo.Rebate_Normal = package.NewRebate_Normal;
            user.PlayInfo.Rebate_IndefinitePosition = package.NewRebate_IndefinitePosition;
            OnExecuted(Actions.ChangeRebate, user);
            db.SaveChanges();
        }

        #endregion

        #region 静态方法

        #region 服务

        /// <summary>
        /// 服务：修改用户的积分
        /// </summary>
        /// <param name="info">数据集</param>
        [OnCall(typeof(AuthorManager), Services.ChangeIntegral)]
        public static void Service_ChangeIntegral(InfoOfCallOnManagerService info)
        {
            IModelToDbContextOfAuthor db = (IModelToDbContextOfAuthor)info.Db;
            ChangeFreezeCrgs args = (ChangeFreezeCrgs)info.Args;

            Author user = db.Authors.Find(args.UserId);
            user.Integral += args.Sum;
        }

        #endregion

        #region 监听

        /// <summary>
        /// 监听：（直属）下级用户数量+1
        /// </summary>
        /// <param name="info">数据集</param>
        [Listen(typeof(AuthorManager), AuthorManager.Actions.Create, ExecutionOrder.After)]
        public static void Monitor_AddSubordinate(InfoOfSendOnManagerService info)
        {
            IModelToDbContextOfAuthor db = (IModelToDbContextOfAuthor)info.Db;
            Author model = (Author)info.Model;

            if (model.Layer <= 1) { return; }
            Author user = db.Authors.FirstOrDefault(x => model.Relatives.Any(r => r.NodeId == x.Id) && x.Layer == model.Layer - 1);
            if (user == null)
            {
                string error = string.Format("致命错误，非顶级用户（用户名：{0}，层级：{1}）没有上级用户"
                    , model.Username
                    , model.Layer);
                throw new Exception(error);
            }

            user.Subordinate++;
        }

        /// <summary>
        /// 监听：（直属）下级用户数量-1
        /// </summary>
        /// <param name="info">数据集</param>
        [Listen(typeof(AuthorManager), AuthorManager.Actions.Remove, ExecutionOrder.Before)]
        public static void Monitor_RemoveSubordinate(InfoOfSendOnManagerService info)
        {
            IModelToDbContextOfAuthor db = (IModelToDbContextOfAuthor)info.Db;
            Author model = (Author)info.Model;

            if (model.Layer <= 1) { return; }
            Author user = db.Authors.FirstOrDefault(x => model.Relatives.Any(r => r.NodeId == x.Id) && x.Layer == model.Layer - 1);
            if (user == null)
            {
                string error = string.Format("致命错误，非顶级用户（用户名：{0}，层级：{1}）没有上级用户"
                    , model.Username
                    , model.Layer);
                throw new Exception(error);
            }

            user.Subordinate--;
        }

        /// <summary>
        /// 监听：（直属）下级用户（高点号）数量+1
        /// </summary>
        /// <param name="info">数据集</param>
        [Listen(typeof(AuthorManager), AuthorManager.Actions.Create, ExecutionOrder.After)]
        [Listen(typeof(AuthorManager), AuthorManager.Actions.ChangeRebate, ExecutionOrder.After)]
        public static void Monitor_AddSubordinateOfHighRebate(InfoOfSendOnManagerService info)
        {
            IModelToDbContextOfAuthor db = (IModelToDbContextOfAuthor)info.Db;
            Author model = (Author)info.Model;

            if (model.Layer <= 1) { return; }//顶级用户没有上级
            SettingOfAuthor setting = new SettingOfAuthor(db);
            if (model.PlayInfo.Rebate_Normal < setting.LowerRebateOfHigh) { return; }//非高点用户不参与统计
            Author user = db.Authors.FirstOrDefault(x => model.Relatives.Any(r => r.NodeId == x.Id) && x.Layer == model.Layer - 1);
            if (user == null)
            {
                string error = string.Format("致命错误，非顶级用户（用户名：{0}，层级：{1}）没有上级用户"
                    , model.Username
                    , model.Layer);
                throw new Exception(error);
            }

            SubordinateData sd = user.SubordinateOfHighRebate.FirstOrDefault(x => x.Rebate == model.PlayInfo.Rebate_Normal);
            if (sd == null)
            {
                sd = new SubordinateData(model.PlayInfo.Rebate_Normal, 1);
                user.SubordinateOfHighRebate.Add(sd);
            }
            else
            {
                sd.Sum++;
            }
        }

        /// <summary>
        /// 监听：（直属）下级用户（高点号）数量-1
        /// </summary>
        /// <param name="info">数据集</param>
        [Listen(typeof(AuthorManager), AuthorManager.Actions.Remove, ExecutionOrder.Before)]
        [Listen(typeof(AuthorManager), AuthorManager.Actions.ChangeRebate, ExecutionOrder.Before)]
        public static void Monitor_RemoveSubordinateOfHighRebate(InfoOfSendOnManagerService info)
        {
            IModelToDbContextOfAuthor db = (IModelToDbContextOfAuthor)info.Db;
            Author model = (Author)info.Model;

            if (model.Layer <= 1) { return; }//顶级用户没有上级
            SettingOfAuthor setting = new SettingOfAuthor(db);
            if (model.PlayInfo.Rebate_Normal < setting.LowerRebateOfHigh) { return; }//非高点用户不参与统计
            Author user = db.Authors.FirstOrDefault(x => model.Relatives.Any(r => r.NodeId == x.Id) && x.Layer == model.Layer - 1);
            if (user == null)
            {
                string error = string.Format("致命错误，非顶级用户（用户名：{0}，层级：{1}）没有上级用户"
                    , model.Username
                    , model.Layer);
                throw new Exception(error);
            }

            SubordinateData sd = user.SubordinateOfHighRebate.FirstOrDefault(x => x.Rebate == model.PlayInfo.Rebate_Normal);
            if (sd != null)
            {
                sd.Sum--;
            }
        }

        /// <summary>
        /// 监听：用户的账户余额改变
        /// </summary>
        /// <param name="info">数据集</param>
        [Listen(typeof(MoneyChangeRecordManager), MoneyChangeRecordManager.Actions.Create, ExecutionOrder.After)]
        public static void Monitor_MoneyChange(InfoOfSendOnManagerService info)
        {
            IModelToDbContextOfAuthor db = (IModelToDbContextOfAuthor)info.Db;
            MoneyChangeRecord model = (MoneyChangeRecord)info.Model;

            Author user = db.Authors.Find(model.Owner.Id);
            user.Money += model.Sum;
        }

        /// <summary>
        /// 监听：冻结资金
        /// </summary>
        /// <param name="info">数据集</param>
        [Listen(typeof(WithdrawalsRecordManager), WithdrawalsRecordManager.Actions.Create, ExecutionOrder.After)]
        public static void Monitor_FreezeMoney(InfoOfSendOnManagerService info)
        {
            IModelToDbContextOfAuthor db = (IModelToDbContextOfAuthor)info.Db;
            WithdrawalsRecord model = (WithdrawalsRecord)info.Model;

            if (model.Status == WithdrawalsStatus.处理中)
            {
                Author user = db.Authors.Find(model.Owner.Id);
                user.Money -= model.Sum;
                user.Money_Frozen += model.Sum;
            }
        }

        /// <summary>
        /// 监听：解冻资金
        /// </summary>
        /// <param name="info">数据集</param>
        [Listen(typeof(WithdrawalsRecordManager), WithdrawalsRecordManager.Actions.ChangeStatus, ExecutionOrder.After)]
        public static void Monitor_ThawMoney(InfoOfSendOnManagerService info)
        {
            IModelToDbContextOfAuthor db = (IModelToDbContextOfAuthor)info.Db;
            WithdrawalsRecord model = (WithdrawalsRecord)info.Model;

            if (model.Status == WithdrawalsStatus.失败)
            {
                Author user = db.Authors.Find(model.Owner.Id);
                user.Money += model.Sum;
                user.Money_Frozen -= model.Sum;
            }
        }

        /// <summary>
        /// 监听：蒸发冻结的资金
        /// </summary>
        /// <param name="info">数据集</param>
        [Listen(typeof(WithdrawalsRecordManager), WithdrawalsRecordManager.Actions.ChangeStatus, ExecutionOrder.After)]
        public static void Monitor_EvaporateMoney(InfoOfSendOnManagerService info)
        {
            IModelToDbContextOfAuthor db = (IModelToDbContextOfAuthor)info.Db;
            WithdrawalsRecord model = (WithdrawalsRecord)info.Model;

            if (model.Status == WithdrawalsStatus.提现成功)
            {
                Author user = db.Authors.Find(model.Owner.Id);
                user.Money_Frozen -= model.Sum;
            }
        }

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
            Remove,
            /// <summary>
            /// 用户登录
            /// </summary>
            Login,
            /// <summary>
            /// 修改用户返点
            /// </summary>
            ChangeRebate
        }

        /// <summary>
        /// 服务
        /// </summary>
        public enum Services
        {
            /// <summary>
            /// 修改用户的积分
            /// </summary>
            ChangeIntegral
        }

        #endregion

        #region 接口

        /// <summary>
        /// 定义用于登陆的数据集
        /// </summary>
        public interface PackageForLogin
        {
            /// <summary>
            /// 用户名
            /// </summary>
            string Username { get; }

            /// <summary>
            /// 密码
            /// </summary>
            string Password { get; }

            /// <summary>
            /// 网络地址
            /// </summary>
            string Ip { get; }

            /// <summary>
            /// 实际地址
            /// </summary>
            string Address { get; }
        }

        /// <summary>
        /// 定于用于修改用户返点的数据集
        /// </summary>
        public interface PackageForChangeRebate
        {
            /// <summary>
            /// 用户的存储指针
            /// </summary>
            int UserId { get; set; }

            /// <summary>
            /// 新的普通返点
            /// </summary>
            double NewRebate_Normal { get; set; }

            /// <summary>
            /// 新的不定位返点
            /// </summary>
            double NewRebate_IndefinitePosition { get; set; }
        }

        #endregion

        #region 类型

        /// <summary>
        /// 用于向修改用户被冻结的金额的服务传递数据的数据集
        /// </summary>
        public class ChangeFreezeCrgs
        {
            /// <summary>
            /// 目标用户的存储指针
            /// </summary>
            public int UserId { get; set; }

            /// <summary>
            /// 所要改变的数额
            /// </summary>
            public double Sum { get; set; }

            /// <summary>
            /// 一个布尔值，表示是否需要跟现金账户联动
            /// </summary>
            public bool LinkageWithMoney { get; set; }
        }

        #endregion

        #endregion
    }
}
