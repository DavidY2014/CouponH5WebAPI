using AutoMapper;
using BangBangFuli.H5.API.Application.Models.Payment;
using BangBangFuli.H5.API.Core;
using BangBangFuli.H5.API.Core.BSystemDB;
using BangBangFuli.H5.API.Core.IRepositories.BasicDatas;
using BangBangFuli.H5.API.EntityFrameworkCore.BSystemDB;
using System.Collections.Generic;
using System.Linq;

namespace BangBangFuli.H5.API.Application.Services.BasicDatas
{
    public class PayTypeService : IPayTypeService
    {
        private readonly IMapper _mapper;
        private readonly IPayTypeRepository _payTypeRepository;
        private readonly IPayTypeRelationSiteRepository _payTypeRelationSiteRepository;


        public PayTypeService(IMapper mapper,IPayTypeRepository payTypeRepository, IPayTypeRelationSiteRepository payTypeRelationSiteRepository)
        {
            _mapper = mapper;
            _payTypeRepository = payTypeRepository;
            _payTypeRelationSiteRepository = payTypeRelationSiteRepository;
        }

        public List<PayTypeOutputDto> GetAll(bool isAciveOnly)
        {
            var data = _payTypeRepository.GetAll();
            if (!isAciveOnly)
            {
                return _mapper.Map<List<PayTypeOutputDto>>(data);
            }

            return _mapper.Map<List<PayTypeOutputDto>>(data.Where(x => x.Status == "A").OrderBy(x => x.ShowOrder).ToList());


        }

        public PayTypeOutputDto GetByPayTypeId(int payTypeId, bool isAciveOnly)
        {
            var data = _payTypeRepository.GetAll().Where(x => x.PayTypeId == payTypeId);
            if (!isAciveOnly)
            {
                return _mapper.Map<PayTypeOutputDto>(data.FirstOrDefault());
            }
            return _mapper.Map<PayTypeOutputDto>(data.Where(x => x.Status == "A").FirstOrDefault());
        }

        public List<PayTypeOutputDto> GetPayTypeBySiteId(int siteId)
        {
            var data =  (from paySite in _payTypeRelationSiteRepository.GetAll()
                    join payType in _payTypeRepository.GetAll() on paySite.PayTypeId equals payType.PayTypeId
                    where paySite.SiteId == siteId && paySite.IsShow == "Y" && payType.Status == "A"
                    select payType
              ).Distinct().OrderBy(x => x.ShowOrder).ToList();

            return _mapper.Map<List<PayTypeOutputDto>>(data);
        }
    }
}
