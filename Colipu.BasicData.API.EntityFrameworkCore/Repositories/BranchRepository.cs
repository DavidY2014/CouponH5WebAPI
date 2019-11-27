using BangBangFuli.H5.API.Core.BSystemDB;
using BangBangFuli.H5.API.Core.ECPubDB;
using BangBangFuli.H5.API.Core.IRepositories;
using BangBangFuli.H5.API.EntityFrameworkCore.BSystemDB;
using Colipu.Utils.ORM.Imp;
using Colipu.Utils.ORM.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BangBangFuli.H5.API.EntityFrameworkCore.Repositories
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
