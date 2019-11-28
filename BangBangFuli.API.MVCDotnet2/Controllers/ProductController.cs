using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BangBangFuli.API.MVCDotnet2.Models;
using BangBangFuli.H5.API.Application.Services.BasicDatas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BangBangFuli.API.MVCDotnet2.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductInformationService _productInformationService;

        public ProductController(IProductInformationService productInformationService)
        {
            _productInformationService = productInformationService;
        }
        public IActionResult Index()
        {
            var productViewModelList = new List<ProductInformationViewModel>();
            var products = _productInformationService.GetAll();
            foreach (var product in products)
            {
                productViewModelList.Add(new ProductInformationViewModel { ProductId = product.Id, Name = product.Name });
            }
            return View(productViewModelList);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult CreateSave(ProductInformationViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }


    }
}