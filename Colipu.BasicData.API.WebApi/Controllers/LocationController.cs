using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BangBangFuli.H5.API.Application.Models.BasicDatas;
using BangBangFuli.H5.API.Application.Models.Location;
using BangBangFuli.H5.API.Application.Services.BasicDatas;
using BangBangFuli.H5.API.WebAPI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BangBangFuli.H5.API.WebAPI.Controllers
{
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly IAreaInfoService _areaInfoService;
        private readonly ILocationService _locationService;
        private readonly IAccountAreaStatisticsService _accountAreaStatisticsService;

        public LocationController(IAreaInfoService areaInfoService, ILocationService locationService, IAccountAreaStatisticsService accountAreaStatisticsService)
        {
            _areaInfoService = areaInfoService;
            _locationService = locationService;
            _accountAreaStatisticsService = accountAreaStatisticsService;
        }

        /// <summary>
        /// 获取全部有效的省市区 树状结构
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/v{version:apiVersion}/Location/AllActiveAreasTree")]
        public ResponseOutput GetAllActiveAreaList()
        {
            var data = _areaInfoService.GetAreaList();
            return new ResponseOutput(data, HttpContext.TraceIdentifier);
        }


        /// <summary>
        /// 根据区编号获取有效的省市信息
        /// </summary>
        /// <param name="districtId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/v{version:apiVersion}/Location/ActiveAreaInfo/{districtId}")]
        public ResponseOutput GetAreaInfo(int districtId)
        {
            AreaInfoOutputDto areainfo  = _areaInfoService.GetAreaInfo(districtId);
            return new ResponseOutput(areainfo, HttpContext.TraceIdentifier);
        }

       
        /// <summary>
        /// 根据省编号获取有效的市,区信息
        /// </summary>
        /// <param name="ProvinceId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/v{version:apiVersion}/Location/ActiveDefaultAreaInfo/{ProvinceId}")]
        public ResponseOutput GetDefaultAreaInfo(int ProvinceId)
        {
            AreaInfoOutputDto areaInfo = _areaInfoService.GetDefaultAreaInfo(ProvinceId);

            return new ResponseOutput(areaInfo, HttpContext.TraceIdentifier);
        }




        #region 过期的


        /// <summary>
        /// 获取账号所有收货地址的省市区集合
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="customerId"></param>
        /// <param name="hasRefer"></param>
        /// <returns></returns>
        [HttpGet]
        [Obsolete]
        [Route("/api/v{version:apiVersion}/Location/{accountId}/{customerId}/{hasRefer}/Areas")]
        public string GetAreaByAccountId(int accountId, int customerId, bool hasRefer)
        {
            return _accountAreaStatisticsService.GetAccountArea(accountId, customerId, hasRefer);
        }

        /// <summary>
        /// 通过GetAreaList 调用，过滤逻辑web 团队自己实现
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/v{version:apiVersion}/Location/SaleArea")]
        [Obsolete]
        public ResponseOutput GetSaleAreaList()
        {
            var data = _areaInfoService.GetSaleAreaList();
            return new ResponseOutput(data, HttpContext.TraceIdentifier);
        }



        /// <summary>
        /// 暂无应用
        /// </summary>
        /// <param name="districtIds"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/v{version:apiVersion}/Location/AreaInfosArray")]
        [Obsolete]
        public ResponseOutput GetAreaInfos([FromQuery]int[] districtIds)
        {
            List<AreaInfoOutputDto> areaInfos = _areaInfoService.GetAreaInfos(districtIds.ToList());

            return new ResponseOutput(areaInfos, HttpContext.TraceIdentifier);
        }

        [HttpGet]
        [Route("/api/v{version:apiVersion}/Location/Provinces")]
        [Obsolete]
        public ResponseOutput GetProvinceAll()
        {
            List<ProvinceOutputDto> provinces = _locationService.GetAllProvinces();

            return new ResponseOutput(provinces, HttpContext.TraceIdentifier);
        }

        [HttpGet]
        [Route("/api/v{version:apiVersion}/Location/Citys")]
        [Obsolete]
        public ResponseOutput GetCityAll()
        {
            List<CityOutputDto> citys = _locationService.GetAllCities();
            return new ResponseOutput(citys, HttpContext.TraceIdentifier);
        }

        [HttpGet]
        [Route("/api/v{version:apiVersion}/Location/Districts")]
        [Obsolete]
        public ResponseOutput GetDistrictAll()
        {
            List<DistrictOutputDto> districts = _locationService.GetAllDistricts();

            return new ResponseOutput(districts, HttpContext.TraceIdentifier);
        }



        #endregion





    }
}
