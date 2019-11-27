using System;
using System.Collections.Generic;

namespace Colipu.BasicData.API.Core.BSystemDB
{
    public partial class Branch
    {
        public int BranchId { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public string BranchFullName { get; set; }
        public int CreateUserId { get; set; }
        public DateTime CreateTime { get; set; }
        public int UpdateUserId { get; set; }
        public DateTime UpdateTime { get; set; }
        public string Status { get; set; }
        public string Remark { get; set; }
        public string BranchEnglishName { get; set; }
        public string BranchAddress { get; set; }
        public string BranchPostcode { get; set; }
        public string BranchBank { get; set; }
        public string BranchBankCode { get; set; }
        public string BranchPhoneNumber { get; set; }
        public string BranchFaxNumber { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string IsSupportElecInvoice { get; set; }
        public string Version { get; set; }
        public string UserName { get; set; }
        public string AuthorizationCode { get; set; }
        public string TaxpayerId { get; set; }
        public string SellerAddress { get; set; }
        public string SellerPhone { get; set; }
        public string SellerBankCode { get; set; }
        public string SellerBankName { get; set; }
        public string Keys { get; set; }
        public int? KpyuserId { get; set; }
        public int? SkyuserId { get; set; }
        public int? FhruserId { get; set; }
    }
}
