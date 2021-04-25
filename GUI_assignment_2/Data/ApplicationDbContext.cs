
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
        public DbSet<CheckedInModel> CheckedInModels { get; set; }
        public DbSet<KitchenModel> kitchenModels  { get; set; }
        public DbSet<OrderModel> orderModels { get; set; }
        
    }
}
