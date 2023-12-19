using latihanDotnet8.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var service = builder.Services;
service.AddControllersWithViews();

// Mysql Configuration
string koneksiDb = "Server=103.186.31.38;Port=53306;Database=jualanonline;user=jualanonline;password=TiRtx2eMFpYM2PiS";
service.AddDbContext<dbAplicationContext>(opt => opt.UseMySql(koneksiDb, ServerVersion.AutoDetect(koneksiDb),
    options => options.EnableRetryOnFailure(
        maxRetryCount: 3,
        maxRetryDelay: System.TimeSpan.FromSeconds(30),
        errorNumbersToAdd: null
        )
    ));


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
