using EntityFrameworkWithoutMigration.Data;
using EntityFrameworkWithoutMigration.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//openapi
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.OpenApiInfo
    {
        Title = "Entity Framework API",
        Version = "v1",
        Description = "Sample Minimal API"
    });
});

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

//map the url for json
app.MapOpenApi();

// Swagger JSON
app.UseSwagger();

// Swagger UI
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Entity API v1");
});


app.MapGet("/db", async (AppDbContext appDbContext) =>
{
    if (appDbContext.Books == null)
    {
        return Results.NotFound();
    }
    // appDbContext.Add(book);
    // appDbContext.SaveChanges();
    return Results.Ok(await appDbContext.Books.ToListAsync());
});

app.MapGet("/db/{id}", async (AppDbContext appDbContext, int id) =>
{
    return appDbContext.Books.FirstOrDefault(x => x.Id == id);
});

app.MapPost("/db", async (AppDbContext appDbContext, [FromBody] Book book) =>
{
    if (book == null)
    {
        return Results.BadRequest();
    }
    appDbContext.Add(book);
    appDbContext.SaveChanges();
    return Results.Created();
}).WithName("AddBookToDB")
.WithSummary("Add new book")
.WithDescription("Returns whether book is created or not.")
.WithTags("Books")

// Success response
.Produces<Book[]>(StatusCodes.Status201Created, "application/json")

// Error responses
.ProducesProblem(StatusCodes.Status400BadRequest)
.ProducesProblem(StatusCodes.Status401Unauthorized)
.ProducesProblem(StatusCodes.Status403Forbidden)
.ProducesProblem(StatusCodes.Status404NotFound)
.ProducesProblem(StatusCodes.Status500InternalServerError)

// Optional - exclude from OpenAPI
// .ExcludeFromDescription()

// Optional - add custom metadata
.WithMetadata(new EndpointNameMetadata("WeatherForecastEndpoint"));;

//additional 
app.MapGet("/book1", async (AppDbContext dbContext) =>
{
    System.Console.WriteLine(dbContext.Books
      .Where(x => x.Price > 500)
      .OrderBy(x => x.Title)
      .ToQueryString());

    System.Console.WriteLine(await dbContext.Books
    .Where(x => x.Price > 500)
    .OrderBy(x => x.Title)
    .FirstOrDefaultAsync());

    return Results.Ok();
});


app.Run();
