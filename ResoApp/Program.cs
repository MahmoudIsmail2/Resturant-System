using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ResturantApp.Bl;
using ResoApp.Models;
using ResoApp;

var builder = WebApplication.CreateBuilder(args);
#region BlServices
builder.Services.AddScoped<IClsCategories, ClsCategories>();
builder.Services.AddScoped<IClsInvoices, ClsInvoices>();
#endregion
// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DbResturantContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddControllersWithViews();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   // app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=index}/{id?}");
//app.MapRazorPages();

app.Run();
