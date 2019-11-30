using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BangBangFuli.H5.API.WebAPI.Controllers.Dtos
{
    public class OrderOutputDto
    {
        public int CouponCode { get; set; }

        public string Contactor { get; set; }


        public string MobilePhone { get; set; }

        public string Province { get; set; }

        public string City { get; set; }

        public string District { get; set; }

        public string Address { get; set; }

        public int ZipCode { get; set; }

        public string Telephone { get; set; }

        public DateTime CreateTime { get; set; }
        public List<OrderDetailOutputDto> Details { get; set; }
    }
}
