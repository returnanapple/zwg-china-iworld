﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zwg_china.client.framework.RecordOfAuthorService;

namespace zwg_china.client.framework
{
    /// <summary>
    /// 返点记录页的试图模型
    /// </summary>
    public class RebateRecordsViewModel : ShowListViewModelBase<RebateRecordExport, RecordOfAuthorServiceClient>
    {
        #region 私有字段

        public DateTime? beginTime = null;
        public DateTime? endTime = null;

        #endregion

        #region 属性

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? BeginTime
        {
            get
            {
                return beginTime;
            }
            set
            {
                if (beginTime != value)
                {
                    beginTime = value;
                    OnPropertyChanged("BeginTime");
                }
            }
        }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? EndTime
        {
            get
            {
                return endTime;
            }
            set
            {
                if (endTime != value)
                {
                    endTime = value;
                    OnPropertyChanged("EndTime");
                }
            }
        }

        #endregion

        #region 构造方法

        public RebateRecordsViewModel()
            : base("数据报表")
        {
            client.GetRebateRecordsCompleted += ShowList;
        }
        #endregion

        #region 保护方法

        protected override void Refresh(object obj)
        {
            int _pageIndex = obj == null ? this.PageIndex : Convert.ToInt32(obj);
            GetRebateRecordsImport import = new GetRebateRecordsImport
            {
                BeginTime = this.BeginTime,
                EndTime = this.EndTime,
                PageIndex = _pageIndex,
                Token = DataManager.GetValue<string>(DataKey.IWorld_Client_Token)
            };
            client.GetRebateRecordsAsync(import);
        }

        protected override void Reset(object obj)
        {
            this.BeginTime = null;
            this.EndTime = null;
            this.PageIndex = 1;
            Refresh(null);
        }

        void ShowList(object sender, GetRebateRecordsCompletedEventArgs e)
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
