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