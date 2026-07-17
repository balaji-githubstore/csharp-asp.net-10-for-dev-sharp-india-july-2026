using BooksManagement.Dtos;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
var groupBook = app.MapGroup("/books");

//middleware 1 -- auth
app.Use(async (context, next) =>
{
    //auth check 
    //run only for delete
    // "/books"
    string apiKey = "kite-delete-456";
    if (!context.Request.Headers.TryGetValue("x-api-key", out var value) || value != apiKey)
    {
        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
        return;
    }
    await next();
});

app.UseWhen(
   context => context.Request.Method == "DELETE",
   appBuilder =>
   {
       appBuilder.Use(async (HttpContext context, RequestDelegate next) =>
       {
           string apiKey = "kite-delete-456";
           if (!context.Request.Headers.TryGetValue("x-api-key", out var value) || value != apiKey)
           {
               context.Response.StatusCode = StatusCodes.Status401Unauthorized;
               return;
           }
           await next(context);

       });
   });

//create List<Book> books--> load 3 items 
List<Book> books = [
    new(1,"b1","Henry",2000),
    new(2,"b2","Jack",1990),
    new(3,"b3","Peter",1970),
    ];

groupBook.MapGet("/", () => books);

groupBook.MapGet("/", (int id) =>
    books.FirstOrDefault(x => x.Id == id)
).WithName("GetBookById");

// groupBook.MapGet("/", ([FromHeader]string name,[FromBody]string text)=>{}

groupBook.MapPost("/", (CreateBook newBook) =>
{
    if (newBook is null)
    {
        return Results.BadRequest();
    }
    var book = new Book(
        Id: books.Count() + 1,
        Title: newBook.Title,
        Author: newBook.Author,
        Year: newBook.Year
        );

    books.Add(book);
    // return Results.Created("",book);
    return Results.CreatedAtRoute("GetBookById", new { id = book.Id }, book);
});

//put 
groupBook.MapPut("/{id?}", (UpdateBook updateBook, int id) =>
{
    // books.FindIndex()
    //find index and try update the record of books 
    // //books[index]=new Book(id,)
    //new Book() --> replace the index with new Book object

    var index = books.FindIndex(x => x.Id == id);
    if (index == -1)
        return Results.NotFound();
    books[index] = new Book(Id: id, Title: updateBook.Title, Author: updateBook.Author, Year: updateBook.Year);
    return Results.NoContent();
});

//put 
groupBook.MapPatch("/{id}", (UpdateBook updateBook, int id) =>
{
    var index = books.FindIndex(x => x.Id == id);
    if (index == -1)
        return Results.NotFound();

    var oldBookFromList = books[index];

    oldBookFromList = oldBookFromList with
    {
        Title = updateBook.Title ?? oldBookFromList.Title,
        Year = updateBook.Year ?? oldBookFromList.Year,
        // Year=updateBook.Year==0?oldBookFromList.Year:updateBook.Year
    };
    return Results.NoContent();
});

//delete using 
groupBook.MapDelete("/{id}", (int id) =>
{
    int itemDeleted = books.RemoveAll(x => x.Id == id);
    if (itemDeleted == 0)
    {
        return Results.NotFound("Book is not present");
        //404
    }
    else
    {
        return Results.NoContent();
    }
});

app.MapGet("/demo", ([AsParameters] BookDetail detail) =>
{
    // detail.book.Id
    Results.Ok(detail.Id);
});
app.Run();
