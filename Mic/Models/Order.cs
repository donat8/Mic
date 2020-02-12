using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mic.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public List<OrderDetail> OrderLines { get; set; } //orderId,catId,amount,price
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Adress { get; set; }

        public string ZipCode { get; set; }

        public string Country { get; set; }

        public string Email { get; set; }

        public decimal OrderTotal { get; set; }

        public DateTime OrderPlaced { get; set; }
    }
}
