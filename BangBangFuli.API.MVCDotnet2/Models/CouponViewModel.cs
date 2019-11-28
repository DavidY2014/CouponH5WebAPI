using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BangBangFuli.API.MVCDotnet2.Models
{
    public class CouponViewModel
    {

        [Required(ErrorMessage = "请输入劵码卡号"), MaxLength(50, ErrorMessage = "名字的长度不能超过50个字符")]
        [Display(Name = "卡号")]
        public int Code { get; set; }

        [Required(),MaxLength(16, ErrorMessage = "名字的长度不能超过16个字符")]
        [Display(Name = "密码")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "有效期")]
        public DateTime ValidityDate { get; set; }

        [Required]
        [Display(Name = "总次数")]
        public int TotalCount { get; set; }

    }
}
