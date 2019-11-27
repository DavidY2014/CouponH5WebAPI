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
    public class AccountAreaStatisticsRepository: BaseRepository<BSystemDBContext, AccountAreaStatistics>, IAccountAreaStatisticsRepository
    {
        public AccountAreaStatisticsRepository(IDbContextManager<BSystemDBContext> dbContextManager)
: base(dbContextManager)
        {
        }

        public List<AccountAreaStatistics> GetAll()
        {
            return MasterSet.ToList();
        }
    }
}
