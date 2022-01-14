using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BismillahGraphicsPro.Data;
using BismillahGraphicsPro.BusinessLogic;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddIdentity<IdentityUser, IdentityRole>(config =>
    {
        config.Password = new PasswordOptions
        {
            RequireDigit = false,
            RequiredLength = 6,
            RequiredUniqueChars = 0,
            RequireLowercase = false,
            RequireNonAlphanumeric = false,
            RequireUppercase = false
        };
    })
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddDependencyInjection();

builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
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
