using Colipu.BasicData.API.Application.Models.Location;
using Colipu.BasicData.API.Core.BSystemDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace Colipu.BasicData.API.Application.Services.BasicDatas
{
    public interface ILocationService: ICanCacheService
    {
        List<ProvinceOutputDto> GetAllProvinces();

        List<CityOutputDto> GetAllCities();
        List<DistrictOutputDto> GetAllDistricts();
    }
}
