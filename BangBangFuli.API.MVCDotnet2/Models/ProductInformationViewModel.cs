using BangBangFuli.H5.API.Core;
using Microsoft.AspNetCore.Http;
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
        public int ProductId { get; set; }

        [DisplayName("商品编号")]
        public string ProductCode { get; set; }

        [DisplayName("商品名称")]
        public string ProductName { get; set; }

        [DisplayName("商品描述")]
        public string Description { get; set; }

        [DisplayName("商品状态")]
        public string ProductStatusName { get; set; }

        [DisplayName("是否有库存")]
        public string StockStatusName { get; set; }

        [DisplayName("类型")]
        public string ChineseTypeName { get; set; }

        [DisplayName("批次号")]
        public string BatchId { get; set; }

        [Display(Name = "图片")]
        public List<IFormFile> Photos { get; set; }

    }
}
