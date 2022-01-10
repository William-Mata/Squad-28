using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Tribo.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TriboDbContext>(options => options.UseSqlServer("Data Source=DESKTOP-PFHLVPM;Initial Catalog=Tribo-DB;Integrated Security=True"));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<TriboDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
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
    pattern: "{controller=Pages}/{action=Home}/{id?}");
app.MapRazorPages();

app.Run();
