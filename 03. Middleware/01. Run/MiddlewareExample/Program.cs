var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{ // Run is one of the moethods used to create middlewares
  await context.Response.WriteAsync("Hello");
});

app.Run(async (HttpContext context) =>
{
  await context.Response.WriteAsync("Hello again");
});

app.Run();
