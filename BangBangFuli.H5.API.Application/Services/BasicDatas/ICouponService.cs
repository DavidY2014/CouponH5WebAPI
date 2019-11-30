using BangBangFuli.H5.API.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BangBangFuli.H5.API.Application.Services.BasicDatas
{
    public interface ICouponService:IAppService
    {

        bool VerifyCoupon(string code, string password);

        Coupon GetCouponByCode(string code);

        List<Coupon> GetAll();

        void AddNew(Coupon coupon);

    }
}
