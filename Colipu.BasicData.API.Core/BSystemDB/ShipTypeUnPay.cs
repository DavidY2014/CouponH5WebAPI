using System;
using System.Collections.Generic;

namespace BangBangFuli.H5.API.Core.BSystemDB
{
    public partial class ShipTypeUnPay
    {
        public int UnPayId { get; set; }
        public int ShipTypeId { get; set; }
        public int PayTypeId { get; set; }
        public int CreateUserId { get; set; }
        public DateTime CreateTime { get; set; }
        public int UpdateUserId { get; set; }
        public DateTime UpdateTime { get; set; }
        public string Status { get; set; }

    }
}
