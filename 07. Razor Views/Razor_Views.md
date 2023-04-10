//----------------------Views
View is a web page cshtml this can be combined with css
//----------------------Code blocks and expressions
Razor code block-> Is a C# code that contains one or more lines of C# code that can contain any statements and local functions
@ {
C# /html code here
}
Razor Expressions -> Razor expression is a C# expression (accessing field, property or method call) that returns a value
@Expression
--or--
@(Expression)

All the code blocks created in the same view have scope in the same acrooss the same view
Facts of views
-View cintains HTML markup with Razor markup (C# code in view to render dynamic contant).
-View is not supposed to have lots of C# code.
Any code written in the view should relate to presenting the content (Presentation logic).

- Razor is the view engine that defines syntax to write C# code in the view. @is the syntax
  -View should neither directly call the bussiness model, nor call the controller's action methods
  but it can send request to controllers
  //--------------------------If statement
  @if(condition) {

}
else {

}
//-------------------------Switch cases
@switch(variable){
case value1: C#code;break;
case value2: C#code;break;
default: C#code;break;
}
//-------------------------Foreach
@foreach(var variable in collection) {
C#
}
//--------------------------For
@for(init;condition;iteration)
{
}
//--------------------------Literal
how to express literal code that is not C# code
razor - literal
@{
@:static text
}
<text>static text</text>
//---------------------------Local functions
Only callables within the same view
@{
return_type method_name(arguments){
  code
}
}
//----------------------------HTML raw
@{
string variable = "html code";
}
@Html.Raw(variable) // prints the html markup without encoding(converting html tags into plain text)
This can be used for testing to keep the numer on
//----------------------------View Data 1
Controller supply, view uses 
The way to give the data from the controller to the view is trough ViewData
-Is a dictionary object that is automatically created up on receiving a request and will be automatically deleted before sending response to the client. It is mainly used to send data from the controller to view.
//----------------------------View data 2
<link href="~/StyleSheet.css" rel="stylesheet" /link> this is the way to add the css file, the '~' character means in the port of the local host.
ViewData is a property of Microsof.AspNetCore.MVC.Controller class and Microsoft.AspNetCore.Mvc.Razor.RazorPage class

namespace Microsoft.AspNetCore.Mvc
{
  public abstract class Controller : ControllerBase
  {
    public ViewDataDictionary ViewData { get; set; }
  }
}
//-------------------------ViewBag
PRoblem with View Data is that we have to cast the type to the appropiate type. 
To fix this proble view bag has been introduced.
ViewBag is a property of controller and View, that is used to access the ViewData easily.
ViewBag is dynamic type
//-------------------------Strongly typed views
Is a view that bound to a specific model class.
It is mainly used to access the model object/model collection easily in the view.
@model.PropertyName
return View("Index", people); first argument is the view, second is the object
insteaad of viewbag->modal
//-------------------------Strongly typed views 2
in this example we want to include a single person
Advantages of stongly typed views
You will get intellisense while accessing model properties in strongly typed views
-only one model per one view
property at compile times
Easy to identify which model is being accessed in the view
--Four versions of the view method
Return View();
Return View(object Model);
Return View(string ViewNAme);
Return View(string ViewName, object model);
//--------------------------Strongly typed views with multiple models
this can be bound to a single model directly, but that model class can have reference to objects of other model classes
a workaround to have different model is to create a wrapper that holds different models
//--------------------------Viewimports.cshtml
instead of using @using "ViewsExample.Models" we can use _Viewimports to use it only once for the whole project
Def: is a special file in the views folder or its subfolder, which executes automatically before execution of a view
It is mainly used to import common namespaces that are to imported in a view.
_Viewimports -> _ViewStart.cshtml -> View.cshtml -> LayoutView.cshtml
//--------------------------Shared views
these are placed in "Shared" folder in "Views" folder.
They are accessible from any controller, if the view is not present in the "Views\ControllerName" folder.