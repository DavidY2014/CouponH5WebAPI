using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BangBangFuli.H5.API.Core.Entities
{
    public class Catelog
    {
        [Key]
        public int Id { get; set; }

        public int ClassId{ get; set; }
        public string ClassName { get; set; }
    }
}
