using System;
using System.Collections.Generic;
using System.Text;

namespace BangBangFuli.H5.API.Application.Models.BasicDatas
{
    [Serializable]
    public class WarehouseDeliveryAreaOutputDto
    {
        public int WarehouseId { get; set; }
        public int CityId { get; set; }
        public int CreateUserId { get; set; }
        public DateTime CreateTime { get; set; }
        public int UpdateUserId { get; set; }
        public DateTime UpdateTime { get; set; }
        public string Status { get; set; }
    }
}
