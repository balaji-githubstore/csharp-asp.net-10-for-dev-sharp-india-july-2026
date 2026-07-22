using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BooksManagement.Dtos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],

        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
    };
});

//3. add AddAuthorization
builder.Services.AddAuthorization();


var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();

// app.UseSession():

// //middleware 1 -- auth
// app.Use(async (context, next) =>
// {
//     //auth check 
//     //run only for delete
//     // "/books"
//     string apiKey = "kite-delete-456";
//     if (!context.Request.Headers.TryGetValue("x-api-key", out var value) || value != apiKey)
//     {
//         context.Response.StatusCode = StatusCodes.Status401Unauthorized;
//         return;
//     }
//     await next();
// });

// app.UseWhen(
//    context => context.Request.Method == "DELETE",
//    appBuilder =>
//    {
//        appBuilder.Use(async (HttpContext context, RequestDelegate next) =>
//        {
//            string apiKey = "kite-delete-456";
//            if (!context.Request.Headers.TryGetValue("x-api-key", out var value) || value != apiKey)
//            {
//                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
//                return;
//            }
//            await next(context);

//        });
//    });


app.MapPost("/auth/token", () =>
{
    var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, "bala"),
            new Claim(ClaimTypes.Email, "admin@book.com"),
            new Claim(ClaimTypes.Role, "Admin")
        };

    var key = new SymmetricSecurityKey(
        Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!));

    var credentials = new SigningCredentials(
        key,
        SecurityAlgorithms.HmacSha256);

    var token = new JwtSecurityToken(
        issuer: builder.Configuration["Jwt:Issuer"],
        audience: builder.Configuration["Jwt:Audience"],
        claims: claims,
        expires: DateTime.Now.AddMinutes(
            Convert.ToInt32(builder.Configuration["Jwt:ExpiryMinutes"])),
        signingCredentials: credentials);

    var jwt = new JwtSecurityTokenHandler().WriteToken(token);

    return Results.Ok(new
    {
        Token = jwt
    });

});

//create List<Book> books--> load 3 items 
List<Book> books = [
    new(1,"b1","Henry",2000),
    new(2,"b2","Jack",1990),
    new(3,"b3","Peter",1970),
    ];
var groupBook = app.MapGroup("/books");

groupBook.MapGet("/", () => books).RequireAuthorization();

// groupBook.MapGet("/", (int id) =>
//     books.FirstOrDefault(x => x.Id == id)
// ).WithName("GetBookById").RequireAuthorization();

// groupBook.MapGet("/", ([FromHeader]string name,[FromBody]string text)=>{}

// groupBook.MapPost("/", (CreateBook newBook) =>
// {
//     if (newBook is null)
//     {
//         return Results.BadRequest();
//     }
//     var book = new Book(
//         Id: books.Count() + 1,
//         Title: newBook.Title,
//         Author: newBook.Author,
//         Year: newBook.Year
//         );

//     books.Add(book);
//     // return Results.Created("",book);
//     return Results.CreatedAtRoute("GetBookById", new { id = book.Id }, book);
// });

// //put 
// // groupBook.MapPut("/{id?}", (UpdateBook updateBook, int id) =>
// // {
// //     // books.FindIndex()
// //     //find index and try update the record of books 
// //     // //books[index]=new Book(id,)
// //     //new Book() --> replace the index with new Book object

// //     var index = books.FindIndex(x => x.Id == id);
// //     if (index == -1)
// //         return Results.NotFound();
// //     books[index] = new Book(Id: id, Title: updateBook.Title, Author: updateBook.Author, Year: updateBook.Year);
// //     return Results.NoContent();
// // });

// //put 
// groupBook.MapPatch("/{id}", (UpdateBook updateBook, int id) =>
// {
//     var index = books.FindIndex(x => x.Id == id);
//     if (index == -1)
//         return Results.NotFound();

//     var oldBookFromList = books[index];

//     oldBookFromList = oldBookFromList with
//     {
//         Title = updateBook.Title ?? oldBookFromList.Title,
//         Year = updateBook.Year ?? oldBookFromList.Year,
//         // Year=updateBook.Year==0?oldBookFromList.Year:updateBook.Year
//     };
//     return Results.NoContent();
// });

// //delete using 
// groupBook.MapDelete("/{id}", (int id) =>
// {
//     int itemDeleted = books.RemoveAll(x => x.Id == id);
//     if (itemDeleted == 0)
//     {
//         return Results.NotFound("Book is not present");
//         //404
//     }
//     else
//     {
//         return Results.NoContent();
//     }
// });

// app.MapGet("/demo", ([AsParameters] BookDetail detail) =>
// {
//     // detail.book.Id
//     Results.Ok(detail.Id);
// });
app.Run();
