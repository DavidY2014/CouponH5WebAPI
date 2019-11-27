using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using BangBangFuli.H5.API.Application.Models.BasicDatas;
using BangBangFuli.H5.API.Application.Models.Delivery;
using BangBangFuli.H5.API.Application.Models.Location;
using BangBangFuli.H5.API.Application.Models.Payment;
using BangBangFuli.H5.API.Core;
using Colipu.BasicData.API.Extension.Configuration.DBConfig;
using Colipu.BasicData.API.Extension.Const;

namespace BangBangFuli.H5.API.Application.Services.BasicDatas
{
    public class BSystemService : IBSystemService
    {
        private readonly IMapper _mapper;
        private readonly IAreaInfoService _areaInfoService;
        private readonly IShipTypeUnDistribService _shipTypeUnDistribService;
        private readonly IShipTypeService _shipTypeService;
        private readonly IWarehouseShipTypeService _warehouseShipTypeService;
        private readonly IShipTypeUnPayService _shipTypeUnPayService;
        private readonly IPayTypeService _payTypeService;

        public BSystemService(IMapper mapper,IAreaInfoService areaInfoService, IShipTypeUnDistribService shipTypeUnDistribService, IShipTypeService shipTypeService,
            IWarehouseShipTypeService warehouseShipTypeService, IShipTypeUnPayService shipTypeUnPayService, IPayTypeService payTypeService)
        {
            _mapper = mapper;
            _areaInfoService = areaInfoService;
            _shipTypeUnDistribService = shipTypeUnDistribService;
            _shipTypeService = shipTypeService;
            _warehouseShipTypeService = warehouseShipTypeService;
            _shipTypeUnPayService = shipTypeUnPayService;
            _payTypeService = payTypeService;
        }

        public AreaInfoOutputDto GetAreaInfo(int Id)
        {
            var dto =  _areaInfoService.GetAreaInfo(Id);
            return _mapper.Map<AreaInfoOutputDto>(dto);
        }

        private List<ShipTypeOutputDto> GetShipTypesByDistrict(AreaInfoOutputDto areaInfo, int warehouseId)
        {
            List<ShipTypeOutputDto> result = new List<ShipTypeOutputDto>();
            if (areaInfo == null)
            {
                return null;
            }
            List<int> areaIds = new List<int>() { areaInfo.ProvinceId, areaInfo.CityId, areaInfo.DistrictId };
            var shipTypeUnAreas = this.GetShipTypeUnAreaAll();
            var shipTypesByWarehouse = this.GetShipTypesByWarehouse(warehouseId);
            foreach (var shipType in this.GetShipTypeAll())
            {
                if ((shipTypesByWarehouse != null && !shipTypesByWarehouse.Contains(shipType.Key))
                    || shipTypeUnAreas.Any(x => areaIds.Contains(x.AreaId) && x.ShipTypeId == shipType.Key)
                    || !AppConst.ShipTypeLevels.ContainsKey(shipType.Value.ServiceLevel))
                {
                    continue;
                }
                result.Add(shipType.Value);
            }
            return result;
        }

        private List<ShipTypeUnAreaOutputDto> GetShipTypeUnAreaAll()
        {
            var data =  _shipTypeUnDistribService.GetAll(); ;

            if (data == null)
            {
                return new List<ShipTypeUnAreaOutputDto>();
            }
            return data.Select(x => new ShipTypeUnAreaOutputDto(x)).ToList();
        }


        /// <summary>
        /// 获取配送方式优先级
        /// </summary>
        /// <returns></returns>
        private Dictionary<int, int> GetPriorityShipTypes()
        {
           return   _shipTypeService.GetPriorityShipTypes();
        }

        public List<int> GetShipTypesByWarehouse(int warehouseId)
        {
            return _warehouseShipTypeService.GetShipTypesByWarehouse(warehouseId);
        }

        private Dictionary<int, ShipTypeOutputDto> GetShipTypeAll()
        {
            Dictionary<int, ShipTypeOutputDto> result = new Dictionary<int, ShipTypeOutputDto>();

            var shiptypes = _shipTypeService.GetAll(true);

            if (shiptypes != null && shiptypes.Any())
            {
                result = shiptypes.ToDictionary(key => key.ShipTypeId , value => value);
            }
            return result;
        }

        /// <summary>
        /// 获取当前配送信息
        /// </summary>
        /// <param name="areaInfo">地区</param>
        /// <param name="shiptype">配送方式</param>
        /// <param name="priceAmt">订单总价格</param>
        /// <returns></returns>
        private CheckShipTypeOutputDto GetShipTypeInfo(AreaInfoOutputDto areaInfo, ShipTypeOutputDto shiptype, decimal priceAmt)
        {
            CheckShipTypeOutputDto shipTypeInfo = new CheckShipTypeOutputDto();
            if (shiptype == null)
            {
                shipTypeInfo.ShipPrice = -1m;
                shipTypeInfo.ShipTypeMsg = "未选择配送方式";
                return shipTypeInfo;
            }
            shipTypeInfo.ShipTypeId = shiptype.ShipTypeId;
            shipTypeInfo.ShipTypeName = shiptype.ShipTypeName;
            shipTypeInfo.ServiceLevel = shiptype.ServiceLevel;
            shipTypeInfo.AreaInfo = areaInfo;
            shipTypeInfo.IsSendInvoice = shiptype.IsSendInvoice == AppStruct.YNStruct.Yes;
            if (AppConst.ShipTypeLevels.ContainsKey(shipTypeInfo.ServiceLevel))
            {
                shipTypeInfo.ShipTypeMsg = AppConst.ShipTypeLevels[shipTypeInfo.ServiceLevel];
            }
            //订单总价是否满足免运费
            if (shiptype.FreeShipBase <= priceAmt)
            {
                shipTypeInfo.ShipPrice = 0m;
                return shipTypeInfo;
            }
            shipTypeInfo.ShipPrice = BasicDatacfg.DefaultShipPrice;
            return shipTypeInfo;

        }

        private List<ShipTypeUnPayTypeOutputDto> GetShipTypeUnPayTypeAll()
        {
            var data = _shipTypeUnPayService.GetAll();
            if (data == null)
            {
                return new List<ShipTypeUnPayTypeOutputDto>();
            }
            return data.Select(x => new ShipTypeUnPayTypeOutputDto(x)).ToList();
        }

        public Dictionary<int, PayTypeOutputDto> GetPayTypeBySiteId(int siteId)
        {
            Dictionary<int, PayTypeOutputDto> result = new Dictionary<int, PayTypeOutputDto>();

            var paytypes = _payTypeService.GetPayTypeBySiteId(siteId);

            if (paytypes != null && paytypes.Any())
            {
                result = paytypes.ToDictionary(x => x.PayTypeId, y => y);
            }
            return result;
        }


        /// <summary>
        /// 接口函数
        /// </summary>
        /// <param name="receiveInfo"></param>
        /// <param name="priceAmt"></param>
        /// <returns></returns>

        public List<CheckShipTypeOutputDto> GetUseShipTypes(int districtId,int warehouseId, decimal priceAmt)
        {
            Dictionary<string, List<CheckShipTypeOutputDto>> checkShipTypeDic = new Dictionary<string, List<CheckShipTypeOutputDto>>();
            var areaInfo = this.GetAreaInfo(districtId);
            var shipTypes = this.GetShipTypesByDistrict(areaInfo, warehouseId);
            if (shipTypes == null || !shipTypes.Any())
            {
                return null;
            }
            var priorityShipTypes = this.GetPriorityShipTypes();
            foreach (var level in AppConst.ShipTypeLevels.Keys)
            {
                foreach (var shiptype in shipTypes.Where(x => x.ServiceLevel == level))
                {
                    var shiptypeInfo = this.GetShipTypeInfo(areaInfo, shiptype, priceAmt);
                    if (shiptypeInfo != null && shiptypeInfo.ShipTypeId > 0 && shiptypeInfo.ShipPrice >= 0)
                    {
                        shiptypeInfo.IsPriority = priorityShipTypes != null && priorityShipTypes.ContainsKey(shiptypeInfo.ShipTypeId);
                        if (checkShipTypeDic.ContainsKey(shiptypeInfo.ServiceLevel))
                        {
                            checkShipTypeDic[shiptypeInfo.ServiceLevel].Add(shiptypeInfo);
                        }
                        else
                        {
                            checkShipTypeDic.Add(shiptypeInfo.ServiceLevel, new List<CheckShipTypeOutputDto> { shiptypeInfo });
                        }
                    }
                }
            }

            //排序规则：优先级 > 价格 > 编号
            return checkShipTypeDic.Select(x => x.Value.OrderBy(a => a.IsPriority)
                                                       .ThenBy(a => a.ShipPrice)
                                                       .ThenBy(a => a.ShipTypeId)
                                                       .FirstOrDefault())
                       .ToList();
        }


        /// <summary>
        /// 接口函数
        /// </summary>
        /// <param name="shipTypeId"></param>
        /// <returns></returns>

        public List<PayTypeOutputDto> GetPayTypesByShipType(int shipTypeId,int siteId)
        {
            List<PayTypeOutputDto> result = new List<PayTypeOutputDto>();
            var shipTypeUnPayTypes = this.GetShipTypeUnPayTypeAll();
            // var paytypes = this.GetPayTypeAll();
            var paytypes = this.GetPayTypeBySiteId(siteId); //获取默认站点的支付方式
            if (paytypes != null && paytypes.Any())
            {
                foreach (var paytype in paytypes)
                {
                    if (shipTypeUnPayTypes != null &&
                        shipTypeUnPayTypes.Any(x => x.ShipTypeId == shipTypeId && x.PayTypeId == paytype.Key))
                    {
                        continue;
                    }
                    if (paytype.Value.IsWebsiteShow == AppStruct.YNStruct.Yes)
                    {
                        paytype.Value.PayTypeName = paytype.Value.PayTypeName;
                        result.Add(paytype.Value);
                    }
                }
            }
            return result;
        }
    }
}
