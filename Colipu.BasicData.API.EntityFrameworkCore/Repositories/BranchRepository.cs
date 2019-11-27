using Colipu.BasicData.API.Core.BSystemDB;
using Colipu.BasicData.API.Core.ECPubDB;
using Colipu.BasicData.API.Core.IRepositories;
using Colipu.BasicData.API.EntityFrameworkCore.BSystemDB;
using Colipu.Utils.ORM.Imp;
using Colipu.Utils.ORM.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Colipu.BasicData.API.EntityFrameworkCore.Repositories
{
    public class BranchRepository : BaseRepository<BSystemDBContext, Branch> ,IBranchRepository
    { 
        public BranchRepository(IDbContextManager<BSystemDBContext> dbContextManager)
          : base(dbContextManager)
        {
        }

        public List<Branch> GetAll()
        {
            return MasterSet.ToList();
        }

        public Branch GetBranchById(int branchId)
        {
            return Where(item => item.BranchId == branchId).FirstOrDefault();
        }
    }
}
