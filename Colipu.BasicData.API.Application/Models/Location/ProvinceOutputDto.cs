using System;
using System.Collections.Generic;
using System.Text;

namespace BangBangFuli.H5.API.Application.Models.Location
{
    [Serializable]
    public class ProvinceOutputDto
    {
        public int ProvinceId { get; set; }
        public string ProvinceName { get; set; }
        public int ShowOrder { get; set; }
        public string Status { get; set; }
        public int CreateUserId { get; set; }
        public int UpdateUserId { get; set; }
        public string PhoneticizeFullName { get; set; }
        public string PhoneticizeShortName { get; set; }

        public List<CityOutputDto> CityList { get; set; }
    }
}
