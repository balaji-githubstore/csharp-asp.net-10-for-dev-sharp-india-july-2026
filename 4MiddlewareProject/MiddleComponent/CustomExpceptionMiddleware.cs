using System;

namespace MiddlewareProject.MiddleComponent;

public class CustomExceptionMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            // System.Console.WriteLine(this.GetHashCode());
            System.Console.WriteLine("Custom exception registered \n");
            await next(context);
            System.Console.WriteLine("Custom exception Middleware after\n");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}