using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zwg_china.client.framework.ActicityService;

namespace zwg_china.client.framework
{
    /// <summary>
    /// 兑换活动页面
    /// </summary>
    public class RedeemPlansViewModel : ShowListViewModelBase<RedeemPlanExport, ActicityServiceClient>
    {
        #region 构造方法

        public RedeemPlansViewModel()
            : base("积分兑换")
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
                PageIndex = _pageIndex,
                Token = DataManager.GetValue<string>(DataKey.IWorld_Client_Token)
            };
            client.GetRedeemPlansAsync(import);
        }

        protected override void Reset(object obj)
        {
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
