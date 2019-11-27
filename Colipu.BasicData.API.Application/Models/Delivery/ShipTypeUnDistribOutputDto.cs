using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BangBangFuli.H5.API.Application.Models.Delivery
{
    [Serializable]
    public class ShipTypeUnDistribOutputDto
    {
        public int UnDistribId { get; set; }
        public int ShipTypeId { get; set; }
        public int AreaId { get; set; }
    }
}
