using StoreOfBuild.Domain.Products;
using StoreOfBuild.Data.Contexts;
using StoreOfBuild.Domain.Sales;
using StoreOfBuild.Data.Identity;
using StoreOfBuild.Domain.Account;
using Microsoft.Extensions.DependencyInjection;
using StoreOfBuild.Domain;
using Microsoft.EntityFrameworkCore;
using StoreOfBuild.Data.Repositories;
using Microsoft.AspNetCore.Identity;

namespace StoreOfBuild.DI
{
    public class Bootstrap
    {
        public static void Configure(IServiceCollection services,string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            //Adicionando atuthentication
            services.AddIdentity<ApplicationUser, IdentityRole>(config => {

                config.Password.RequireDigit = false;
                config.Password.RequiredLength = 3;
                config.Password.RequireLowercase = false;
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequireUppercase = false;
                //Não existe mais essa opção no Core 2.1
                //config.Cookies.ApplicationCookie.LoginPath = "/Account/Login";
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options => options.AccessDeniedPath = "/Account/Login");

            //Injetando dependencias
            services.AddScoped(typeof(IRepository<Product>), typeof(ProductRepository));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IAuthentication), typeof(Authentication));
            services.AddScoped(typeof(IManager), typeof(Manager));
            //services.AddScoped(typeof(UserManager<ApplicationUser>));            
            services.AddScoped(typeof(CategoryStorer));
            services.AddScoped(typeof(ProductStorer));
            services.AddScoped(typeof(SaleFactory));
            services.AddScoped(typeof(Domain.IUnitOfWork),typeof(Data.IUnitOfWork));

        }
    }
}
