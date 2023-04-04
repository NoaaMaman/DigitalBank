using BankAPI.DAL;
using BankAPI.Models;
using BankAPI.Services.Implementations;
using BankAPI.Services.Interfaces;
using Newtonsoft.Json;

using Microsoft.EntityFrameworkCore;

namespace BankAPI
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
            services.AddDbContext<youBankingDbContext>(x => x.UseSqlServer(Configuration.GetConnectionString("youBankingDbConnection")));
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ITransactionService, TransactionService>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "BankAPI doc",
                    Version = "v2",
                    Description = "This is the API which manage the Accounts and the transactions"
                });
            });
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(x =>
            {
                var prefix = string.IsNullOrEmpty(x.RoutePrefix) ? "." : "..";
                x.SwaggerEndpoint($"{prefix}/swagger/v2/swagger.json", "BankAPI doc");

            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
