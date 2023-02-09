namespace MiddlewareExample.CustomMiddleware
{
    public class MyCustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next) // Task async to delegate middleware
        {
            await context.Response.WriteAsync("My Custom Middleware - Starts\n");
            await next(context);
            await context.Response.WriteAsync("My Custom Middleware - Ends\n");
        }
    }

    public static class CustomMiddlewareExtension // Extension methos is a method that is going to be inserted into an onject dynamically
    {
        public static IApplicationBuilder UseMyCustomMiddleware(this IApplicationBuilder app) 
// This IApplicationBuilder is a higer class of build which creates the app, the idea is to insert a methos inside this class
        {
            return app.UseMiddleware<MyCustomMiddleware>();
        }
    }

}
