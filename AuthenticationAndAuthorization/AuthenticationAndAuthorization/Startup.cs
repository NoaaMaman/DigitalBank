using AuthenticationAndAuthorization.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AuthenticationAndAuthorization
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
                options.LoginPath= "/Account/Login";//Explicitly declare the login page
                options.AccessDeniedPath= "/Account/AccessDenied";
                options.ExpireTimeSpan= TimeSpan.FromMinutes(2);
            });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly",
                    policy => policy.RequireClaim("Admin"));

                options.AddPolicy("MustBelongConsultingBanker"
                    , policy => policy.RequireClaim("Employee", "ConsultingBankers"));
                options.AddPolicy("ConsultantManagerOnly", policy => policy
                    //.RequireClaim("Department", "ConsultingBankers")
                    .RequireClaim("Manager")
                    .Requirements.Add(new ConsultantManagerProbationRequiremet(3)));    
            });
            services.AddSingleton<IAuthorizationHandler, ConsultantManagerProbationRequiremetHandler>();
            services.AddRazorPages();
            services.AddHttpClient("OurWebAPI", client =>
            {
                client.BaseAddress = new Uri("https://localhost:7193/");
            });
            services.AddSession(options =>
            {
                options.Cookie.HttpOnly = true;
                options.IdleTimeout = TimeSpan.FromHours(8);
                options.Cookie.IsEssential = true;
            });
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
            });
        }
    }
}
