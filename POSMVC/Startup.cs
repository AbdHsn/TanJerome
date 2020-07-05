using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CommonLogics;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using POSMVC.CommonBusinessFunctions;
using POSMVC.Models.Entities;

namespace POSMVC
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        private string _contentRootPath = "";
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            Configuration = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("settings.json")
            .Build();

            _contentRootPath = env.ContentRootPath;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddMvc(option =>
            //{
            //    option.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            //    var policy = new AuthorizationPolicyBuilder()
            //    .RequireAuthenticatedUser()
            //    .Build();
            //    option.Filters.Add(new AuthorizeFilter(policy));
            //}).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            //    .AddCookie(option =>
            //    {
            //        option.AccessDeniedPath = "/Accounts/Denied";
            //        option.LoginPath = "/Accounts/NotLogIn";
            //    });


            services.AddMvc().AddJsonOptions(option => 
            option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<CommonFunctions>();
            services.AddScoped<CommonBusinessLogics>();

            //Online Database
            services.AddDbContext<EyePosDBContext>(option =>
            option.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));

            ////Offline Database ...
            //services.AddDbContext<EyePosDBContext>(option =>
            //{
            //    string conn = Configuration.GetConnectionString("connection");
            //    if (conn.Contains("%CONTENTROOTPATH%"))
            //    {
            //        conn = conn.Replace("%CONTENTROOTPATH%", _contentRootPath);
            //    }
            //    option.UseSqlServer(conn);
            //});

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //app.UseStaticFiles();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseStaticFiles();
            app.UseHttpsRedirection();

            //app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
         
            });
        }
    }
}
