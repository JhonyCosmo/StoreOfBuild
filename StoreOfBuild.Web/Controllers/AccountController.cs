using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StoreOfBuild.Data;
using StoreOfBuild.Data.Identity;
using StoreOfBuild.Domain;
using StoreOfBuild.Domain.Account;
using StoreOfBuild.Domain.Products;
using StoreOfBuild.Web.ViewModels;

namespace StoreOfBuild.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthentication _authentication;
       
        public AccountController( IAuthentication authentication)
        {
            _authentication = authentication;
           
        }   
        public IActionResult Login() {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var result = await _authentication.Authenticate(model.Email, model.Password);

            if (result)
                return Redirect("/");
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid loguin attempt.");
                return View(model);
            }           
        }
              
        public IActionResult Register()
        {           
            return View();
        }

        [HttpPost]            
        public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {

                var result = await _authentication.CreateAsync(model.Email, model.Password);

                if (result)
                    return Redirect("/");
                else
                {
                    ModelState.AddModelError(string.Empty, "Cannot create user");
                    return View(model);
                }
                
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _authentication.Logout();
            return Redirect("/Account/Login");
        }

        public IActionResult AccessDenied() {
            return View();
        }
    }
}
