using BangBangFuli.H5.API.Core.Entities;
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Coupon> Coupons { get; set; }

    }
}
