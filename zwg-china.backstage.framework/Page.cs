﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zwg_china.backstage.framework
{
    /// <summary>
    /// 界面标识
    /// </summary>
    public enum Page
    {
        //基本
        登陆页 = 101,
        首页 = 102,
        //用户管理
        查看用户列表 = 201,
        查看用户组 = 202,
        查看用户登陆记录 = 203,
        查看帐变记录 = 204,
        高点号配额方案 = 205,
        //彩票管理
        查看彩票列表 = 301,
        查看开奖记录 = 302,
        查看投注记录 = 303,
        查看追号记录 = 304,
        查看虚拟排行 = 305,
        //活动管理
        查看注册奖励 = 401,
        查看消费奖励 = 402,
        查看充值奖励 = 403,
        查看积分兑换 = 404,
        //数据报表
        查看站点统计 = 501,
        查看个人统计 = 502,
        查看转账记录 = 503,
        查看充值记录 = 504,
        查看提现记录 = 505,
        查看返点记录 = 506,
        查看佣金记录 = 507,
        查看分红记录 = 508,
        //系统设置
        基础系统设置 = 601,
        用户模块设置 = 602,
        彩票模块设置 = 603,
        银行帐号设置 = 604,
        系统公告设置 = 605,
        //管理员组
        查看管理员列表 = 701,
        查看管理员用户组 = 702,
        查看管理员登陆记录 = 703
    }
}
