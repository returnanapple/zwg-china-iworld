using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zwg_china.client.framework.LotteryService;

namespace zwg_china.client.framework
{
    /// <summary>
    /// 投注页的视图模型
    /// </summary>
    public class MainViewModel : ManagerViewModelBase
    {
        #region 私有字段

        LotteryTicketExport ticket = null;
        List<ISelectedNumResult> selectedNums = new List<ISelectedNumResult>();

        #endregion

        #region 属性

        /// <summary>
        /// 位
        /// </summary>
        public string Seats
        {
            get { return ticket == null ? "选位" : ticket.Seats; }
        }

        /// <summary>
        /// 初始选号
        /// </summary>
        public int FirstNum
        {
            get { return ticket == null ? 0 : ticket.FirstNum; }
        }

        /// <summary>
        /// 选号个数
        /// </summary>
        public int CountOfNUm
        {
            get { return ticket == null ? 10 : ticket.CountOfNUm; }
        }

        /// <summary>
        /// 选中的号码
        /// </summary>
        public List<ISelectedNumResult> SelectedNums
        {
            get { return selectedNums; }
            set
            {
                if (selectedNums != value)
                {
                    selectedNums = value;
                    OnPropertyChanged("SelectedNums");
                }
            }
        }

        #endregion

        #region 构造方法

        public MainViewModel(string ticketName)
            : base(ticketName)
        {
            List<LotteryTicketExport> tickets = new List<LotteryTicketExport>();
            ticket = tickets.First(x => x.Name == ticketName);

        }

        #endregion
    }
}
