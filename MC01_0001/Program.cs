// Program.cs
// Version: 1.0.0
// (c) 2024, Minh Tri Tran, with assistance from Google's Gemini - Licensed under CC BY 4.0
// https://creativecommons.org/licenses/by/4.0/

using Microsoft.EntityFrameworkCore;

using MC01_0001.Data;



var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MovieCatalogueDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
