using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pindorama.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PindoramaDbContext>(options => options.UseSqlServer("Data Source=DESKTOP-PFHLVPM;Initial Catalog=PindoramaNewDB;Integrated Security=True"));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<PindoramaDbContext>();
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

    //Data Source=SQL5097.site4now.net; Initial Catalog = db_a82f30_pindoramanew; User Id = db_a82f30_pindoramanew_admin; Password = Wm#26637997"

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
