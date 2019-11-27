using BangBangFuli.H5.API.Application.Models.BasicDatas;
using BangBangFuli.H5.API.Application.Models.Payment;
using System;
using System.Collections.Generic;
using System.Text;

namespace BangBangFuli.H5.API.Application.Services.BasicDatas
{
    public interface IBSystemService: IAppService
    {
        /// <summary>
        /// 获取当前可使用配送方式
        /// </summary>
        /// <param name="receiveInfo"></param>
        /// <param name="priceAmt"></param>
        /// <returns></returns>
        List<CheckShipTypeOutputDto> GetUseShipTypes(int districtId, int warehouseId, decimal priceAmt);


        List<PayTypeOutputDto> GetPayTypesByShipType(int shipTypeId, int siteId);
    }
}
