using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mic.Models
{
    public class Cat
    {
        
        public int CatId { get; set; }

        [StringLength(25)]
        //  [MaxLength(25)]
        [Required(ErrorMessage ="Polje je obavezno")]
        [Display(Name="Ime")]
        public string Name { get; set; }


        [Display(Name = "Datum rođenja")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Kratki opis")]
        [Required]
        [StringLength(100)]
        public string ShortDescription { get; set; }

        [Display(Name = "Detaljniji opis")]
        [StringLength(501)]
        public string LongDescription { get; set; }

        [Display(Name = "Cijena")]
        [Range(0,100)]
        [DataType(DataType.Currency)]
        public int Price { get; set; }

        [Display(Name = "Url slike:")]
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }
        public string ImageThumbnailUrl { get; set; }       
        public bool IsPreferredCat { get; set; }

        [Display(Name = "Količina")]
        [Range(0,7)]
        public int InStock { get; set; }


        [Display(Name = "Vrsta Mačke")]      
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
