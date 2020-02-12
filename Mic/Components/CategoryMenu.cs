using Mic.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mic.Components
{
    public class CategoryMenu:ViewComponent
    {
        private readonly MicCategoryContext _categoryContext;

        public CategoryMenu(MicCategoryContext categoryContext)
        {
            _categoryContext = categoryContext;
        }
        
        public IViewComponentResult Invoke()
        {
            var categories = _categoryContext.Category.OrderBy(p => p.CategoryName);
            return View(categories);
        }
        
    }
}
