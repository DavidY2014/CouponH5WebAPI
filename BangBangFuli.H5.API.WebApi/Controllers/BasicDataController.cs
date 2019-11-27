using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using BangBangFuli.H5.API.Application.Models.BasicDatas;
using BangBangFuli.H5.API.Application.Services.BasicDatas;
using BangBangFuli.H5.API.Application.Services.Redis;
using BangBangFuli.H5.API.WebAPI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace BangBangFuli.H5.API.WebAPI.Controllers
{
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class BasicDataController : ControllerBase
    {
        private readonly ICouponService _couponService;
        private readonly IBannerService _bannerService;

        public BasicDataController(ICouponService couponService,IBannerService bannerService)
        {
            _couponService = couponService;
            _bannerService = bannerService;
        }



        /// <summary>
        /// 获取banner根据批次时间
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/v{version:apiVersion}/BasicData/Banner/{batchCode}")]
        public ResponseOutput GetBannerByBatchCode(string batchCode)
        {
            var photoUniqueNames = _bannerService.GetUniquePhotoNamesByBatchCode(batchCode);
            return new ResponseOutput(photoUniqueNames, HttpContext.TraceIdentifier);
        }










    }
}
