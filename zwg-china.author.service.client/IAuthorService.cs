using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace zwg_china.service.client
{
    /// <summary>
    /// 定义用户信息服务
    /// </summary>
    [ServiceContract]
    public interface IAuthorService
    {
        #region 获取数据

        /// <summary>
        /// 获取下级用户的用户信息的分页列表
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回下级用户的用户信息的分页列表</returns>
        [OperationContract]
        PageResult<BasicAuthorExport> GetUsers(GetUsersImport import);

        /// <summary>
        /// 获取自身的详细用户信息
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回自身的详细用户信息</returns>
        [OperationContract]
        NormalResult<AuthorExport> GetUserInfo(GetUserInfoImpoert import);

        /// <summary>
        /// 获取基本的自身数据信息
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回基本的自身数据信息</returns>
        [OperationContract]
        NormalResult<BasicSelfInfoExport> GetBasicSelfInfo(GetBasicSelfInfoImport import);

        #endregion

        #region 操作

        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果（如成功将返回档次登陆的身份标识）</returns>
        [OperationContract]
        NormalResult<string> Login(LoginImport import);

        /// <summary>
        /// 信息绑定
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        [OperationContract]
        NormalResult BindingUserInfo(BindingUserInfoImport import);

        /// <summary>
        /// 创建下级用户
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        [OperationContract]
        NormalResult CreateUser(CreateUserImport import);

        /// <summary>
        /// 升点
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        [OperationContract]
        NormalResult UpgradePorn(UpgradePornImport import);

        /// <summary>
        /// 修改银行卡信息
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        [OperationContract]
        NormalResult EditBank(EditBankImport import);

        /// <summary>
        /// 修改登陆密码
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        [OperationContract]
        NormalResult EditPassword(EditPasswordImport import);

        /// <summary>
        /// 修改资金密码
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        [OperationContract]
        NormalResult EditFundsCode(EditFundsCodeImport import);

        /// <summary>
        /// 使用安全码修改登陆密码
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        [OperationContract]
        NormalResult EditPasswordWithSafeCode(EditPasswordWithSafeCodeImport import);

        /// <summary>
        /// 使用安全码修改资金密码
        /// </summary>
        /// <param name="import">数据集</param>
        /// <returns>返回操作结果</returns>
        [OperationContract]
        NormalResult EditFundsCodeWithSafeCode(EditFundsCodeWithSafeCodeImport import);

        #endregion

        #region 心跳协议

        /// <summary>
        /// 保持心跳
        /// </summary>
        /// <param name="token">身份标识</param>
        /// <returns>返回操作结果</returns>
        [OperationContract]
        NormalResult KeepHeartbeat(string token);

        #endregion
    }
}
