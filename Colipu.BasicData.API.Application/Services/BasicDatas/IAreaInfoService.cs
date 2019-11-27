using BangBangFuli.H5.API.Application.Models.BasicDatas;
using BangBangFuli.H5.API.Application.Models.Location;
using System;
using System.Collections.Generic;
using System.Text;

namespace BangBangFuli.H5.API.Application.Services.BasicDatas
{
    public interface IAreaInfoService: ICanCacheService
    {
        /// <summary>
        /// 获取全部有效的省市区
        /// </summary>
        /// <returns></returns>
        List<ProvinceOutputDto> GetAreaList();

        /// <summary>
        /// 根据区编号获取当前省市区
        /// </summary>
        /// <param name="districtId"></param>
        /// <returns></returns>
        AreaInfoOutputDto GetAreaInfo(int districtId);


        /// <summary>
        /// 根据区编号批量获取当前省市区
        /// </summary>
        /// <param name="districtId"></param>
        /// <returns></returns>
        List<AreaInfoOutputDto> GetAreaInfos(List<int> districtIds);

        /// <summary>
        /// 获取默认省市区
        /// </summary>
        /// <returns></returns>
        AreaInfoOutputDto GetDefaultAreaInfo(int ProvinceId);

        /// <summary>
        /// 获取可销售的省市区
        /// </summary>
        /// <returns></returns>
        List<ProvinceOutputDto> GetSaleAreaList();
    }
}
