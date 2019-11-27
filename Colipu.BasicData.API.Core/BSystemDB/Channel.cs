using System;
using System.Collections.Generic;
using System.Text;

namespace Colipu.BasicData.API.Core.BSystemDB
{
    public partial class Channel
    {
        public int ChannelId { get; set; }
        public string ChannelCode { get; set; }
        public string ChannelName { get; set; }
        public string Remark { get; set; }
        public int CreateUserId { get; set; }
        public DateTime CreateTime { get; set; }
        public int UpdateUserId { get; set; }
        public DateTime UpdateTime { get; set; }
        public string Status { get; set; }
    }
}
