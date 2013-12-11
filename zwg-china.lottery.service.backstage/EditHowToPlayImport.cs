using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace zwg_china.service
{
    /// <summary>
    /// 用于修改玩法的数据集
    /// </summary>
    [DataContract]
    public class EditHowToPlayImport
    {
        #region 属性

        /// <summary>
        /// 名称
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// 一个布尔值，表示该玩法是否对前台用户隐藏
        /// </summary>
        [DataMember]
        public bool Hide { get; set; }

        #endregion
    }
}
