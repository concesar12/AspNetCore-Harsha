Routing is a process of making incoming HTTP requests by checking the http method and URL,
and then invoking corresponding endpoints(middlewares)

app.UseRouting(); // This enables the use of routing in the methods

app.UseEndpoints(endpoints => -> this is a callback to put the enpoits with the methos map
{
    //add the endpoints in here
}); // 


 endpoints.Map("/map1", async (context) =>  // This is is the way of creating endpoints for routings
    { // there are more methods available like .MapGet or MapPost
        await context.Response.WriteAsync("In Map 1");
    });

in order to access values in the routing path use context.Request.RouteValues["filename"]

since c#9 it is posible to use ? after a type to make nullable

//------------Default parameters

This one relates to when you don't want to have parameters in the http request at least no fixed parameters

so by adding a value after an equals, it is possible to set a default value 
 endpoints.Map("employee/profile/{personName=Cesar}", async context =>

//---------------Optional parameters

In case to receive in the http header something like null it is useful to have an optional parameter
this is done by marking that parameter with question mark {parameter?}

// --------------Route constraints 1
This is used to ask retrictions in the parameters 
endpoints.Map("products/type/{id:int?}", async context -> by using colon and especifiyng the type that should receive I can declare the constraint
// --------------Route constraints 2
There is another type for constraint like DateTime
guid -> this type is used for unique identifiers
It is possible to generate GUID going to tool and create a new GUID
// --------------Route constraints 3
There are constraints for minlenght or maxlenght  or regex
length(2,8)
endpoints.Map("sales-report/{year:int:min(1900)}/{month:regex(^(apr|jul|oct|jan)$)}", async context => -> way to use it with regex
//--------------Custom Route constrain class
It is possible to create a class to centralize the consraints in one, this will prevent to havint to write the same constrain in multiple places, this is the signature to create the class

 public class MonthsCustomConstraint : IRouteConstraint
    { 
public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
{
    throw new NotImplementedException();
}
This is necesary to import the contraint
builder.Services.AddRouting(options =>
{
    options.ConstraintMap.Add("months", typeof(MonthsCustomConstraint));
});

//---------------Endpoint Selection Order
If more than one URL matches the endpoint, which one should be picked up to be redirected to
this is the precedence for wich endpoint will be selected first
1. URL with more segments EX. "a/b/c/d" higher than "a/b/c"
2.URL with literal text has more precedence than parameter EX "a/b" more than "a/{parameter}"
3. URL with constraints will be evaluated first EX: "a/{b}:int" higher than "a/b"
4.  Catch all parameters EX "a/b" higher than "a/**"
//------------------WebRoot and UseStaticFiles
in order to use files in the web root for the application it is necessary to enable the propperty UseStaticFiles()
** It is important if I want to change wwroot name to another thing then I have to WebApplicationOptions() add in the builder args

but still it is necessary to leave wwroot folder as it is to prevent an exception error
this is the template to use this:
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(
        //builder.Environment.ContentRootPath + "\\mywebroot" this is one way to concatenate, but above is the prefered way
        Path.Combine(builder.Environment.ContentRootPath, "mywebroot")
        )
});

