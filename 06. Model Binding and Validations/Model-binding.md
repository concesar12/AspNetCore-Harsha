//----------------Overview
Model binding is a feature of asp.net core that reads values from http requests and pass them as arguments to the action method
how to retrive data from the model binding
Controllers can retrieve data in thsi order: 
1. Form fields 
2. Request body
3. Route Data
4. Query string parameters
//-----------------Query string vs  Route data
when the value is poassed as parameter it retrieves from the query string EG
public IActionResult Index(int bookid) // in this case the URL is // //Url: /bookstore?bookid=5&isloggedin=true//
This will retrieve 5 because bookid is = 5.
pick first values gathered from the route
Route("bookstore/{bookid?}/{isloggedin?}"
/bookstore/1/false?bookid=5&isloggedin=true
//-----------------From Query and From Route
I can decide from which source I want to retrieve the data
[FromQuery]
//gets the value from query string only
public IActionResult ActionMethodName([FromQuery] type parameter)
{
}
[FromRoute]
//gets the value from Route string only
public IActionResult ActionMethodName([FromRoute] type parameter)
{
}
//----------------------Model class
Model is a class that represents structure of data (as properties) that you would like to receive from the request and/or send to response Also known as POCO (Plain Old CLR Objects)

In this example a new model was created called book, it is  class that is going to be received as the parametrers in the query string or the route.
Declared like this: 
        public override string ToString()
        {
            return $"Book object - Book id: {BookId}, Author: {Author}"; //Return a string that contains all the property values
        }
//---------------------Form-urlencoded and form-data
They they come formated are:
1. form-urlencoded (Default)
RequestHeaders-> Content-type: application/x-www-form-urlencoded
Request body-> param1=value1&param2=value2
2. Form-data
Request Headers-> multipart/form-data
 
The differences between those two are: 
for simple scenarios like sending few amout of information 5 to 6 fields for-urlencoded works well
For complex data instead is better o uso Form-data - more than 10 fields
//-------------------Introdution to model validation
Class Classname
{
    [Attribute] //applies validation rule on this property
    public type PropertyName {get;set}
}

The idea is to avoid the repitition when validating
//--------------------Model State
Propperty of the controllerBase that is available in the action methods of the controller used to check the status of the validation. 
Contains three propperties mainly: 
1. IsValid -> Specifies whether there is at least one validation error or not
2. Values -> Contains each model propperty value with corresponding "Errors" ppropperty that contains list of validation errors of that model propperty
3. ErrorCount -> returns number of errors

There is a way to modify the message of the verification which is: 
[Required(ErrorMessage = "Person NAme can't be empty or null")]