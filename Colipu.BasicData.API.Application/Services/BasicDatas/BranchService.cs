using System;
using System.Collections.Generic;
using System.Text;
using BangBangFuli.H5.API.Core;
using System.Linq;
using Colipu.BasicData.API.Extension.Const;
using BangBangFuli.H5.API.Core.BSystemDB;
using BangBangFuli.H5.API.Core.IRepositories;
using BangBangFuli.H5.API.Application.Models.BasicDatas;
using BangBangFuli.H5.API.Application.Services.Redis;
using Newtonsoft.Json;

namespace BangBangFuli.H5.API.Application.Services.BasicDatas
{
    public class BranchService : IBranchService
    {
        private readonly IBranchRepository _branchRepository;

        public BranchService(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }

        /// <summary>
        /// 获取所有分公司
        /// </summary>
        /// <returns></returns>
        public List<BranchOutputDto>  GetAllBranch()
        {
            var result = _branchRepository.GetAll().Select(item => new BranchOutputDto
            {
                BranchId = item.BranchId,
                BranchCode = item.BranchCode,
                BranchFullName = item.BranchFullName,
                BranchName = item.BranchName,
                IsSupportElecInvoice = item.IsSupportElecInvoice,
                UserName = item.UserName
            }).ToList();

            return result;

        }

        public BranchOutputDto GetBranchById(int branchId)
        {
            var branch =  _branchRepository.GetBranchById(branchId);
            if (branch == null)
            {
                return new BranchOutputDto();
            }
            return new BranchOutputDto
            {
                BranchId = branch.BranchId,
                BranchCode = branch.BranchCode,
                BranchName = branch.BranchName,
                BranchFullName = branch.BranchFullName,
                IsSupportElecInvoice = branch.IsSupportElecInvoice,
                UserName=branch.UserName
            };
        }
    }
}
