using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zwg_china.backstage.framework.AdministratorService;
using zwg_china.backstage.framework.LotteryService;

namespace zwg_china.backstage.framework
{
    /// <summary>
    /// 查看追号记录页的视图模型
    /// </summary>
    public class ChasingsViewModel : ShowListViewModelBase<ChasingExport, LotteryServiceClient>
    {
        #region 私有字段

        string keywordForUsername = null;
        int? ownerId = null;
        DateTime? beginTime = null;
        DateTime? endTime = null;

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
        public int? OwnerId
        {
            get { return ownerId; }
            set
            {
                if (ownerId == value) { return; }
                ownerId = value;
                OnPropertyChanged("OwnerId");
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

        public ChasingsViewModel()
            : base("彩票管理", "查看追号记录")
        {
        }

        #endregion

        #region 保护方法

        protected override void Refresh(object obj)
        {
            int _pageIndex = obj == null ? this.PageIndex : Convert.ToInt32(obj);
            GetChasingsImport import = new GetChasingsImport
            {
                KeywordForUsername = this.KeywordForUsername,
                OwnerId = this.OwnerId,
                BeginTime = this.BeginTime,
                EndTime = this.EndTime,
                PageIndex = _pageIndex,
                Token = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo).Token
            };
            client.GetChasingsAsync(import);
        }

        protected override void Reset(object obj)
        {
            this.KeywordForUsername = null;
            this.OwnerId = null;
            this.BeginTime = null;
            this.EndTime = null;
            this.PageIndex = 1;
            Refresh(null);
        }

        void ShowList(object sender, GetChasingsCompletedEventArgs e)
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
