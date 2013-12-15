using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.client.framework
{
    /// <summary>
    /// 弹窗标识
    /// </summary>
    public enum Pop
    {
        /// <summary>
        /// 普通弹窗
        /// </summary>
        NormalPrompt,
        /// <summary>
        /// 错误提示弹窗
        /// </summary>
        ErrorPrompt,
        /// <summary>
        /// 创建用户弹窗
        /// </summary>
        CreateUserWindows,
        /// <summary>
        /// 确认投注弹窗
        /// </summary>
        EnterBettingWindow,
        /// <summary>
        /// 修改返点 - 赔率转换点数弹窗
        /// </summary>
        ChangePoinWindow
    }
}
