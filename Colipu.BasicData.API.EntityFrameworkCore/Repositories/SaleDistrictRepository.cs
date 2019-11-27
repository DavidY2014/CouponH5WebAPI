using BangBangFuli.H5.API.Core.ECPubDB;
using BangBangFuli.H5.API.Core.IRepositories.ECPubs;
using BangBangFuli.H5.API.EntityFrameworkCore.ECPubDB;
using Colipu.Utils.ORM.Imp;
using System;
using System.Collections.Generic;
using System.Text;

namespace BangBangFuli.H5.API.EntityFrameworkCore.Repositories
{
    public class SaleDistrictRepository : BaseRepository<ECPubDBContext, SaleDistrict>, ISaleDistrictRepository
    {
        public SaleDistrictRepository(IDbContextManager<ECPubDBContext> dbContextManager)
  : base(dbContextManager)
        {
        }



    }
}
