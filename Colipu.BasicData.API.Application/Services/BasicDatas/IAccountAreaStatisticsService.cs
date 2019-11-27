using System;
using System.Collections.Generic;
using System.Text;

namespace BangBangFuli.H5.API.Application.Services.BasicDatas
{
    public interface IAccountAreaStatisticsService: IAppService
    {
        /// <summary>
        /// 获取账号的收货地址省市区
        /// </summary>
        /// <param name="accountAreaStatisticsList"></param>
        string GetAccountArea(int accountId, int customerId, bool hasRefer = false);
        /// <summary>
        /// 将客户冗余省市区数据保存到mongodb
        /// </summary>
        /// <param name="accountAreaStatisticsList"></param>
        string SetAccountArea(int accountId, int customerId);

        void RefreshAccountArea(int accountId, int customerId);
    }
}
