using System;
using System.Collections.Generic;

namespace BangBangFuli.H5.API.Core.BSystemDB
{
    public partial class WarehouseDeliveryArea
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
