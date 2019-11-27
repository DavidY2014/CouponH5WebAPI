using Colipu.BasicData.API.Core.BSystemDB;
using Colipu.Utils.ORM.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Colipu.BasicData.API.Core.IRepositories.BasicDatas
{
    public interface IWarehouseShipTypeRepository: IBaseRepository<WarehouseShipType>
    {
        List<WarehouseShipType> GetAll();
    }
}
