using System.Collections.Generic;
using BangBangFuli.H5.API.Core.IRepositories.BasicDatas;
using AutoMapper;
using BangBangFuli.H5.API.Core.BSystemDB;
using BangBangFuli.H5.API.Application.Models.BasicDatas;
using BangBangFuli.H5.API.Application.Models.Delivery;

namespace BangBangFuli.H5.API.Application.Services.BasicDatas
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
