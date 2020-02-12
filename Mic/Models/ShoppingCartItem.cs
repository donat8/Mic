using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mic.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
        public Cat Cat { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartId { get; set; }

    }
}
