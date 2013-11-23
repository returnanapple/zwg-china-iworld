using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model.manager
{
    /// <summary>
    /// 用户模块的逻辑注册机
    /// </summary>
    public class RIOfAuthor : RIBase
    {
        /// <summary>
        /// 注册
        /// </summary>
        public override void Register()
        {
            #region 用户的管理者对象

            //创建用户后 其上级用户的“直属下级用户”+1
            RegisterMonitor<IModelToDbContextOfAuthor, AuthorManager.Actions, Author>(typeof(AuthorManager), AuthorManager.Actions.Create, ExecutionOrder.After
                , new Action<InfoOfSendOnManagerService<IModelToDbContextOfAuthor, AuthorManager.Actions, Author>>(AuthorManager.Monitor_AddSubordinate));

            //移除用户前 其上级用户的“直属下级用户”-1
            RegisterMonitor<IModelToDbContextOfAuthor, AuthorManager.Actions, Author>(typeof(AuthorManager), AuthorManager.Actions.Remove, ExecutionOrder.Before
                , new Action<InfoOfSendOnManagerService<IModelToDbContextOfAuthor, AuthorManager.Actions, Author>>(AuthorManager.Monitor_RemoveSubordinate));

            //创建用户后 如果其返点符合“高点号定义” 其上级用户的“直属高点号用户”的相应配额-1
            RegisterMonitor<IModelToDbContextOfAuthor, AuthorManager.Actions, Author>(typeof(AuthorManager), AuthorManager.Actions.Create, ExecutionOrder.After
                , new Action<InfoOfSendOnManagerService<IModelToDbContextOfAuthor, AuthorManager.Actions, Author>>(AuthorManager.Monitor_AddSubordinateOfHighRebate));

            //移除用户前 如果其返点符合“高点号定义” 其上级用户的“直属高点号用户”的相应配额+1
            RegisterMonitor<IModelToDbContextOfAuthor, AuthorManager.Actions, Author>(typeof(AuthorManager), AuthorManager.Actions.Remove, ExecutionOrder.Before
                , new Action<InfoOfSendOnManagerService<IModelToDbContextOfAuthor, AuthorManager.Actions, Author>>(AuthorManager.Monitor_RemoveSubordinateOfHighRebate));

            //改变用户的返点前 如果其返点符合“高点号定义” 其上级用户的“直属高点号用户”的相应配额+1
            RegisterMonitor<IModelToDbContextOfAuthor, AuthorManager.Actions, Author>(typeof(AuthorManager), AuthorManager.Actions.ChangeRebate, ExecutionOrder.Before
                , new Action<InfoOfSendOnManagerService<IModelToDbContextOfAuthor, AuthorManager.Actions, Author>>(AuthorManager.Monitor_AddSubordinateOfHighRebate));

            //改变用户的返点后 如果其返点符合“高点号定义” 其上级用户的“直属高点号用户”的相应配额-1
            RegisterMonitor<IModelToDbContextOfAuthor, AuthorManager.Actions, Author>(typeof(AuthorManager), AuthorManager.Actions.ChangeRebate, ExecutionOrder.After
                , new Action<InfoOfSendOnManagerService<IModelToDbContextOfAuthor, AuthorManager.Actions, Author>>(AuthorManager.Monitor_RemoveSubordinateOfHighRebate));

            //服务：修改用户的账户余额
            RegisterService<IModelToDbContextOfAuthor, AuthorManager.Services, AuthorManager.ChangeMoneyArgs>(typeof(AuthorManager), AuthorManager.Services.ChangeMoney
                , new Action<InfoOfCallOnManagerService<IModelToDbContextOfAuthor, AuthorManager.Services, AuthorManager.ChangeMoneyArgs>>(AuthorManager.Service_ChangeMoney));

            //服务：修改用户被冻结的金额
            RegisterService<IModelToDbContextOfAuthor, AuthorManager.Services, AuthorManager.ChangeFreezeCrgs>(typeof(AuthorManager), AuthorManager.Services.ChangeFreeze
                , new Action<InfoOfCallOnManagerService<IModelToDbContextOfAuthor, AuthorManager.Services, AuthorManager.ChangeFreezeCrgs>>(AuthorManager.Service_ChangeFreeze));

            //服务：修改用户的积分
            RegisterService<IModelToDbContextOfAuthor, AuthorManager.Services, AuthorManager.ChangeIntegralArgs>(typeof(AuthorManager), AuthorManager.Services.ChangeIntegral
                , new Action<InfoOfCallOnManagerService<IModelToDbContextOfAuthor, AuthorManager.Services, AuthorManager.ChangeIntegralArgs>>(AuthorManager.Service_ChangeIntegral));

            #endregion
        }
    }
}
