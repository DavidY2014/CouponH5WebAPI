using Colipu.BasicData.API.Core.Param;
using Colipu.BasicData.API.Core.BSystemDB;
using System.Collections.Generic;
using Colipu.BasicData.API.Application.Models.BasicDatas;

namespace Colipu.BasicData.API.Application.Services.BasicDatas
{
    public interface IWarehouseService: IAppService
    {
        WarehouseOutputDto GetByLogicalWarehouseId(int logicalWarehouseId);

        /// <summary>
        /// 获取城市配置分仓的逻辑仓编号
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        int GetLogicalWarehouseByCity(int cityId);

        /// <summary>
        /// 多个城市分仓同时获取
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        List<WarehouseParamOutputDto> GetWarehouseByProvince(int provinceId);
    }
}
