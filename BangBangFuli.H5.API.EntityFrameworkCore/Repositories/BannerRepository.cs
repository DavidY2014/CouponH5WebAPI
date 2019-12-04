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
        public BannerRepository(IDbContextManager<CouponSystemDBContext> dbContextManager)
: base(dbContextManager)
        {
        }

        public void CreateNew(Banner banner)
        {
            Master.Add(banner);
            Master.SaveChanges();
        }

        public int GetMax()
        {
            return Master.Banners.ToList().Count();
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


    }
}
