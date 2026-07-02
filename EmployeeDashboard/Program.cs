var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//context --> it's an object of HTTPContext class (it contains all details related to request and with that you can build response)
app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("Planning to design employee dashboard\n");
    await context.Response.WriteAsync($"{context.Request.Method}\n");
    await context.Response.WriteAsync($"{context.Request.Path}\n");
    await context.Response.WriteAsync($"{context.Request.Host}\n");
    await context.Response.WriteAsync($"{context.Request.Headers}\n");
    await context.Response.WriteAsync($"");
    //context.Request.Method --> get {} - retreive the data
    //post --> post{} - create a record 
    //put --> put{} - update the existing record
    //delete --> route parameter --> employee
});

//minimal api work

app.Run();
