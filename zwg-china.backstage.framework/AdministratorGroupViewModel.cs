using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zwg_china.backstage.framework.AdministratorService;

namespace zwg_china.backstage.framework
{
    /// <summary>
    /// 查看管理员用户组页的视图模型
    /// </summary>
    public class AdministratorGroupViewModel : ShowListViewModelBase<AdministratorGroupExport, AdministratorServiceClient>
    {
        #region 私有字段

        string keywordForGroupName = null;

        #endregion

        #region 属性

        /// <summary>
        /// 关键字（用户组名）
        /// </summary>
        public string KeywordForGroupName
        {
            get { return keywordForGroupName; }
            set
            {
                if (keywordForGroupName == value) { return; }
                keywordForGroupName = value == "" ? null : value;
                OnPropertyChanged("KeywordForGroupName");
                Refresh(null);
            }
        }

        #endregion

        #region 构造方法

        public AdministratorGroupViewModel()
            : base("管理员组", "查看管理员用户组")
        {
            client.GetAdministratorGroupsCompleted += ShowList;
        }

        #endregion

        #region 保护方法

        protected override void Refresh(object obj)
        {
            int _pageIndex = obj == null ? this.PageIndex : Convert.ToInt32(obj);
            GetAdministratorGroupsImport import = new GetAdministratorGroupsImport
            {
                KeywordForGroupName = this.KeywordForGroupName,
                PageIndex = _pageIndex,
                Token = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo).Token
            };
            client.GetAdministratorGroupsAsync(import);
        }

        protected override void Reset(object obj)
        {
            this.KeywordForGroupName = null;
            this.PageIndex = 1;
            Refresh(null);
        }

        void ShowList(object sender, GetAdministratorGroupsCompletedEventArgs e)
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
