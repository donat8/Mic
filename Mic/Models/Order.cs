using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mic.Models
{
    public class Order
    {
        [BindNever]
        public int OrderId { get; set; }

        public List<OrderDetail> OrderLines { get; set; } //orderId,catId,amount,price
       
        [Display(Name="Ime")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Display(Name = "Prezime")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Display(Name = "Adresa")]
        [StringLength(50)]
        public string Adress { get; set; }

        [StringLength(10, MinimumLength = 4)]
        [Display(Name = "Poštanski broj")]
        public string ZipCode { get; set; }

        [StringLength(20)]
        [Display(Name = "Grad")]
        public string Country { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]

        public string Email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        [DataType(DataType.Currency)]
        public decimal OrderTotal { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderPlaced { get; set; }
    }
}
