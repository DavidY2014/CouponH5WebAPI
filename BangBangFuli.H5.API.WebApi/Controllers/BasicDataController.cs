using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using BangBangFuli.H5.API.Application.Models.BasicDatas;
using BangBangFuli.H5.API.Application.Services.BasicDatas;
using BangBangFuli.H5.API.Application.Services.Redis;
using BangBangFuli.H5.API.Core.Entities;
using BangBangFuli.H5.API.WebAPI;
using BangBangFuli.H5.API.WebAPI.Controllers.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace BangBangFuli.H5.API.WebAPI.Controllers
{
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class BasicDataController : ControllerBase
    {
        private readonly ICouponService _couponService;
        private readonly IBannerService _bannerService;
        private readonly IProductInformationService _productService;
        private readonly IOrderService _orderService;
        public string VERFIY_CODE_TOKEN_COOKIE_NAME = "VerifyCode";

        public BasicDataController(ICouponService couponService,IBannerService bannerService,IProductInformationService productService, IOrderService orderService)
        {
            _couponService = couponService;
            _bannerService = bannerService;
            _orderService = orderService;
            _productService = productService;
        }



        /// <summary>
        /// 1,获取批次号获取banner图片数组
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/v{version:apiVersion}/BasicData/Banner/{batchCode}")]
        public ResponseOutput GetBannerByBatchCode(string batchCode)
        {
            var photoUniqueNames = _bannerService.GetUniquePhotoNamesByBatchCode(batchCode);
            return new ResponseOutput(photoUniqueNames, HttpContext.TraceIdentifier);
        }


        /// <summary>
        ///2, 验证码接口,验证code写入cookie的VerifyCode键值对中
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/v{version:apiVersion}/BasicData/NumberVerifyCode")]
        public FileContentResult GetNumberVerifyCode()
        {
            string code = VerifyCodeHelper.GetSingleObj().CreateVerifyCode(VerifyCodeHelper.VerifyCodeType.NumberVerifyCode);

            Response.Cookies.Append(VERFIY_CODE_TOKEN_COOKIE_NAME, code);

            byte[] codeImage = VerifyCodeHelper.GetSingleObj().CreateByteByImgVerifyCode(code, 100, 40);
            return File(codeImage, @"image/jpeg");
        }

        /// <summary>
        /// 3,兑换,成功就返回券号信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/v{version:apiVersion}/BasicData/ExchangeCoupon/{code}/{password}")]
        public ResponseOutput ExchangeCoupon(int code,string password )
        {
            CouponDto dto = new CouponDto();
            var ret = _couponService.VerifyCoupon(code, password);
            if (ret)
            {
                var coupon = _couponService.GetCouponByCode(code);
                dto = new CouponDto
                {
                    Code = coupon.Code,
                    ValidityDate = coupon.ValidityDate,
                    AvaliableCount = coupon.AvaliableCount,
                    TotalCount = coupon.TotalCount
                };
                return new ResponseOutput(dto, HttpContext.TraceIdentifier);
            }
            else
            {
                return new ResponseOutput(dto,"劵信息获取失败", HttpContext.TraceIdentifier);
            }
        }

        /// <summary>
        /// 4and5 返回大类下的商品信息，包含图片，是否有货，详情等信息
        /// </summary>
        /// <param name="class1"></param>
        /// <param name="class2"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/v{version:apiVersion}/BasicData/Products/{class1}/{class2}")]
        public ResponseOutput GetProductsByCatelog(int class1,int class2)
        {
            var products = _productService.GetProductsByClass(class1, class2);

            var productDtos = new List<ProductDto>();

            foreach (var product in products)
            {
                productDtos.Add(new ProductDto
                {
                    Code = product.ProductCode,
                    Name = product.ProductName,
                    Description = product.Description,
                    IsInStock = product.IsInStock,
                    Photos = product.Details.Select(item => item.PhotoPath).ToList()
                });
            }

            return new ResponseOutput(productDtos, HttpContext.TraceIdentifier);
        }


        /// <summary>
        /// 6,下订单，可以传入多个商品的信息
        /// </summary>
        /// <param name="inputDto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/v{version:apiVersion}/BasicData/NewOrder")]
        public ResponseOutput CreateNewOrder(OrderInputDto inputDto)
        {
            if (inputDto==null)
            {
                return new ResponseOutput(null, "传入参数为空", HttpContext.TraceIdentifier);
            }

            List<OrderDetail> details = new List<OrderDetail>();

            foreach (var item in inputDto.DetailDtos)
            {
                ProductInformation productInfo = _productService.GetProductById(item.ProductId);

                details.Add(new OrderDetail
                {
                    ProductId = item.ProductId,
                    ProductCode = productInfo.ProductCode,
                    ProductName = productInfo.ProductName,
                    ProductCount = item.Count,
                });
            }
                
            Order order = new Order
            {
                Contactor = inputDto.Contactor,
                MobilePhone = inputDto.MobilePhone,
                Province = inputDto.Province,
                City = inputDto.City,
                District = inputDto.District,
                Address = inputDto.Address,
                ZipCode = inputDto.ZipCode,
                Telephone = inputDto.Telephone,
                Details = details
            };

            _orderService.CreateNewOrder(order);
            //发送手机短信给用户，当然这个可以用job实现

            return new ResponseOutput(null,"创建订单成功" ,HttpContext.TraceIdentifier);
        }


        /// <summary>
        /// 7,获取此兑换券生成的订单列表
        /// </summary>
        /// <param name="couponId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/v{version:apiVersion}/BasicData/Orders/{couponId}")]
        public ResponseOutput GetOrderList(int couponId)
        {
            List<OrderOutputDto> orderDtos = new List<OrderOutputDto>();
            Coupon coupon =  _couponService.GetCouponByCode(couponId);

            //_orderService.geta; ;

            //foreach (var order in coupon)
            //{
            //    OrderOutputDto dto = new OrderOutputDto { };
            //    orderDtos.Add(dto);
            //}

            return new ResponseOutput(orderDtos, HttpContext.TraceIdentifier);
        }


























        }
}
