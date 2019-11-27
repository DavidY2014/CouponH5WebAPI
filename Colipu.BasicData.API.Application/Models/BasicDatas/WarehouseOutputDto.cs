using System;
using System.Collections.Generic;
using System.Text;

namespace BangBangFuli.H5.API.Application.Models.BasicDatas
{
    [Serializable]
    public class WarehouseOutputDto
    {
        public int WarehouseId { get; set; }
        public string WarehouseCode { get; set; }
        public string WarehouseName { get; set; }
        public int BranchId { get; set; }
        public string Remark { get; set; }
        public int CreateUserId { get; set; }
        public DateTime CreateTime { get; set; }
        public int UpdateUserId { get; set; }
        public DateTime UpdateTime { get; set; }
        public string Status { get; set; }
        public int ShowOrder { get; set; }
    }
}
