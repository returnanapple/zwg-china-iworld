using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model.manager
{
    /// <summary>
    /// 用户相关的系统设置
    /// </summary>
    public class SettingOfAuthor : SettingBase
    {
        #region 属性

        /// <summary>
        /// 允许设置的最低返点
        /// </summary>
        public double LowerRebate
        {
            get { return GetDoubleValue("LowerRebate", 4.5); }
            set { SetValue("LowerRebate", value); }
        }

        /// <summary>
        /// 允许设置的最高返点
        /// </summary>
        public double CapsRebate
        {
            get { return GetDoubleValue("CapsRebate", 13.0); }
            set { SetValue("CapsRebate", value); }
        }

        /// <summary>
        /// “高点号”定义的下限
        /// </summary>
        public double LowerRebateOfHigh
        {
            get { return GetDoubleValue("LowerRebateOfHigh", 12.1); }
            set { SetValue("LowerRebateOfHigh", value); }
        }

        /// <summary>
        /// “高点号”定义的上限
        /// </summary>
        public double CapsRebateOfHigh
        {
            get { return GetDoubleValue("CapsRebateOfHigh", 13.0); }
            set { SetValue("CapsRebateOfHigh", value); }
        }

        /// <summary>
        /// 充值记录超时时间（小时）
        /// </summary>
        public int RechargeRecordTimeout
        {
            get { return GetIntValue("RechargeRecordTimeout", 24); }
            set { SetValue("RechargeRecordTimeout", value); }
        }

        /// <summary>
        /// 推广记录超时时间（小时）
        /// </summary>
        public int SpreadRecordTimeout
        {
            get { return GetIntValue("SpreadRecordTimeout", 24); }
            set { SetValue("SpreadRecordTimeout", value); }
        }

        /// <summary>
        /// 找回密码记录超时时间（小时）
        /// </summary>
        public int ForgotPasswordRecordTimeout
        {
            get { return GetIntValue("ForgotPasswordRecordTimeout", 24); }
            set { SetValue("ForgotPasswordRecordTimeout", value); }
        }

        #endregion

        #region 构造方法

        /// <summary>
        /// 获取一个用户相关的系统设置的副本（空）
        /// </summary>
        public SettingOfAuthor()
        {

        }

        /// <summary>
        /// 获取一个用户相关的系统设置的副本
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public SettingOfAuthor(IModelToDbContextOfBase db)
            : base(db)
        {

        }

        #endregion
    }
}
