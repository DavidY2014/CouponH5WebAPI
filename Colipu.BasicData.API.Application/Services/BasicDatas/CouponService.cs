using System;
using System.Collections.Generic;
using System.Text;
using BangBangFuli.H5.API.Core;
using System.Linq;
using BangBangFuli.H5.API.Core.IRepositories;
using BangBangFuli.H5.API.Application.Models.BasicDatas;
using BangBangFuli.H5.API.Application.Services.Redis;
using Newtonsoft.Json;

namespace BangBangFuli.H5.API.Application.Services.BasicDatas
{
    public class CouponService : ICouponService
    {
        private readonly ICouponRepository _couponRepository;

        public CouponService(ICouponRepository couponRepository)
        {
            _couponRepository = couponRepository;
        }



    }
}
