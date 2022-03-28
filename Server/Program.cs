using BlazorCRUDApp.Server.AppDbContext;
using BlazorCRUDApp.Server.Models;
using BlazorCRUDApp.Server.Repository;
using BlazorCRUDApp.Server.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
bool FakeDatabase = true;
if (FakeDatabase)
    builder.Services.AddTransient<IRepository<Car>, CarRepositoryFake>();
else
{
    // For entity Framework
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
    {
        var file = "cars";
        options.UseSqlite($"Data Source={file}.db");
    });
    builder.Services.AddTransient<IRepository<Car>, CarRepository>();
}


// For DI registration

builder.Services.AddTransient<ICarService, PersonService>();

// PersonRepository.InitData();

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

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
