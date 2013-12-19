using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zwg_china.backstage.framework.AuthorService;
using zwg_china.backstage.framework.AdministratorService;

namespace zwg_china.backstage.framework
{
    /// <summary>
    /// 查看用户组页的视图模型
    /// </summary>
    public class UserGroupsViewModel : ShowListViewModelBase<UserGroupExport, AuthorServiceClient>
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
                keywordForGroupName = value;
                OnPropertyChanged("KeywordForGroupName");
            }
        }

        #endregion

        #region 构造方法

        public UserGroupsViewModel()
            : base("用户管理", "查看用户组")
        {
        }

        #endregion

        #region 保护方法

        protected override void Refresh(object obj)
        {
            int _pageIndex = obj == null ? this.PageIndex : Convert.ToInt32(obj);
            GetUserGroupsImport import = new GetUserGroupsImport
            {
                KeywordForGroupName = this.KeywordForGroupName,
                PageIndex = _pageIndex,
                Token = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo).Token
            };
            client.GetGroupsAsync(import);
        }

        protected override void Reset(object obj)
        {
            this.KeywordForGroupName = null;
            this.PageIndex = 1;
            Refresh(null);
        }

        void ShowList(object sender, GetGroupsCompletedEventArgs e)
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
