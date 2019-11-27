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

        public List<string> GetUniquePhotoNamesByBatchCode(string batchCode)
        {
            var items = Master.Banners.Where(item => item.BatchCode == batchCode).Select(item => item.Photo).ToList();
            return items;
        }
    }
}
