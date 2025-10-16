using Catalog.Application.Contracts;
using Catalog.Application.Features.Product.Quaries.GetAllProducts;
using Catalog.Application.Services;
using Catalog.Infrastructure.Data;
using Catalog.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, EFProductRepository>();
builder.Services.AddScoped<GetAllProductsRequestHandler>(); 

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetAllProductRequest).Assembly));

var conectionString = builder.Configuration.GetConnectionString("db");
builder.Services.AddDbContext<EGMCatalogDbContext>(option => option.UseSqlServer(conectionString));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
