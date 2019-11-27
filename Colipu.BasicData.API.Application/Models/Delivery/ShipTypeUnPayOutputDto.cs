using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BangBangFuli.H5.API.Application.Models.Delivery
{
    [Serializable]
    public class ShipTypeUnPayOutputDto
    {
        public int UnPayId { get; set; }
        public int ShipTypeId { get; set; }
        public int PayTypeId { get; set; }
    }
}
