using BangBangFuli.H5.API.Core.BSystemDB;
using BangBangFuli.H5.API.Core.Param;
using Colipu.Utils.ORM.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BangBangFuli.H5.API.Core.IRepositories.BasicDatas
{
    public interface IWareHouseRepository: IBaseRepository<Warehouse>
    {
        Warehouse GetByLogicalWarehouseId(int logicalWarehouseId);
    }
}
