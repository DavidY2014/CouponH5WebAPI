using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Colipu.BasicData.API.Application.Models.BasicDatas
{
    [Serializable]
    public class CheckReceiveOutputDto
    {
        public CheckReceiveOutputDto()
        {
            this.Init();
        }
        public int ReceiveAdressId { get; set; }

        /// <summary>
        /// 是否选中
        /// </summary>
        public bool IsChecked { get; set; }

        public int DistrictId { get; set; }

        public string ReceiveAreaName { get; set; }

        public string ReceiveContact { get; set; }

        public string ReceiveCellPhone { get; set; }

        public string ReceivePhone { get; set; }

        public string ReceiveAddress { get; set; }

        public string ReceiveZip { get; set; }

        public string ReceiveEmail { get; set; }

        /// <summary>
        /// 省
        /// </summary>
        public string ProvinceName { get; set; }
        /// <summary>
        /// 市
        /// </summary>
        public string CityName { get; set; }
        /// <summary>
        /// 区
        /// </summary>
        public string DistrictName { get; set; }

        /// <summary>
        /// 经度(对应地址)
        /// </summary>
        public decimal Longitude { get; set; }
        /// <summary>
        /// 纬度(对应地址)
        /// </summary>
        public decimal Latitude { get; set; }

        public int LogicalWalehouseId { get; set; }

        public int WarehouseId { get; set; }

        public bool IsDefault { get; set; }

        public int CityId { get; set; }

        public int ProvinceId { get; set; }


        public string ReceiveMsg
        {
            get
            {
                if (this.ReceiveAdressId <= 0)
                {
                    return "没有任何地址信息";
                }
                string phonestr = "";
                if (!string.IsNullOrWhiteSpace(this.ReceiveCellPhone))
                {
                    phonestr += "手机：" + this.ReceiveCellPhone;
                }
                if (!string.IsNullOrWhiteSpace(this.ReceivePhone))
                {
                    phonestr += "  电话：" + this.ReceivePhone;
                }
                return string.Format(@"<p> {0}&nbsp;{1}，邮编：{2}</p><p> 收货人：{3}， {4}</p>",
                    ReceiveAreaName, ReceiveAddress, ReceiveZip, ReceiveContact, phonestr);
            }
        }

        public static CheckReceiveOutputDto MapTo(AddressOutputDto addressModel)
        {
            if (addressModel == null) return default(CheckReceiveOutputDto);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AddressOutputDto, CheckReceiveOutputDto>());
            var mapper = config.CreateMapper();
            return mapper.Map<CheckReceiveOutputDto>(addressModel);
        }

        private void Init()
        {
            this.ReceiveAreaName = string.Empty;
            this.ReceiveContact = string.Empty;
            this.ReceiveCellPhone = string.Empty;
            this.ReceivePhone = string.Empty;
            this.ReceiveAddress = string.Empty;
            this.ReceiveZip = string.Empty;
            this.ReceiveEmail = string.Empty;
        }



    }
}
