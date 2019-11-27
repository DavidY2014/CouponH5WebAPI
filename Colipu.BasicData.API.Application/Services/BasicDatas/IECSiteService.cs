using Colipu.BasicData.API.Application.Models.BasicDatas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Colipu.BasicData.API.Application.Services.BasicDatas
{
    public interface IECSiteService: IAppService
    {
        /// <summary>
        /// 获取当前分站信息
        /// </summary>
        /// <param name="branchId"></param>
        /// <param name="channelId"></param>
        /// <returns></returns>
        ECSiteOutputDto GetECSite(int branchId, int channelId);

        /// <summary>
        /// 根据渠道获取分站
        /// </summary>
        /// <param name="channelId"></param>
        /// <returns></returns>
        List<int> GetSiteIdByChannel(int channelId);
        /// <summary>
        /// 获取所有分站
        /// </summary>
        /// <returns></returns>
        List<int> GetAllSiteId();

        /// <summary>
        /// 获取所有分站
        /// </summary>
        /// <returns></returns>
        List<ECSiteOutputDto> GetAllSite();
    }
}
