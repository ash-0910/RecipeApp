using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RecipeApp.Areas.Identity.Data;
using RecipeApp.Data;

[assembly: HostingStartup(typeof(RecipeApp.Areas.Identity.IdentityHostingStartup))]
namespace RecipeApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<RecipeAppContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("RecipeAppContextConnection")));

                services.AddDefaultIdentity<RecipeAppUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<RecipeAppContext>();
            });
        }
    }
}