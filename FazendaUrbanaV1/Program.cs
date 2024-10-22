using FazendaUrbanaV1.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adiciona a connection string a partir do appsettings.json
#pragma warning disable CS8600 // Convers�o de literal nula ou poss�vel valor nulo em tipo n�o anul�vel.
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
#pragma warning restore CS8600 // Convers�o de literal nula ou poss�vel valor nulo em tipo n�o anul�vel.

// Registra o ApplicationDbContext no cont�iner de servi�os
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));



// Add services to the container.
builder.Services.AddControllers()
     .AddJsonOptions(options =>
     {
         options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
     });

builder.Services.AddRazorPages();

// Swagger (para documenta��o da API)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();



// Configure o pipeline de requisi��es HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();
app.MapRazorPages();

app.Run();
