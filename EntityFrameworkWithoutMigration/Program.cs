using EntityFrameworkWithoutMigration.Data;
using EntityFrameworkWithoutMigration.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

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
});

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
