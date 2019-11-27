using System.Collections.Generic;
using BangBangFuli.H5.API.Core.IRepositories.BasicDatas;
using AutoMapper;
using BangBangFuli.H5.API.Core.BSystemDB;
using BangBangFuli.H5.API.Application.Models.BasicDatas;
using BangBangFuli.H5.API.Application.Models.Delivery;

namespace BangBangFuli.H5.API.Application.Services.BasicDatas
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
