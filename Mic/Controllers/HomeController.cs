using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mic.Models;
using Mic.Data;

namespace Mic.Controllers
{
    public class HomeController : Controller
    {
      //  private readonly ILogger<HomeController> _logger;

        private readonly MicCategoryContext _micCategoryContext;

        public HomeController(MicCategoryContext micCategoryContext)
        {
            _micCategoryContext = micCategoryContext;
        }

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
        //    PartialViewResult partialView = new PartialViewResult() {  = _micCategoryContext.Cat };   
            
        //    return View(partialView);
                return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }


}
