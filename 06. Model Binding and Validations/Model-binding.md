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
//---------------------All model validations
instead of using this:
[Required(ErrorMessage = "Person Name can't be empty or null")]
it is possible to use this: 
[Required(ErrorMessage = "{0} can't be empty or null")]this is done to get the attribute name.
In order to have the attribute separate by spaces use: [Display(Name = "Person Name")]
        [StringLength(40, MinimumLength =3, ErrorMessage = "{0} should be between 3 and 40 characters long")] // this is used to specify the length

// This is to evaluate the range
[Range(0, 999.99, ErrorMessage = "{0} should be between {1} and ${2}")] // This evaluates the range

//----------------------------Model validation part 2
Three types: 
1. [RegularExpression(string pattern, ErrorMessage="value")] // Specifies the valid pattern
2. [EmailAddress(ErrorMessage = "value")] // Specifies that the value should be a valid email address.
3. [Phone (ErrorMessage = "value")] // Specifies that the value should be a valid phone number.
4. [Compare(string otherProperty, ErrorMessage = "value")] 
// Specifies that the values of current property and other property are the same
5. [Url(ErrorMessage = "value")] // Specifies that the value should be a valid url (website address).
6. [ValidateNever] // Specifies that the propperty should not be validated (Excludes the propperty from model validation)
//---------------------------Custom Validation
Custom validation attribute are to handle own and complex validations
class Classname : ValidationAttribute
{
    public override ValidaqtionResult? IsValid(object? value, ValidationContext validationContext)
    {
        //return ValidationResult.Success;
        //[or] return new ValidationResult("error message")
    }
}
//--------------------------Custom validations with multiple properties
how to validate several fields.
Steps are create the attribute and plce it in the property you want to use it.
then go and create the class that will handle that condition
Then override the validation and generate your custom validation.
// ValidationContext -> get the corresponding value from the object.-> get information about the modal property, the modal class and the modal object
The properties get retrieved inside of: 
ObjectInstance -> which has a datatype of object values can not be retrieved directly.
Then the way to retrieve the data is trough "Reflection"
//REFLECTION -> Reading the metadata from onjects and classes it is useful to get the propperty of the objects that are been gathered dynamically
//--------------------------Validatable Object
class ClassName : IValidatableObject
{
    //Model properties here
    public IEnumerable <ValidationResult> Validate( ValidationContext validationContext)
    {
        if(consition)
        {
            yield return new ValidationResult("error message")
        }
    }
}
If the custom validation wants to be done inside of the same class this can be used, but is not practical to make it reusable because then the reflection method needs to be used
nameof operator// this will allow to refactor names all ofer the code
yield // This will allow to return multiple values

This is most usefull when performing quick and simple validations in the same file
//------------------Bind and BindNever
Bind Attribute specifies that only the specified properties should be included in model binding
This will prevent the over-posting (post values into unexpected properties) especially in 'Create' scenarios.

Controller* 

class ClassNAmeController : Controller
{
    public IActionResult ActionMethodName ([Bind(nameof(ClassName.PropertyName), nameof(ClassNAme.PorpertyName))] ClassNAme parameterName)
    {

    }
}

[BindNever] This is used to prevent just one from binding

//------------------------FromBody
for files of type csv, excel or json this is the one that will be most useful
//Enables the input formatters to read data from request body (as Json or XML or custom) only
public IActionResult ActionMethodName ([FromBody] type parameter)
{

}
//------------------------Input Formatters
They are used to transform or convert the request body into the modal object 
In order to receive Json or XML format I have to first [FromBody] and then add in the main program 
builder.Services.AddControllers().AddXmlSerializerFormatters(); // however, Json is already added by default by .net core
//------------------------Custom Model Binders
Whenever creating a complex binding it is necessary to create a model custom binder, So in brief if I wat to join two attributes or more then I can use Custom model binders

class ClassName : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        //gets value from request
        bindingContext.ValueProvider.GetValue("FirstName");

        //returns model object after reading data from the request
        bindingContext.Result = ModelBindingResult.Success(your_object);
    }
}

in the controller it is necessary to add [ModelBinder()]// eG public IActionResult Index([FromBody] [ModelBinder(BinderType = typeof(PersonModelBinder))] Person person)
 
// As example of the types used were: FirstName and LastName

//--------------------------------Model Binder Providers
this is useful when I want to use the same custom modal binder for the same object that I am handling (Person person) it can be declared globally using binder provider
class ClassName : IModelBinderProvider
{
    public IModelBinder GetBinder(ModelBinderProviderContext providerContext)
    {
        //return type of custom model binder class to be invoked
        return new BinderTypeModelBinder(typeof(YourModelBinderClassName));
    }
}
The best outcome is that I do not have to write this all the time: 
[ModelBinder(BinderType = typeof(PersonModelBinder))]

//-------------------------------Collection Binding
Whenever I want to send more than one value for the same property
 public List<string?> Tags { get; set; } = new List<string?>(); // So this mean the property is ready to receive several tags
//-------------------------------FromHeader
It is possible to get the inform,ation from the headers.
public IActionResult Index( Person person, [FromHeader(Name = "User-Agent")]string UserAgent) // So in runtime this will pick up request user value called user-agent and the value will be received in the variable "string UserAgent", to check the request headers go-> inspect-> Network -> HEaders