using BangBangFuli.H5.API.Application.Models.BasicDatas;
using System;
using System.Collections.Generic;
using System.Text;

namespace BangBangFuli.H5.API.Application.Services.BasicDatas
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
