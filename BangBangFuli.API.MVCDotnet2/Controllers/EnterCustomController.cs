using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BangBangFuli.API.MVCDotnet2.Filter;
using BangBangFuli.Common;
using BangBangFuli.H5.API.Application.Services.BasicDatas;
using BangBangFuli.H5.API.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BangBangFuli.API.MVCDotnet2.Controllers
{
    [UserLoginFilter]
    public class EnterCustomController : Controller
    {
        private UserInfo _userinfo;
        private IUserRoleJurisdictionService _userRoleJurisdictionService;
        private IModuleInfoService _moduleInfoService;
        public EnterCustomController(IUserRoleJurisdictionService userRoleJurisdictionService, IModuleInfoService moduleInfoService)
        {
            _userRoleJurisdictionService = userRoleJurisdictionService;
            _moduleInfoService = moduleInfoService;
        }

        /// <summary>
        /// 首页，工作台
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> ConsoleIndex()
        {
            return View();
        }

        public async Task<IActionResult> ProductIndex()
        {
            return View();
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
    }
}