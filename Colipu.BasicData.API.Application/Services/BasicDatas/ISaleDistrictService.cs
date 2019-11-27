using Colipu.BasicData.API.Core.ECPubDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace Colipu.BasicData.API.Application.Services.BasicDatas
{
    public interface ISaleDistrictService: IAppService
    {
        /// <summary>
        /// 获取全部有效的可销售行政区
        /// </summary>
        /// <returns></returns>
        Dictionary<int, SaleDistrict> GetAll();
    }
}
