using System;
using System.Collections.Generic;

namespace Colipu.BasicData.API.Core.BSystemDB
{
    public partial class PayType
    {
        public int PayTypeId { get; set; }
        public string PayTypeCode { get; set; }
        public string PayTypeName { get; set; }
        public string PayClass { get; set; }
        public string PayPageUrl { get; set; }
        public int ShowOrder { get; set; }
        public string IsWebsiteShow { get; set; }
        public string Remark { get; set; }
        public int CreateUserId { get; set; }
        public DateTime CreateTime { get; set; }
        public int UpdateUserId { get; set; }
        public DateTime UpdateTime { get; set; }
        public string Status { get; set; }
    }
}
