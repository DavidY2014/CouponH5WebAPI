using BangBangFuli.H5.API.Core.Entities;
using BangBangFuli.H5.API.Core.IRepositories.BasicDatas;
using BangBangFuli.Utils.ORM.Imp;
using System;
using System.Collections.Generic;
using System.Text;

namespace BangBangFuli.H5.API.EntityFrameworkCore.Repositories
{
    public class CatelogRepository: BaseRepository<CouponSystemDBContext, Catelog>, ICatelogRepository
    {
        public CatelogRepository(IDbContextManager<CouponSystemDBContext> dbContextManager)
: base(dbContextManager)
        {
        }



    }
}
