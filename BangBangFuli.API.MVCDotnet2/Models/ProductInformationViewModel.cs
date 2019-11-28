using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BangBangFuli.API.MVCDotnet2.Models
{
    public class ProductInformationViewModel
    {
        [DisplayName("商品Id")]
        public int ProductId { get; set; }

        [DisplayName("商品名称")]
        public string Name { get; set; }

    }
}
