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
using Microsoft.EntityFrameworkCore;

namespace Mic.Controllers
{
    public class HomeController : Controller
    {
        // private readonly ILogger<HomeController> _logger;
        private readonly MicCategoryContext _context;

        public HomeController(MicCategoryContext context)
        {
            _context = context;
        }

        //public async Task<IActionResult> Index()
        //{
        //    var micContext = _context.Cat.Include(c => c.Category);
        //    return View(await micContext.ToListAsync());
        //}

        //[HttpPost]
        public async Task<IActionResult> Index(string id)
        {
            var micContext = _context.Cat.Include(c => c.Category);

            if (!string.IsNullOrWhiteSpace(id))
            {
                var model = from m in _context.Cat
                            select m;
                
                 model = model.Where(s => s.Name.Contains(id));

                
                return View(await model.ToListAsync());
            }
            return View(await micContext.ToListAsync());
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
