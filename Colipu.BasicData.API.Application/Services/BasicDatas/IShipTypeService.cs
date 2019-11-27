using Colipu.BasicData.API.Application.Models.Delivery;
using Colipu.BasicData.API.Core.BSystemDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace Colipu.BasicData.API.Application.Services.BasicDatas
{
    public interface IShipTypeService: IAppService
    {
        List<ShipTypeOutputDto> GetAll(bool isAciveOnly);

        Dictionary<int, int> GetPriorityShipTypes();

    }
}
