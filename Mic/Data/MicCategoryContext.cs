using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mic.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Mic.Data
{
    public class MicCategoryContext:IdentityDbContext<IdentityUser>
    {
        public MicCategoryContext(DbContextOptions<MicCategoryContext> options)
            : base(options)
        {
        }

        public DbSet<Cat> Cat { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

   


    }
}
