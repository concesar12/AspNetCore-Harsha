var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//middlware 1
app.Use(async (HttpContext context, RequestDelegate next) =>
{ // Request delegate represents the sequent middleware
  await context.Response.WriteAsync("Hello");
  await next(context);
});

//middleware 2
app.Use(async (context, next) =>
{
  await context.Response.WriteAsync("Hello again");
  await next(context); // Neext in this case is optional I can choose not to calle it
});

//middleware 3
app.Run(async (HttpContext context) =>
{
  await context.Response.WriteAsync("Hello again");
});


app.Run();
