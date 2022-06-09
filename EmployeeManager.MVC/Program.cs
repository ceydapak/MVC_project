using EmployeeManager.MVC.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.GetConnectionString("AppDb");
builder.Services.AddDbContext<AppDbContext>(
options => options.UseSqlServer(builder.Configuration.GetConnectionString("AppDb"))
);
builder.Services.AddControllersWithViews();


var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.UseEndpoints(endpoints => {
    endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller=EmployeeManager}/{action=List}/{id?}");
});
//app.MapGet("/", () => "Hello World!");

app.Run();
