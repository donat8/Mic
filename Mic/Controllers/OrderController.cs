using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mic.Data;
using Mic.Interfaces;
using Mic.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mic.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ShoppingCart _shoppingCart;
        //private readonly MicCategoryContext _micCategoryContext;


        public OrderController(IOrderRepository orderRepository, ShoppingCart shoppingCart,MicCategoryContext micCategoryContext)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
            //_micCategoryContext = micCategoryContext;
        }

        [Authorize]
        public IActionResult Checkout()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;
            if (_shoppingCart.ShoppingCartItems.Count== 0)
            {
                ModelState.AddModelError("", "Košarica je prazna dodajte nešto");
            }

            if (ModelState.IsValid)    //ako je model state ok
            {
                _orderRepository.CreateOrder(order);
                _shoppingCart.ClearCart();
                

                return RedirectToAction("CheckoutComplete");
            }
            return View(order);
        }

        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Hvala na narudžbi :)";
            return View();
        }
    }
}