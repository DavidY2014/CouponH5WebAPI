using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Colipu.BasicData.API.Application.Models.Location
{
    [Serializable]
    public class AreaInfoOutputDto
    {
        public int ProvinceId { get; set; }

        public int CityId { get; set; }

        public int DistrictId { get; set; }

        public string ProvinceName { get; set; }

        public string CityName { get; set; }

        public string DistrictName { get; set; }
    }
}
