using System;
using GUI_assignment_2.Data;
using GUI_assignment_2.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(GUI_assignment_2.Areas.Identity.IdentityHostingStartup))]
namespace GUI_assignment_2.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                //    services.AddDbContext<ApplicationDbContext>(options =>
                //        options.UseSqlServer(
                //            context.Configuration.GetConnectionString("GUI_assignment_2DbContextConnection")));

                //    services.AddDefaultIdentity<ApplicationUser>(options =>
                //    {
                //        options.SignIn.RequireConfirmedAccount = false;
                //        options.Password.RequireUppercase = false;
                //        options.Password.RequireLowercase = false;

                //    })

                //    .AddEntityFrameworkStores<ApplicationDbContext>();
            });
        }
    }
}