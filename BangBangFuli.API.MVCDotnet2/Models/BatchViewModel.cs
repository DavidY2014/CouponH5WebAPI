using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BangBangFuli.API.MVCDotnet2.Models
{
    public class BatchViewModel
    {
        public int Id { get; set; }

        public string BatchId { get; set; }

        public string Name { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
