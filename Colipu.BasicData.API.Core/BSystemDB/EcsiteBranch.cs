using System;
using System.Collections.Generic;

namespace BangBangFuli.H5.API.Core.BSystemDB
{
    public partial class EcsiteBranch
    {
        public int SiteId { get; set; }
        public int BranchId { get; set; }
        public string Remark { get; set; }
        public int CreateUserId { get; set; }
        public DateTime CreateTime { get; set; }
        public int UpdateUserId { get; set; }
        public DateTime UpdateTime { get; set; }
        public string Status { get; set; }
    }
}
