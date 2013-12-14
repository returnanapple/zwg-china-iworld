using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace zwg_china.service.backstage
{
    /// <summary>
    /// 用于修改玩法标签的数据集
    /// </summary>
    [DataContract]
    public class EditPlayTagImport
    {
        #region 属性

        /// <summary>
        /// 名称
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// 下辖玩法
        /// </summary>
        [DataMember]
        public List<EditHowToPlayImport> HowToPlays { get; set; }

        /// <summary>
        /// 一个布尔值，表示该玩法标签是否对前台客户隐藏
        /// </summary>
        [DataMember]
        public bool Hide { get; set; }

        #endregion
    }
}
