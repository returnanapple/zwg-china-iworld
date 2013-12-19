using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zwg_china.backstage.framework.SettingOfAuthorService;

namespace zwg_china.backstage.framework
{
    /// <summary>
    /// 用于修改高点号配额方案的数据模型
    /// </summary>
    public class EditSQModel : ModelBase
    {
        #region 私有字段

        double rebate = 0;
        List<EditSQDModel> details = new List<EditSQDModel>();

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
        /// 明细
        /// </summary>
        public List<EditSQDModel> Details
        {
            get { return details; }
            set
            {
                if (details == value) { return; }
                details = value;
                OnPropertyChanged("Details");
            }
        }

        #endregion

        #region 构造方法

        public EditSQModel(SystemQuotaExport model)
        {
            this.Rebate = model.Rebate;
            model.Details.ForEach(x =>
                {
                    EditSQDModel sqdm = new EditSQDModel(x);
                    this.Details.Add(sqdm);
                });
        }

        #endregion
    }
}
