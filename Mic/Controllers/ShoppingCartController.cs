using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mic.Data;
using Mic.Models;
using Mic.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Mic.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ShoppingCart _shoppingCart;
        private readonly MicCategoryContext _micCategoryContext;

        public ShoppingCartController(MicCategoryContext micCategoryContext, ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
            _micCategoryContext = micCategoryContext;
        }
        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var sCVM = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()

            };
            return View(sCVM);

        }
        public RedirectToActionResult AddToShoppingCart(int catId)
        {
            var selectedCat = _micCategoryContext.Cat.FirstOrDefault(p => p.CatId == catId);
            if (selectedCat != null)
            {
                _shoppingCart.AddToCart(selectedCat, 1);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int catId)
        {
            var selectedCat = _micCategoryContext.Cat.FirstOrDefault(p => p.CatId == catId);
            if (selectedCat != null)
            {
                _shoppingCart.RemoveFromCart(selectedCat);
            }
            return RedirectToAction("Index");
        }
    }
}