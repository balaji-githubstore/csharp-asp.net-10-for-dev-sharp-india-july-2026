using System;

namespace MiddlewareProject.MiddleComponent;

public class CustomMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        System.Console.WriteLine("Custom Middleware before\n");
        await next(context);
        System.Console.WriteLine("Custom Middleware after\n");
    }
}
