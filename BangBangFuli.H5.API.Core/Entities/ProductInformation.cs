using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BangBangFuli.H5.API.Core.Entities
{
    public class ProductInformation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string ProductCode { get; set; }

        public string Description { get; set; }

        public bool IsInStock { get; set; }

        public int Catelog1 { get; set; }

        public int Catelog2 { get; set; }

        public List<ProductDetail> Details { get; set; }

    }

}
