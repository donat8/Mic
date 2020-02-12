using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mic.Data;
using Mic.Models;
using Microsoft.AspNetCore.Mvc;

namespace Mic.Controllers
{
    public class OrderController : Controller
    {
        private readonly MicCategoryContext _micCategoryContext;
        private readonly ShoppingCart _shoppingCart;


        public OrderController(MicCategoryContext micCategoryContext, ShoppingCart shoppingCart)
        {
            _micCategoryContext = micCategoryContext;
            _shoppingCart = shoppingCart;
        }
        public IActionResult Checkout()
        {
            return View();
        }
    }
}