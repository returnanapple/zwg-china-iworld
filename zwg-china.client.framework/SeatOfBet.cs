using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.client.framework
{
    /// <summary>
    /// 用于投注的位信息
    /// </summary>
    public class SeatOfBet : ModelBase
    {
        #region 私有字段

        string name = "";

        #endregion

        #region 属性

        /// <summary>
        /// 名称
        /// </summary>
        public string Name
        {
            get { return name; }
            set
            {
                if (name == value) { return; }
                name = value;
                OnPropertyChanged("Name");
            }
        }

        /// <summary>
        /// 号码的集合
        /// </summary>
        public List<NumOfBet> Nums { get; set; }

        /// <summary>
        /// 大
        /// </summary>
        public UniversalCommand SelectBigCommand { get; set; }

        /// <summary>
        /// 小
        /// </summary>
        public UniversalCommand SelectSmallCommand { get; set; }

        /// <summary>
        /// 单
        /// </summary>
        public UniversalCommand SelectSingleCommand { get; set; }

        /// <summary>
        /// 双
        /// </summary>
        public UniversalCommand SelectDoubleCommand { get; set; }

        /// <summary>
        /// 全
        /// </summary>
        public UniversalCommand SelectAllCommand { get; set; }

        /// <summary>
        /// 清
        /// </summary>
        public UniversalCommand ClearCommand { get; set; }

        #endregion

        #region 构造方法

        /// <summary>
        /// 实例化一个用于投注的位信息
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="firstNum">首显号码</param>
        /// <param name="countOfNum">总号码数量</param>
        /// <param name="clearBetCommand">清理已选投注的命令</param>
        public SeatOfBet(string name, int firstNum, int countOfNum, UniversalCommand clearBetCommand)
        {
            this.Name = name;
            this.Nums = new List<NumOfBet>();
            for (int i = 0; i < countOfNum; i++)
            {
                NumOfBet num = new NumOfBet(firstNum + i, clearBetCommand);
                this.Nums.Add(num);
            }
            this.SelectBigCommand = new UniversalCommand(new Action<object>(SelectBig));
            this.SelectSmallCommand = new UniversalCommand(new Action<object>(SelectSmall));
            this.SelectSingleCommand = new UniversalCommand(new Action<object>(SelectSingle));
            this.SelectDoubleCommand = new UniversalCommand(new Action<object>(SelectDouble));
            this.SelectAllCommand = new UniversalCommand(new Action<object>(SelectAll));
            this.ClearCommand = new UniversalCommand(new Action<object>(Clear));
        }

        #endregion

        #region 私有方法

        void SelectBig(object obj)
        {
            int t = this.Nums.Count() / 2 + this.Nums.Min(x => x.Num);
            this.Nums.ForEach(x =>
            {
                if (x.Num <= t)
                {
                    x.Selected = false;
                }
                else
                {
                    x.Selected = true;
                }
            });
        }

        void SelectSmall(object obj)
        {
            int t = this.Nums.Count() / 2 + this.Nums.Min(x => x.Num);
            this.Nums.ForEach(x =>
            {
                if (x.Num <= t)
                {
                    x.Selected = true;
                }
                else
                {
                    x.Selected = false;
                }
            });
        }

        void SelectSingle(object obj)
        {
            this.Nums.ForEach(x =>
            {
                if (x.Num % 2 == 0)
                {
                    x.Selected = false;
                }
                else
                {
                    x.Selected = true;
                }
            });
        }

        void SelectDouble(object obj)
        {
            this.Nums.ForEach(x =>
            {
                if (x.Num % 2 == 0)
                {
                    x.Selected = true;
                }
                else
                {
                    x.Selected = false;
                }
            });
        }

        void SelectAll(object obj)
        {
            this.Nums.ForEach(x => x.Selected = true);
        }

        public void Clear(object obj)
        {
            this.Nums.ForEach(x => x.Selected = false);
        }

        #endregion
    }
}
