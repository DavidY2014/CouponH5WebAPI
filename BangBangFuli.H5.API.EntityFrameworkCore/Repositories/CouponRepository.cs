using BangBangFuli.H5.API.Core.Entities;
using BangBangFuli.H5.API.Core.IRepositories;
using BangBangFuli.Utils.ORM.Imp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BangBangFuli.H5.API.EntityFrameworkCore.Repositories
{
    public class CouponRepository : BaseRepository<CouponSystemDBContext, Coupon>, ICouponRepository
    {
        public CouponRepository(IDbContextManager<CouponSystemDBContext> dbContextManager)
  : base(dbContextManager)
        {
        }

        public List<Coupon> GetAll()
        {
            return Master.Coupons.ToList();
        }

        public Coupon GetCouponByCode(string code)
        {
            var coupon = Master.Coupons.Where(item => item.Code == code).FirstOrDefault();
            return coupon;
        }


        public bool VerifyCoupon(string code ,string password)
        {
            var coupon = Master.Coupons.Where(item => item.Code == code && item.Password == password);
            if (coupon != null && coupon.Count() > 0)
            {
                return true;
            }
            return false;
        }

        public void CreateNew(Coupon coupon)
        {
            Master.Coupons.Add(coupon);
            Master.SaveChanges();
        }


    }
}
