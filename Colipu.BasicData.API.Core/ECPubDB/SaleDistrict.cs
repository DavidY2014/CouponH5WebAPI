using System;
using System.Collections.Generic;

namespace Colipu.BasicData.API.Core.ECPubDB
{
    public partial class SaleDistrict
    {
        public int DistrictId { get; set; }
        public string DistrictName { get; set; }
        public int CreateUserId { get; set; }
        public DateTime CreateTime { get; set; }
        public int UpdateUserId { get; set; }
        public DateTime UpdateTime { get; set; }
        public string Status { get; set; }
    }
}
