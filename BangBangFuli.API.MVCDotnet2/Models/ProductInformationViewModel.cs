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
        public ProductStatus Status { get; set; }

        [DisplayName("是否有库存")]
        public bool IsInStock { get; set; }

        [DisplayName("分类1")]
        public int Class1 { get; set; }

        [DisplayName("分类2")]
        public int Class2 { get; set; }

        [Display(Name = "图片")]
        public List<IFormFile> Photos { get; set; }

    }

    public enum ProductStatus
    {
        On,
        Down
    }
}
