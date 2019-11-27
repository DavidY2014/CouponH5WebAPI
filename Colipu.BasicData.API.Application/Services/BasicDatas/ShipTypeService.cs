using AutoMapper;
using Colipu.BasicData.API.Application.Models.Delivery;
using Colipu.BasicData.API.Core;
using Colipu.BasicData.API.Core.BSystemDB;
using Colipu.BasicData.API.Core.IRepositories.BasicDatas;
using Colipu.BasicData.API.EntityFrameworkCore.BSystemDB;
using Colipu.BasicData.API.Extension.Const;
using System.Collections.Generic;
using System.Linq;

namespace Colipu.BasicData.API.Application.Services.BasicDatas
{
    public class ShipTypeService : IShipTypeService
    {
        private readonly IMapper _mapper;
        private readonly IShipTypeRepository _shipTypeRepository;

        public ShipTypeService(IMapper mapper, IShipTypeRepository shipTypeRepository)
        {
            _mapper = mapper;
            _shipTypeRepository = shipTypeRepository;
        }

        public List<ShipTypeOutputDto> GetAll(bool isAciveOnly)
        {
            var data = _shipTypeRepository.GetAll();
            if (!isAciveOnly)
            {
                return _mapper.Map<List<ShipTypeOutputDto>>(data);
               
            }
            return _mapper.Map<List<ShipTypeOutputDto>>(data.Where(x => x.Status == "A").OrderBy(x => x.ShowOrder).ToList());
        }

        public Dictionary<int, int> GetPriorityShipTypes()
        {
           return  _shipTypeRepository.GetPriorityShipTypes();
        }
    }
}
