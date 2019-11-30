using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BangBangFuli.H5.API.Core.Entities
{
    public class Banner
    {
        [Key]
        public int Id { get; set; }

        public string BatchCode { get; set; }

        public string Photo { get; set; }

        public DateTime CreateTime { get; set; }

    }
}
