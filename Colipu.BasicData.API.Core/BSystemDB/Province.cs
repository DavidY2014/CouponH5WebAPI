using System;
using System.Collections.Generic;

namespace Colipu.BasicData.API.Core.BSystemDB
{
    public partial class Province
    {
        public int ProvinceId { get; set; }
        public string ProvinceName { get; set; }
        public int ShowOrder { get; set; }
        public string Status { get; set; }
        public int CreateUserId { get; set; }
        public DateTime CreateTime { get; set; }
        public int UpdateUserId { get; set; }
        public DateTime UpdateTime { get; set; }
        public string PhoneticizeFullName { get; set; }
        public string PhoneticizeShortName { get; set; }
    }
}
