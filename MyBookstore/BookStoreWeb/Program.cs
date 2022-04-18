

using BookStoreWeb.Models.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
string connectionString = "Server=(localdb)\\mssqllocaldb;Database=BookBasketDB;Trusted_Connection=True";
//string connectionString = @"Server=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\test.mdf;Integrated Security=True;Connect Timeout=30"
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ContextBook>(options=>options.UseSqlServer(connectionString));
//builder.Services.AddDbContext<ContextBook>(options=>options.UseMySql("server=localhost;user=root;password=0-=p[]L:\"<>?;database= BookBasket;", new MySqlServerVersion(new Version(8, 0, 28))));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//при запуске если нет бызы выполн€ютс€ все миграции
//using (var serviceScope = app.Services.GetService<IServiceScopeFactory>().CreateScope())
//{
//    var context = serviceScope.ServiceProvider.GetRequiredService<ContextBook>();
//    context.Database.Migrate();
//}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
