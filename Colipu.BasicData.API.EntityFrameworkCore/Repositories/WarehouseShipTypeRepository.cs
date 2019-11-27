using Colipu.BasicData.API.Core.BSystemDB;
using Colipu.BasicData.API.Core.IRepositories.BasicDatas;
using Colipu.BasicData.API.EntityFrameworkCore.BSystemDB;
using Colipu.Utils.ORM.Imp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Colipu.BasicData.API.EntityFrameworkCore.Repositories
{
    public class WarehouseShipTypeRepository : BaseRepository<BSystemDBContext, WarehouseShipType> , IWarehouseShipTypeRepository
    {
        public WarehouseShipTypeRepository(IDbContextManager<BSystemDBContext> dbContextManager)
  : base(dbContextManager)
        {
        }

        public List<WarehouseShipType> GetAll()
        {
            return MasterSet.ToList();
        }
    }
}
