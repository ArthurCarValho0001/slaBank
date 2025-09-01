using Microsoft.EntityFrameworkCore;
using mvc.Models; 

var builder = WebApplication.CreateBuilder(args);

// 1. Recupera a string de conexão do arquivo appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// 2. Configura o DbContext para ser usado com MySQL e injetado nos controllers
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// 3. Adiciona suporte a controllers e views do MVC (LINHA JÁ EXISTENTE NO SEU PROJETO)
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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