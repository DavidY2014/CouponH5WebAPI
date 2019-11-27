using Colipu.BasicData.API.Application.Models.Location;
using System;
using System.Collections.Generic;
using System.Text;

namespace Colipu.BasicData.API.Application.Models.BasicDatas
{
    [Serializable]
    public class CheckShipTypeOutputDto
    {
        public int ShipTypeId { get; set; }

        /// <summary>
        /// 地址配送区域编号
        /// </summary>
        public AreaInfoOutputDto AreaInfo { get; set; }

        /// <summary>
        /// 运费
        /// </summary>
        public decimal ShipPrice { get; set; }

        /// <summary>
        /// 积分运费
        /// </summary>
        public decimal PointShipPrice { get; set; }

        /// <summary>
        /// 配送名称
        /// </summary>
        public string ShipTypeName { get; set; }

        /// <summary>
        /// 展示配送描述信息
        /// </summary>
        public string ShipTypeMsg { get; set; }

        /// <summary>
        /// 服务等级
        /// </summary>
        public string ServiceLevel { get; set; }

        /// <summary>
        /// 是否随单送票
        /// </summary>
        public bool IsSendInvoice { get; set; }

        /// <summary>
        /// 是否优先
        /// </summary>
        public bool IsPriority { get; set; }
    }
}
