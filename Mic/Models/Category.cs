using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mic.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public List<Cat> Cats { get; set; }
    }
}