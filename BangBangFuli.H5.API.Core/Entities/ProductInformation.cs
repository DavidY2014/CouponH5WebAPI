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
        public string ProductName { get; set; }

        public string ProductCode { get; set; }

        public string Description { get; set; }

        public ProductStatus Status { get; set; }

        public StockStatus StockType { get; set; }

        public ClassType Type { get; set; }

        public int BatchId { get; set; }
        public List<ProductDetail> Details { get; set; }

    }



}
