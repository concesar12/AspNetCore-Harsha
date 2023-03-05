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
There are constraints for minlenght or maxlenght 
length(2,8)
endpoints.Map("sales-report/{year:int:min(1900)}/{month:regex(^(apr|jul|oct|jan)$)}", async context => -> way to use it with regex


