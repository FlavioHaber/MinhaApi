using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using MinhaApi.Models;


var builder = WebApplication.CreateBuilder(args);


// Usar InMemory em Development
builder.Services.AddDbContext<AppDbContext>(opt => 
  opt.UseInMemoryDatabase("TestDb"));

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Seed de dados InMemory
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Produtos.AddRange(
    new Produto { Nome = "Teste A", Preco = 1m, Quantidade = 1 },
    new Produto { Nome = "Teste B", Preco = 2m, Quantidade = 2 }
    );
    db.SaveChanges();
}


app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.MapGet("/", () => "API InMemory OK");


app.Run();
