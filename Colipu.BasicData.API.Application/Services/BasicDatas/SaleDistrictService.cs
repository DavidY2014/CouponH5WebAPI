using Colipu.BasicData.API.Core;
using Colipu.BasicData.API.Core.ECPubDB;
using Colipu.BasicData.API.Core.IRepositories.ECPubs;
using Colipu.BasicData.API.Extension.Const;
using System.Collections.Generic;
using System.Linq;

namespace Colipu.BasicData.API.Application.Services.BasicDatas
{
    public class SaleDistrictService : ISaleDistrictService
    {
        private readonly ISaleDistrictRepository _saleDistrictRepository;
        public SaleDistrictService(ISaleDistrictRepository saleDistrictRepository)
        {
            _saleDistrictRepository = saleDistrictRepository;
        }

        public Dictionary<int, SaleDistrict> GetAll()
        {
            return _saleDistrictRepository.Where(x => x.Status == AppStruct.StatusType.Active).ToDictionary(x => x.DistrictId, y => y);
        }
    }
}
