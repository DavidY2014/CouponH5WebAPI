using Colipu.BasicData.API.Core.BSystemDB;
using Colipu.BasicData.API.Core.IRepositories.BasicDatas;
using Colipu.BasicData.API.EntityFrameworkCore.BSystemDB;
using Colipu.Utils.ORM.Imp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Colipu.BasicData.API.EntityFrameworkCore.Repositories
{
    public class ECSiteRepository: BaseRepository<BSystemDBContext, Ecsite>, IECSiteRepository
    {
        public ECSiteRepository(IDbContextManager<BSystemDBContext> dbContextManager)
  : base(dbContextManager)
        {
        }


    }
}
