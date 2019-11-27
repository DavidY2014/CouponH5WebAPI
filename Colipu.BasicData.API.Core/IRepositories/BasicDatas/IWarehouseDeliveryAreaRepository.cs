using Colipu.BasicData.API.Core.BSystemDB;
using Colipu.BasicData.API.Core.Param;
using Colipu.Utils.ORM.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Colipu.BasicData.API.Core.IRepositories.BasicDatas
{
   public interface IWarehouseDeliveryAreaRepository: IBaseRepository<WarehouseDeliveryArea>
    {
        int GetLogicalWarehouseByCity(int cityId);
        List<WarehouseParamOutputDto> GetWarehouseByProvince(int provinceId);
    }
}
