using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Session;
using PraktickaMaturita.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ArchivPoznamekData>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("ArchivPoznamekSil")));
builder.Services.AddSession(options => {
    options.Cookie.Name = ".PoznamkovyArchiv";
    options.Cookie.IsEssential = true;
    options.IdleTimeout = TimeSpan.FromMinutes(30);
});

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
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
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Poznamky}/{action=Vypsat}/{id?}");

app.Run();
