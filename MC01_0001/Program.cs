/*
    Program.cs
    Version: 1.0.0
    (c) 2024, Minh Tri Tran, with assistance from Google's Gemini - Licensed under CC BY 4.0
    https://creativecommons.org/licenses/by/4.0/

    This work builds upon concepts and examples from:
    "Get started with ASP.NET Core MVC | Microsoft Learn"
    https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/start-mvc?view=aspnetcore-8.0&tabs=visual-studio

    If you like my work, please consider supporting me by checking out my music on YouTube:
    https://youtube.com/shorts/Q921NmrtY9c
    Please leave a good comment and like.
*/

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

using MC01_0001.Models;
using MC01_0001.Data;
using MC01_0001.Areas.Identity.Services;

var SEED_DATA = true;
var ADD_ROLES = true;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MovieCatalogueDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("SqliteMovieCatalog")));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>() // Add roles
    .AddEntityFrameworkStores<MovieCatalogueDbContext>();

builder.Services.AddScoped<UserManager<ApplicationUser>, CustomUserManager>();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AuthenticatedUsers", policy =>
        policy.RequireAuthenticatedUser());

    options.AddPolicy("CanEditMovies", policy =>
        policy.RequireAuthenticatedUser()
               .RequireRole("Admin", "Editor"));

    options.AddPolicy("CanMakeComments", policy =>
        policy.RequireAuthenticatedUser()
               .RequireRole("Admin", "Editor", "User"));
});


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    if (SEED_DATA == true)
    {
        SeedData.Initialize(services);
    }
}

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
    pattern: "{controller=Movies}/{action=Index}/{id?}");
app.MapRazorPages();

if(ADD_ROLES == true) { 
    using (var scope = app.Services.CreateScope())
    {
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

        if (!await roleManager.RoleExistsAsync("Admin"))
        {
            await roleManager.CreateAsync(new IdentityRole("Admin"));
        }

        if (!await roleManager.RoleExistsAsync("Editor"))
        {
            await roleManager.CreateAsync(new IdentityRole("Editor"));
        }

        if (!await roleManager.RoleExistsAsync("User"))
        {
            await roleManager.CreateAsync(new IdentityRole("User"));
        }

        // Assign a user to a role (example)
        var adminUser = await userManager.FindByEmailAsync("superbomb@moviecatalogue.com");
        if (adminUser != null)
        {
            await userManager.AddToRoleAsync(adminUser, "Admin");
        }
        adminUser = await userManager.FindByEmailAsync("quincy@moviecatalogue.com");
        if (adminUser != null)
        {
            await userManager.AddToRoleAsync(adminUser, "Admin");
        }
        adminUser = await userManager.FindByEmailAsync("phil@moviecatalogue.com");
        if (adminUser != null)
        {
            await userManager.AddToRoleAsync(adminUser, "Admin");
        }
        adminUser = await userManager.FindByEmailAsync("george@moviecatalogue.com");
        if (adminUser != null)
        {
            await userManager.AddToRoleAsync(adminUser, "Admin");
        }
    }
}
app.Run();
