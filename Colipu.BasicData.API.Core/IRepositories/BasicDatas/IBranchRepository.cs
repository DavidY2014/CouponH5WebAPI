
using Colipu.BasicData.API.Core.BSystemDB;
using Colipu.Utils.ORM.Interface;
using System.Collections.Generic;

namespace Colipu.BasicData.API.Core.IRepositories
{
    public interface IBranchRepository: IBaseRepository<Branch>
    {
        List<Branch> GetAll();

        Branch GetBranchById(int branchId);

    }
}
