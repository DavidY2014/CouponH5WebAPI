using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BangBangFuli.H5.API.WebAPI.Controllers.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        
        public string Name { get; set; }

        public bool IsInStock { get; set; }

        public int Class1 { get; set; }

        public int Class2 { get; set; }

        public string Description { get; set; }

        public List<string> Photos { get; set; }


    }
}
