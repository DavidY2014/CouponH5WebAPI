using Colipu.BasicData.API.Core.BSystemDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colipu.BasicData.API.Application.Models.BasicDatas
{
    [Serializable]
    public class BranchOutputDto
    {
        public int BranchId { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public string BranchFullName { get; set; }

        public string IsSupportElecInvoice { get; set; }
        public string UserName { get; set; }
    }
}
