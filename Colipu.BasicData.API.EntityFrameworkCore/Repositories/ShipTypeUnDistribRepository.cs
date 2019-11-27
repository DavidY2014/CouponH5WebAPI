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
    public class ShipTypeUnDistribRepository : BaseRepository<BSystemDBContext, ShipTypeUnDistrib>, IShipTypeUnDistribRepository
    {
        public ShipTypeUnDistribRepository(IDbContextManager<BSystemDBContext> dbContextManager)
  : base(dbContextManager)
        {
        }

        public List<ShipTypeUnDistrib> GetAll()
        {
            string sql = "SELECT * FROM dbo.TShipTypeUnDistrib(nolock) WHERE Status='A'";
            return Query<ShipTypeUnDistrib>(sql, null).ToList();
        }

    }
}
