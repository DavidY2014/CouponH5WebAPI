using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BangBangFuli.H5.API.Application.Services.BasicDatas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BangBangFuli.API.MVCDotnet2.Controllers
{
    public class BatchController : Controller
    {
        public BatchController(IBatchInformationService batchInformationService)
        {

        }
        // GET: Batch
        public ActionResult Index()
        {
            return View();
        }

    }
}