﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Colipu.BasicData.API.Application.Models.Location
{
    [Serializable]
    public class DistrictOutputDto
    {
        public int DistrictId { get; set; }
        public int CityId { get; set; }
        public string DistrictName { get; set; }
        public int ShowOrder { get; set; }
        public string Status { get; set; }
        public int CreateUserId { get; set; }
        public DateTime CreateTime { get; set; }
        public int UpdateUserId { get; set; }
        public DateTime UpdateTime { get; set; }
        public string PhoneticizeFullName { get; set; }
        public string PhoneticizeShortName { get; set; }
    }
}
