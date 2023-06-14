//-------------------------------------Action Filter
We will focus on action executing and on action executed
1. we will create the filters in our .net core main application so we added /Filters/ActionFilters/PersonsListActionFilter.cs
2. We have to add the action filter to the actual method in the controller, so we will apply it to the index in our persons controller 
3. we added like this: [TypeFilter(typeof(PersonsListActionFilter))]

//--------------------------------------02. Parameter Validation in Action Filter
In this lecture we will use the filters to validate the values of the parameters in the controller before executing the action
1. So in PErsonslistActionFilter we will try to look the way to bring the information to be validated
2. So we filled up OnActionExecuting we used if (context.ActionArguments.ContainsKey("searchBy")) which ensure that is the value we want get from the parameter
3. remember this will validate before this is passed to the view

//---------------------------------------03. ViewData in Action Filter
So in this action fiilter we will try to access the view data we can write or read, we will try and simplify the viewdata
1. in personsListFilter, we are going to add the data to be seen in viewdata in onActionExecuted
2.  then in persons controller we took out the ViewBag since the filter was getting it before
3. then we came back to persons filter and modifiew the values of the view bag to put it in the filter

//---------------------------------------04. Serilog Structured Logging
It is not advisable to write static messages in the serilog, the reason is because it is easier to look after
1. So in the log message of onexecuted of personsfilter we will pass them as parameters
2. So we looked in the seq app like this: FilterName = "PersonsListActionFilter"

//--------------------------------------05. Filter Arguments
We can receive arguiment values to the filter
1. We will create a new action filter  class ResponseHeaderActionFilter
2. then we will create the logger and the the structure log
  [TypeFilter(typeof(ResponseHeaderActionFilter), Arguments = new object[] { "X-Custom-Key", "Custom-Value" })]
3. so we will supply the actual values to this parameter in the controller: 
4. we added as well in the create action method

//-------------------------------------06. Global Filters
We have different scopes of filters, we will apply global filters
1. We have added a filter in the class (personcontroller)which will apply that filter for all the methods of that class  
2. So in the program.cs in the addcontrollerwithviews we will add our filter
3. The sequesnce of scoped filters is from the most global to the narrowest onExecuted

//------------------------------------07. Custom Order of Filters
We can modify the order of execution of the scoped filters, by default is 0 the order
1. We added order and the number in the action methods to set the execution order
2. That was done in the controller of person

//-----------------------------------08. IOrderedFilter
The problem in here is that in global filters we can't set the order filter by default, there is another way to set the order, using Iorder
1. In responseheader filter aside of IAction we have to implement IOrderedFilter
2. So we can set it as {get, set;} depending if we want to only read or not
3. So instead of using the order property in the controller
4. We added the last value we have just added which is 1
5. No me want to set the global as second so we are going to program.cs
6. then in persons controller we specifically set it to 4 since we have a specific configuration
7. We then manually set up the order of the filter to read the properties this is only when using typefilter
8. We have supplied in the program.cs an order value as a paremeter since it is in built only when no parameters

//--------------------------------09. Async Filters
If wanting to use asyncronous methods in the filter, so we have to use async filters
1. so instead of using IActionFilter we are using IAsyncActionFilter in the response header
2. Now We will implement that interface which will have the before and after method on it

//--------------------------------10. Short Circuiting Action Filter
Preventing the remaining items from execution, so this will prevent from validating twice the same code
1. we added a new action filter to perform the validation on create person PersonCreateAndEditPostActionFilter
2. in Persons controller the idea is to use both edit and create with the same filter for validation, so we will rename the parameters of edit to have the same name as create
3. So we added filters in all action methods of create and edit

//--------------------------------11. Result Filter
result filter are usefull when wanting to validate or make changes before passing to the view
1. the first thing is to create a foler in filters folder called ResultFilters
2. We add the class that will handle the result filter for persons PersonsListResultFilter :IAsyncResultFilter
3. now we added this new filter to the controller

//-------------------------------12. Resource Filter
useful to prevent the filter pipeline from execution, resource filters are the way, there is a use case for caching the response body in the resoults filter
1. So will create a new folder for this filter and inside the actual filter: FeatureDisabledResourceFilter
2. then we added this filter in the create action method

//-------------------------------13. Authorization Filter
we will verify before execution any action method if user is logged in or not
1. firstly we are going to create an authorization filter folder and then the class TokenAuthorizationFilter
2. Then we will add the actual authorization
3. then we will appliy the filter created to edit method http post
4. We will create a result filter to add a cookie before executing the view TokenResultFilter in person controller
5. as well as adding tokenfilter in the http get method of edit, to be beforehand logged in

//--------------------------------14. Exception Filter
When we want to catch exceptions ocurring when model binding, action filter or action method exception filter is the way
1. first we crate a folder and then a class for the filter HandleExceptionFilter
2. then we added the exception handler filter in the controller

//-------------------------------15. Impact of Short Circuiting
We are going to see how short circuiting affects the overall behaviour of the application
1. we added new logging in PersonCreateAndEditPostActionFilter
2. Then we added an after logic logger
3. It is important to know what happens when short circuiting and the impact 

//-------------------------------16. IAlwaysRunResultFilter
Always run executes after short circuiting
1. We will create file and the class for this filter in the resultfilter
2. Then we added the filteer in edit
3. then we commented put the filter in http get to avoid create the cookies and demonstrate always run works

//-------------------------------17. Filter Overrides
if we have a filter in the controller or in the global level and we want to skip the execution for an action method
1. first thing to do to demostrate this is to take this filter:     [TypeFilter(typeof(PersonAlwaysRunResultFilter))] out from edit
2. Then we will added to the actual controller (person controller)
3. We created a new filter valled SkipFilter in the filter folder
4. then in the controller in the index we added the [SkipFilter]
5.  then in personalways we added some logic

//-------------------------------18. Service Filter
We will impplement service filter, which only difference is that with service filter we can't supply argument
1. we change first personlist filter from type to service
2. but it gave us an error, that is because we have to add it as servoce in the program.cs

//-------------------------------19. Filter Attribute Classes
we will try to instead of calling [TypeFilter(typeof(PersonsListResultFilter))] we can just use the name of our filter and pass arguments in the parethesis
1. instead of using ResponseHeaderActionFilter : IAsyncActionFilter, IOrderedFilter we can just used the predefined attribute ActionFilterAttribute
2. We added in the controller the response filter without filter key [ResponseHeaderActionFilter("MyKey-FromAction", "MyValue-From-Action", 1)]
3. now in the responseheaderfilter we will delete the use of logger since it does not support DI
4. then we have to add override key word on the action method
5. we addded as well in the controller in the services 

//------------------------------20. IFilterFactory
in this lesson we will try to get the best of both Filter Attribute and typefilter by creating Ifactory filter
1. in Response headerAction we have to inherit first from IAsyncActionFilter, IOrderedFilter
2. then we have to add the order value and logger if needed
3. then we have to create another class  public class ResponseHeaderFilterFactoryAttribute : Attribute, IFilterFactory this is inside Response header (same class)
4. then in the controller filter we changed to use this factory and as well as in the index method
5. then back to response we will implement response header
6. we have to bear in mind that attributes now are public and the can read and write
7. We added logger and DI
8. Then in Controller we added the scope: builder.Services.AddTransient<ResponseHeaderActionFilter>();

//-----------------------------Filters vs Middleware
They are not the same filters operatye more to the action method level whereas middlewhere more in the application level

//-----------------------------21. UI Enhancements - Part 1
We will enhance the ui
1. There is a new css file to be replaced in the wwrootfolder
2. then we started adding in the layout the new changes in layout added top bar and persons and upload countries navbar
3. Now we are going to the person index view and make it different changing the table and filters

//-----------------------------22. UI Enhancements - Part 2
After changing layout and index we will still change some tings in the ui
1. We added a new class in edit and delete buttons
2. we will add the same breadcrumbs to the delete view
3. we will do the same for the other vies, but as a challenge we can make as a partial view to avoid repetition of code
4. then in personlistaction filter we added in the viewbaga default sort order

//----------------------------23. Configure Services Extension
we are separating the services on program.cs to release load
1. we have added a new foldeer in the projects and a cofigureservice esxtension file
2. in program we added this line above build builder.Services.ConfigureServices(builder.Configuration);
3. then we transfer everithing saying build.services to the new class created before
So as a perk we can easier modify middlewares in program.cs
4. don't forget to return the service
5. we will mock logger in tests
6. and we verified in the integration tests that Create_IfModelErrors_ToReturnCreateView is not longer applicable
