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
