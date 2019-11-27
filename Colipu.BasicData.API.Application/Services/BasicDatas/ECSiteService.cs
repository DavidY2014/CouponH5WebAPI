using Colipu.BasicData.API.Extension.Const;
using System;
using System.Collections.Generic;
using System.Linq;
using BangBangFuli.H5.API.Core.IRepositories.BasicDatas;
using BangBangFuli.H5.API.Application.Models.BasicDatas;

namespace BangBangFuli.H5.API.Application.Services.BasicDatas
{
    public class ECSiteService : IECSiteService
    {

        private readonly IECSiteRepository _ecSiteRepository;
        private readonly IECSiteBranchRepository _ecSiteBranchRepository;

        public ECSiteService(IECSiteRepository ecSiteRepository, IECSiteBranchRepository ecSiteBranchRepository)
        {
            _ecSiteRepository = ecSiteRepository;
            _ecSiteBranchRepository = ecSiteBranchRepository;
        }

        public List<ECSiteOutputDto> GetAllSite()
        {
            var result = _ecSiteRepository.Where(item => item.Status == AppStruct.StatusType.Active).Select(b => new ECSiteOutputDto
            {
                SiteId = b.SiteId,
                SiteName = b.SiteName,
                ChannelId = b.ChannelId,
                CreateTime = b.CreateTime

            });

            return result.ToList();
        }

        public List<int> GetAllSiteId()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取当前分站信息
        /// </summary>
        /// <param name="branchId"></param>
        /// <param name="channelId"></param>
        /// <returns></returns>
        public ECSiteOutputDto GetECSite(int branchId, int channelId)
        {
            var result = from ecsite in _ecSiteRepository.Where(item => item.SiteId >= 0).ToList()
                         join ecsiteBranch in _ecSiteBranchRepository.Where(item => item.SiteId >= 0)
                             on ecsite.SiteId equals ecsiteBranch.SiteId
                         where ecsite.Status == AppStruct.StatusType.Active &&
                             ecsiteBranch.Status == AppStruct.StatusType.Active &&
                             ecsite.ChannelId == channelId &&
                             ecsiteBranch.BranchId == branchId
                         select new ECSiteOutputDto
                         {
                             SiteId = ecsite.SiteId,
                             SiteName = ecsite.SiteName
                         };
            return result.FirstOrDefault();

        }

        public List<int> GetSiteIdByChannel(int channelId)
        {
            return   _ecSiteRepository.Where(x => x.ChannelId == channelId).Select(x => x.SiteId).ToList();
        }
    }
}
