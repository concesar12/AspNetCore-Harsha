//-----------------------------Introduction to environments
An environment represents is a system in which the applicatoin is deployed and executed.
-> Development: The environment, where the developer makes changes in the code, commits code to the source control.
-> Staging The environment, where the application runs on a server, from which other developrs and quality controllers access the application.
-> Production: The environment, where the real end-users access the application shortly, it's where the application "live" to the audience.
development for coding, Stging to have it ready in the servers for testers and other developers to see and production for the public.
 //----------------------------Environment in lunchSettings.json
how to configure the environment in launch .json file, when creating a asp.net core app the launchSettings.json is always created.
1. We checked and changed the environment from development to staging in the folder properties/launchSettings.json
2. generate all things for normal projects
3. Have generated in program.cs the app.IsDevelopment and generate a intentional exception to try out
4. We do have three different methods app.Environment.IsStaging(), app.Environment.IsDevelopment() and app.Environment.IsProduction()
5. What is returned after calling these methods are EnvironmentName: Gets or sets name of the environment. By default it reads the value from either DOTNET_ENVIRONMENT or ASPNETCORE_ENVIRONMENT
6. ContentRootPath : Gets or sets absolute path of the application folder.
There is another method for user defined environments : IsEnvironment(string environmentName)
//-----------------------------Environment in Controller
Thi lesson is useful when I have to access the environment in the controller or any other service. This is possible by injecting a predefined service called IWebHostEnvironment: defined like this: 
using MVC;
using Hosting;

public class ControllerName : Controller
{
  private readonly IWebHostEnvironment _webHost;
 
 public ControllerName(IWebHostingEnvironment webHost)
{
  _webHost = webHost;
}
}
1. in the controller homecontroller we will build the IwebHostEnvironment thing
2. created a constructor to inject the service
3. We used the service injected.
//--------------------------------Environment Tag Helper
ASP. net views can show specific content in different environments: 
In View -> <environment include= "Environment1, Environment2"> html code</environment>
It renders the content only when the current environment name matches with either of the specified environment names in the "include" property
1. we creted the viewimports and added the addtaghelper 
2. we created a button and added the environment
3. I can use exclude instead of include
//-------------------------------Process-Level Environments
LunchSettingsfile IT IS ONLY FOR DEVELOPMENT PORPUSES
What was learnt in this part was how to set the environment in other type rather than development
1. We are using powersheell to use dotnet run
in order to avoid lunchjson -> dotnet run --no-launch-profile
then to set an environment in powershell: $Env:ASPNETCORE_ENVIRONMENT="Staging" -> This is only valid for the current terminal
