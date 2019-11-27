using AutoMapper;
using BangBangFuli.H5.API.Application.Models.Location;
using BangBangFuli.H5.API.Core;
using BangBangFuli.H5.API.Core.BSystemDB;
using BangBangFuli.H5.API.Core.IRepositories.BasicDatas;
using BangBangFuli.H5.API.EntityFrameworkCore.BSystemDB;
using System.Collections.Generic;
using System.Linq;

namespace BangBangFuli.H5.API.Application.Services.BasicDatas
{
    public class LocationService : ILocationService
    {
        private readonly IMapper _mapper;
        private readonly ICityRepository _cityRepository;
        private readonly IDistrictRepository _districtRepository;
        private readonly IProvinceRepository _provinceRepository;
        public LocationService(IMapper mapper, ICityRepository cityRepository, IDistrictRepository districtRepository, IProvinceRepository provinceRepository)
        {
            _mapper = mapper;
            _cityRepository = cityRepository;
            _districtRepository = districtRepository;
            _provinceRepository = provinceRepository;
        }
        public List<CityOutputDto> GetAllCities()
        {
            var data = _cityRepository.GetAll();

            return _mapper.Map<List<CityOutputDto>>(data);
        }

        public List<DistrictOutputDto> GetAllDistricts()
        {
            var data = _districtRepository.GetAll();
            return _mapper.Map<List<DistrictOutputDto>>(data);
        }

        public List<ProvinceOutputDto> GetAllProvinces()
        {
            var data = _provinceRepository.GetAll();
            return _mapper.Map<List<ProvinceOutputDto>>(data);
        }
    }
}
