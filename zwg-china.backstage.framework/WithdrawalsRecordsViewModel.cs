using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zwg_china.backstage.framework.AdministratorService;
using zwg_china.backstage.framework.RecordOfAuthorService;

namespace zwg_china.backstage.framework
{
    /// <summary>
    /// 查看提现记录页的视图模型
    /// </summary>
    public class WithdrawalsRecordsViewModel: ShowListViewModelBase<WithdrawalsRecordExport, RecordOfAuthorServiceClient>
    {
        #region 私有字段

        string keywordForUsername = null;
        int? userId = null;
        DateTime? beginTime = null;
        DateTime? endTime = null;
        WithdrawalsStatus? status = null;

        #endregion

        #region 属性

        /// <summary>
        /// 关键字（用户名）
        /// </summary>
        public string KeywordForUsername
        {
            get { return keywordForUsername; }
            set
            {
                if (keywordForUsername == value) { return; }
                keywordForUsername = value;
                OnPropertyChanged("KeywordForUsername");
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

        /// <summary>
        /// 状态
        /// </summary>
        public WithdrawalsStatus? Status
        {
            get { return status; }
            set
            {
                if (status == value) { return; }
                status = value;
                OnPropertyChanged("Status");
            }
        }

        #endregion

        #region 构造方法

        public WithdrawalsRecordsViewModel()
            : base("数据报表", "查看提现记录")
        {
            client.GetWithdrawalsRecordsCompleted += ShowList;
        }

        #endregion

        #region 保护方法

        protected override void Refresh(object obj)
        {
            int _pageIndex = obj == null ? this.PageIndex : Convert.ToInt32(obj);
            GetWithdrawalsRecordsImport import = new GetWithdrawalsRecordsImport
            {
                KeywordForUsername = this.KeywordForUsername,
                UserId = this.UserId,
                BeginTime = this.BeginTime,
                EndTime = this.EndTime,
                Status = this.Status,
                PageIndex = _pageIndex,
                Token = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo).Token
            };
            client.GetWithdrawalsRecordsAsync(import);
        }

        protected override void Reset(object obj)
        {
            this.KeywordForUsername = null;
            this.UserId = null;
            this.BeginTime = null;
            this.EndTime = null;
            this.status = null;
            this.PageIndex = 1;
            Refresh(null);
        }

        void ShowList(object sender, GetWithdrawalsRecordsCompletedEventArgs e)
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
