using WebApplication.Services;
using WebApplication.Models.DTOS.AccountDTO;

using BankAPI.DAL;
using WebApplication.Profiles;
using Umbraco.Core.Composing.CompositionExtensions;

var builder = Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IAccountServicesApp, AccountServiceApp>();
builder.Services.AddHttpClient(); // Add this line to register IHttpClientFactory
builder.Services.AddAutoMapper(typeof(AutomapperProfiles));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();