using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.IsolatedStorage;

namespace zwg_china.client.framework
{
    /// <summary>
    /// 缓存数据的管理者对象
    /// </summary>
    public class DataManager
    {
        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        public static void SetValue(DataKey key, object value)
        {
            IsolatedStorageSettings.ApplicationSettings[key.ToString()] = value;
            IsolatedStorageSettings.ApplicationSettings.Save();
        }

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="key">键</param>
        /// <returns>返回缓存的值</returns>
        public static T GetValue<T>(DataKey key)
        {
            return (T)IsolatedStorageSettings.ApplicationSettings[key.ToString()];
        }

        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="key">键</param>
        public static void RemoveValue(DataKey key)
        {
            IsolatedStorageSettings.ApplicationSettings.Remove(key.ToString());
            IsolatedStorageSettings.ApplicationSettings.Save();
        }

        /// <summary>
        /// 判断缓存是否存在
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="key">键</param>
        /// <returns>返回一个布尔值，表示缓存是否存在</returns>
        public static bool HaveValue<T>(DataKey key)
        {
            return IsolatedStorageSettings.ApplicationSettings.Any(x => x.Key == key.ToString() && x.Value is T);
        }
    }
}
