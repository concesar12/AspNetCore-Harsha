var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
// the reason for having two methods doing the same for the endpoint is to get info before and after the useRouting, otherwise the field will be null
app.Use(async (context, next) =>
{
  Microsoft.AspNetCore.Http.Endpoint? endPoint = context.GetEndpoint(); // In this case the object endPoint can receive a value null that is the reason for the ?
  if (endPoint != null)
  {
    await context.Response.WriteAsync($"Endpoint: {endPoint.DisplayName}\n");
  }
  await next(context);
});

//enable routing
app.UseRouting();

app.Use(async (context, next) =>
{
  Microsoft.AspNetCore.Http.Endpoint? endPoint = context.GetEndpoint();
  if (endPoint != null)
  {
    await context.Response.WriteAsync($"Endpoint: {endPoint.DisplayName}\n");
  }
  
  await next(context);
});

//creating endpoints
app.UseEndpoints(endpoints =>
{
  //add your endpoints here
  endpoints.MapGet("map1", async (context) => {
    await context.Response.WriteAsync("In Map 1");
  });

  endpoints.MapPost("map2", async (context) => {
    await context.Response.WriteAsync("In Map 2");
  });
});

app.Run(async context => {
  await context.Response.WriteAsync($"Request received at {context.Request.Path}");
});
app.Run();
