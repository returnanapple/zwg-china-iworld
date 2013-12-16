using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.client.framework
{
    /// <summary>
    /// 界面标识
    /// </summary>
    public enum Page
    {
        //主界面
        登陆,
        彩票投注,
        //资金管理
        充值,
        提现,
        充值记录,
        提现记录,
        //会员管理
        会员管理,
        //彩票相关
        投注明细,
        //报表
        统计数据,
        帐变明细,
        返点,
        佣金,
        分红,
        //个人中心
        个人信息,
        修改密码,
        修改资金密码,
        修改银行卡绑定,
        //活动
        积分兑换,
        兑换记录
    }
}
