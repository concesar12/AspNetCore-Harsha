//------------------------------01. Web API Project
1. we are creating a new .net webapi
2. we are selecting .net 7 no authentication, HTTPS enabled and only use controllers checked
3. we added UseHsts to enforce https 

//------------------------------02. Web API Controllers
1. We are going to inherit from controllerbase class since we don't need views for an API
2. we have a dded in the launchURL inside of launchSettings the route of the controller test
3. now we created an endpoint and in the contgroller class test to print a hello world

//------------------------------03. EntityFrameworkCore with Web API
we will use databases entity framework core in this application
1. install all essential packjages
2. we have added the folder models with the properties that we are going to handle(In here is better to separate into different project to make it as clean architecture)
3. Now we will create our folder DatabaseContext, in here we have added the application context with the actaul options and getting the db sets to handle the databases (so not forget to inhherit from DbContext)
4. thn we will create onmodelcreating to have objects on creation
5. then we added new objects city
6. Now we will configure the connection string for for the database in appsettings.json
7. then we will create a new database and then click in properties of that database to get the connection string
8. once all that is done we have to run the commands to create and update the database
9. but before doing that we have to add our service in program.cs, so we added pur database as aservice and linked the connection we provided in the default
10. the run Add-Migration Initial ->   Update-Database

//-------------------------------04. Web API Controllers with EntityFrameworkCore - Part 1
We will use the ehole CRUD operations
1. first thing to do is to create a new controller to start using the databases and managing request and responses
2. click on controllers and add new controller, we are going to use the 3 option to create actions using Entity framework
3. by creating controller in this way, will generate the controller with all the code necessary to run(saves a lot of time)
4. whe we run the application and use the URL https://localhost:7163/api/cities by edfault performs a get method, in order to see what happens with pst put and delete we have to do it with a client which could be Postman
5. After we used post man to try all the http methods

//------------------------------05. Web API Controllers with EntityFrameworkCore - Part 2
in part two we mainly review all the post and get methods created by the web api application

//------------------------------ 06. Web API Controllers with EntityFrameworkCore - Part 3
we will understand the post methods created
1. we have made some changes on putcity
2. we used thge binder to accept the values that we want, we have used bind, since we don't have DTO objects in this case

//-----------------------------07. ProblemDetails
when wanting to show an error to the client, there is a better way to report that
1. in the getCity method we added Problem(detail: "Invalid CityID", statusCode: 400, title: "City Search");
2. To demonstrate the problem we will de first add required in the city class of the model
3. we will run the updates in the database by: Add-Migration CityNameRequired in the package manager
4. then run Update-Database, the whole point of this is to add problems description instead og generic problem for everythiong, this will be sent to the client

//-----------------------------08. IActionResult vs ActionResult
If we want to return any of the resullt types of Action result IActionResult is appropiate, but we have to cast the action result first thenn the object(OK(city))
if we are sure about returning only one type then ActionResult should do the job

//----------------------------09. ControllerBase


