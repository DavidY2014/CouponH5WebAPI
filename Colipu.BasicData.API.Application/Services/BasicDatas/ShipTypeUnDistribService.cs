using System.Collections.Generic;
using Colipu.BasicData.API.Core.IRepositories.BasicDatas;
using AutoMapper;
using Colipu.BasicData.API.Core.BSystemDB;
using Colipu.BasicData.API.Application.Models.BasicDatas;
using Colipu.BasicData.API.Application.Models.Delivery;

namespace Colipu.BasicData.API.Application.Services.BasicDatas
{
    public class ShipTypeUnDistribService : IShipTypeUnDistribService
    {
        private readonly IShipTypeUnDistribRepository _shipTypeUnDistribRepository;
        private readonly IMapper _mapper;
        public ShipTypeUnDistribService(IMapper mapper, IShipTypeUnDistribRepository shipTypeUnDistribRepository)
        {
            _mapper = mapper;
            _shipTypeUnDistribRepository = shipTypeUnDistribRepository;
        }
        public List<ShipTypeUnDistribOutputDto> GetAll()
        {
            List<ShipTypeUnDistrib> entities = _shipTypeUnDistribRepository.GetAll();
            return _mapper.Map<List<ShipTypeUnDistribOutputDto>>(entities);
        }
    }
}
