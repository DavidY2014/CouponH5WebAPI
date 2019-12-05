using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BangBangFuli.H5.API.Core.Entities;
using BangBangFuli.H5.API.Core.IRepositories.BasicDatas;
using BangBangFuli.Utils.ORM.Imp;

namespace BangBangFuli.H5.API.EntityFrameworkCore.Repositories
{
    public class BannerRepository : BaseRepository<CouponSystemDBContext, Banner>, IBannerRepository
    {
        public BannerRepository(CouponSystemDBContext dbContext):base(dbContext)
        {

        }

        public void CreateNew(Banner banner)
        {
            Master.Add(banner);
        }

        public int GetMax()
        {
            return Master.Banners.ToList().Count();
        }

        public void UpdateBanner(Banner banner)
        {
            Master.Banners.Update(banner);
        }


        public List<Banner> GetAll()
        {
            return Master.Banners.ToList();
        }

        public Banner GetBannerById(int Id)
        {
            return Master.Banners.Find(Id);
        }

        public List<Banner> GetBannersByBatchId(int batchId)
        {
            return Master.Banners.Where(item => item.BatchId == batchId).ToList();
        }

        public void RemoveBannerById(int bannerId)
        {
            Banner banner = Master.Banners.Find(bannerId);
            Master.Banners.Remove(banner);
        }

    }
}
