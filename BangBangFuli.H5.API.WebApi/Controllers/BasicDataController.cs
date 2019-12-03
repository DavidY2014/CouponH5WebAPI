using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using BangBangFuli.H5.API.Application.Models.BasicDatas;
using BangBangFuli.H5.API.Application.Services.BasicDatas;
using BangBangFuli.H5.API.Application.Services.Redis;
using BangBangFuli.H5.API.Core;
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
        private readonly IOrderDetailService _orderDetailService;
        private readonly IProductDetailService _productDetailService;
        private readonly IOrderService _orderService;
        public string VERFIY_CODE_TOKEN_COOKIE_NAME = "VerifyCode";

        public BasicDataController(ICouponService couponService,IBannerService bannerService,IProductInformationService productService, IOrderService orderService,
            IOrderDetailService orderDetailService,IProductDetailService productDetailService)
        {
            _couponService = couponService;
            _bannerService = bannerService;
            _orderService = orderService;
            _productService = productService;
            _orderDetailService = orderDetailService;
            _productDetailService = productDetailService;
        }



        /// <summary>
        /// 1,获取批次号获取banner图片数组
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/v{version:apiVersion}/BasicData/Banner/{batchId}")]
        public ResponseOutput GetBannerByBatchId(int batchId)
        {
            var photoUniqueNames = _bannerService.GetUniquePhotoNamesByBatchId(batchId);
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
        ///2.1, 验证码接口,验证code写入字典
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/v{version:apiVersion}/BasicData/NumberVerifyCodeByDictionary")]
        public ResponseOutput GetNumberVerifyCodeByDictionary()
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            string code = VerifyCodeHelper.GetSingleObj().CreateVerifyCode(VerifyCodeHelper.VerifyCodeType.NumberVerifyCode);
            byte[] codeImage = VerifyCodeHelper.GetSingleObj().CreateByteByImgVerifyCode(code, 100, 40);
            string imageStr = Convert.ToBase64String(codeImage);
            result.Add("VerifyCode", code);
            result.Add("ImageBase64", imageStr);
            return new ResponseOutput(result,"0","Base64验证码",HttpContext.TraceIdentifier);
        }

        /// <summary>
        /// 3,兑换,成功就返回券号信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/v{version:apiVersion}/BasicData/ExchangeCoupon")]
        public ResponseOutput ExchangeCoupon(CouponInputDto couponInputDto )
        {
            CouponDto dto = new CouponDto();
            var ret = _couponService.VerifyCoupon(couponInputDto.Code,couponInputDto.Password);
            if (ret)
            {
                var coupon = _couponService.GetCouponByCode(couponInputDto.Code);
                dto = new CouponDto
                {
                    Code = coupon.Code,
                    ValidityDate = coupon.ValidityDate,
                    AvaliableCount = coupon.AvaliableCount,
                    TotalCount = coupon.TotalCount
                };
                return new ResponseOutput(dto,"0","兑换成功", HttpContext.TraceIdentifier);
            }
            else
            {
                return new ResponseOutput(dto,"-1","劵信息获取失败", HttpContext.TraceIdentifier);
            }
        }

        /// <summary>
        /// 4,通过批次号获取下面所有商品
        /// </summary>
        /// <param name="batchId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/v{version:apiVersion}/BasicData/Products/{batchId}")]
        public ResponseOutput GetProductsByBatchId(int batchId)
        {
            List<ProductDto> productDtos = new List<ProductDto>();
            List<ProductInformation> products = _productService.GetProductsByBatchId(batchId);
            foreach (var product in products)
            {
                productDtos.Add(new ProductDto
                {
                    Id=product.Id,
                    Code = product.ProductCode,
                    Name = product.ProductName,
                    Description = product.Description,
                    IsInStock = Enum.GetName(typeof(StockStatus), product.StockType),
                    TypeName = Enum.GetName(typeof(ClassType), product.Type),
                }) ;
            }
            return new ResponseOutput(productDtos, HttpContext.TraceIdentifier);
        }

        /// <summary>
        /// 根据id 获取商品信息
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/v{version:apiVersion}/BasicData/ProductDetail/{productId}")]
        public ResponseOutput GetProductDetailByProductId(int productId)
        {
            ProductInformation product= _productService.GetProductById(productId);
            //图片详情
            var productDetails = _productDetailService.GetDetailsByProductId(product.Id);

            List<ProductDetailOutputDto> detailDtos = new List<ProductDetailOutputDto>();
            if (productDetails!=null)
            {
                foreach (var productDetail in productDetails)
                {
                    detailDtos.Add(new ProductDetailOutputDto()
                    {
                        PhotoPath = productDetail.PhotoPath
                    });
                }
            }

            ProductDto dto = new ProductDto
            {
                Code = product.ProductCode,
                Name = product.ProductName,
                Description = product.Description,
                TypeName = Enum.GetName(typeof(ClassType), product.Type),
                IsInStock = Enum.GetName(typeof(StockStatus), product.StockType),
                Photos = detailDtos.Select(item => item.PhotoPath).ToList()
            };
            return new ResponseOutput(dto, HttpContext.TraceIdentifier);
        }


        /// <summary>
        /// 4and5 返回大类下的商品信息，包含图片，是否有货，详情等信息
        /// </summary>
        /// <param name="class1"></param>
        /// <param name="class2"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/v{version:apiVersion}/BasicData/Products/{classType}")]
        public ResponseOutput GetProductsByCatelog(ClassType classType)
        {
            var productDtos = new List<ProductDto>();
            var products = _productService.GetProductsByClassType(classType);
            foreach (var product in products)
            {
                var productDetails = _productDetailService.GetDetailsByProductId(product.Id);

                List<ProductDetailOutputDto> detailDtos = new List<ProductDetailOutputDto>();
                foreach (var productDetail in productDetails)
                {
                    detailDtos.Add(new ProductDetailOutputDto()
                    {
                        PhotoPath = productDetail.PhotoPath
                    });
                }

                productDtos.Add(new ProductDto
                {
                    Code = product.ProductCode,
                    Name = product.ProductName,
                    Description = product.Description,
                    IsInStock = Enum.GetName(typeof(StockStatus), product.StockType),
                    Photos = detailDtos.Select(item => item.PhotoPath).ToList()
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
                return new ResponseOutput(null, "-1", "传入参数为空", HttpContext.TraceIdentifier);
            }

            if (inputDto.CouponCode == "0")
            {
                return new ResponseOutput(null, "-1", "券号不对", HttpContext.TraceIdentifier);
            }

            var coupon = _couponService.GetCouponByCode(inputDto.CouponCode);
            if (coupon == null )
            {
                return new ResponseOutput(null,"-1", "券不存在", HttpContext.TraceIdentifier);
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
                CouponCode = inputDto.CouponCode,
                Contactor = inputDto.Contactor,
                MobilePhone = inputDto.MobilePhone,
                Province = inputDto.Province,
                City = inputDto.City,
                District = inputDto.District,
                Address = inputDto.Address,
                ZipCode = int.Parse(inputDto.ZipCode),
                Telephone = inputDto.Telephone,
                Details = details
            };

            _orderService.CreateNewOrder(order);
            //发送手机短信给用户，当然这个可以用job实现

            return new ResponseOutput(null,"0","创建订单成功" ,HttpContext.TraceIdentifier);
        }


        /// <summary>
        /// 7和8 获取此兑换券生成的订单列表,入参为券卡号
        /// </summary>
        /// <param name="couponCode"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/v{version:apiVersion}/BasicData/Orders/{couponCode}")]
        public ResponseOutput GetOrderList(string couponCode)
        {
            List<OrderOutputDto> orderDtos = new List<OrderOutputDto>();
            Coupon coupon =  _couponService.GetCouponByCode(couponCode);
            List<Order> orders =  _orderService.GetOrdersByCoupon(coupon.Code);
            foreach (var order in orders)
            {
                List<OrderDetail> details = _orderDetailService.GetOrderDetailByOrderId(order.Id);

                List<OrderDetailOutputDto> detailOutputDtos = new List<OrderDetailOutputDto>();
                foreach (var detail in details)
                {
                    detailOutputDtos.Add(new OrderDetailOutputDto
                    {
                        ProductCode = detail.ProductCode,
                        ProductName = detail.ProductName,
                        ProductCount = detail.ProductCount
                    });
                }

                orderDtos.Add(new OrderOutputDto
                {
                    CouponCode = couponCode,
                    Contactor = order.Contactor,
                    MobilePhone = order.MobilePhone,
                    Province = order.Province,
                    City = order.City,
                    District = order.District,
                    Address = order.Address,
                    ZipCode = order.ZipCode,
                    Telephone = order.Telephone,
                    CreateTime = order.CreateTime,
                    Details = detailOutputDtos
                });
            }

            return new ResponseOutput(orderDtos, HttpContext.TraceIdentifier);
        }


        public ClassType ConvertToEnum(string TypeName)
        {
            ClassType ret = ClassType.chufangzhengxuan;
            switch (TypeName)
            {
                case "yuexiangmeiwei":
                    ret = ClassType.yuexiangmeiwei;
                    break;
                case "jujiahaowu":
                    ret = ClassType.jujiahaowu;
                    break;
                case "pingzhishenghuo":
                    ret = ClassType.pingzhishenghuo;
                    break;
                case "chufangzhengxuan":
                    ret = ClassType.chufangzhengxuan;
                    break;
            }
            return ret;
        }























    }
}
