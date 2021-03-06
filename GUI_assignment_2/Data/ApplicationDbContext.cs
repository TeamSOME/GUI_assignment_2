
using GUI_assignment_2.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GUI_assignment_2.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<OrderModel> OrderModels { get; set; }
        public DbSet<CheckedInModel> CheckedInModels { get; set; }
        public DbSet<KitchenModel> kitchenModels  { get; set; }
        
        
    }
}
