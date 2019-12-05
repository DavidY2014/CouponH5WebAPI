using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BangBangFuli.API.MVCDotnet2.Models;
using BangBangFuli.H5.API.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BangBangFuli.API.MVCDotnet2.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {

            if (ModelState.IsValid)
            {
                var user = new User
                {
                    UserName = model.Email,
                    Email = model.Email,
                };

                var result =  await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {

                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }



        [AcceptVerbs("Get", "Post")]
        public IActionResult IsEmailInUse(string email)
        {

            //var user = await userManager.FindByEmailAsync(email);

            //if (user == null)
            //{
            //    return Json(true);
            //}
            //else
            //{

            //    return Json($"邮箱：{email}已经被注册使用了。");

            //}
            return null;

        }



    }
}