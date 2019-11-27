using Colipu.BasicData.API.Application;
using Colipu.BasicData.API.Core;

namespace Colipu.BasicData.API.WebApi
{
    /// <summary>
    /// 回复信息
    /// </summary>
    public class ResponseOutput 
    {

        /// <summary>
        /// 状态码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 请求编号
        /// </summary>
        public string RequestId { get; set; }

        /// <summary>
        /// 业务数据
        /// </summary>
        public object Data { get; set; }

        public ResponseOutput(string requestId)
        {
            RequestId = requestId;
            Code = AppConst.ResponseCode.Success;
        }

        public ResponseOutput(string code, string message, string requestId)
            : this(requestId)
        {
            Code = code;
            Message = message;
        }

        public ResponseOutput(object data, string requestId)
            : this(requestId)
        {
            Data = data;
        }

        public ResponseOutput(object data, string messages, string requestId)
            : this(data, requestId)
        {
            Message = messages;
        }
    }
}
