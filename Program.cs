using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SistemaDeVendasWeb.Data;
using SistemaDeVendasWeb.Services;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<SistemaDeVendasWebContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("SistemaDeVendasWebContext") ?? throw new InvalidOperationException("Connection string 'SistemaDeVendasWebContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<SeedingService>();
builder.Services.AddScoped<SellerService>();
builder.Services.AddScoped<DepartmentService>();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Crie um escopo para rodar o Seed
using (var scope = app.Services.CreateScope())
{
    var seedingService = scope.ServiceProvider.GetRequiredService<SeedingService>();
    seedingService.Seed();
    
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
