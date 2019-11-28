using System;
using System.Collections.Generic;
using System.Text;
using BangBangFuli.H5.API.Core;
using System.Linq;
using BangBangFuli.H5.API.Core.IRepositories;
using BangBangFuli.H5.API.Application.Models.BasicDatas;
using BangBangFuli.H5.API.Application.Services.Redis;
using Newtonsoft.Json;
using BangBangFuli.H5.API.Core.Entities;

namespace BangBangFuli.H5.API.Application.Services.BasicDatas
{
    public class CouponService : ICouponService
    {
        private readonly ICouponRepository _couponRepository;

        public CouponService(ICouponRepository couponRepository)
        {
            _couponRepository = couponRepository;
        }

        public bool VerifyCoupon(int code, string password)
        {
            return _couponRepository.VerifyCoupon(code, password);
        }

        public Coupon GetCouponByCode(int code)
        {
            return _couponRepository.GetCouponByCode(code);
        }

        public List<Coupon> GetAll()
        {
            return _couponRepository.GetAll();
        }

        public void AddNew(Coupon coupon)
        {
            _couponRepository.CreateNew(coupon);
        }

    }
}
