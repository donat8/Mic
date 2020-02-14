using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mic.Data;
using Mic.Models;
using Mic.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace Mic.Controllers
{
    public class CatsController : Controller
    {
        private readonly MicCategoryContext _context;
        //private readonly ICatRepository _catRepository;

        public CatsController(MicCategoryContext context/*,ICatRepository catRepository */)
        {
            _context = context;
            //_catRepository = catRepository;
        }

        // GET: Cats
        public async Task<IActionResult> Index()
        {           
            var micContext = _context.Cat.Include(c => c.Category);
            return View(await micContext.ToListAsync());
        }

        // GET: Cats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cat = await _context.Cat
                .Include(c => c.Category)
                .FirstOrDefaultAsync(m => m.CatId == id);
            if (cat == null)
            {
                return NotFound();
            }

            return View(cat);
        }

        [Authorize]
        
        // GET: Cats/Create
        public IActionResult Create()
        {
        
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryName");
    

            return View();
        }

        // POST: Cats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CatId,Name,DateOfBirth,ShortDescription,LongDescription,Price,ImageUrl,ImageThumbnailUrl,IsPreferredCat,InStock,CategoryId")] Cat cat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryName",cat.CategoryId);

            return View(cat);
        }
        
        [Authorize]
        // GET: Cats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cat = await _context.Cat.FindAsync(id);
            if (cat == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "CategoryId", "CategoryName", cat.CategoryId);
            return View(cat);
        }

        // POST: Cats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CatId,Name,DateOfBirth,ShortDescription,LongDescription,Price,ImageUrl,ImageThumbnailUrl,IsPreferredCat,InStock,CategoryId")] Cat cat)
        {
            if (id != cat.CatId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatExists(cat.CatId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "CategoryId", "CategoryName", cat.CategoryId);
            return View(cat);
        }

        [Authorize(AuthenticationSchemes ="Admin")]
        // GET: Cats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cat = await _context.Cat
                .Include(c => c.Category)
                .FirstOrDefaultAsync(m => m.CatId == id)
                ;
            if (cat == null)
            {
                return NotFound();
            }

            return View(cat);
        }

        // POST: Cats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cat = await _context.Cat.FindAsync(id);
            _context.Cat.Remove(cat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatExists(int id)
        {
            return _context.Cat.Any(e => e.CatId == id);
        }

        public ViewResult Details(int catId)
        {
            var cat = _context.Cat.FirstOrDefault(d => d.CatId == catId);
            if (cat == null)
            {
                return View("~/Views/Error/Error.cshtml");
            }
            return View(cat);
        }
    }
}
