using Colipu.BasicData.API.Application.Models.Payment;
using Colipu.BasicData.API.Core.BSystemDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace Colipu.BasicData.API.Application.Services.BasicDatas
{
    public interface IPayTypeService: IAppService
    {
        List<PayTypeOutputDto> GetAll(bool isAciveOnly);

        PayTypeOutputDto GetByPayTypeId(int payTypeId, bool isAciveOnly);

        List<PayTypeOutputDto> GetPayTypeBySiteId(int siteId);
    }
}
