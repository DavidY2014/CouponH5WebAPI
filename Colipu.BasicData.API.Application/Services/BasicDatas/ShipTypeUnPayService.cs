using System.Collections.Generic;
using Colipu.BasicData.API.Core.IRepositories.BasicDatas;
using AutoMapper;
using Colipu.BasicData.API.Core.BSystemDB;
using Colipu.BasicData.API.Application.Models.BasicDatas;
using Colipu.BasicData.API.Application.Models.Delivery;

namespace Colipu.BasicData.API.Application.Services.BasicDatas
{
    public class ShipTypeUnPayService : IShipTypeUnPayService
    {
        private readonly IShipTypeUnPayRepository _shipTypeUnPayRepository;
        private readonly IMapper _mapper;

        public ShipTypeUnPayService(IMapper mapper,  IShipTypeUnPayRepository shipTypeUnPayRepository)
        {
            _mapper = mapper;
            _shipTypeUnPayRepository = shipTypeUnPayRepository;
        }
        public List<ShipTypeUnPayOutputDto> GetAll()
        {
            var ret = new List<ShipTypeUnPayOutputDto>();
            List<ShipTypeUnPay> entities = _shipTypeUnPayRepository.GetAll();
            foreach (var item in entities)
            {
                ret.Add(new ShipTypeUnPayOutputDto { PayTypeId = item.PayTypeId, ShipTypeId = item.ShipTypeId, UnPayId = item.UnPayId });
            }
            return ret;
        }
    }
}
