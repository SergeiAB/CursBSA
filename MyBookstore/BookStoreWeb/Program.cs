

using BookStoreWeb.DataContext;
using BookStoreWeb.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
string connectionString = "Server=(localdb)\\mssqllocaldb;Database=BookBasketDB;Trusted_Connection=True";

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ContextBook>(options=>options.UseSqlServer(connectionString));
builder.Services.AddTransient<IBookService,BookService>();
builder.Services.AddTransient<AccountServiice>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>//CookieAuthenticationOptions
                {
                    options.LoginPath = new PathString("/Account/Login");
                    options.AccessDeniedPath = new PathString("/Account/login");
                }
                );


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//при запуске если нет бызы выполн€ютс€ все миграции
using (var serviceScope = app.Services.GetService<IServiceScopeFactory>().CreateScope())
{
    var context = serviceScope.ServiceProvider.GetRequiredService<ContextBook>();
    context.Database.Migrate();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
