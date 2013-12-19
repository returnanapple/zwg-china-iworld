using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zwg_china.backstage.framework.MessageService;
using zwg_china.backstage.framework.AdministratorService;

namespace zwg_china.backstage.framework
{
    /// <summary>
    /// 系统公告设置页的视图模型
    /// </summary>
    public class BulletinsViewModel : ShowListViewModelBase<BulletinExport, MessageServiceClient>
    {
        #region 私有字段

        string keywordOfTitle = null;

        #endregion

        #region 属性

        /// <summary>
        /// 关键字
        /// </summary>
        public string KeywordOfTitle
        {
            get { return keywordOfTitle; }
            set
            {
                if (keywordOfTitle == value) { return; }
                keywordOfTitle = value;
                OnPropertyChanged("KeywordOfTitle");
            }
        }

        #endregion

        #region 构造方法

        public BulletinsViewModel()
            : base("系统设置", "系统公告设置")
        {
        }

        #endregion

        #region 保护方法

        protected override void Refresh(object obj)
        {
            int _pageIndex = obj == null ? this.PageIndex : Convert.ToInt32(obj);
            GetBulletinsImport import = new GetBulletinsImport
            {
                KeywordOfTitle = this.KeywordOfTitle,
                PageIndex = _pageIndex,
                Token = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo).Token
            };
            client.GetBulletinsAsync(import);
        }

        protected override void Reset(object obj)
        {
            this.KeywordOfTitle = null;
            this.PageIndex = 1;
            Refresh(null);
        }

        void ShowList(object sender, GetBulletinsCompletedEventArgs e)
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
