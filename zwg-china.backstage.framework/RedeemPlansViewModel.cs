using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zwg_china.backstage.framework.AdministratorService;
using zwg_china.backstage.framework.ActicityService;

namespace zwg_china.backstage.framework
{
    /// <summary>
    /// 查看积分兑换页的视图模型
    /// </summary>
    public class RedeemPlansViewModel : ShowListViewModelBase<RedeemPlanExport, ActicityServiceClient>
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
                keywordForTitle = value == "" ? null : value;
                OnPropertyChanged("KeywordForTitle");
                Refresh(null);
            }
        }

        #endregion

        #region 构造方法

        public RedeemPlansViewModel()
            : base("活动管理", "查看积分兑换")
        {
            client.GetRedeemPlansCompleted += ShowList;
        }

        #endregion

        #region 保护方法

        protected override void Refresh(object obj)
        {
            int _pageIndex = obj == null ? this.PageIndex : Convert.ToInt32(obj);
            GetRedeemPlansImport import = new GetRedeemPlansImport
            {
                KeywordForTitle = this.KeywordForTitle,
                PageIndex = _pageIndex,
                Token = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo).Token
            };
            client.GetRedeemPlansAsync(import);
        }

        protected override void Reset(object obj)
        {
            this.KeywordForTitle = null;
            this.PageIndex = 1;
            Refresh(null);
        }

        void ShowList(object sender, GetRedeemPlansCompletedEventArgs e)
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
