using System;
using System.Collections.Generic;

namespace BangBangFuli.H5.API.Core.BSystemDB
{
    public partial class Holiday
    {
        public int HolidayId { get; set; }
        public string Note { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public int CreateUserId { get; set; }
        public DateTime CreateTime { get; set; }
        public int UpdateUserId { get; set; }
        public DateTime UpdateTime { get; set; }
        public string Status { get; set; }
        public string Remark { get; set; }
    }
}
