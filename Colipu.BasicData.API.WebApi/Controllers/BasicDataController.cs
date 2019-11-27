using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Colipu.BasicData.API.Application.Models.BasicDatas;
using Colipu.BasicData.API.Application.Services.BasicDatas;
using Colipu.BasicData.API.Application.Services.Redis;
using Colipu.BasicData.API.Core.Param;
using Colipu.BasicData.API.WebApi;
using Colipu.Utils.Cache;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Colipu.BasicData.API.WebAPI.Controllers
{
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class BasicDataController : ControllerBase
    {
        private readonly IECSiteService _ecSiteService;
        private readonly IBranchService _branchService;
        private readonly IChannelService _channelService;
        private readonly IHolidayService _holidayService;
        private readonly IWarehouseService _warehouseService;


        public BasicDataController(IECSiteService ecSiteService, IBranchService branchService, 
            IChannelService channelService, IHolidayService holidayService, IWarehouseService warehouseService, ICache cache)
        {
            _ecSiteService = ecSiteService;
            _branchService = branchService;
            _channelService = channelService;
            _holidayService = holidayService;
            _warehouseService = warehouseService;
        }


        /// <summary>
        /// 获取所有分公司
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/v{version:apiVersion}/BasicData/AllBranchs")]
        public ResponseOutput GetAllBranch()
        {
            List<BranchOutputDto> models= _branchService.GetAllBranch();              
            return new ResponseOutput(models, HttpContext.TraceIdentifier);
        }

        /// <summary>
        /// 获取有效的节假日
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/v{version:apiVersion}/BasicData/AllActiveHolidays")]
        public ResponseOutput GetAllActiveHolidays()
        {
            List<DateTime> datas = _holidayService.GetAll();
            return new ResponseOutput(datas, HttpContext.TraceIdentifier);
        }


        /// <summary>
        /// 校验下单时间是否节假日
        /// </summary>
        /// <param name="orderDateString"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/v{version:apiVersion}/BasicData/IsHoliday/{orderDateString}")]
        public ResponseOutput CheckIsHoliday(string orderDateString)
        {
            DateTime orderDate = DateTime.ParseExact(orderDateString, "yyyyMMdd", null);
            var ret = _holidayService.CheckIsHoliday(orderDate);
            return new ResponseOutput(ret, HttpContext.TraceIdentifier);
        }


        /// <summary>
        /// 根据逻辑仓获取有效的大仓
        /// </summary>
        /// <param name="logicalWarehouseId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/v{version:apiVersion}/BasicData/ActiveWareHouse/{logicalWarehouseId}")]
        public ResponseOutput GetByLogicalWarehouseId(int logicalWarehouseId)
        {
            WarehouseOutputDto warehouse = _warehouseService.GetByLogicalWarehouseId(logicalWarehouseId);

            return new ResponseOutput(warehouse, HttpContext.TraceIdentifier);
        }



        /// <summary>
        /// 根据城市获取有效的逻辑仓
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/v{version:apiVersion}/BasicData/ActiveLogicalWareHouses/{cityId}")]
        public ResponseOutput GetLogicalWarehouseByCity(int cityId)
        {
            int logicalWarehouseId =  _warehouseService.GetLogicalWarehouseByCity(cityId);
            return new ResponseOutput(logicalWarehouseId, HttpContext.TraceIdentifier);
        }


        /// <summary>
        /// 根据省份获取有效的大仓列表
        /// </summary>
        /// <param name="provinceId">省编号</param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/v{version:apiVersion}/BasicData/ActiveWareHouses/{provinceId}")]
        public ResponseOutput GetLogicalWarehouseByProvince(int provinceId)
        {
            List<WarehouseParamOutputDto> datas = _warehouseService.GetWarehouseByProvince(provinceId);
            return new ResponseOutput(datas, HttpContext.TraceIdentifier);
        }

        /// <summary>
        /// 获取所有有效的渠道
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/v{version:apiVersion}/BasicData/AllActiveChannels")]
        public ResponseOutput GetAllActiveChannel()
        {
            List<ChannelOutputDto> models = _channelService.GetAllChannel();

            return new ResponseOutput(models, HttpContext.TraceIdentifier);
        }


        /// <summary>
        /// 根据渠道获取分站
        /// </summary>
        /// <param name="channelId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/v{version:apiVersion}/BasicData/EcSites/{channelId}")]
        public ResponseOutput GetSiteIdByChannel(int channelId)
        {
            List<int> datas = _ecSiteService.GetSiteIdByChannel(channelId);
            return new ResponseOutput(datas, HttpContext.TraceIdentifier);
        }

        /// <summary>
        /// 获取所有有效的分站
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/v{version:apiVersion}/AllActiveBasicData/Sites")]
        public ResponseOutput GetAllActiveSite()
        {
            List<ECSiteOutputDto> models = _ecSiteService.GetAllSite();

            return new ResponseOutput(models, HttpContext.TraceIdentifier);
        }

        /// <summary>
        /// 根据分公司编号获取分公司
        /// </summary>
        /// <param name="branchId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/v{version:apiVersion}/BasicData/Branchs/{branchId}")]
        public ResponseOutput GetBranchById(int branchId)
        {
            BranchOutputDto model = _branchService.GetBranchById(branchId);
            return new ResponseOutput(model, HttpContext.TraceIdentifier);
        }


        #region 过期的

        [HttpGet]
        [Route("/api/v{version:apiVersion}/BasicData/{branchId}/{channelId}/EcSites")]
        [Obsolete]
        public ResponseOutput GetECSite(int branchId, int channelId)
        {
            ECSiteOutputDto model = _ecSiteService.GetECSite(branchId, channelId);
            return new ResponseOutput(model, HttpContext.TraceIdentifier);
        }






        #endregion







    }
}
