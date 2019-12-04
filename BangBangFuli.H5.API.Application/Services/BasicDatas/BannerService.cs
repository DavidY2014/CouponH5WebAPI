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

        public List<Banner> GetAll()
        {
            return _bannerRepository.GetAll();
        }

        public Banner GetBannerById(int Id)
        {
           return  _bannerRepository.GetBannerById(Id);
        }

        public List<Banner> GetBannersByBatchId(int batchId)
        {
            return _bannerRepository.GetBannersByBatchId(batchId);
        }

    }
}
