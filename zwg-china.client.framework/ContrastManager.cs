using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.client.framework
{
    /// <summary>
    /// 对照的管理者对象
    /// </summary>
    public class ContrastManager
    {
        #region 按键分组对照

        static List<ButtonContrast> contrasts = null;

        /// <summary>
        /// 按键分组对照
        /// </summary>
        public static List<ButtonContrast> Contrasts
        {
            get
            {
                if (contrasts == null)
                {
                    ButtonContrast bc1 = new ButtonContrast
                    {
                        GroupName = "时时彩",
                        ButtonNames = new List<string> { "重庆时时彩", "江西时时彩", "新疆时时彩", "五分时时彩" }
                    };
                    ButtonContrast bc2 = new ButtonContrast
                    {
                        GroupName = "十一选五",
                        ButtonNames = new List<string> { "十一夺运金", "广东十一选五", "五分十一选五" }
                    };
                    ButtonContrast bc3 = new ButtonContrast
                    {
                        GroupName = "其他高频彩",
                        ButtonNames = new List<string> { "上海时时乐", "江苏快三" }
                    };
                    ButtonContrast bc4 = new ButtonContrast
                    {
                        GroupName = "低频彩",
                        ButtonNames = new List<string> { "福彩3D", "排列三" }
                    };
                    contrasts = new List<ButtonContrast> { bc1, bc2, bc3, bc4 };

                }
                return contrasts;
            }
        }

        #endregion
    }
}
