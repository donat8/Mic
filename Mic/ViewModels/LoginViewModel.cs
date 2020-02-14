using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mic.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name ="Korisničko ime")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(15,MinimumLength =6,ErrorMessage ="Duljina lozinke treba biti 6-15 znakova")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }


    }
}
