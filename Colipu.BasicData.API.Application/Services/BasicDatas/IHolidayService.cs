using System;
using System.Collections.Generic;
using System.Text;

namespace BangBangFuli.H5.API.Application.Services.BasicDatas
{
    public interface IHolidayService: ICanCacheService
    {
        List<DateTime> GetAll();

        /// <summary>
        /// 校验下单时间是否节假日
        /// </summary>
        /// <param name="orderData"></param>
        /// <returns></returns>
        bool CheckIsHoliday(DateTime orderData);
    }
}
