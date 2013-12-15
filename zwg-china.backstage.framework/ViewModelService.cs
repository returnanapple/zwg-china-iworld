﻿using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace zwg_china.backstage.framework
{
    /// <summary>
    /// 视图模型服务
    /// </summary>
    public sealed class ViewModelService
    {
        #region 私有字段

        /// <summary>
        /// 界面创建者的集合
        /// </summary>
        static Dictionary<PageCreaterKey, ControlCreater> _pageCreaters = new Dictionary<PageCreaterKey, ControlCreater>();

        /// <summary>
        /// 弹窗的创建者的基赫
        /// </summary>
        static Dictionary<Pop, WindowCreater> _popCreaters = new Dictionary<Pop, WindowCreater>();

        #endregion

        #region 公开属性

        /// <summary>
        /// 获取当前应用程序的主界面
        /// </summary>
        public static IMainPage Root { get; set; }

        #endregion

        #region 静态方法

        /// <summary>
        /// 初始化视图模型服务
        /// </summary>
        /// <param name="root">当前应用程序的主界面</param>
        public static void Initialize(IMainPage root)
        {
            Root = root;
            Root.RegisterViews();
            JumpToDefaultPage();
        }

        #region 界面

        #region 界面跳转

        /// <summary>
        /// 加载默认界面
        /// </summary>
        public static void JumpToDefaultPage()
        {
            bool haveCreater = _pageCreaters.Any(x => x.Key.IsDefault);
            if (!haveCreater)
            {
                throw new Exception("指定的界面并没有在系统中注册");
            }
            Page page = _pageCreaters.Where(x => x.Key.IsDefault).Select(x => x.Key.Page).Single();
            JumpTo(page);
        }

        /// <summary>
        /// 界面跳转
        /// </summary>
        /// <param name="pageName">界面名称</param>
        public static void JumpTo(string pageName)
        {
            try
            {
                Page page = (Page)Enum.Parse(typeof(Page), pageName, false);
                JumpTo(page);
            }
            catch (Exception)
            {
                JumpToDefaultPage();
            }
        }

        /// <summary>
        /// 界面跳转
        /// </summary>
        /// <param name="page">界面标识</param>
        public static void JumpTo(Page page)
        {
            bool haveCreater = _pageCreaters.Any(x => x.Key.Page == page);
            if (!haveCreater)
            {
                throw new Exception("指定的界面并没有在系统中注册");
            }
            ControlCreater creater = _pageCreaters.Where(x => x.Key.Page == page).Select(x => x.Value).Single();
            UserControl userControl = creater();
            Root.DataContext = GetViewModel(page);
            Root.Show(userControl);
        }
        #region 获取ViewModel实例

        /// <summary>
        /// 获取ViewModel实例
        /// </summary>
        /// <param name="page">界面标识</param>
        /// <returns>返回ViewModel实例</returns>
        static object GetViewModel(Page page)
        {
            string viewModelName = _pageCreaters.Where(x => x.Key.Page == page).Select(x => x.Key.ViewModelName).Single();
            Assembly assembly = Assembly.GetExecutingAssembly();
            return assembly.CreateInstance(viewModelName);
        }

        #endregion

        #endregion

        #region 可跳转界面注册

        /// <summary>
        /// 注册可跳转界面
        /// </summary>
        /// <param name="page">界面标识</param>
        /// <param name="pageName">界面名称</param>
        /// <param name="creater">对应的创建者委托</param>
        public static void RegisterPage(Page page, string pageName, bool isDefault, ControlCreater creater)
        {
            #region 检查界面池

            bool haveCreater = _pageCreaters.Any(x => x.Key.Page == page);
            if (haveCreater)
            {
                throw new Exception("该界面已经被注册到界面池，请检查程序");
            }
            bool hadDefault = _pageCreaters.Any(x => x.Key.IsDefault);
            if (hadDefault)
            {
                throw new Exception("已经有一个被声明为默认界面的界面被注册到界面池，请检查程序");
            }

            #endregion

            PageCreaterKey key = new PageCreaterKey(page, pageName, isDefault);
            _pageCreaters.Add(key, creater);
        }

        #endregion

        #endregion

        #region 弹窗

        #region 获取弹窗对象

        /// <summary>
        /// 获取弹窗对象
        /// </summary>
        /// <param name="pop">弹窗标识</param>
        /// <returns>返回弹窗对象</returns>
        public static IPop GetPop(Pop pop)
        {
            bool hadPop = _popCreaters.Any(x => x.Key == pop);
            if (!hadPop)
            {
                throw new Exception("该弹窗没有被注册");
            }

            WindowCreater creater = _popCreaters.Where(x => x.Key == pop).Select(x => x.Value).Single();
            ChildWindow cw = creater();
            return cw as IPop;
        }

        #endregion

        #region 弹窗注册

        /// <summary>
        /// 注册弹窗
        /// </summary>
        /// <param name="pop">弹窗标识</param>
        /// <param name="creater">弹窗的创建者对象</param>
        public static void RegisterPop(Pop pop, WindowCreater creater)
        {
            #region 检查弹窗池

            bool hadPop = _popCreaters.Any(x => x.Key == pop);
            if (hadPop)
            {
                throw new Exception("该弹窗已经被注册到弹窗池，请检查程序");
            }

            #endregion

            _popCreaters.Add(pop, creater);
        }

        #endregion

        #endregion

        #endregion

        #region 内嵌类型/委托

        /// <summary>
        /// UI元素的创建者委托
        /// </summary>
        /// <returns>返回界面实例</returns>
        public delegate UserControl ControlCreater();

        /// <summary>
        /// 弹窗元素的创建者委托
        /// </summary>
        /// <returns>返回子窗口实例</returns>
        public delegate ChildWindow WindowCreater();

        /// <summary>
        /// 界面创建者的对照键值信息封装
        /// </summary>
        class PageCreaterKey
        {
            /// <summary>
            /// 界面标识
            /// </summary>
            public Page Page { get; protected set; }

            /// <summary>
            /// 视图模型的名称
            /// </summary>
            public string ViewModelName { get; protected set; }

            /// <summary>
            /// 一个布尔值 表示被标记对象是否为默认界面
            /// </summary>
            public bool IsDefault { get; protected set; }

            /// <summary>
            /// 界面创建者的对照键值信息封装
            /// </summary>
            /// <param name="page">界面标识</param>
            /// <param name="pageName">视图模型的名称</param>
            /// <param name="isDefault">一个布尔值 表示被标记对象是否为默认界面</param>
            public PageCreaterKey(Page page, string pageName, bool isDefault)
            {
                this.Page = page;
                this.IsDefault = isDefault;
                pageName = new Regex("Page").Replace(pageName, "ViewModel");
                string vmName = string.Format("zwg_china.backstage.framework.{0}", pageName);
                this.ViewModelName = vmName;
            }
        }

        #endregion
    }
}
