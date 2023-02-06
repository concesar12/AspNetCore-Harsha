var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
    string path = context.Request.Path; //this line will give the request URL that is present in the start line
    string method = context.Request.Method; // this will give me the methos (post/get)
  
    context.Response.Headers["Content-type"] = "text/html";
    await context.Response.WriteAsync($"<p>{path}</p>");
    await context.Response.WriteAsync($"<p>{method}</p>");
});

app.Run();
