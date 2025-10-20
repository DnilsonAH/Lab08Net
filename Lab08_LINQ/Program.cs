using Lab08_LINQ.Core.Mapper;
using Lab08_LINQ.Core.Repositories;
using Lab08_LINQ.Core.Repositories.Interfaces;
using Lab08_LINQ.Core.Services;
using Lab08_LINQ.Core.Services.Interfaces;
using Lab08_LINQ.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Obtener la cadena de conexión desde appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//agregar servicio de AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapping).Assembly);

builder.Services.AddDbContext<TiendadbDbContext>(options =>
{
    // Usamos el método UseMySql y configuramos la versión del servidor (ajusta la versión si es necesario)
    options.UseMySql(
        connectionString,
        ServerVersion.AutoDetect(connectionString),//Detecta automáticamente la versión del servidor MySQL
        mySqlOptions => mySqlOptions.EnableRetryOnFailure()
    );
});

//Agregar servicios de la capa Core
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<IProductosService, ProductosService>();
builder.Services.AddScoped<IPagosService, PagosService>();
builder.Services.AddScoped<IOrdenesService, OrdenesService>();
builder.Services.AddScoped<IDetallesOrdenService, DetallesOrdenService>();

//Agregar repositorios de la capa Core
builder.Services.AddScoped<IClientesRepository, ClientesRepository>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<IProductosRepository, ProductosRepository>();
builder.Services.AddScoped<IPagosRepository, PagosRepository>();
builder.Services.AddScoped<IOrdenesRepository, OrdenesRepository>();
builder.Services.AddScoped<IDetallesOrdenRepository, DetallesOrdenRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();


app.Run();
