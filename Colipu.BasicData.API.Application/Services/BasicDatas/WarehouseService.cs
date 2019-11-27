using Colipu.BasicData.API.Core.Param;
using Colipu.BasicData.API.Core;
using Colipu.BasicData.API.Core.BSystemDB;
using Colipu.BasicData.API.Extension.Configuration.DBConfig;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Colipu.BasicData.API.Application.Models.BasicDatas;
using Colipu.BasicData.API.Core.IRepositories.BasicDatas;

namespace Colipu.BasicData.API.Application.Services.BasicDatas
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IMapper _mapper;
        private readonly IWareHouseRepository _wareHouseRepository;
        private readonly IWarehouseDeliveryAreaRepository _warehouseDeliveryAreaRepository;
        public WarehouseService(IMapper mapper, IWareHouseRepository wareHouseRepository, IWarehouseDeliveryAreaRepository warehouseDeliveryAreaRepository)
        {
            _mapper = mapper;
            _wareHouseRepository = wareHouseRepository;
            _warehouseDeliveryAreaRepository = warehouseDeliveryAreaRepository;
        }
        public WarehouseOutputDto GetByLogicalWarehouseId(int logicalWarehouseId)
        {
            var data = _wareHouseRepository.GetByLogicalWarehouseId(logicalWarehouseId);
            return _mapper.Map<WarehouseOutputDto>(data);
        }

        public int GetLogicalWarehouseByCity(int cityId)
        {
            return  _warehouseDeliveryAreaRepository.GetLogicalWarehouseByCity(cityId);
        }

        public List<WarehouseParamOutputDto> GetWarehouseByProvince(int provinceId)
        {
            return _warehouseDeliveryAreaRepository.GetWarehouseByProvince(provinceId);
        }
    }
}
