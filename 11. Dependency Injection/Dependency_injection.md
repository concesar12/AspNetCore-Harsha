//----------------------------------Services 1
Buisiness logic should be in the service not in the controller or in the view, controller will invoke the service
'Service' is a class that contains business logic such as business calculations and validations that are specific to the domain of the client's business.
-Service is an abstraction layer (middle layer) between presentation (or application layer) and data layer.
1. Created a new project
2. inside of this project we added another project to add the services in order to have them decoupled from the project
3. fill up the services with data to be passed.
//-------------------------------------Services 2
4. Add controller, add views, add layout 
5. add vie imports and view start,
6. We used the readonly to avoid unwanted values to be assigned to that variable.
7. we added the reference of the cities service
8. getters for the citiesservice was created too.
9. added strongly typed model, @model IEnumerable<string> -> parent of list class
10. It is so bad practice create an object of a service in this case in the home controller
//--------------------------------------Dependency Inversion Principle
_citiesService = new CitiesService(); // The reason for is bad having this statement: it will make the service dependant from the controller, in case of chanching the class name for another one then I might need to refactor// With dependency inversion this problem can be solved.
Controller depends on the service.
Higher-level modeules depend on lower modeules. Means, they are tightly coupled.
Dependency inversion principle is a design principle(guideline), which is a solution for the dependency problem. -- The higer-level modules should not depend on low-level modeules(Dependecies).
Both should depend on abstractions(interfaces or abstract classes).
*Abstractions should not depend on details.
*Details should depend on abstractions.
The developer of the controller should create the service contract class(dependency inversion)
1. We created a new project calles serviceContracts
2. We made an interface ICitiesServices -> I comes from interface.
//--------------------------------------Inversion of control
The question raised was, who will create the object that got the service.
Inversion of control is a design pattern (reusable solution for a common problem), which suggests "IoC container" for implementation of dependency inversion principle.
** All the dependecies should be added into the IServiceCollection (acts as IoC container)
builder.Services.Add(new ServiceDescriptor(typerof(interface), typeof(service) ServiceLifetime.LifeTime));
1. Went to program.cs and created -> using ServiceContracts and using Services.
2. created the service descriptor class
//--------------------------------------Dependency Injection
The question is how are we going to pass the ServiceDescriptor to the HomeController
DI: is a design pattern, which is a technique for achieving "Inversion of control(IoC)" between clients and their dependencies.
-It allows to inject (supply) a concrete impolementation object of a low-level component into a high-level component. // It is a technique to receive an object of the citiesService to the home controller in this example.
-The client class receives the dependency object as a parameter either in the contructor or in a method.
1. We passed the object ICitiesServices citiesService to the contructor
2. whole process=> Create a service that implements an interface add the service to the IoC container, this will contain and return an object of the service class and supplies the same to the controller:
Controller(client)
public class MyController : Controller
{
  private readonly IService _service;
  public MyController(IService service)
  {
    _service=service;
  }

public IActionResult ActionMethod()
{
  _service.ServiceMethod();
}
}
With this I am implementing three things :
1) dependency inversion principle
2) Inversion of control
3) Dependency injection
//-----------------------------------Method injection - FromService
If I don't want to have the service from the DI in the arguments of the contructor, then I I can added to a method instead by using: 
[FromServices] ICitiesServices _citiesServices
//-----------------------------------Transient, Scoped and Singleton 1
A service lifetime indicates when a new object of the service has to be created by the IoC / DI container.
Transient -> Per injection // so a new class of the service will be created everytime there is an injection
Scoped -> Per scope (Browser request) this is by response to the browser
Singleton -> For entire application lifetime // no new objects of the singleton will be created until the application shutdown
**Service Lifetimes in DI
Transient -> Transient lifetime service objects are created each time wehen they are injected. // Service instances are disposed at the end of the scope (usually, a browser request).
Scoped -> they are created once per a scope // Service instances are disposed at the end of the scoope 
Singleton -> get destroyed when application finishes.
//-----------------------------------Transient, Scoped and Singleton 2
The idea of this lesson is to demostratge the times and the scope of each. 
1. We created a Guid that will increase by 1 everytime a new object of the cities is created
2. We added the implementation in CitiesService.
3. now we are going to inject the service more than once.
***When to use which of this: 
1. When you want to store data for all the users, like cache, then singleton are the best.
2. Entity framework db contexts are better as scoped services, because when a new browser request is received by the application a new database connection should be opened and that database conection should be colsed at the end of the request so for each request a new database connection
3. when I want the service to be short live like one time for one controller, for example on encryption keys that needs to be replaced every request, 
//-------------------------------------Service Scope
It is possible to instantiate child scopes in the same request by using IServiceScopeFactory.CreateScope()
1. We went to the cities service and add another interface called IDisposable
2. then with quick actions we implemented the interface
// The example here is if we have a connection to the database, we want to close it as soon as possible so we create new child scopes to erase it
3. made the service scoped in program
4. went back to home controller and add IServiceScopeFactory
5. then we aded to the view
// To sumarize theis is useful when creating own database connections that need the connection to be destroyed before
//--------------------------------------Addtransient(), Scope and Singleton
I can make the code in program that addss the scope smaller by doing the next:
builder.Services.AddTransient<ICitiesServices, CitiesService>();
//--------------------------------------View Injection
Views are compiled as classes, that is the reason why it is possible to inject services as well in the Views.
@inject IService referenceVariable
@{referenceVariable.ServiceMethod();}
1. In this lesson we added using ServiceContracts in the ViewImports
2. then we use @inject ICitiesServices in the index view
//---------------------------------------Best Practices for DI
-> Global State in services: 
-Avoid using static classes to store some data globally for all users / all requests.
-You may use singleton services for simple scenarios/ simple amount of data. in this case, prefer Concurrent Dictionary instead of Dictionary, which better handles concurrent access via multiple threads.
-Aleternatively, prefer to use Distributed Cache / Redis for any significant amount of data or complex scenarios.

->Request State in services
Don't use scoped services to share data among services within the same request, because they are NOT thread-safe.
Use HttpContext.Items instead.

->Service Locator Pattern
-Avoid using service locator pattern, without creating a child scope, because it will be harder to know about dependencies of a class.
For example, don't invoke GetService() in the default scope that is created when a new request is received.
But you can use the IServiceScopeFactory.ServiceProvider.GetService() within a child scope.

->Calling Dispose() method
-Don't invoke the Dispose() method manually for the services injected via DI.
The IoC container automatically invoke Disspose(), at the end of its scope.

->Captive Dependencies
-Don't inject scoped or transient services in singleton services.
Because, in this case, transient or scoped services act as singleton services, inside of singleton service

->Storing reference of service instance
Don't hold the reference of a resolved service object. it may cause memory leaks and you may have access to a disposed service object.
 //--------------------------------------Autofac
It is another IoC container libray for .Net Core. Means, both are tightly-coupled.
Microsoft.Extensions.DependencyInjection vs Autofac
Autofac has two more lifetime': InstancePerOwned, InstancePerMatchingLifeTimeScope
1. First we are going to add autofac by clicking on dependencies in the project view -> nuget packages download first
2. then Autofac.Extensions.DependencyInjection 
3. Now in order to enable the autofac we go to program.cs
4. Then add this line builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
5. the replace the service by builder.Host.ConfigureContainer<ContainerBuilder>().AddScoped<ICitiesServices, CitiesService>();
6. then we changed IServiceScopeFactory for ILifetimeScope in the home controller
