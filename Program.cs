using jj_eskolina_silver_enigma.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();

builder.Services.AddDbContext<BusverhuurContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("BusverhuurConnection")));

var app = builder.Build();
app.UseStaticFiles();
app.MapRazorPages();

app.Run();
