using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zwg_china.backstage.framework.AuthorService;
using zwg_china.backstage.framework.AdministratorService;

namespace zwg_china.backstage.framework
{
    /// <summary>
    /// 查看用户列表页的视图模型
    /// </summary>
    public class UsersViewModel : ShowListViewModelBase<AuthorExport, AuthorServiceClient>
    {
        #region 私有字段

        string keywordForUsername = null;
        int? groupId = null;
        int? belongingUserId = null;

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
                keywordForUsername = value == "" ? null : value;
                OnPropertyChanged("KeywordForUsername");
                Refresh(null);
            }
        }

        /// <summary>
        /// 所从属的用户组的存储指针
        /// </summary>
        public int? GroupId
        {
            get { return groupId; }
            set
            {
                if (groupId == value) { return; }
                if (value < 0) { return; }
                groupId = value;
                OnPropertyChanged("GroupId");
                Refresh(null);
            }
        }

        /// <summary>
        /// 所隶属的上级（无论是否直属）用户的存储指针
        /// </summary>
        public int? BelongingUserId
        {
            get { return belongingUserId; }
            set
            {
                if (belongingUserId == value) { return; }
                belongingUserId = value;
                OnPropertyChanged("BelongingUserId");
            }
        }

        #endregion

        #region 构造方法

        public UsersViewModel()
            : base("用户管理", "查看用户列表")
        {
            client.GetUsersCompleted += ShowList;
        }

        #endregion

        #region 保护方法

        protected override void Refresh(object obj)
        {
            int _pageIndex = obj == null ? this.PageIndex : Convert.ToInt32(obj);
            GetUsersImport import = new GetUsersImport
            {
                KeywordForUsername = this.KeywordForUsername,
                GroupId = this.GroupId,
                BelongingUserId = this.BelongingUserId,
                PageIndex = _pageIndex,
                Token = DataManager.GetValue<AdministratorExport>(DataKey.IWorld_Backstage_AdministratorInfo).Token
            };
            client.GetUsersAsync(import);
        }

        protected override void Reset(object obj)
        {
            this.KeywordForUsername = null;
            this.GroupId = null;
            this.BelongingUserId = null;
            this.PageIndex = 1;
            Refresh(null);
        }

        void ShowList(object sender, GetUsersCompletedEventArgs e)
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
