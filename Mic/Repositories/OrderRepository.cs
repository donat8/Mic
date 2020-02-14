using Mic.Data;
using Mic.Interfaces;
using Mic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mic.Repositories
{
    public class OrderRepository:IOrderRepository
    {
        private readonly MicCategoryContext _micCategoryContext;
        private readonly ShoppingCart _shoppingCart;


        public OrderRepository(MicCategoryContext micCategoryContext,ShoppingCart shoppingCart)
        {
            _micCategoryContext = micCategoryContext;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;
          
            _micCategoryContext.Orders.Add(order);

            _micCategoryContext.SaveChanges();

            var shoppingCartItems = _shoppingCart.ShoppingCartItems;
        
            foreach (var item in shoppingCartItems)
            {
                var orderDetail = new OrderDetail()
                {
                    Amount = item.Amount,
                    CatId = item.Cat.CatId,
                     OrderId = order.OrderId,
                    Price = item.Cat.Price


                };


                _micCategoryContext.OrderDetails.Add(orderDetail);
            }

            _micCategoryContext.SaveChanges();


        }



    }
}
