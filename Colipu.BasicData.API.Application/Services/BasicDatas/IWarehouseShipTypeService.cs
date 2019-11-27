using System;
using System.Collections.Generic;
using System.Text;

namespace BangBangFuli.H5.API.Application.Services.BasicDatas
{
    public interface IWarehouseShipTypeService: IAppService
    {
        List<int> GetShipTypesByWarehouse(int warehouseId);
    }
}
