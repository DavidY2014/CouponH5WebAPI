using BangBangFuli.H5.API.Application.Models.BasicDatas;
using BangBangFuli.H5.API.Core.IRepositories.BasicDatas;
using Colipu.BasicData.API.Extension.Const;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BangBangFuli.H5.API.Application.Services.BasicDatas
{
    public class ChannelService : IChannelService
    {
        private readonly IChannelRepository _channelRepository;

        public ChannelService(IChannelRepository channelRepository)
        {
            _channelRepository = channelRepository;
        }


        public List<ChannelOutputDto> GetAllChannel()
        {
            var result = _channelRepository.Where(b => b.Status == AppStruct.StatusType.Active).Select(item => new ChannelOutputDto
            {
                ChannelId = item.ChannelId,
                ChannelCode = item.ChannelCode,
                ChannelName = item.ChannelName,
                CreateTime = item.CreateTime,
                CreateUserId = item.CreateUserId,
                Status = item.Status,
                UpdateTime = item.UpdateTime,
                UpdateUserId = item.UpdateUserId
            });

            return result.ToList();

        }
    }
}
