using Kookis.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICategoryRepsitory, CategoryRepository>();
builder.Services.AddScoped<IPieRepository, PieRepository>();

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<KookisDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration["ConnectionString:KookisDbContextConnection"]);
});

var app = builder.Build();

app.UseRouting();
app.UseStaticFiles();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapDefaultControllerRoute();

app.Run();
