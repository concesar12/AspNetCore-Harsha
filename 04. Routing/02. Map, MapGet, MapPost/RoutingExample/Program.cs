var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//enable routing
app.UseRouting();

//creating endpoints
app.UseEndpoints(endpoints =>
{
  endpoints.Map("Map alone", async (context)=> {
    await context.Response.WriteAsync("This is the example of map alone"); //-> this is for any kind of methos post-get   
  });
  //add your endpoints here
  endpoints.MapGet("map1", async (context) => { // Receiving the request delegate which is context
    await context.Response.WriteAsync("In Map 1"); // method map for exclusive Get requests
  });

  endpoints.MapPost("map2", async (context) => {
    await context.Response.WriteAsync("In Map 2"); // Method exclusive for Post requests
  });
});
//This last Run method will execute if the path provided does not exist
app.Run(async context => {
  await context.Response.WriteAsync($"Request received at {context.Request.Path}");
});
app.Run();
