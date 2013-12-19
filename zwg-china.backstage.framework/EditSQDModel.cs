using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zwg_china.backstage.framework.SettingOfAuthorService;

namespace zwg_china.backstage.framework
{
    /// <summary>
    /// 用于修改高点号配额方案的明细的数据模型
    /// </summary>
    public class EditSQDModel : ModelBase
    {
        #region 私有字段

        double rebate = 0;
        int sum = 0;

        #endregion

        #region 属性

        /// <summary>
        /// 名称
        /// </summary>
        public double Rebate
        {
            get { return rebate; }
            set
            {
                if (rebate == value) { return; }
                rebate = value;
                OnPropertyChanged("Rebate");
            }
        }

        /// <summary>
        /// 数额
        /// </summary>
        public int Sum
        {
            get { return sum; }
            set
            {
                if (sum == value) { return; }
                sum = value;
                OnPropertyChanged("Sum");
            }
        }

        #endregion

        #region 构造方法

        public EditSQDModel(SystemQuotaDetailExport model)
        {
            this.Rebate = model.Rebate;
            this.sum = model.Sum;
        }

        #endregion
    }
}
