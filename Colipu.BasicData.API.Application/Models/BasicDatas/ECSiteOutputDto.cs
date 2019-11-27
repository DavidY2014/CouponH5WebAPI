using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Colipu.BasicData.API.Application.Models.BasicDatas
{
    [Serializable]
    public class ECSiteOutputDto
    {
        public int SiteId { get; set; }

        public string SiteName { get; set; }

        public int ChannelId { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
