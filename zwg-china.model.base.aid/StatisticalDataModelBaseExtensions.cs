using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 统计数据相关的数据模型的基类的拓展
    /// </summary>
    public static class StatisticalDataModelBaseExtensions
    {
        #region 私有方法

        /// <summary>
        /// 增减数额
        /// </summary>
        /// <param name="propertyName">属性名</param>
        /// <param name="propertyValue">属性值</param>
        /// <param name="sum">数额</param>
        /// <returns>返回修改后的属性值</returns>
        static double IncreaseTheSum(string propertyName, double propertyValue, double sum)
        {
            double result = propertyValue + sum;
            if (result < 0)
            {
                throw new Exception(propertyName + "不能小于0");
            }
            return result;
        }

        #endregion

        #region 静态方法

        /// <summary>
        /// 登陆次数+1
        /// </summary>
        /// <param name="model">数据模型</param>
        public static void IncreaseTimesOfLogin(this StatisticalDataModelBase model)
        {
            model.TimesOfLogin++;
        }

        /// <summary>
        /// 增减投注额
        /// </summary>
        /// <param name="model">数据模型</param>
        /// <param name="sum">数额</param>
        public static void IncreaseAmountOfBets(this StatisticalDataModelBase model, double sum)
        {
            model.AmountOfBets = IncreaseTheSum("投注额", model.AmountOfBets, sum);
        }

        /// <summary>
        /// 增减返点
        /// </summary>
        /// <param name="model">数据模型</param>
        /// <param name="sum">数额</param>
        public static void IncreaseRebate(this StatisticalDataModelBase model, double sum)
        {
            model.Rebate = IncreaseTheSum("返点", model.Rebate, sum);
        }

        /// <summary>
        /// 增减奖金
        /// </summary>
        /// <param name="model">数据模型</param>
        /// <param name="sum">数额</param>
        public static void IncreaseRebate(this StatisticalDataModelBase model, double sum)
        {
            model.Bonus = IncreaseTheSum("奖金", model.Bonus, sum);
        }

        /// <summary>
        /// 增减佣金
        /// </summary>
        /// <param name="model">数据模型</param>
        /// <param name="sum">数额</param>
        public static void IncreaseRebate(this StatisticalDataModelBase model, double sum)
        {
            model.Commission = IncreaseTheSum("佣金", model.Commission, sum);
        }

        /// <summary>
        /// 增减分红
        /// </summary>
        /// <param name="model">数据模型</param>
        /// <param name="sum">数额</param>
        public static void IncreaseRebate(this StatisticalDataModelBase model, double sum)
        {
            model.Dividend = IncreaseTheSum("分红", model.Dividend, sum);
        }

        /// <summary>
        /// 增减盈亏
        /// </summary>
        /// <param name="model">数据模型</param>
        /// <param name="sum">数额</param>
        public static void IncreaseRebate(this StatisticalDataModelBase model, double sum)
        {
            model.Profit = IncreaseTheSum("盈亏", model.Profit, sum);
        }

        /// <summary>
        /// 增减充值
        /// </summary>
        /// <param name="model">数据模型</param>
        /// <param name="sum">数额</param>
        public static void IncreaseRebate(this StatisticalDataModelBase model, double sum)
        {
            model.Recharge = IncreaseTheSum("充值", model.Recharge, sum);
        }

        /// <summary>
        /// 增减提现
        /// </summary>
        /// <param name="model">数据模型</param>
        /// <param name="sum">数额</param>
        public static void IncreaseRebate(this StatisticalDataModelBase model, double sum)
        {
            model.Withdrawal = IncreaseTheSum("提现", model.Withdrawal, sum);
        }

        #endregion
    }
}