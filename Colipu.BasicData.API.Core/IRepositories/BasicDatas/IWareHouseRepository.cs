using Colipu.BasicData.API.Core.BSystemDB;
using Colipu.BasicData.API.Core.Param;
using Colipu.Utils.ORM.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Colipu.BasicData.API.Core.IRepositories.BasicDatas
{
    public interface IWareHouseRepository: IBaseRepository<Warehouse>
    {
        Warehouse GetByLogicalWarehouseId(int logicalWarehouseId);
    }
}
