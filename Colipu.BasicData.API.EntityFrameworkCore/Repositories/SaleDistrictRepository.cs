using Colipu.BasicData.API.Core.ECPubDB;
using Colipu.BasicData.API.Core.IRepositories.ECPubs;
using Colipu.BasicData.API.EntityFrameworkCore.ECPubDB;
using Colipu.Utils.ORM.Imp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Colipu.BasicData.API.EntityFrameworkCore.Repositories
{
    public class SaleDistrictRepository : BaseRepository<ECPubDBContext, SaleDistrict>, ISaleDistrictRepository
    {
        public SaleDistrictRepository(IDbContextManager<ECPubDBContext> dbContextManager)
  : base(dbContextManager)
        {
        }



    }
}
