using DataAccess.Concrete.EntityFrameworkCore.Context;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcUI.CustomCollectionExtensions
{
    public static class CollectionExtensions
    {
        public static void AddCustomIdentity(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, AppRole>()
             .AddEntityFrameworkStores<HotelDbContext>();

            services.ConfigureApplicationCookie(opt =>
            {
                opt.Cookie.Name = "IsTakipCookie";
                opt.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict;
                opt.Cookie.HttpOnly = true;
                opt.ExpireTimeSpan = TimeSpan.FromDays(20);
                opt.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.SameAsRequest;
                opt.LoginPath = "/Account/AccessDenied";
            });
        }
    }
}
