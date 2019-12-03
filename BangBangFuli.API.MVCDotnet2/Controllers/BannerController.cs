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
    public class BannerController : Controller
    {
        private readonly IBannerService _bannerService;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IBannerDetailService _bannerDetailService;

        public BannerController(IBannerService bannerService, IHostingEnvironment hostingEnvironment,IBannerDetailService bannerDetailService)
        {
            _bannerService = bannerService;
            _hostingEnvironment = hostingEnvironment;
            _bannerDetailService = bannerDetailService;
        }

        public IActionResult Index()
        {
            List<BannerViewModel> bannerViewModels = new List<BannerViewModel>();
            List<Banner> banners = _bannerService.GetAll();
            foreach (var banner in banners)
            {
                bannerViewModels.Add(new BannerViewModel
                {
                    BatchId = banner.BatchId,
                    CreateTime = banner.CreateTime
                });
            }
            return View(bannerViewModels);
        }


        /// <summary>
        /// 创建banner新建视图
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Detail()
        {
            return View();
        }

        //详情界面，图片渲染
        public IActionResult Details(int id)
        {
            List<BannerDetailViewModel> vmdetails = new List<BannerDetailViewModel>();
            List<BannerDetail> details = _bannerDetailService.GetDetailsByBannerId(id);
            foreach (var detail in details)
            {
                vmdetails.Add(new BannerDetailViewModel()
                {
                    PhotoPath = detail.PhotoPath
                });
            }

            return View(vmdetails);
        }


        [HttpPost]
        public IActionResult CreateSave(BannerViewModel model)
        {
            if (ModelState.IsValid)
            {

                List<string> uniqueFileNameList = null;

                if (model.Photos != null && model.Photos.Count > 0)
                {
                    uniqueFileNameList = ProcessUploadedFile(model);
                }
                var details = new List<BannerDetail>();
                foreach (var uniqueFileName in uniqueFileNameList)
                {
                    details.Add(new BannerDetail
                    {
                        PhotoPath = uniqueFileName
                    });
                }

                Banner banner = new Banner
                {
                    BatchId = model.BatchId,
                    CreateTime = DateTime.Now,
                    BannerDetails = details
                };
                _bannerService.Save(banner);

                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        /// <summary>
        /// 将照片保存到指定的路径中，并返回唯一的文件名
        /// </summary>
        /// <returns></returns>
        private List<string> ProcessUploadedFile(BannerViewModel model)
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
                    string fileNameWithoutExtension =System.IO.Path.GetFileName(photo.FileName);

                    uniqueFileName = Guid.NewGuid().ToString() + "_" + fileNameWithoutExtension;
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


    }
}