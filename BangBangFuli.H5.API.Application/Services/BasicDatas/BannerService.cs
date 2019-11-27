using System;
using System.Collections.Generic;
using System.Text;
using BangBangFuli.H5.API.Core.Entities;
using BangBangFuli.H5.API.Core.IRepositories.BasicDatas;

namespace BangBangFuli.H5.API.Application.Services.BasicDatas
{
    public class BannerService : IBannerService
    {
        private readonly IBannerRepository _bannerRepository;

        public BannerService(IBannerRepository bannerRepository)
        {
            _bannerRepository = bannerRepository;
        }

        public void Save(Banner banner)
        {
            _bannerRepository.CreateNew(banner);
        }

        public int GetMax()
        {
            return _bannerRepository.GetMax();
        }

        public List<string> GetUniquePhotoNamesByBatchCode(string batchCode)
        {
            return _bannerRepository.GetUniquePhotoNamesByBatchCode(batchCode);
        }
       

    }
}
