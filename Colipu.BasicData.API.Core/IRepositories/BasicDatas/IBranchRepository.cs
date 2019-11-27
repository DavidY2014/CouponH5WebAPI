
using BangBangFuli.H5.API.Core.BSystemDB;
using Colipu.Utils.ORM.Interface;
using System.Collections.Generic;

namespace BangBangFuli.H5.API.Core.IRepositories
{
    public interface IBranchRepository: IBaseRepository<Branch>
    {
        List<Branch> GetAll();

        Branch GetBranchById(int branchId);

    }
}
