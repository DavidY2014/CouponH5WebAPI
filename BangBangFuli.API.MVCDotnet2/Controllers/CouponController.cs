﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BangBangFuli.API.MVCDotnet2.Models;
using BangBangFuli.H5.API.Application.Services.BasicDatas;
using BangBangFuli.H5.API.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BangBangFuli.API.MVCDotnet2.Controllers
{
    public class CouponController : Controller
    {
        private readonly ICouponService _couponService;

        public CouponController(ICouponService couponService)
        {
            _couponService = couponService;
        }
  
        public IActionResult Index()
        {
            var couponViewModelList = new List<CouponViewModel>();
            var coupons = _couponService.GetAll();
            foreach (var item in coupons)
            {
                couponViewModelList.Add(new CouponViewModel { 
                 Code=item.Code.ToString(),
                 Password = item.Password,
                 ValidityDate = item.ValidityDate,
                 TotalCount = item.TotalCount
                });
            }

            return View(couponViewModelList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateSave(CouponViewModel model)
        {
            if (ModelState.IsValid)
            {
                Coupon coupon = new Coupon
                {
                    Code = int.Parse(model.Code),
                    Password = model.Password,
                    ValidityDate = model.ValidityDate,
                    TotalCount = model.TotalCount
                };

                _couponService.AddNew(coupon);

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }


    }
}