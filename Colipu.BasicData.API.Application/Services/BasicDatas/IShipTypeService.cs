using BangBangFuli.H5.API.Application.Models.Delivery;
using BangBangFuli.H5.API.Core.BSystemDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace BangBangFuli.H5.API.Application.Services.BasicDatas
{
    public interface IShipTypeService: IAppService
    {
        List<ShipTypeOutputDto> GetAll(bool isAciveOnly);

        Dictionary<int, int> GetPriorityShipTypes();

    }
}
