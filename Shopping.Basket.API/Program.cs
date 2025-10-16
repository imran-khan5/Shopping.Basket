using Microsoft.AspNetCore.Mvc; // for [FromServices]
using Shopping.Basket.Application.Abstractions;
using Shopping.Basket.Application.Mediator;
using Shopping.Basket.Application.Commands;
using Shopping.Basket.Application.Queries;
using Shopping.Basket.Infrastructure.Repositories;
using Shopping.Basket.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IMediator, SimpleMediator>();
builder.Services.AddSingleton<IBasketRepository, InMemoryBasketRepository>();
builder.Services.AddSingleton<ICatalogReadService, CatalogReadService>();

builder.Services.AddTransient<ICommandHandler<CreateBasket, Guid>, CreateBasketHandler>();
builder.Services.AddTransient<IQueryHandler<GetProducts, IEnumerable<Product>>, GetProductsHandler>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

var v1 = app.MapGroup("/v1");

v1.MapPost("/baskets", async ([FromServices] IMediator mediator, CancellationToken ct) =>
{
    var id = await mediator.Send(new CreateBasket(), ct);
    return Results.Ok(new { id });
}).WithOpenApi();

v1.MapGet("/products", async ([FromServices] IMediator mediator, CancellationToken ct) =>
    {
        var products = await mediator.Send(new GetProducts(), ct);
        return Results.Ok(products);
    }).WithOpenApi();


app.Run();

