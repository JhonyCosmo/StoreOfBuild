using Microsoft.AspNetCore.Identity;
using StoreOfBuild.Domain.Account;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StoreOfBuild.Data.Identity
{
    public class Authentication : IAuthentication
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        private readonly UserManager<ApplicationUser> _userManager;
        
        public Authentication(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<bool> Authenticate(string email, string password)
        {            
            var result = await _signInManager.PasswordSignInAsync(email, password, false, lockoutOnFailure: true);
            return result.Succeeded;
        }

        public async Task<bool> CreateAsync(string email, string password)
        {
            var user = new ApplicationUser {
                UserName = email,
                Email = email,
                SecurityStamp = Guid.NewGuid().ToString(),
                PhoneNumber = "111-222-3344",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };            

            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                return true;
            }

            return false;

        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
