using BangBangFuli.H5.API.Application.Models.Payment;
using BangBangFuli.H5.API.Core.BSystemDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace BangBangFuli.H5.API.Application.Services.BasicDatas
{
    public interface IPayTypeService: IAppService
    {
        List<PayTypeOutputDto> GetAll(bool isAciveOnly);

        PayTypeOutputDto GetByPayTypeId(int payTypeId, bool isAciveOnly);

        List<PayTypeOutputDto> GetPayTypeBySiteId(int siteId);
    }
}
