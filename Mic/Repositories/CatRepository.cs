using Mic.Data;
using Mic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mic.Repositories
{
    public interface ICatRepository
    {
        IEnumerable<Cat> Cats { get; }
      
        Cat GetCatById(int catId);
    }
    public class CatRepository:ICatRepository
    {
        private readonly MicCategoryContext _micCategoryContext;
        public CatRepository(MicCategoryContext micCategoryContext)
        {
            _micCategoryContext = micCategoryContext;
        }

        public IEnumerable<Cat> Cats => _micCategoryContext.Cat.Include(c => c.Category);

        public Cat GetCatById(int catId) => _micCategoryContext.Cat.FirstOrDefault(p => p.CatId == catId);
    }
}
