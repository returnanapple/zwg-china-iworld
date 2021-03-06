﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zwg_china.backstage.framework.ReportService;
using zwg_china.backstage.framework.AdministratorService;

namespace zwg_china.backstage.framework
{
    /// <summary>
    /// 查看个人统计页的视图模型
    /// </summary>
    public class RersonalAndTeamReportsViewModel : ShowListViewModelBase<RersonalAndTeamReportExport, ReportServiceClient>
    {
        #region 私有字段

        string keywordOfUsername = null;
        int? userId = null;
        string mod = "Day";
        string tos = "Self";
        DateTime? beginTime = null;
        DateTime? endTime = null;

        #endregion

        #region 属性

        /// <summary>
        /// 关键字
        /// </summary>
        public string KeywordOfUsername
        {
            get { return keywordOfUsername; }
            set
            {
                if (keywordOfUsername == value) { return; }
                keywordOfUsername = value == "" ? null : value;
                OnPropertyChanged("KeywordOfUsername");
                Refresh(null);
            }
        }

        /// <summary>
        /// 用户的存储指针
        /// </summary>
        public int? UserId
        {
            get { return userId; }
            set
            {
                if (userId == value) { return; }
                userId = value;
                OnPropertyChanged("UserId");
            }
        }

        /// <summary>
        /// 用户的存储指针
        /// </summary>
        public string MOD
        {
            get { return mod; }
            set
            {
                if (value == "") { return; }
                if (mod == value) { return; }
                mod = value;
                OnPropertyChanged("MOD");
                Refresh(null);
            }
        }

        /// <summary>
        /// 团队还是个人 
        /// </summary>
        public string TOS
        {
            get { return tos; }
            set
            {
                if (value == "") { return; }
                if (tos == value) { return; }
                tos = value;
                OnPropertyChanged("TOS");
                Refresh(null);
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
                Refresh(null);
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
                Refresh(null);
            }
        }

        #endregion

        #region 构造方法

        public RersonalAndTeamReportsViewModel()
            : base("数据报表", "查看个人统计")
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
                KeywordOfUsername = this.KeywordOfUsername,
                UserId = this.UserId,
                MOD = (MonthOrDay)Enum.Parse(typeof(MonthOrDay), this.MOD, false),
                TOS = (TeamOrSelf)Enum.Parse(typeof(TeamOrSelf), this.TOS, false),
                BeginTime = this.BeginTime,
                EndTime = this.EndTime,
                PageIndex = _pageIndex,
                Token = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo).Token
            };
            client.GetRersonalAndTeamReportsAsync(import);
        }

        protected override void Reset(object obj)
        {
            this.KeywordOfUsername = null;
            this.UserId = null;
            this.MOD = "Day";
            this.tos = "Self";
            this.BeginTime = null;
            this.EndTime = null;
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
