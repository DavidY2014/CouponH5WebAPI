using System;
using System.Collections.Generic;
using System.Text;
using Colipu.BasicData.API.Application.Models.BasicDatas;
using Colipu.BasicData.API.Core.BSystemDB;

namespace Colipu.BasicData.API.Application.Services.BasicDatas
{
    public interface IBranchService: ICanCacheService
    {
        BranchOutputDto GetBranchById(int branchId);

        /// <summary>
        /// 获取所有分公司
        /// </summary>
        /// <returns></returns>
        List<BranchOutputDto> GetAllBranch();
    }
}
