using BangBangFuli.H5.API.Core;
using Colipu.BasicData.API.Domain;
using Colipu.Utils.Log.Aliyun;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace BangBangFuli.H5.API.WebAPI
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _next;

        public ExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, ILogService logService)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, logService, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, ILogService logService, Exception exception)
        {
            string responseCode;

            HttpResponse httpResponse = context.Response;

            httpResponse.ContentType = "application/json";

            switch (exception)
            {
                case BusinessException _:
                    {
                        BusinessException businessException = exception as BusinessException;

                        responseCode = businessException.ResponseCode;

                        break;
                    }
                case ArgumentNullException _:
                case ArgumentException _:
                    {
                        responseCode = AppConst.ResponseCode.IllegalParameter;

                        break;
                    }
                case NullReferenceException _:
                    {
                        responseCode = AppConst.ResponseCode.ServerError;

                        logService.Error("服务器内部处理异常", exception.Message, exception.StackTrace);

                        break;
                    }
                default:
                    {
                        responseCode = AppConst.ResponseCode.Unknown;

                        logService.Error("发生预期之外异常", exception.Message, exception.StackTrace);

                        break;
                    }
            }

            await httpResponse.WriteAsync(JsonConvert.SerializeObject(new ResponseOutput(responseCode, exception.Message, context.TraceIdentifier)));
        }
    }
}
