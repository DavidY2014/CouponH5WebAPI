using BangBangFuli.H5.API.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BangBangFuli.H5.API.EntityFrameworkCore
{
    public class DbIniializer
    {
        public static void Initialize(CouponSystemDBContext context)
        {

            #region 添加种子数据

            var coupons = new[]
            {
                new Coupon { Code= "XL1232131", Password="123456"},
                new Coupon { Code= "XL1232132", Password="123456"},
                new Coupon { Code= "XL1232133", Password="123456"},

            };
            foreach (var s in coupons)
                context.Coupons.Add(s);
            context.SaveChanges();


            #endregion

        }
    }
}
