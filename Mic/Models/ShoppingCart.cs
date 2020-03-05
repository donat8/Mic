using Mic.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mic.Models
{
    public class ShoppingCart
    {
        private readonly MicCategoryContext _micCategoryContext;
        public ShoppingCart(MicCategoryContext micCategoryContext)
        {
            _micCategoryContext = micCategoryContext;
        }
        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            var context = services.GetService<MicCategoryContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

       
        public void AddToCart(Cat cat, int amount)
        {
            var shoppingCartItem = _micCategoryContext.ShoppingCartItems.SingleOrDefault(
                s => s.Cat.CatId == cat.CatId && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Cat = cat,
                    Amount = 1
                };
                cat.InStock -= 1;

                _micCategoryContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
                cat.InStock -= 1;
            }
            _micCategoryContext.SaveChanges();
            
        }
        public int RemoveFromCart(Cat cat)
        {
            var shoppingCartItem =
                _micCategoryContext.ShoppingCartItems.SingleOrDefault(
                    s => s.Cat.CatId == cat.CatId && s.ShoppingCartId == ShoppingCartId);

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _micCategoryContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }

            _micCategoryContext.SaveChanges();

            return localAmount;
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??
                   (ShoppingCartItems =
                       _micCategoryContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                           .Include(s => s.Cat)
                           .ToList());
        }

        public void ClearCart()
        {
            
            var cartItems = 
                _micCategoryContext
                .ShoppingCartItems
                .Where(cart => cart.ShoppingCartId == ShoppingCartId);

            

            _micCategoryContext.ShoppingCartItems.RemoveRange(cartItems);



            _micCategoryContext.ShoppingCartItems.RemoveRange(_micCategoryContext
                .ShoppingCartItems
                .Where(cart => cart.Amount == 1));

            _micCategoryContext.Cat.RemoveRange(_micCategoryContext.Cat.Where(c=>c.InStock<1));


            _micCategoryContext.SaveChanges();
        }

        public decimal GetShoppingCartTotal()
        {
            var total = _micCategoryContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.Cat.Price * c.Amount).Sum();
            return total;
        }


    }


}
