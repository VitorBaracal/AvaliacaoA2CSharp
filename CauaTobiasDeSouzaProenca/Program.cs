
using CauaTobiasDeSouzaProenca.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDataContext>();
var app = builder.Build();

app.MapGet("/", () => "Aplicação em Andamento");

app.Run();
