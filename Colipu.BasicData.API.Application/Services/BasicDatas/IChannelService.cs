using Colipu.BasicData.API.Application.Models.BasicDatas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Colipu.BasicData.API.Application.Services.BasicDatas
{
    public interface IChannelService: ICanCacheService
    {
        /// <summary>
        /// 获取所有有效的渠道
        /// </summary>
        /// <returns></returns>
        List<ChannelOutputDto> GetAllChannel();
    }
}
