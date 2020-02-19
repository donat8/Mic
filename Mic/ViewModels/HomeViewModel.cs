using Mic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mic.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Cat> Cats { get; set; }
    }
}
