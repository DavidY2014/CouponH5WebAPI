using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Colipu.BasicData.API.Application.Models.BasicDatas;
using Colipu.BasicData.API.Application.Models.Delivery;
using Colipu.BasicData.API.Application.Models.Payment;
using Colipu.BasicData.API.Application.Services.BasicDatas;
using Colipu.BasicData.API.WebApi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Colipu.BasicData.API.WebAPI.Controllers
{
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {
        private readonly IWarehouseShipTypeService _warehouseShipTypeService;
        private readonly IShipTypeService _shipTypeService;
        private readonly IShipTypeUnDistribService _shipTypeUnDistribService;
        private readonly IBSystemService _bSystemService;

        public DeliveryController(IWarehouseShipTypeService warehouseShipTypeService, IShipTypeService shipTypeService, 
            IShipTypeUnDistribService shipTypeUnDistribService, IBSystemService bSystemService)
        {
            _warehouseShipTypeService = warehouseShipTypeService;
            _shipTypeService = shipTypeService;
            _shipTypeUnDistribService = shipTypeUnDistribService;
            _bSystemService = bSystemService;
        }

        /// <summary>
        /// 根据分仓获取有效的配送方式
        /// </summary>
        /// <param name="warehouseId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/v{version:apiVersion}/Delivery/ActiveShipTypes/{warehouseId}")]
        public ResponseOutput GetActiveShipTypesByWarehouse(int warehouseId)
        {
            var data = _warehouseShipTypeService.GetShipTypesByWarehouse(warehouseId);
            return new ResponseOutput(data, HttpContext.TraceIdentifier) ;
        }

        /// <summary>
        /// 获取所有的配送方式(可选)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/v{version:apiVersion}/Delivery/AllShipTypes/{isAciveOnly}")]
        public ResponseOutput GetShipTypeAll(bool isAciveOnly = true)
        {
            List< ShipTypeOutputDto > shipTypes = _shipTypeService.GetAll(isAciveOnly);

            return new ResponseOutput(shipTypes, HttpContext.TraceIdentifier);
        }

        /// <summary>
        /// 根据配送方式和站点过滤获取支付方式
        /// </summary>
        /// <param name="shipTypeId"></param>
        /// <param name="siteId"></param>
        /// <returns></returns>

        [HttpGet]
        [Route("/api/v{version:apiVersion}/Delivery/{shipTypeId}/{siteId}/PayTypes")]
        public ResponseOutput GetPayTypesByShipType(int shipTypeId, int siteId)
        {
            List<PayTypeOutputDto> dtos = _bSystemService.GetPayTypesByShipType(shipTypeId, siteId);
            return new ResponseOutput(dtos, HttpContext.TraceIdentifier);
        }

        /// <summary>
        /// 根据地区，分仓，价格筛选获取当前可使用配送方式
        /// </summary>
        /// <param name="districtId"></param>
        /// <param name="warehouseId"></param>
        /// <param name="priceAmt"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/v{version:apiVersion}/Delivery/{districtId}/{warehouseId}/{priceAmt}/UseShipTypes")]
        public ResponseOutput GetUseShipTypes(int districtId, int warehouseId, decimal priceAmt)
        {
            List<CheckShipTypeOutputDto> checkShipTypeModels = _bSystemService.GetUseShipTypes(districtId, warehouseId, priceAmt);
            return new ResponseOutput(checkShipTypeModels, HttpContext.TraceIdentifier);
        }

        #region 过期的

        [HttpGet]
        [Route("/api/v{version:apiVersion}/Delivery/PriorityShipTypes")]
        [Obsolete]
        public Dictionary<int, int> GetPriorityShipTypes()
        {
            return _shipTypeService.GetPriorityShipTypes();
        }



        [HttpGet]
        [Route("/api/v{version:apiVersion}/Delivery/ShipTypeUnDistribAll")]
        [Obsolete]
        public ResponseOutput GetShipTypeUnDistribAll()
        {
            var models = _shipTypeUnDistribService.GetAll();
            return new ResponseOutput(models, HttpContext.TraceIdentifier);
        }


        #endregion
    }
}
