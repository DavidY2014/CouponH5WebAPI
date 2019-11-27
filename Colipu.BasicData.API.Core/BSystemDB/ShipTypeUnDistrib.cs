using System;
using System.Collections.Generic;

namespace Colipu.BasicData.API.Core.BSystemDB
{
    public partial class ShipTypeUnDistrib
    {
        public int UnDistribId { get; set; }
        public int ShipTypeId { get; set; }
        public int AreaId { get; set; }
        public int CreateUserId { get; set; }
        public DateTime CreateTime { get; set; }
        public int UpdateUserId { get; set; }
        public DateTime UpdateTime { get; set; }
        public string Status { get; set; }
    }
}
