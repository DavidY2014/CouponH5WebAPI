using AutoMapper;
using BangBangFuli.H5.API.Application.Models.BasicDatas;
using BangBangFuli.H5.API.Application.Models.Delivery;
using BangBangFuli.H5.API.Application.Models.Location;
using BangBangFuli.H5.API.Application.Models.Payment;
using BangBangFuli.H5.API.Core.BSystemDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace BangBangFuli.H5.API.Application
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
