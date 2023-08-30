using ElgrosWeb.Server.Data.Db;
using ElgrosWeb.Server.Facades;
using ElgrosWeb.Server.Facades.Interfaces;
using ElgrosWeb.Server.Repositories;
using ElgrosWeb.Server.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ElgrosContext>(options => options.UseSqlServer(@"Server=(LocalDb)\MSSQLLocalDB;Database=ElgrosDb;Trusted_Connection=True"));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductFacade, ProductFacade>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderFacade, OrderFacade>();
builder.Services.AddScoped<IPaymentFacade, PaymentFacade>();
builder.Services.AddScoped<INotificationFacade, NotificationFacade>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
using (var serviceScope = app.Services.CreateScope())
{
    var ctx = serviceScope.ServiceProvider.GetService<ElgrosContext>();
    DbInitializer.Initialize(ctx);
}
app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
