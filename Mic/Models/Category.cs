using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mic.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Display(Name = "Ime vrste")]
        public string CategoryName { get; set; }

        [Display(Name = "Opis vrste")]
        public string Description { get; set; }
        public List<Cat> Cats { get; set; }
    }
}