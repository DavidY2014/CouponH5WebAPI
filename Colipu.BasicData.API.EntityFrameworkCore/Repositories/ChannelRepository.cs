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
   public  class ChannelRepository : BaseRepository<BSystemDBContext, Channel>, IChannelRepository
    {
        public ChannelRepository(IDbContextManager<BSystemDBContext> dbContextManager)
  : base(dbContextManager)
        {
        }

        public List<Channel> GetAll()
        {
            return MasterSet.ToList();
        }

    }
}
