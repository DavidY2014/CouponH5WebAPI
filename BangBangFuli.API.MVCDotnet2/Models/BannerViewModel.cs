﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BangBangFuli.API.MVCDotnet2.Models
{
    public class BannerViewModel
    {
        public int BannerId { get; set; }

        [Required(ErrorMessage = "请输入批次号"), MaxLength(50, ErrorMessage = "名字的长度不能超过50个字符")]
        [Display(Name = "批次号")]
        public string BatchId { get; set; }

        [Display(Name = "批次名称")]
        public string Name { get; set; }

        [Display(Name = "图片")]
        public List<IFormFile> Photos { get; set; }

        public List<string> PhotoNames { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
