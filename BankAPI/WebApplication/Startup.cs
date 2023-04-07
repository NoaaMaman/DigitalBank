using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Profiles;
using WebApplication.Services;


//builder.Services.AddControllersWithViews();
//builder.Services.AddScoped<IAccountServicesApp, AccountServiceApp>();
//builder.Services.AddHttpClient(); // Add this line to register IHttpClientFactory
//builder.Services.AddAutoMapper(typeof(AutomapperProfiles));

namespace WebApplication
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
            
            services.AddAuthentication("MyCookieAuth").AddCookie("MyCookieAuth", options =>
            {
                options.Cookie.Name = "MyCookieAuth";
                options.LoginPath = "/Account/Login"; // Explicitly declare the login page
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(2);
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly",
                    policy => policy.RequireClaim("Admin"));

                options.AddPolicy("MustBelongConsultingBanker",
                   policy => policy.RequireClaim("Department", "ConsultingBankers"));

                options.AddPolicy("ConsultantManagerOnly", policy =>
                {
                    policy.RequireClaim("Manager")
                    .RequireClaim("Department", "ConsultingBankers");
                });
            });

            services.AddControllers();
            services.AddRazorPages();

            services.AddHttpClient("AuthenAuthorAPI", client =>
            {
                client.BaseAddress = new Uri("https://localhost:7168");
            });

            services.AddSession(options =>
            {
                options.Cookie.HttpOnly = true;
                options.IdleTimeout = TimeSpan.FromHours(2);
                options.Cookie.IsEssential = true;
            });

            services.AddHttpContextAccessor();
            services.AddScoped<IAccountServicesApp, AccountServiceApp>();
            services.AddHttpClient(); // Add this line to register IHttpClientFactory
            services.AddAutoMapper(typeof(AutomapperProfiles));
            services.AddControllersWithViews();
            services.AddMvc();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();


            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
