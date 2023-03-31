//------------------Creating controllers
porpouse of this is groping the middlewares based on the logical purpose -> Controller
Controller is a class that is used to group-up a set of actions.
Action methods do perform certain operation when a request is received and returns the result(repsonse)

in order to run a controller two things must be done: 
1. Add the controller as a service class : so it can participate in the dependecy injection
2. Enable the routing for the method
// Class must be public to be instantiated by .netcore

//--------------------Multiple Action Methods
It is possible to add multiple route attributes for the same action method
This lesson is about creating different routing points (endpoints) from one class
EX. about/Contact/Home
//--------------------Takeouts of controllers
It is possible to use an attribute [Controller] if the class is not to be used with the suffix controller
//....................Content Result
ContentResult can represent any type of response, based on the specified MIME type. 
MIME ( Multipurpose Internet Mail Extensions, now properly called "media type")
MIME type represents type of the content such as text/plain, text/html, application/jaon , application, xml, application/pdf etc.
ContentType, will be the type of the content

In order to avoid using all of this 
        public ContentResult Index() // Method to be accessed // The name index relates to the main page // ContentResult will have the type to be responded 
        {
            return new ContentResult() { Content = "Hello from Index", ContentType = "text/plain" }; // It is necessary to provide a valid content type
        }
It is posible to return Content() this is done by inheriting from 

Microsoft.AspNetCore.Mvc.-> is not necessary to put it implicity since it is already in the using statement 
If I don't want to inherit controller, I can do it in the long way

//-------------------------Json Result
Represent an object in Javascript object notation Eg: {"firstName": "James"}
in order to avoid writing confusing quotes to avoid doble quotes to return a Jason, it is better to create an object and return it
in this case a person class was created in order to return the json
//-------------------------File Result
sends the content file as response
three types of file results:
virtualFileResult: return  new VirtualFileResult("file relative path", "content type")
PhysicalFileResult: new PhysicalFileResult("file absolute path", "content type")
FileContentResult: new FileContentResult("byte_array", "content type")
The way to return this object is:
        [Route("file-download")] 
        public VirtualFileResult FileDownload() 
        {
            return new VirtualFileResult("/sample.pdf", "application/pdf");
        }

However, if the file is out of wwroot then physical is the way to response:
//------------------IActionResult
The recommended way to specify the return type of a response is using IActionResult, this way it doesn't matter what is return it will catch it
It is the parent interfce for all action result
The benefit is that it can return any type of action result
//-------------------Status code results
Fixing the previous code that there are two statements that are repeated almost every time.
Send an empty response with specified status code
4 Types of status code : 
1. StatusCodeResult
2. UnauthorizedResult
3. BadRequestResult
4. NotFoundResult
//--------------------Redirect results 1
every request that comes to an old endpoint will be redirected to a new endpoint
Redirect result sends either HTTP 302 or 301 response to the browser, in order to redirect to a specific action or url
eg: redirecting from action 1 to action 2
In order to redirect this can be used: 
 return new RedirectToActionResult("Books", "Store", new { });
first is the name of class, then name of controller without the word controller and finally the last argument is a dummy because we don't want to provide a specific rule
301 Permanently redirection 
302 Temporary
//--------------------Redirect results 2
LocalRedirectResult //it will only redirect to local url's not google or facebook
RedirectResult - This is to acces remote apps or pages