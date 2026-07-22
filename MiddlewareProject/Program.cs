using System.Reflection.Metadata.Ecma335;
using BusinessService.Services;
using MiddlewareProject.MiddleComponent;

var builder = WebApplication.CreateBuilder(args);

//Dependency injection - gets registered only once 
builder.Services.AddTransient<CustomExceptionMiddleware>();
builder.Services.AddTransient<CustomMiddleware>();

var app = builder.Build();

app.UseMiddleware<CustomExceptionMiddleware>();

//middleware 1 -- logging
app.Use(async (context, next) =>
{
    context.Response.StatusCode=StatusCodes.Status204NoContent;
    System.Console.WriteLine("Middleware 1 before\n");
    await next();
    System.Console.WriteLine("Middleware 1 after\n");
});

//call the custommiddleware
app.UseMiddleware<CustomMiddleware>();

//middleware 2 -- auth
app.Use(async (context, next) =>
{
    // await context.Response.WriteAsync("hello from middleware 2");
    System.Console.WriteLine("Middleware 2 before\n");
    await next();
    System.Console.WriteLine("Middleware 2 after\n");
});

// app.Map("/statements", async branch =>
// {
//     branch.Use(async (context, next) =>
//    {
//        System.Console.WriteLine("Middleware map for statements before\n");
//        await next();
//        System.Console.WriteLine("Middleware map for statements after\n");
//    });

//     //endpoints 
//     branch.Run(async (HttpContext context) =>
//     {
//         context.Response.StatusCode = StatusCodes.Status503ServiceUnavailable;
//         await context.Response.WriteAsync("Service unavailable");

//     });
// });

bool isDBAvailable = false;

// app.MapWhen(context => !isDBAvailable & context.Request.Method == "POST", async branch =>
// {
//     branch.Use(async (context, next) =>
//    {
//        System.Console.WriteLine("Middleware map when db not available before\n");
//        await next();
//        System.Console.WriteLine("Middleware map when db not avilable after\n");
//    });

//     //endpoints 
//     branch.Run(async (HttpContext context) =>
//     {
//         context.Response.StatusCode = StatusCodes.Status503ServiceUnavailable;
//         await context.Response.WriteAsync("Service unavailable");

//     });
// });


// app.UseWhen(
//    context => context.Request.Method == "POST",
//    appBuilder =>
//    {
//        appBuilder.Use(async (context, next) =>
//        {
//            System.Console.WriteLine("Middleware run when post before\n");
//            await next();
//            System.Console.WriteLine("Middleware run post after\n");
//        });
//    });

//middleware 3 -- auth
app.Use(async (context, next) =>
{
    System.Console.WriteLine("Middleware 3 before\n");
    await next();
    System.Console.WriteLine("Middleware 3 after\n");
});

// app.MapGet("/accounts", (string name) =>
// {
//     return Results.Ok($"Account name is {name}");
// });

// app.MapPost("/accounts", (HttpContext context) =>
// {
//     var body = new StreamReader(context.Request.Body);
//     var bodyStr = body.ReadToEndAsync();
//     return Results.Created("", body);

// });

// app.MapGet("/statements", (string name) =>
// {
//     return Results.Ok($"Account name is {name}");
// });

app.Run();



BookService.GetBooks();