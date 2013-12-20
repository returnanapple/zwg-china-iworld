using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zwg_china.backstage.framework.AdministratorService;
using zwg_china.backstage.framework.ActicityService;

namespace zwg_china.backstage.framework
{
    /// <summary>
    /// 查看充值奖励页的视图模型
    /// </summary>
    public class RewardForRechargePlansViewModel : ShowListViewModelBase<RewardForRechargePlanExport, ActicityServiceClient>
    {
        #region 私有字段

        string keywordForTitle = null;

        #endregion

        #region 属性

        /// <summary>
        /// 关键字
        /// </summary>
        public string KeywordForTitle
        {
            get { return keywordForTitle; }
            set
            {
                if (keywordForTitle == value) { return; }
                keywordForTitle = value;
                OnPropertyChanged("KeywordForTitle");
            }
        }

        #endregion

        #region 构造方法

        public RewardForRechargePlansViewModel()
            : base("活动管理", "查看充值奖励")
        {
            client.GetRewardForRechargePlansCompleted += ShowList;
        }

        #endregion

        #region 保护方法

        protected override void Refresh(object obj)
        {
            int _pageIndex = obj == null ? this.PageIndex : Convert.ToInt32(obj);
            GetRewardForRechargePlansImport import = new GetRewardForRechargePlansImport
            {
                KeywordForTitle = this.KeywordForTitle,
                PageIndex = _pageIndex,
                Token = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo).Token
            };
            client.GetRewardForRechargePlansAsync(import);
        }

        protected override void Reset(object obj)
        {
            this.KeywordForTitle = null;
            this.PageIndex = 1;
            Refresh(null);
        }

        void ShowList(object sender, GetRewardForRechargePlansCompletedEventArgs e)
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
