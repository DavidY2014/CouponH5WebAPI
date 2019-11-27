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
   public  class ShipTypeUnPayRepository: BaseRepository<BSystemDBContext, ShipTypeUnPay>, IShipTypeUnPayRepository
    {
        public ShipTypeUnPayRepository(IDbContextManager<BSystemDBContext> dbContextManager)
  : base(dbContextManager)
        {
        }

        public List<ShipTypeUnPay> GetAll()
        {
            string sql = "SELECT * FROM dbo.TShipTypeUnPay(nolock) WHERE Status='A'";
            return Query<ShipTypeUnPay>(sql, null).ToList();
        }

    }
}
