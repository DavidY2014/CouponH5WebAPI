using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BangBangFuli.H5.API.Application;
using BangBangFuli.H5.API.Application.Models.BasicDatas;
using BangBangFuli.H5.API.Application.Models.Delivery;
using BangBangFuli.H5.API.Application.Models.Payment;
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
    public class PaymentController : ControllerBase
    {
        private readonly IPayTypeService _payTypeService;
        private readonly IShipTypeUnPayService _shipTypeUnPayService;

        public PaymentController(IPayTypeService payTypeService, IShipTypeUnPayService shipTypeUnPayService)
        {
            _payTypeService = payTypeService;
            _shipTypeUnPayService = shipTypeUnPayService;
        }

        /// <summary>
        /// 获取所有支付方式(状态可选)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/v{version:apiVersion}/Payment/AllPayTypes/{isAciveOnly}")]
        public ResponseOutput GetPayTypeAll(bool isAciveOnly = true)
        {
            List<PayTypeOutputDto> paytypes = _payTypeService.GetAll(isAciveOnly);
            return new ResponseOutput(paytypes, HttpContext.TraceIdentifier);
        }


        /// <summary>
        /// 根据分站获取有效的支付方式
        /// </summary>
        /// <param name="siteId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/v{version:apiVersion}/Payment/ActivePayTypes/{siteId}")]
        public ResponseOutput GetPayTypeBySiteId(int siteId)
        {
            List<PayTypeOutputDto> paytypes = _payTypeService.GetPayTypeBySiteId(siteId);
            return new ResponseOutput(paytypes, HttpContext.TraceIdentifier);
        }


        /// <summary>
        /// 根据支付方式编号获取支付方式(状态可选)
        /// </summary>
        /// <param name="payTypeId"></param>
        /// <param name="isAciveOnly"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/v{version:apiVersion}/Payment/PayTypes/{payTypeId}/{isAciveOnly}")]
        public ResponseOutput GetByPayTypeId(int payTypeId, bool isAciveOnly)
        {
            PayTypeOutputDto payType = _payTypeService.GetByPayTypeId(payTypeId, isAciveOnly);
            return new ResponseOutput(payType, HttpContext.TraceIdentifier);
        }

        /// <summary>
        /// 获取有效的配送方式与支付方式互斥信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/v{version:apiVersion}/Payment/ActiveUnPayShipTypes")]
        public ResponseOutput GetShipTypeUnPayAll()
        {
            List<ShipTypeUnPayOutputDto> models = _shipTypeUnPayService.GetAll();

            return new ResponseOutput(models, HttpContext.TraceIdentifier);
        }


    }
}
