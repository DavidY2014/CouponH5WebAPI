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
        [Display(Name = "劵码编号")]
        public string Code { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "劵密码")]
        public string Password { get; set; }
    }
}
