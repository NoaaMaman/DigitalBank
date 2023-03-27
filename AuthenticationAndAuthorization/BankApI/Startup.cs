<<<<<<< HEAD
﻿
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
=======
﻿using Microsoft.OpenApi.Models;
>>>>>>> 6b020f7139a3606cc80faecac92a2003862d6710

namespace BankApI
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
<<<<<<< HEAD
           

            services.AddControllers();

=======

            services.AddControllers();
>>>>>>> 6b020f7139a3606cc80faecac92a2003862d6710
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BankAPI", Version = "v1" });
            });
<<<<<<< HEAD

            services.AddCors(options =>
            {
                var frontendURL = Configuration.GetValue<string>("frontend_url");
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder.WithOrigins(frontendURL).AllowAnyMethod().AllowAnyHeader();
                    options.AddDefaultPolicy(builder =>
                    {
                        builder.WithOrigins(frontendURL).AllowAnyMethod().AllowAnyHeader();
                    });
                });
            });
        }


=======
        }

>>>>>>> 6b020f7139a3606cc80faecac92a2003862d6710
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BankAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

<<<<<<< HEAD
           

=======
>>>>>>> 6b020f7139a3606cc80faecac92a2003862d6710
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
