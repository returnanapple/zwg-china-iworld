using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 系统设置的基类
    /// </summary>
    public class SettingBase
    {
        #region 保护字段

        /// <summary>
        /// 设置明细
        /// </summary>
        protected List<SettingDetail> details = new List<SettingDetail>();

        #endregion

        #region 构造方法

        /// <summary>
        /// 获取一个新的系统设置的副本（空）
        /// </summary>
        public SettingBase()
        {

        }

        /// <summary>
        /// 获取一个新的系统设置的副本
        /// </summary>
        /// <param name="db">数据库连接项目</param>
        public SettingBase(IModelToDbContextOfBase db)
        {
            Type classType = this.GetType();
            classType.GetProperties().ToList().ForEach(property =>
                {
                    if (!property.CanRead) { return; }
                    string key = string.Format("[{0}]{1}", classType.FullName, property.Name);
                    SettingDetail sd = db.SettingDetails.FirstOrDefault(x => x.Key == key);
                    if (sd == null)
                    {
                        string value = property.GetValue(this).ToString();
                        sd = new SettingDetail(key, value);
                    }
                    details.Add(sd);
                });
        }

        #endregion

        #region 方法

        /// <summary>
        /// 将对设置的修改持久化到数据库
        /// </summary>
        /// <param name="db">数据库连接对象</param>
        public void Save(IModelToDbContextOfBase db)
        {
            this.details.ForEach(detail =>
                {
                    SettingDetail sd = db.SettingDetails.FirstOrDefault(x => x.Key == detail.Key);
                    if (sd != null)
                    {
                        sd.Value = detail.Value;
                    }
                    else
                    {
                        db.SettingDetails.Add(detail);
                    }
                });
            db.SaveChanges();
        }

        #endregion

        #region 保护方法

        /// <summary>
        /// 获取类型为双精度浮点数的设定值
        /// </summary>
        /// <param name="propertyName">属性名</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>返回类型为双精度浮点数的设定值</returns>
        protected double GetDoubleValue(string propertyName, double defaultValue)
        {
            Type classType = this.GetType();
            string key = string.Format("[{0}]{1}", classType.FullName, propertyName);
            SettingDetail sd = this.details.FirstOrDefault(x => x.Key == key);
            double result = sd == null
                ? defaultValue
                : Convert.ToDouble(sd.Value);
            return result;
        }

        /// <summary>
        /// 获取类型为短整型的设定值
        /// </summary>
        /// <param name="propertyName">属性名</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>返回类型为短整型的设定值</returns>
        protected int GetIntValue(string propertyName, int defaultValue)
        {
            Type classType = this.GetType();
            string key = string.Format("[{0}]{1}", classType.FullName, propertyName);
            SettingDetail sd = this.details.FirstOrDefault(x => x.Key == key);
            int result = sd == null
                ? defaultValue
                : Convert.ToInt32(sd.Value);
            return result;
        }

        /// <summary>
        /// 获取类型为布尔型的的设定值
        /// </summary>
        /// <param name="propertyName">属性名</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>返回类型为布尔型的的设定值</returns>
        protected bool GetBooleanValue(string propertyName, bool defaultValue)
        {
            Type classType = this.GetType();
            string key = string.Format("[{0}]{1}", classType.FullName, propertyName);
            SettingDetail sd = this.details.FirstOrDefault(x => x.Key == key);
            bool result = sd == null
                ? defaultValue
                : Convert.ToBoolean(sd.Value);
            return result;
        }

        /// <summary>
        /// 获取类型为字符串的设定值
        /// </summary>
        /// <param name="propertyName">属性名</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>返回类型为字符串的设定值</returns>
        protected string GetStringValue(string propertyName, string defaultValue)
        {
            Type classType = this.GetType();
            string key = string.Format("[{0}]{1}", classType.FullName, propertyName);
            SettingDetail sd = this.details.FirstOrDefault(x => x.Key == key);
            string result = sd == null
                ? defaultValue
                : sd.Value;
            return result;
        }

        /// <summary>
        /// 设置
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        protected void SetValue(string propertyName, object value)
        {
            Type classType = this.GetType();
            string key = string.Format("[{0}]{1}", classType.FullName, propertyName);
            SettingDetail sd = this.details.FirstOrDefault(x => x.Key == key);
            if (sd == null)
            {
                sd = new SettingDetail(key, value.ToString());
                this.details.Add(sd);
                return;
            }
            sd.Value = value.ToString();
        }

        #endregion
    }
}
