using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colipu.BasicData.API.Application.Models.BasicDatas
{
    [Serializable]
    public class ChannelOutputDto
    {
        /// <summary>
        /// 渠道编号
        /// </summary>
        public int ChannelId { get; set; }

        /// <summary>
        /// 渠道代码
        /// </summary>
        public string ChannelCode { get; set; }

        /// <summary>
        /// 渠道名称
        /// </summary>
        public string ChannelName { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public int CreateUserId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>
        public int UpdateUserId { get; set; }

        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime? UpdateTime { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public string Status { get; set; }
    }
}
