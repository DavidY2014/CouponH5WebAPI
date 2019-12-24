using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using BangBangFuli.API.MVCDotnet2.Filter;
using BangBangFuli.API.MVCDotnet2.Models;
using BangBangFuli.Common;
using BangBangFuli.H5.API.Application.Services.BasicDatas;
using BangBangFuli.H5.API.Core.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BangBangFuli.API.MVCDotnet2.Controllers
{
    [UserLoginFilter]
    public class EnterCustomController : Controller
    {
        private UserInfo _userinfo;
        private IUserRoleJurisdictionService _userRoleJurisdictionService;
        private IModuleInfoService _moduleInfoService;
        private readonly IBatchInformationService _batchInformationService;
        private readonly IProductInformationService _productInformationService;
        private readonly IHostingEnvironment _hostingEnvironment;

        private readonly IBannerService _bannerService;
        private readonly IBannerDetailService _bannerDetailService;
        private readonly ICouponService _couponService;

        public EnterCustomController(IUserRoleJurisdictionService userRoleJurisdictionService, IModuleInfoService moduleInfoService , 
            IProductInformationService productInformationService, IBatchInformationService batchInformationService, IHostingEnvironment hostingEnvironment,
            IBannerService bannerService , IBannerDetailService bannerDetailService,ICouponService couponService)
        {
            _hostingEnvironment = hostingEnvironment;
            _userRoleJurisdictionService = userRoleJurisdictionService;
            _moduleInfoService = moduleInfoService;
            _productInformationService = productInformationService;
            _batchInformationService = batchInformationService;
            _bannerService = bannerService;
            _bannerDetailService = bannerDetailService;
            _couponService = couponService;
        }

        /// <summary>
        /// 当前登录的用户
        /// </summary>
        public new UserInfo User
        {
            get
            {
                if (_userinfo == null)
                    _userinfo = JsonSerializerHelper.Deserialize<UserInfo>(HttpContext.Session.GetString("user"));
                return _userinfo;
            }
        }


        /// <summary>
        /// 首页，工作台
        /// </summary>
        /// <returns></returns>
        public IActionResult ConsoleIndex()
        {
            return View();
        }

        #region 商品

        /// <summary>
        /// 商品页面
        /// </summary>
        /// <returns></returns>
        public IActionResult QueryProductList()
        {
            var productViewModelList = new List<ProductInformationViewModel>();
            var products = _productInformationService.GetAll();
            foreach (var product in products)
            {
                BatchInformation batchInfo = _batchInformationService.GetBatchInfoById(product.BatchId);
                productViewModelList.Add(new ProductInformationViewModel
                {
                    ProductId = product.Id,
                    ProductCode = product.ProductCode,
                    ProductName = product.ProductName,
                    StockStatusType = product.StockType,
                    ProductStatusType = product.ProductStatus,
                    ClassType = product.Type,
                    BatchId = product.BatchId,
                    BatchName = batchInfo.Name
                });
            }
            return View(productViewModelList);
        }

        /// <summary>
        /// 新建商品页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult AddNewProduct()
        {
            ProductInformationViewModel model = new ProductInformationViewModel();
            PopulateBatchDropDownList();
            return View(model);
        }


        [HttpPost]
        public IActionResult CreateSave(ProductInformationViewModel model)
        {
            if (ModelState.IsValid)
            {
                List<string> uniqueFileNameList = null;
                var details = new List<ProductDetail>();
                if (uniqueFileNameList != null)
                {
                    foreach (var uniqueFileName in uniqueFileNameList)
                    {
                        details.Add(new ProductDetail { PhotoPath = uniqueFileName });
                    }
                }
                ProductInformation product = new ProductInformation
                {
                    ProductCode = model.ProductCode,
                    ProductName = model.ProductName,
                    ProductStatus = model.ProductStatusType,
                    StockType = model.StockStatusType,
                    Type = model.ClassType,
                    BatchId = model.BatchId,
                    //Details = details
                };

                _productInformationService.Save(product);
                return RedirectToAction(nameof(QueryProductList), new { productId = product.Id });
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Uploadattachment()
        {
            #region 文件上传
            var imgFile = Request.Form.Files[0];
            if (imgFile != null && !string.IsNullOrEmpty(imgFile.FileName))
            {
                string uniqueFileName = null;
                var filename = ContentDispositionHeaderValue
                     .Parse(imgFile.ContentDisposition)
                     .FileName
                     .Trim('"');
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + filename;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (FileStream fs = System.IO.File.Create(filePath))
                {
                    imgFile.CopyTo(fs);
                    fs.Flush();
                }
                return Json(new { code = 0, msg = "上传成功", data = new { src = $"/images/{filePath}", title = "图片标题" } });
            }
            return Json(new { code = 1, msg = "上传失败", });
            #endregion
        }

        #endregion


        #region banner

        /// <summary>
        /// banner 页面
        /// </summary>
        /// <returns></returns>
        public IActionResult QueryBannerList()
        {
            List<BannerViewModel> bannerViewModels = new List<BannerViewModel>();
            List<Banner> banners = _bannerService.GetAll();
            foreach (var banner in banners)
            {
                bannerViewModels.Add(new BannerViewModel
                {
                    BannerId = banner.Id,
                    BatchId = banner.BatchId,
                    Name = banner.Name,
                    CreateTime = banner.CreateTime
                });
            }
            return View(bannerViewModels);
        }

        /// <summary>
        /// 新建banner视图
        /// </summary>
        /// <returns></returns>
        public IActionResult AddNewBanner()
        {
            BannerViewModel model = new BannerViewModel();
            PopulateBatchDropDownList();
            return View(model);
        }

        [HttpPost]
        public IActionResult CreateBannerSave(BannerViewModel model)
        {
            if (ModelState.IsValid)
            {
                Banner banner = new Banner
                {
                    BatchId = model.BatchId,
                    Name = model.Name,
                    CreateTime = DateTime.Now,
                    //BannerDetails = details
                };
                _bannerService.Save(banner);

                return RedirectToAction(nameof(QueryBannerList));
            }
            return View(model);
        }


        #endregion


        #region 提货券管理

        /// <summary>
        /// 券列表页
        /// </summary>
        /// <returns></returns>
        public IActionResult QueryCouponList()
        {
            var couponViewModelList = new List<CouponViewModel>();
            var coupons = _couponService.GetAll();
            foreach (var item in coupons)
            {
                couponViewModelList.Add(new CouponViewModel
                {
                    Code = item.Code,
                    Password = item.Password,
                    ValidityDate = item.ValidityDate,
                    AvaliableCount = item.AvaliableCount,
                    TotalCount = item.TotalCount
                });
            }

            return View(couponViewModelList);
        }

        /// <summary>
        /// 券新增页
        /// </summary>
        /// <returns></returns>
        public IActionResult AddNewCoupon()
        {
            return View();
        }

        public IActionResult CheckResult()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCouponSave(CouponViewModel model)
        {
            if (ModelState.IsValid)
            {
                var checkRet = _couponService.CheckIfCouponAlreadyExist(model.Code);
                if (checkRet)
                {
                    return RedirectToAction(nameof(CheckResult));
                }
                Coupon coupon = new Coupon
                {
                    Code = model.Code,
                    Password = model.Password,
                    ValidityDate = model.ValidityDate,
                    AvaliableCount = model.AvaliableCount,
                    TotalCount = model.TotalCount
                };
                _couponService.AddNew(coupon);

                return RedirectToAction(nameof(QueryCouponList));
            }
            return View(model);
        }

        #endregion




        #region 基类

        public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            return base.OnActionExecutionAsync(context, next);
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.HttpContext.Session.Keys.Contains("user"))
            {
                context.Result = new RedirectResult("/Account/Index");
                return;
            }
            base.OnActionExecuting(context);
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            ViewData["user"] = User;
            List<UserRoleJurisdiction> userrolejurlist = _userRoleJurisdictionService.GetListAsync(User.RoleID);
            ViewData["userrolejurlist"] = userrolejurlist;
            List<ModuleInfo> modulelist = _moduleInfoService.GetList();
            ViewData["modulelist"] = modulelist;
            base.OnActionExecuted(context);
        }

        #endregion


        #region 分类枚举
        private void PopulateClassDropDownList(object selectedClass = null)
        {
            var productTypes = new List<object>();
            productTypes.Add(new { id = 0, name = "悦享生活" });
            productTypes.Add(new { id = 1, name = "居家好物" });
            productTypes.Add(new { id = 2, name = "品质生活" });
            productTypes.Add(new { id = 3, name = "厨房甄选" });
            ViewBag.Catelogs = new SelectList(productTypes, "id", "name", selectedClass);
        }


        private void PopulateProductStatusDropDownList(object selectedProductStatus = null)
        {
            var productStatusTypes = new List<object>();
            productStatusTypes.Add(new { id = 0, name = "下架" });
            productStatusTypes.Add(new { id = 1, name = "上架" });
            ViewBag.ProductStatusTypes = new SelectList(productStatusTypes, "id", "name", selectedProductStatus);
        }

        private void PopulateStockStatusDropDownList(object selectedStockStatus = null)
        {
            var stockStatusTypes = new List<object>();
            stockStatusTypes.Add(new { id = 0, name = "无货" });
            stockStatusTypes.Add(new { id = 1, name = "有货" });
            ViewBag.StockStatusTypes = new SelectList(stockStatusTypes, "id", "name", selectedStockStatus);
        }

        private void PopulateBatchDropDownList(object selectedBatch = null)
        {
            var batchs = new List<object>();
            List<BatchInformation> batchInfos = _batchInformationService.GetAll();
            ViewBag.BatchInfos = batchInfos;
        }


        public string GetClassTypeDisplayName(int index)
        {
            var ret = string.Empty;
            switch (index)
            {
                case 0:
                    ret = "悦享生活";
                    break;
                case 1:
                    ret = "居家好物";
                    break;
                case 2:
                    ret = "品质生活";
                    break;
                case 3:
                    ret = "厨房甄选";
                    break;
            }
            return ret;
        }

        public string GetProductStatusDisplayName(int index)
        {
            var ret = string.Empty;
            switch (index)
            {
                case 0:
                    ret = "下架";
                    break;
                case 1:
                    ret = "上架";
                    break;
            }
            return ret;
        }

        public string GetStockStatusDisplayName(int index)
        {
            var ret = string.Empty;
            switch (index)
            {
                case 0:
                    ret = "无货";
                    break;
                case 1:
                    ret = "有货";
                    break;
            }
            return ret;
        }

        #endregion
    }
}