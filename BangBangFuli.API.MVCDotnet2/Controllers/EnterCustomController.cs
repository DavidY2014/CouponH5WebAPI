using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        public EnterCustomController(IUserRoleJurisdictionService userRoleJurisdictionService, IModuleInfoService moduleInfoService , 
            IProductInformationService productInformationService, IBatchInformationService batchInformationService, IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            _userRoleJurisdictionService = userRoleJurisdictionService;
            _moduleInfoService = moduleInfoService;
            _productInformationService = productInformationService;
            _batchInformationService = batchInformationService;
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
                BatchInformation batchInfo = _batchInformationService.GetBatchInfoByBatchId(product.BatchId);
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
            PopulateClassDropDownList();
            PopulateProductStatusDropDownList();
            PopulateStockStatusDropDownList();
            PopulateBatchDropDownList();
            return View(model);
        }


        [HttpPost]
        public IActionResult CreateSave(ProductInformationViewModel model)
        {
            if (ModelState.IsValid)
            {
                List<string> uniqueFileNameList = null;

                //if (model.Photos != null && model.Photos.Count > 0)
                //{
                //    uniqueFileNameList = ProcessUploadedFile(model);

                //}
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
                    //ProductStatus = GetProductStatusMap(model.ProductStatus),
                    //StockType = GetStockStatusMap(model.StockStatus),
                    Type = model.ClassType,
                    BatchId = model.BatchId,
                    Details = details
                };

                //_productInformationService.Save(product);
                //return RedirectToAction(nameof(NewEdit), new { productId = product.Id });
                return View();
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Uploadattachment()
        {
            var imgFile = Request.Form.Files[0];
            return View();
        }


        #region 上传图片文件到wwwroot目录

        /// <summary>
        /// 将照片保存到指定的路径中，并返回唯一的文件名
        /// </summary>
        /// <returns></returns>
        //private List<string> ProcessUploadedFile(ProductInformationViewModel model)
        //{
        //    var photoFileNameList = new List<string>();

        //    if (model.Photos.Count > 0)
        //    {
        //        foreach (var photo in model.Photos)
        //        {
        //            string uniqueFileName = null;
        //            //必须将图像上传到wwwroot中的images文件夹
        //            //而要获取wwwroot文件夹的路径，我们需要注入 ASP.NET Core提供的HostingEnvironment服务
        //            //通过HostingEnvironment服务去获取wwwroot文件夹的路径
        //            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
        //            //为了确保文件名是唯一的，我们在文件名后附加一个新的GUID值和一个下划线

        //            uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
        //            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

        //            //因为使用了非托管资源，所以需要手动进行释放
        //            using (var fileStream = new FileStream(filePath, FileMode.Create))
        //            {
        //                //使用IFormFile接口提供的CopyTo()方法将文件复制到wwwroot/images文件夹
        //                photo.CopyTo(fileStream);
        //            }

        //            photoFileNameList.Add(uniqueFileName);
        //        }
        //    }
        //    return photoFileNameList;

        //}

        #endregion



        /// <summary>
        /// banner 页面
        /// </summary>
        /// <returns></returns>

        public IActionResult QueryBannerList()
        {

            return View();
        }





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