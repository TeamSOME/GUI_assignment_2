using GUI_assignment_2.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GUI_assignment_2.Data
{
    public class DbHelper
    {
        public void CreateUsers(UserManager<ApplicationUser> userManager)
        {
            CreateReceptionUser(userManager);
            CreateRestaurantUser(userManager);
            CreateKitchenUser(userManager);
        }

        private async void CreateKitchenUser(UserManager<ApplicationUser> userManager)
        {
            const string KitchenEmail = "chef@baguettes.com";
            const string password = "hej123.";

            if (userManager.FindByNameAsync(KitchenEmail).Result == null)
            {
                var user = new ApplicationUser
                {
                    UserName = KitchenEmail,
                    Email = KitchenEmail

                };
                IdentityResult result = userManager.CreateAsync
                    (user, password).Result;
                if (result.Succeeded)
                {
                    var claim = new Claim("Chef", "Yes");
                    userManager.AddClaimAsync(user, claim).Wait();
                    string token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                    userManager.ConfirmEmailAsync(user, token).Wait();

                }
            }
        }

        private async void CreateReceptionUser(UserManager<ApplicationUser> userManager)
        {

            const string receptionEmail = "receptionist@baguettes.com";
            const string password = "hej123.";

            if (userManager.FindByNameAsync(receptionEmail).Result == null)
            {
                var user = new ApplicationUser
                {
                    UserName = receptionEmail,
                    Email = receptionEmail

                };
                IdentityResult result = userManager.CreateAsync
                    (user, password).Result;
                if (result.Succeeded)
                {
                    var claim = new Claim("Receptionist", "Yes");
                    userManager.AddClaimAsync(user, claim).Wait();
                    string token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                    userManager.ConfirmEmailAsync(user, token).Wait();

                }
            }
        }

        public async void CreateRestaurantUser(UserManager<ApplicationUser> userManager)
        {
            const string restaurantEmail = "waiter@baguettes.com";
            const string password = "hej123.";

            if (userManager.FindByNameAsync(restaurantEmail).Result == null)
            {
                var user = new ApplicationUser
                {
                    UserName = restaurantEmail,
                    Email = restaurantEmail

                };
                IdentityResult result = userManager.CreateAsync
                    (user, password).Result;
                if (result.Succeeded)
                {
                    var claim = new Claim("Waiter", "Yes");
                    userManager.AddClaimAsync(user, claim).Wait();
                    string token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                    userManager.ConfirmEmailAsync(user, token).Wait();
                }
            }
        }
    }
}
