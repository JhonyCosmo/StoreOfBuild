using Microsoft.AspNetCore.Identity;
using StoreOfBuild.Data.Contexts;
using StoreOfBuild.Domain.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreOfBuild.Data.Identity
{
    public class Manager:IManager
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private ApplicationDbContext _context;

        public Manager(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public async Task<bool> CreateAsync(string email, string password, string role) {

                        



            var user = new ApplicationUser {UserName = email, Email = email , SecurityStamp = Guid.NewGuid().ToString() };


          // _userManager.add
            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded) {

                await _userManager.AddToRoleAsync(user, role);
                return true;

            }

            return false;

        }

        public List<IUser> ListAll()
        {
            var users = _context.Users;
            //Retornando a interface de IUser para não haver necessidade de adicionar 
            //a dependencia do projeto .Data no .Web
            return users.Any()? users.Select(u=>(IUser)u).ToList():new List<IUser>();
        }

    }
}
