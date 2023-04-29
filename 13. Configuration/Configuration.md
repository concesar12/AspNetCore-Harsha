//-----------------------------------Configuration basics
Configuration (or configuration settings) are the constant key/value pairs that are set a common location and can be read from anywhere in the same application.
Examples: connection strings, Client ID & API keys to make REST-API calls Domain names, Constant email addresses etc.

1. we added a nue key value in appsettings.json to demonstrate that is possible to cofigurate things
2. created the new project with all info
3. we added this to program.cs :
   app.UseEndpoints(endpoints => //The rihght way to read this is by, whenever going to this endpoint perform whatever is inside of the lamda function
   {
   endpoints.Map("/", async context =>
   {
   await context.Response.WriteAsync(app.Configuration["MyKey"]);
   });
4. this lecture we saw appsettings.json
   //----------------------------------IConfiguration in Controller
   Thi is useful when wanting to read the configuration from the controller
   using MVC
   using Extensions.Configuration;

public class ControllerName : Controller
{
private readonly IConfiguration \_configuration;

public ControllerName(IConfiguration configuration)
{
\_configuration = configuration;
}
}

1. We are changing the path of the endpoint to "/config"
2. Create the view
3. in the controller the Dependency injection was performed to het the value of configuration

//---------------------------------Hierarchical Configuration
the idea of this is wrap a key valuo within another key value pairs:
{
"MasterKey":
{
"key1": "value"
"key2": "value2"
}
}
To read the info: Configuration["MasterKey:key1"]

1. we get the appsettings.jsonchanged
   //-------------------------------Options Pattern
   Options pattern is about specifying the pproperties to be read from the configuration, this is done by creating a new class and assigning the attributes to it. that is options pattern --> Options patteern uses custom classes to specify what configuration settings are to be loaded into properties. EX Reading athe specific connections string out of many configureation settings.
   **The option class should be a non-abstract class with a public parameterless constructor.
   **Public read-write properties are bound.
   \*\*Fields are not bound
1. We created a new class in the project
1. we added the two attributes that need to be retrieved from
1. In the homecontroller we added the method get that will allow us to have the info from the controller
1. This method is get<type> which will allow us to retrieve the info of properties as lons as the names match
1. then an object of that class was created to receive those options.
1. there is another way to retrieve those values too: Bind
1. The prefered and easiest way is using get

//--------------------------------Configuration as Service
The idea of this lecture is to pass into the construcctor the options, then they not neet to be called in the controller page, this will make the code more simple. We will create the configuration as a service.

1. we added the build service to be able to implement DI in the constructor
   Then in the Home controlller we got WeatherApi Options which will allow us to generate a DI
2. Then we changed the name of configuration por options instead
3. The Pro's of this approach is that we do not need a lot of code in the controller, and the DI is used.
   //--------------------------------Environment specific Configuration
   In this lecture we will understand the differences between appsettings.json and appsettings.Development.json
   We were looking at the precedence of the files.
1. We changed what was in appsettings.Development to show which one has precedence.
2. The main use of this is to be able to set up different connections strings depending on the environment(test, development, etc.)
   //--------------------------------Secrets Manager
   This is when thinking about the security of the configuration files, so if passwords or API keys or user secrets are presents it should not be included in the Git file.
   So this stores the user secrets (sensitive configuration data) in a separate location on the developer machine.
1. It is necessary to enable the secret manager with a dotnet command:
   dotnet user-secrets init
   dotnet user-secrets set "Key" "Value"
   dotnet user-secrets init list
Steps 
1. First go to View and click on terminal
2. this will bring the terminal (which is powershell developer).
3. then run the first dotnet command(This will generate an Hexadevcimal code in json format)
4. then we set the environment by doing, dotnet user-secrets set "weatherapi:ClientID" "ClientID from user secrets"
5. to see the user secret then right click on project and then go to manage user-secrets
6. so this will override the other configurations since it was called last.

//-----------------------------------Environment Variables Configuration
In production vaiables will be accessible only from the terminal
In powershell I can use: 
$Env:ParentKey__ChildKey="value" -> this is accesible from the application that is running from the same terminal
dotnet run --no-launch-profile
**It is one of the most secured way of setting-up sensitive values in configuration.
**__(underscore and underscore) is the separator between parent key and child key.
1. An environment variable was set up by : $Env:weatherapi__ClientID="ClientID from environment variables"
2. This is only accesible from this terminal and is called process call environments
3. then set the other value $Env:weatherapi__ClientSecret="ClientSecret from environment variables"
4. Then we will run the application with :  dotnet run --no-launch-profile
5. From production server perspective, this is the best way to store sensitive information/ configuration 
//-----------------------------------Custom Json configuration
in this context we are meant to just put the non sensible data into the configuration as part of the code, we can configure different json files for the options and configurations.
in order to add this new configuration this has to be created in program.cs
builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{
    config.AddJsonFile("MyOwnConfig.json", optional:true, reloadOnChange: true); 
});
Better to have separation of json files