using System;
using System.Collections.Generic;
using System.Text;
using BangBangFuli.H5.API.Application.Models.BasicDatas;
using BangBangFuli.H5.API.Core.BSystemDB;

namespace BangBangFuli.H5.API.Application.Services.BasicDatas
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
