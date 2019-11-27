using System;
using System.Collections.Generic;

namespace Colipu.BasicData.API.Core.BSystemDB
{
    public partial class PayTypeRelationSite
    {
        public int RelationId { get; set; }
        public int PayTypeId { get; set; }
        public int SiteId { get; set; }
        public int CreateUserId { get; set; }
        public DateTime CreateTime { get; set; }
        public int UpdateUserId { get; set; }
        public DateTime UpdateTime { get; set; }
        public string Status { get; set; }
        public string IsShow { get; set; }
    }
}
