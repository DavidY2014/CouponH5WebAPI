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

        #region 名称
        public string ProductStatusName { get; set; }
        public string StockStatusName { get; set; }
        public string ClassTypeName { get; set; }
        #endregion

        [DisplayName("商品状态")]
        public int ProductStatus { get; set; }
        [DisplayName("库存状态")]
        public int StockStatus { get; set; }
        [DisplayName("商品大类别")]
        public int ClassType { get; set; }

        [DisplayName("批次号")]
        public string BatchId { get; set; }

        [DisplayName("批次名称")]
        public string BatchName { get; set; }

        [Display(Name = "图片")]
        public List<IFormFile> Photos { get; set; }

    }
}
