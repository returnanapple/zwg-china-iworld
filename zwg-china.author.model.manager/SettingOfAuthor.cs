using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model.manager
{
    /// <summary>
    /// 用户相关的系统设置
    /// </summary>
    public class SettingOfAuthor
    {
        #region 私有字段

        List<SettingDetail> details = new List<SettingDetail>();

        #endregion

        #region 属性

        #endregion

        #region 构造方法

        public SettingOfAuthor(IModelToDbContextOfBase db)
        {
            Type classType = this.GetType();
            classType.GetProperties().ToList().ForEach(property =>
                {
                    if (!property.CanRead) { return; }
                    string key = string.Format("[{0}]{1}", classType.FullName, property.Name);
                    SettingDetail sd = db.SettingDetails.FirstOrDefault(x => x.Key == key);
                    if (sd == null)
                    {

                    }
                    else
                    {
                        details.Add(sd);
                    }
                });
        }

        #endregion
    }
}
