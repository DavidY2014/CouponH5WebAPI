using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BangBangFuli.API.MVCDotnet2.Controllers
{
    public class CouponController : Controller
    {
  
        public ActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }


    }
}