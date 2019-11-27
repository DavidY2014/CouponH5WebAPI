using BangBangFuli.H5.API.Application.Models.Delivery;
using BangBangFuli.H5.API.Core.BSystemDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace BangBangFuli.H5.API.Application.Models.BasicDatas
{
    [Serializable]
    public class ShipTypeUnPayTypeOutputDto
    {
        public ShipTypeUnPayTypeOutputDto(ShipTypeUnPayOutputDto dto) {
            if (dto != null)
            {
                this.UnPayId = dto.UnPayId;
                this.ShipTypeId = dto.ShipTypeId;
                this.PayTypeId = dto.PayTypeId;
            }
        }

        public ShipTypeUnPayTypeOutputDto(ShipTypeUnPay entity)
        {
            if (entity != null)
            {
                this.UnPayId = entity.UnPayId;
                this.ShipTypeId = entity.ShipTypeId;
                this.PayTypeId = entity.PayTypeId;
            }
        }

        /// <summary>
        /// 系统编号
        /// </summary>
        public int UnPayId { get; set; }


        /// <summary>
        /// 配送方式系统编号
        /// </summary>
        public int ShipTypeId { get; set; }


        /// <summary>
        /// 支付方式系统编号
        /// </summary>
        public int PayTypeId { get; set; }

    }
}
