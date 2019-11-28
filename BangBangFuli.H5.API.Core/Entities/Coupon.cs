using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BangBangFuli.H5.API.Core.Entities
{
    public  class Coupon
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(20)]
        [Display(Name = "劵卡号")]
        public int Code { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "劵密码")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "有效期")]
        public DateTime ValidityDate { get; set; }

        [Required]
        [Display(Name = "剩余次数")]
        public int AvaliableCount { get; set; }

        [Required]
        [Display(Name = "总次数")]
        public int TotalCount { get; set; }
    }
}
