using System;
using System.Collections.Generic;
using System.Text;

namespace Colipu.BasicData.API.Application.Services.BasicDatas
{
    public interface IWarehouseShipTypeService: IAppService
    {
        List<int> GetShipTypesByWarehouse(int warehouseId);
    }
}
