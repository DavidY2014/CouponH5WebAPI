using Colipu.BasicData.API.Application.Models.Delivery;
using Colipu.BasicData.API.Core.BSystemDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace Colipu.BasicData.API.Application.Models.BasicDatas
{
    [Serializable]
    public class ShipTypeUnAreaOutputDto
    {
        public ShipTypeUnAreaOutputDto() { }

        public ShipTypeUnAreaOutputDto(ShipTypeUnDistribOutputDto dto)
        {
            if (dto != null)
            {
                this.UnDistribId = dto.UnDistribId;
                this.ShipTypeId = dto.ShipTypeId;
                this.AreaId = dto.AreaId;
            }
        }

        /// <summary>
        /// 系统编号
        /// </summary>
        public int UnDistribId { get; set; }


        /// <summary>
        /// 配送方式系统编号
        /// </summary>
        public int ShipTypeId { get; set; }


        /// <summary>
        /// 地区系统编号
        /// </summary>
        public int AreaId { get; set; }


    }




}
