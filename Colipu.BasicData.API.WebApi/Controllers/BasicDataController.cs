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
        //private readonly IECSiteService _ecSiteService;
        //private readonly IBranchService _branchService;
        //private readonly IChannelService _channelService;
        //private readonly IHolidayService _holidayService;
        //private readonly IWarehouseService _warehouseService;


        //public BasicDataController(IECSiteService ecSiteService, IBranchService branchService, 
        //    IChannelService channelService, IHolidayService holidayService, IWarehouseService warehouseService, ICache cache)
        //{
        //    _ecSiteService = ecSiteService;
        //    _branchService = branchService;
        //    _channelService = channelService;
        //    _holidayService = holidayService;
        //    _warehouseService = warehouseService;
        //}


        /// <summary>
        /// 获取所有分公司
        /// </summary>
        /// <returns></returns>
        //[HttpGet]
        //[Route("/api/v{version:apiVersion}/BasicData/AllBranchs")]
        //public ResponseOutput GetAllBranch()
        //{
        //    List<BranchOutputDto> models= _branchService.GetAllBranch();              
        //    return new ResponseOutput(models, HttpContext.TraceIdentifier);
        //}

        ///// <summary>
        ///// 校验下单时间是否节假日
        ///// </summary>
        ///// <param name="orderDateString"></param>
        ///// <returns></returns>
        //[HttpGet]
        //[Route("/api/v{version:apiVersion}/BasicData/IsHoliday/{orderDateString}")]
        //public ResponseOutput CheckIsHoliday(string orderDateString)
        //{
        //    DateTime orderDate = DateTime.ParseExact(orderDateString, "yyyyMMdd", null);
        //    var ret = _holidayService.CheckIsHoliday(orderDate);
        //    return new ResponseOutput(ret, HttpContext.TraceIdentifier);
        //}









    }
}
