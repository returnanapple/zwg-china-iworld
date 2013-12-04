using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace zwg_china.service
{
    /// <summary>
    /// 分页列表信息
    /// </summary>
    /// <typeparam name="T">所要传递的信息的类型</typeparam>
    [DataContract]
    public class PageResult<T> : NormalResult
    {
        #region 属性

        /// <summary>
        /// 页码
        /// </summary>
        public int PageInde { get; set; }

        /// <summary>
        /// 页面总数
        /// </summary>
        public int CountOfPage { get; set; }

        /// <summary>
        /// 页面大小
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 列表
        /// </summary>
        [DataMember]
        public List<T> List { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的分页列表信息（操作成功）
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="countOfPage">页面总数</param>
        /// <param name="pageSize">页面大小</param>
        /// <param name="list">列表</param>
        public PageResult(int pageIndex, int countOfPage, int pageSize, List<T> list)
        {
            this.PageInde = pageIndex;
            this.CountOfPage = countOfPage;
            this.PageSize = pageSize;
            this.List = list;
        }

        /// <summary>
        /// 实例化一个新的分页列表信息（操作失败）
        /// </summary>
        /// <param name="error">错误信息</param>
        public PageResult(string error)
            : base(error)
        {

        }

        #endregion
    }
}
