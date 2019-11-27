using Colipu.BasicData.API.Application.Models.BasicDatas;
using Colipu.BasicData.API.Application.Models.Delivery;
using System;
using System.Collections.Generic;
using System.Text;

namespace Colipu.BasicData.API.Application.Services.BasicDatas
{
    public interface IShipTypeUnDistribService: IAppService
    {
        List<ShipTypeUnDistribOutputDto> GetAll();
    }
}
