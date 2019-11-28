using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BangBangFuli.H5.API.Core.Entities
{
    public class ProductDetail
    {
        [Key]
        public int Id { get; set; }


        public int ProductId { get; set; }
        public string PhotoPath { get; set; }

    }
}
