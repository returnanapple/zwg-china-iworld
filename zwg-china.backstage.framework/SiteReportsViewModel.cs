using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zwg_china.backstage.framework.ReportService;
using zwg_china.backstage.framework.AdministratorService;

namespace zwg_china.backstage.framework
{
    /// <summary>
    /// 查看站点统计页的视图模型
    /// </summary>
    public class SiteReportsViewModel : ShowListViewModelBase<SiteReportExpot, ReportServiceClient>
    {
        #region 私有字段

        MonthOrDay mod = MonthOrDay.Day;
        DateTime? beginTime = null;
        DateTime? endTime = null;

        #endregion

        #region 属性

        /// <summary>
        /// 用户的存储指针
        /// </summary>
        public MonthOrDay MOD
        {
            get { return mod; }
            set
            {
                if (mod == value) { return; }
                mod = value;
                OnPropertyChanged("MOD");
            }
        }

        /// <summary>
        /// 起始时间
        /// </summary>
        public DateTime? BeginTime
        {
            get { return beginTime; }
            set
            {
                if (beginTime == value) { return; }
                beginTime = value;
                OnPropertyChanged("BeginTime");
            }
        }

        /// <summary>
        /// 终止时间
        /// </summary>
        public DateTime? EndTime
        {
            get { return endTime; }
            set
            {
                if (endTime == value) { return; }
                endTime = value;
                OnPropertyChanged("EndTime");
            }
        }

        #endregion

        #region 构造方法

        public SiteReportsViewModel()
            : base("数据报表", "查看站点统计")
        {
        }

        #endregion

        #region 保护方法

        protected override void Refresh(object obj)
        {
            int _pageIndex = obj == null ? this.PageIndex : Convert.ToInt32(obj);
            GetSiteReportsImport import = new GetSiteReportsImport
            {
                MOD = this.MOD,
                BeginTime = this.BeginTime,
                EndTime = this.EndTime,
                PageIndex = _pageIndex,
                Token = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo).Token
            };
            client.GetSiteReportsAsync(import);
        }

        protected override void Reset(object obj)
        {
            this.MOD = MonthOrDay.Day;
            this.BeginTime = null;
            this.EndTime = null;
            this.PageIndex = 1;
            Refresh(null);
        }

        void ShowList(object sender, GetSiteReportsCompletedEventArgs e)
        {
            if (e.Result.Success)
            {
                this.PageIndex = e.Result.PageIndex;
                this.TotalPage = e.Result.CountOfPage;
                UpdateLsit(e.Result.List);
            }
            else
            {
                ShowError(e.Result.Error);
            }
        }


        #endregion
    }
}
