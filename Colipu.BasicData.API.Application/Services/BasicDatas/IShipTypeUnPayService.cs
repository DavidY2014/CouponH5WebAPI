using BangBangFuli.H5.API.Application.Models.BasicDatas;
using BangBangFuli.H5.API.Application.Models.Delivery;
using System;
using System.Collections.Generic;
using System.Text;

namespace BangBangFuli.H5.API.Application.Services.BasicDatas
{
    public interface IShipTypeUnPayService: IAppService
    {
        List<ShipTypeUnPayOutputDto> GetAll();
    }
}
