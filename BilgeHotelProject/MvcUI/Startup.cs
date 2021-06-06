using DataAccess.Concrete.EntityFrameworkCore.Context;
using DataAccess.Concrete.EntityFrameworkCore.SeedData;
using Entities.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using MvcUI.CustomCollectionExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Containers.MicrosoftIoC;

namespace MvcWebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddDbContext<HotelDbContext>();

            services.AddCustomIdentity();

            services.AddDependencies();

            services.AddControllersWithViews().AddFluentValidation();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,UserManager<AppUser> userManager,RoleManager<AppRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();

                app.UseHsts();
            }

            SeedInitializer.Seed(userManager, roleManager).Wait();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area}/{controller=Home}/{action=Index}/{id?}"
                    );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                    );
            });
        }
    }
}
