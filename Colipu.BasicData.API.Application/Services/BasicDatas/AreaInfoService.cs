using Colipu.BasicData.API.Core.BSystemDB;
using Colipu.BasicData.API.Core.ECPubDB;
using Colipu.BasicData.API.Extension.Const;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using Colipu.BasicData.API.EntityFrameworkCore.BSystemDB;
using Colipu.BasicData.API.Core.IRepositories.BasicDatas;
using AutoMapper;
using Colipu.BasicData.API.Application.Models.Location;
using Colipu.BasicData.API.Application.Models.BasicDatas;

namespace Colipu.BasicData.API.Application.Services.BasicDatas
{
    public class AreaInfoService : IAreaInfoService
    {
        private readonly IMapper _mapper;
        private readonly ISaleDistrictService _saleDistrictService;
        private readonly IProvinceRepository _provinceRepository;
        private readonly ICityRepository _cityRepository;
        private readonly IDistrictRepository _districtRepository;

        public AreaInfoService(IMapper mapper, ISaleDistrictService saleDistrictService, IProvinceRepository provinceRepository, ICityRepository cityRepository, IDistrictRepository districtRepository)
        {
            _mapper = mapper;
            _saleDistrictService = saleDistrictService;
            _provinceRepository = provinceRepository;
            _cityRepository = cityRepository;
            _districtRepository = districtRepository;
        }


        public List<ProvinceOutputDto> GetAreaList()
        {
            return this.GetData();
        }

        public List<ProvinceOutputDto> GetSaleAreaList()
        {
            return this.GetData(false);
        }


        public AreaInfoOutputDto GetAreaInfo(int districtId)
        {
            AreaInfoOutputDto data = this.GetData(districtId);
            return data;
        }

        public List<AreaInfoOutputDto> GetAreaInfos(List<int> districtIds)
        {
            List<AreaInfoOutputDto> areaInfos = this.GetDatas(districtIds);
            return areaInfos;
        }

        public AreaInfoOutputDto GetDefaultAreaInfo(int ProvinceId)
        {
            AreaInfoOutputDto data = this.GetDefaultData(ProvinceId);
            return data;
        }


        private List<ProvinceOutputDto> GetData(bool isAll = true)
        {
            List<ProvinceOutputDto> result = new List<ProvinceOutputDto>();
            var proList = this.GetProvinceList();
            var cityList = this.GetCityList();
            var disList = this.GetDistrictList();
            Dictionary<int, SaleDistrict> saleDistrictDic = null;
            if (!isAll)
            {
                saleDistrictDic = _saleDistrictService.GetAll();
            }
            foreach (var p in proList)
            {
                //获取省级信息
                ProvinceOutputDto proInfo = new ProvinceOutputDto();
                proInfo.ProvinceId = p.ProvinceId;
                proInfo.ProvinceName = p.ProvinceName;
                //取出省下的市
                var cityListByProId = cityList.Where(x => x.ProvinceId == p.ProvinceId);
                if (cityListByProId != null && cityListByProId.Any())
                {
                    List<CityOutputDto> cityResult = new List<CityOutputDto>();
                    foreach (var c in cityListByProId)
                    {
                        //获取市级信息
                        CityOutputDto cityInfo = new CityOutputDto();
                        cityInfo.CityId = c.CityId;
                        cityInfo.CityName = c.CityName;
                        //取出市下的区
                        var disListByCityId = disList.Where(x => x.CityId == c.CityId);
                        if (disListByCityId != null && disListByCityId.Any())
                        {
                            List<DistrictOutputDto> disResult = new List<DistrictOutputDto>();
                            foreach (var d in disListByCityId)
                            {
                                //获取区级信息
                                if (isAll || (saleDistrictDic != null && saleDistrictDic.ContainsKey(d.DistrictId)))
                                {
                                    disResult.Add(new DistrictOutputDto
                                    {
                                        DistrictId = d.DistrictId,
                                        DistrictName = d.DistrictName
                                    });
                                }
                            }
                            cityInfo.DistrictList = disResult;
                        }
                        //市下面必须有区
                        if (cityInfo.DistrictList != null && cityInfo.DistrictList.Any())
                            cityResult.Add(cityInfo);
                    }
                    proInfo.CityList = cityResult;
                }
                //省下面必须有市
                if (proInfo.CityList != null && proInfo.CityList.Any())
                    result.Add(proInfo);
            }
            return result;
        }

        public AreaInfoOutputDto GetData(int districtId)
        {

            var result = from p in this.GetProvinceList()
                         join c in this.GetCityList()
                             on p.ProvinceId equals c.ProvinceId
                         join d in this.GetDistrictList()
                             on c.CityId equals d.CityId
                         where p.Status == AppStruct.StatusType.Active &&
                               c.Status == AppStruct.StatusType.Active &&
                               d.Status == AppStruct.StatusType.Active &&
                               d.DistrictId == districtId
                         select new AreaInfoOutputDto
                         {
                             ProvinceId = p.ProvinceId,
                             CityId = c.CityId,
                             ProvinceName = p.ProvinceName,
                             CityName = c.CityName,
                             DistrictId = d.DistrictId,
                             DistrictName = d.DistrictName
                         };
            return result.FirstOrDefault();

        }
        public List<AreaInfoOutputDto> GetDatas(List<int> districtIds)
        {

            var result = from p in this.GetProvinceList()
                         join c in this.GetCityList()
                             on p.ProvinceId equals c.ProvinceId
                         join d in this.GetDistrictList()
                             on c.CityId equals d.CityId
                         where p.Status == AppStruct.StatusType.Active &&
                               c.Status == AppStruct.StatusType.Active &&
                               d.Status == AppStruct.StatusType.Active &&
                               districtIds.Contains(d.DistrictId)
                         select new AreaInfoOutputDto
                         {
                             ProvinceId = p.ProvinceId,
                             CityId = c.CityId,
                             ProvinceName = p.ProvinceName,
                             CityName = c.CityName,
                             DistrictId = d.DistrictId,
                             DistrictName = d.DistrictName
                         };
            return result.ToList();

        }

        public AreaInfoOutputDto GetDefaultData(int ProvinceId)
        {

            var result = from p in this.GetProvinceList()
                         join c in this.GetCityList()
                             on p.ProvinceId equals c.ProvinceId
                         join d in this.GetDistrictList()
                             on c.CityId equals d.CityId
                         where p.Status == AppStruct.StatusType.Active &&
                               c.Status == AppStruct.StatusType.Active &&
                               d.Status == AppStruct.StatusType.Active &&
                               p.ProvinceId == ProvinceId
                         orderby p.ShowOrder, c.ShowOrder, d.ShowOrder
                         select new AreaInfoOutputDto
                         {
                             ProvinceId = p.ProvinceId,
                             CityId = c.CityId,
                             ProvinceName = p.ProvinceName,
                             CityName = c.CityName,
                             DistrictId = d.DistrictId,
                             DistrictName = d.DistrictName
                         };
            return result.FirstOrDefault();

        }

        public List<Province> GetProvinceList()
        {
            return _provinceRepository.GetProvinceList();
        }

        public List<City> GetCityList()
        {
            return _cityRepository.Where(x => x.Status == AppStruct.StatusType.Active).OrderBy(x => x.ShowOrder).ThenBy(x => x.CityId).ToList();
        }

        public List<District> GetDistrictList()
        {
            return _districtRepository.Where(x => x.Status == AppStruct.StatusType.Active).OrderBy(x => x.ShowOrder).ThenBy(x => x.DistrictId).ToList();
        }


    }
}
