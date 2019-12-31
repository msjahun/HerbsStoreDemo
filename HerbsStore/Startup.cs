using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using HerbsStore.Libraries.HS.Core.Domain.Users;
using HerbsStore.Libraries.HS.Data;
using HerbsStore.Libraries.HS.Data.Repository;
using HerbsStore.Libraries.HS.Services.DiseaseServices;
using HerbsStore.Libraries.HS.Services.DropdownServices;
using HerbsStore.Libraries.HS.Services.FeedbackServices;
using HerbsStore.Libraries.HS.Services.HospitalServices;
using HerbsStore.Libraries.HS.Services.ImageServices;
using HerbsStore.Libraries.HS.Services.OrdersServices;
using HerbsStore.Libraries.HS.Services.ProductServices;
using HerbsStore.Libraries.HS.Services.Security;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace HerbsStore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IPermissionService, PermissionService> ();
            //Add identity
            services.AddIdentity<User, UserRole>()
                .AddEntityFrameworkStores<Context>()
                .AddDefaultTokenProviders();


            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Login";
                options.AccessDeniedPath = "/Error/AccessDenied";

            });
           
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();


            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IImageService, ImageService > ();
            services.AddScoped<IProductService, ProductService > ();
            services.AddScoped<IDropdownService, DropdownService> ();
            services.AddScoped< IHospitalService,HospitalService > ();
            services.AddScoped< IFeedbackService, FeedbackService > ();
            services.AddScoped<IOrderService, OrderService > ();
            services.AddScoped<ICartService, CartService> ();
            services.AddScoped< IDiseaseService, DiseaseService > ();


            var connectionString = Configuration.GetValue<string>("DbSettings:SqlConnectionString");
            services.AddDbContext<Context>(options => options.UseSqlServer(connectionString));



            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            // identity middleware
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseStatusCodePages(async context => {
                var request = context.HttpContext.Request;
                var response = context.HttpContext.Response;

                if (response.StatusCode == (int)HttpStatusCode.Unauthorized)
                    // you may also check requests path to do this only for specific methods       
                    // && request.Path.Value.StartsWith("/specificPath")

                {
                    response.Redirect("/authentication/login");
                }
            });
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
