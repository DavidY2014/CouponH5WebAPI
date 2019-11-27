using BangBangFuli.H5.API.Application.Models.Location;
using BangBangFuli.H5.API.Core.BSystemDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace BangBangFuli.H5.API.Application.Services.BasicDatas
{
    public interface ILocationService: ICanCacheService
    {
        List<ProvinceOutputDto> GetAllProvinces();

        List<CityOutputDto> GetAllCities();
        List<DistrictOutputDto> GetAllDistricts();
    }
}
