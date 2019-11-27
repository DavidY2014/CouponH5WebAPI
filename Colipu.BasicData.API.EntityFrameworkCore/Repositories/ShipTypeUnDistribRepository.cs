using BangBangFuli.H5.API.Core.BSystemDB;
using BangBangFuli.H5.API.Core.IRepositories.BasicDatas;
using BangBangFuli.H5.API.EntityFrameworkCore.BSystemDB;
using Colipu.Utils.ORM.Imp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BangBangFuli.H5.API.EntityFrameworkCore.Repositories
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
