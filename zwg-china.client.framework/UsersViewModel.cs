using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zwg_china.client.framework.AuthorService;

namespace zwg_china.client.framework
{
    /// <summary>
    /// 会员列表页的视图模型
    /// </summary>
    public class UsersViewModel : ShowListViewModelBase<BasicAuthorExport, AuthorServiceClient>
    {
        #region 私有字段

        public string keywordForUsername = null;
        public bool? onlyImmediate = null;

        #endregion

        #region 属性

        /// <summary>
        /// 关键字（用户名）
        /// </summary>
        public string KeywordForUsername
        {
            get
            {
                return keywordForUsername;
            }
            set
            {
                if (keywordForUsername != value)
                {
                    keywordForUsername = value;
                    OnPropertyChanged("KeywordForUsername");
                }
            }
        }

        /// <summary>
        /// 一个布尔值，表示只查看直属下级
        /// </summary>
        public bool? OnlyImmediate
        {
            get
            {
                return onlyImmediate;
            }
            set
            {
                if (onlyImmediate != value)
                {
                    onlyImmediate = value;
                    OnPropertyChanged("OnlyImmediate");
                }
            }
        }

        /// <summary>
        /// 创建新用户命令
        /// </summary>
        public UniversalCommand CreateUserCommand { get; set; }

        #endregion

        #region 构造方法

        public UsersViewModel()
            : base("会员")
        {
            this.CreateUserCommand = new UniversalCommand(CreateUser);
            client.GetUsersCompleted += ShowList;
            client.CreateUserCompleted += ShowCreateUserResult;
        }

        #endregion

        #region 保护方法

        protected override void Refresh(object obj)
        {
            int _pageIndex = obj == null ? this.PageIndex : Convert.ToInt32(obj);
            GetUsersImport import = new GetUsersImport
            {
                KeywordForUsername = this.KeywordForUsername,
                OnlyImmediate = this.OnlyImmediate,
                PageIndex = _pageIndex,
                Token = DataManager.GetValue<string>(DataKey.IWorld_Client_Token)
            };
            client.GetUsersAsync(import);
        }

        protected override void Reset(object obj)
        {
            this.KeywordForUsername = null;
            this.OnlyImmediate = null;
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

        #region 私有方法

        /// <summary>
        /// 创建新用户
        /// </summary>
        /// <param name="obj"></param>
        void CreateUser(object obj)
        {
            IPop<CreateUserPackage> cw = ViewModelService.GetPop(Pop.CreateUserWindows) as IPop<CreateUserPackage>;
            cw.Closed += CreateUser_do;
            cw.Show();
        }

        void CreateUser_do(object sender, EventArgs e)
        {
            IPop<CreateUserPackage> cw = (IPop<CreateUserPackage>)sender;
            if (cw.DialogResult == true)
            {
                CreateUserImport import = new CreateUserImport
                {
                    Username = cw.State.Username,
                    Password = cw.State.Password,
                    Rebate_Normal = cw.State.Rebate_Normal,
                    Rebate_IndefinitePosition = cw.State.Rebate_IndefinitePosition,
                    Token = DataManager.GetValue<string>(DataKey.IWorld_Client_Token)
                };
                client.CreateUserAsync(import);
            }
        }
        void ShowCreateUserResult(object sender, CreateUserCompletedEventArgs e)
        {
            if (e.Result.Success)
            {
                IPop<string> cw = ViewModelService.GetPop(Pop.ErrorPrompt) as IPop<string>;
                cw.State = "创建下级用户成功";
                cw.Closed += ReflehPage;
                cw.Show();
            }
            else
            {
                ShowError(e.Result.Error);
            }
        }

        void ReflehPage(object sender, EventArgs e)
        {
            Refresh(null);
        }

        #endregion
    }
}
