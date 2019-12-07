﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BangBangFuli.API.MVCDotnet2.Models;
using BangBangFuli.H5.API.Application.Services.BasicDatas;
using BangBangFuli.H5.API.Core;
using BangBangFuli.H5.API.Core.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BangBangFuli.API.MVCDotnet2.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductInformationService _productInformationService;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IProductDetailService _productDetailService;
        private readonly IBatchInformationService _batchInformationService;

        public ProductController(IProductInformationService productInformationService ,IHostingEnvironment hostingEnvironment
            ,IProductDetailService productDetailService, IBatchInformationService batchInformationService)
        {
            _productInformationService = productInformationService;
            _hostingEnvironment = hostingEnvironment;
            _productDetailService = productDetailService;
            _batchInformationService = batchInformationService;
        }
        public IActionResult Index()
        {
            var productViewModelList = new List<ProductInformationViewModel>();
            var products = _productInformationService.GetAll();
            foreach (var product in products)
            {
                productViewModelList.Add(new ProductInformationViewModel
                {
                    ProductId = product.Id,
                    ProductCode = product.ProductCode,
                    ProductName = product.ProductName,
                    StockStatusName = EnumStockStatusConvertToChinese(product.StockType),
                    ProductStatusName = EnumConvertToChinese(product.ProductStatus),
                    ChineseTypeName = ConvertToChinese(product.Type),
                    BatchId = product.BatchId
                }) ;
            }
            return View(productViewModelList);
        }

        public IActionResult Details(int id)
        {
            List<ProductDetailViewModel> detailViewModels = new List<ProductDetailViewModel>();
            List<ProductDetail> details =  _productDetailService.GetDetailsByProductId(id);
            foreach (var item in details)
            {
                detailViewModels.Add(new ProductDetailViewModel
                {
                    PhotoPath = item.PhotoPath
                });
            }
            return View(detailViewModels);
        }

        /// <summary>
        /// 新增编辑界面
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            ProductInformationViewModel model = new ProductInformationViewModel();
            PopulateClassDropDownList();
            PopulateProductStatusDropDownList();
            PopulateStockStatusDropDownList();
            PopulateBatchDropDownList();
            return View(model);
        }

        public IActionResult Edit(int? id)
        {
            ProductInformationViewModel model = new ProductInformationViewModel();
            //编辑界面
            if (id != null)
            {
                ProductInformation product = _productInformationService.GetProductById((int)id);
                model = new ProductInformationViewModel
                {
                    ProductId = product.Id,
                    ProductCode = product.ProductCode,
                    ProductName = product.ProductName,
                    ProductStatusName = Enum.GetName(typeof(ProductStatusType), product.ProductStatus),
                    Description = product.Description,
                    StockStatusName = Enum.GetName(typeof(StockStatusType), product.StockType),
                    ChineseTypeName = Enum.GetName(typeof(ClassType), product.Type),
                };
            }
            PopulateClassDropDownList();
            PopulateProductStatusDropDownList();
            PopulateStockStatusDropDownList();
            PopulateBatchDropDownList();
            return View(model);
        }



        //删除
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();
            _productInformationService.RemoveProductById((int)id);
            //图片删除由自动任务实现，不然会影响性能
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public IActionResult CreateSave(ProductInformationViewModel model)
        {
            if (ModelState.IsValid)
            {
                List<string> uniqueFileNameList = null;

                if (model.Photos != null && model.Photos.Count > 0)
                {
                    uniqueFileNameList = ProcessUploadedFile(model);

                }
                var details = new List<ProductDetail>();
                if (uniqueFileNameList!=null)
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
                    StockType = GetStockStatusMap(model.StockStatusName),
                    ProductStatus = GetProductStatusMap(model.ProductStatusName),
                    Type = ChineseConvertToEnum(GetMapClassName(model.ChineseTypeName)),
                    BatchId = model.BatchId,
                    Description = model.Description,
                    Details = details
                };

                _productInformationService.Save(product);

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }



        [HttpPost]
        public IActionResult EditSave(ProductInformationViewModel model)
        {
            if (ModelState.IsValid)
            {
                List<string> uniqueFileNameList = null;

                if (model.Photos != null && model.Photos.Count > 0)
                {
                    uniqueFileNameList = ProcessUploadedFile(model);

                }
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
                    Id= model.ProductId,
                    ProductCode = model.ProductCode,
                    ProductName = model.ProductName,
                    StockType = GetStockStatusMap(model.StockStatusName),
                    ProductStatus = GetProductStatusMap(model.ProductStatusName),
                    Type = ChineseConvertToEnum(GetMapClassName(model.ChineseTypeName)),
                    BatchId = model.BatchId,
                    Details = details
                };

                _productInformationService.UpdateProduct(product);

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }


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


        private void PopulateProductStatusDropDownList(object selectedProductStatus= null)
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
            foreach (var batch in batchInfos)
            {
                batchs.Add(new { id = batch.BatchId, name = batch.Name });
            }
            ViewBag.BatchIds = new SelectList(batchs, "id", "name", selectedBatch);
        }


        public string GetMapClassName(string index)
        {
            var ret = string.Empty;
            switch (index)
            {
                case "0":
                    ret = "悦享生活";
                    break;
                case "1":
                    ret = "居家好物";
                    break;
                case "2":
                    ret = "品质生活";
                    break;
                case "3":
                    ret = "厨房甄选";
                    break;
            }
            return ret;
        }

        public string ConvertToChinese(ClassType classType)
        {
            var ret = string.Empty;
            switch (classType)
            {
                case ClassType.yuexiangmeiwei:
                    ret = "悦享生活";
                    break;
                case ClassType.jujiahaowu:
                    ret = "居家好物";
                    break;
                case ClassType.pingzhishenghuo:
                    ret = "品质生活";
                    break;
                case ClassType.chufangzhengxuan:
                    ret = "厨房甄选";
                    break;
            }
            return ret;

        }

        public ClassType ChineseConvertToEnum(string chineseTypeName)
        {
            ClassType ret = ClassType.unknown;
            switch (chineseTypeName)
            {
                case "悦享生活":
                    ret = ClassType.yuexiangmeiwei;
                    break;
                case "居家好物":
                    ret = ClassType.jujiahaowu;
                    break;
                case "品质生活":
                    ret = ClassType.pingzhishenghuo;
                    break;
                case "厨房甄选":
                    ret = ClassType.chufangzhengxuan;
                    break;
            }
            return ret;


        }
        #endregion

        #region 商品状态枚举

        public string EnumConvertToChinese(ProductStatusType productStatus)
        {
            var ret = string.Empty;
            switch (productStatus)
            {
                case ProductStatusType.On:
                    ret = "上架";
                    break;
                case ProductStatusType.Down:
                    ret = "下架";
                    break;
            }
            return ret;
        }

        public ProductStatusType GetProductStatusMap(string index)
        {
            ProductStatusType ret = ProductStatusType.Unknown;
            switch (index)
            {
                case "0":
                    ret = ProductStatusType.Down;
                    break;
                case "1":
                    ret = ProductStatusType.On;
                    break;
                default:
                    ret = ProductStatusType.Unknown;
                    break;
            }
            return ret;

        }

        public StockStatusType GetStockStatusMap(string index)
        {
            StockStatusType ret = StockStatusType.Unknown;
            switch (index)
            {
                case "0":
                    ret = StockStatusType.No;
                    break;
                case "1":
                    ret = StockStatusType.Yes;
                    break;
                default:
                    ret = StockStatusType.Unknown;
                    break;
            }
            return ret;
        }


        #endregion

        #region 商品库存状态

        public string EnumStockStatusConvertToChinese(StockStatusType stockStatus)
        {
            var ret = string.Empty;
            switch (stockStatus)
            {
                case StockStatusType.Yes:
                    ret = "有货";
                    break;
                case StockStatusType.No:
                    ret = "无货";
                    break;
            }
            return ret;
        }


        #endregion




        #region 上传图片文件到wwwroot目录

        /// <summary>
        /// 将照片保存到指定的路径中，并返回唯一的文件名
        /// </summary>
        /// <returns></returns>
        private List<string> ProcessUploadedFile(ProductInformationViewModel model)
        {
            var photoFileNameList = new List<string>();

            if (model.Photos.Count > 0)
            {
                foreach (var photo in model.Photos)
                {
                    string uniqueFileName = null;
                    //必须将图像上传到wwwroot中的images文件夹
                    //而要获取wwwroot文件夹的路径，我们需要注入 ASP.NET Core提供的HostingEnvironment服务
                    //通过HostingEnvironment服务去获取wwwroot文件夹的路径
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                    //为了确保文件名是唯一的，我们在文件名后附加一个新的GUID值和一个下划线

                    uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    //因为使用了非托管资源，所以需要手动进行释放
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        //使用IFormFile接口提供的CopyTo()方法将文件复制到wwwroot/images文件夹
                        photo.CopyTo(fileStream);
                    }

                    photoFileNameList.Add(uniqueFileName);
                }
            }
            return photoFileNameList;

        }

        #endregion

    }
}