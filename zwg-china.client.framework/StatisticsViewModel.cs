using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zwg_china.client.framework.ReportService;

namespace zwg_china.client.framework
{
    public class StatisticsViewModel : ShowListViewModelBase<RersonalAndTeamReportExport, ReportServiceClient>
    {
        #region 私有字段

        public MonthOrDay mod = MonthOrDay.Day;
        public TeamOrSelf tos = TeamOrSelf.Self;

        #endregion

        #region 属性

        /// <summary>
        /// 月还是日
        /// </summary>
        public MonthOrDay MOD
        {
            get
            {
                return mod;
            }
            set
            {
                if (mod != value)
                {
                    mod = value;
                    OnPropertyChanged("BeginTime");
                }
            }
        }

        /// <summary>
        /// 团队还是个人
        /// </summary>
        public TeamOrSelf TOS
        {
            get
            {
                return tos;
            }
            set
            {
                if (tos != value)
                {
                    tos = value;
                    OnPropertyChanged("EndTime");
                }
            }
        }

        #endregion

        #region 构造方法

        public StatisticsViewModel()
            : base("数据报表")
        {
            client.GetRersonalAndTeamReportsCompleted += ShowList;
        }
        #endregion

        #region 保护方法

        protected override void Refresh(object obj)
        {
            int _pageIndex = obj == null ? this.PageIndex : Convert.ToInt32(obj);
            GetRersonalAndTeamReportsImport import = new GetRersonalAndTeamReportsImport
            {
                MOD = this.MOD,
                TOS = this.TOS,
                PageIndex = _pageIndex,
                Token = DataManager.GetValue<string>(DataKey.IWorld_Client_Token)
            };
            client.GetRersonalAndTeamReportsAsync(import);
        }

        protected override void Reset(object obj)
        {
            this.MOD = MonthOrDay.Day;
            this.TOS = TeamOrSelf.Self;
            this.PageIndex = 1;
            Refresh(null);
        }

        void ShowList(object sender, GetRersonalAndTeamReportsCompletedEventArgs e)
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
