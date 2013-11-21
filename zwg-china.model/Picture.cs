using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.model
{
    /// <summary>
    /// 图片
    /// </summary>
    public class Picture : ModelBase
    {
        #region 属性

        /// <summary>
        /// 文件名
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// 文件实体
        /// </summary>
        public byte[] FileContent { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个新的图片
        /// </summary>
        public Picture()
        {
        }

        /// <summary>
        /// 实例化一个新的图片
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="fileContent">文件实体</param>
        public Picture(string fileName, byte[] fileContent)
        {
            this.FileName = fileName;
            this.FileContent = fileContent;
        }

        #endregion
    }
}
