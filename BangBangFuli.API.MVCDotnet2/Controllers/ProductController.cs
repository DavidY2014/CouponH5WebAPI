using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BangBangFuli.API.MVCDotnet2.Models;
using BangBangFuli.H5.API.Application.Services.BasicDatas;
using BangBangFuli.H5.API.Core.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BangBangFuli.API.MVCDotnet2.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductInformationService _productInformationService;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IProductDetailService _productDetailService;

        public ProductController(IProductInformationService productInformationService ,IHostingEnvironment hostingEnvironment,IProductDetailService productDetailService)
        {
            _productInformationService = productInformationService;
            _hostingEnvironment = hostingEnvironment;
            _productDetailService = productDetailService;
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
                    IsInStock = product.IsInStock,
                    Class1 = product.Class1,
                    Class2 = product.Class2,
                    BatchId = product.BatchId
                });
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


        public IActionResult Create()
        {
            PopulateClass1DropDownList();
            return View();
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
                foreach (var uniqueFileName in uniqueFileNameList)
                {
                    details.Add(new ProductDetail { PhotoPath = uniqueFileName });
                }

                ProductInformation product = new ProductInformation
                {
                    ProductCode = model.ProductCode,
                    ProductName = model.ProductName,
                    IsInStock = model.IsInStock,
                    Class1 = model.Class1,
                    Class2 = model.Class2,
                    BatchId = model.BatchId,
                    Details = details
                };

                _productInformationService.Save(product);

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }


        private void PopulateClass1DropDownList(object selectedClass1 = null)
        {
            var departments = from d in _context.Departments orderby d.Name select d;

            ViewBag.DepartmentId = new SelectList(departments.AsNoTracking(), "Id", "Name", selectedDepartment);
        }




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