using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BangBangFuli.H5.API.Core.Entities
{
    /// <summary>
    /// 订单信息
    /// </summary>
   public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "联系人")]
        public string Contactor { get; set; }


        [Required]
        [MaxLength(20)]
        [Display(Name = "手机号")]
        public string MobilePhone { get; set; }


        [Required]
        [MaxLength(10)]
        [Display(Name = "省")]
        public string Province { get; set; }

        [Required]
        [MaxLength(10)]
        [Display(Name = "市")]
        public string City { get; set; }

        [Required]
        [MaxLength(10)]
        [Display(Name = "区")]
        public string District { get; set; }

        [Required]
        [MaxLength(10)]
        [Display(Name = "地址")]
        public string Address { get; set; }

        [Required]
        [MaxLength(10)]
        [Display(Name = "邮编")]
        public int ZipCode { get; set; }

        [Required]
        [MaxLength(10)]
        [Display(Name = "固定电话")]
        public string Telephone { get; set; }


        public List<OrderDetail> Details { get; set; }
        

    }
}
