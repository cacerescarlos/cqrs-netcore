using Microsoft.EntityFrameworkCore;
using TiendaCQRS.Data;
using TiendaCQRS.Hadlers;
using TiendaCQRS.Handlers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<TiendaContext>(options =>
    options.UseInMemoryDatabase("TiendaDB"));

// Registro de Handlers como servicios
builder.Services.AddTransient<CrearProductoCommandHandler>();
builder.Services.AddTransient<ObtenerProductosQueryHandler>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
