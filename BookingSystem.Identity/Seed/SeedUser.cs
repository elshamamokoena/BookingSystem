using BookingSystem.Identity.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Identity.Seed
{
    public class SeedUser
    {
        public static class UserCreator
        {
            public static async Task SeedUserAsync(UserManager<ApplicationUser> userManager)
            {
                var applicationUser = new ApplicationUser
                {
                    FirstName = "Masedi",
                    LastName = "Mokoena",
                    Email = "elshamamokoena@gmail.com",
                };
                var user = await userManager.FindByEmailAsync(applicationUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(applicationUser, "Sedi@2024");
                }

            }
        }
    }
}