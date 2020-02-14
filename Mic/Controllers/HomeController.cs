using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mic.Models;
using Mic.Data;
using Mic.ViewModels;
using Mic.Repositories;

namespace Mic.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //private readonly ICatRepository _catRepository;

        //public HomeController(ICatRepository catRepository)
        //{
        //    _catRepository = catRepository;
        //}

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //var homeViewModel = new HomeViewModel
            //{
            //    Cats = _catRepository.Cats
            //};
      
            return View(/*homeViewModel*/);
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
