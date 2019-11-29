using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BangBangFuli.H5.API.WebAPI.Controllers.Dtos
{
    public class ProductDto
    {
        public string Code { get; set; }
        
        public string Name { get; set; }

        public bool IsInStock { get; set; }

        public string Description { get; set; }

        public List<string> Photos { get; set; }


    }
}
