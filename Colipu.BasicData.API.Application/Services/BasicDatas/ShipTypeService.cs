using AutoMapper;
using BangBangFuli.H5.API.Application.Models.Delivery;
using BangBangFuli.H5.API.Core;
using BangBangFuli.H5.API.Core.BSystemDB;
using BangBangFuli.H5.API.Core.IRepositories.BasicDatas;
using BangBangFuli.H5.API.EntityFrameworkCore.BSystemDB;
using Colipu.BasicData.API.Extension.Const;
using System.Collections.Generic;
using System.Linq;

namespace BangBangFuli.H5.API.Application.Services.BasicDatas
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
