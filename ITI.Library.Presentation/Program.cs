
using Microsoft.EntityFrameworkCore;
using ITI.Library.Models;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Identity;

public class Program
{
    static int Main()
    {
        var builder  = WebApplication.CreateBuilder();
        builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
        builder.Services.AddControllersWithViews();
        builder.Services.AddDbContext
             <LibraryContext>(options =>
             {
                 options.UseLazyLoadingProxies()
                 .UseSqlServer(builder.Configuration.GetConnectionString("MiniaQ1"));
             });
        builder.Services.AddIdentity<User, IdentityRole>
            ().AddEntityFrameworkStores<LibraryContext>();

        builder.Services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequireDigit = false; 
            options.Password.RequireLowercase = false; 
            options.Password.RequireUppercase = false; 
            options.Password.RequireNonAlphanumeric = false;
            options.Lockout.MaxFailedAccessAttempts = 1;
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
        });
        builder.Services.ConfigureApplicationCookie(options =>
        {
            options.LoginPath = "/User/SignIn";
            options.AccessDeniedPath = "/User/AccessDenied";
        });
        var app  = builder.Build();
        app.UseStaticFiles(new StaticFileOptions()
        {
            RequestPath="/Content", 
            FileProvider = new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(),"Content")
                )
        });

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllerRoute("route", "{controller=Home}/{action=Index}/{id?}");
        app.Run();
        return 0;
    }
}