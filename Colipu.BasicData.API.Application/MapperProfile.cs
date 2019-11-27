using AutoMapper;
using Colipu.BasicData.API.Application.Models.BasicDatas;
using Colipu.BasicData.API.Application.Models.Delivery;
using Colipu.BasicData.API.Application.Models.Location;
using Colipu.BasicData.API.Application.Models.Payment;
using Colipu.BasicData.API.Core.BSystemDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace Colipu.BasicData.API.Application
{
   public  class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<City, CityOutputDto>();

            CreateMap<District, DistrictOutputDto>();

            CreateMap<Province, ProvinceOutputDto>();

            CreateMap<PayType, PayTypeOutputDto>();

            CreateMap<ShipType, ShipTypeOutputDto>();

            CreateMap<Warehouse, WarehouseOutputDto>();

            CreateMap<WarehouseDeliveryArea, WarehouseDeliveryAreaOutputDto>();

        }

    }
}
