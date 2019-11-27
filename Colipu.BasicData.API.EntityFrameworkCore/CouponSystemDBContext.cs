
using BangBangFuli.H5.API.Core.CouponSystemDB;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BangBangFuli.H5.API.EntityFrameworkCore
{
    public partial class CouponSystemDBContext : DbContext
    {

        public CouponSystemDBContext(DbContextOptions<CouponSystemDBContext> options)
                   : base(options)
        {
        }
        public DbSet<Coupon> Coupons { get; set; }

    }
}
