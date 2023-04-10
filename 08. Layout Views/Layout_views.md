//---------------------Layout Views
Ias a web page (.cshtml) that is responsible for cintaining presentation logic template (Commonly the html template with header, sidebar, footer. etc)
common views are to be placed in the shared folder
I need to create a view in order to execute a layout view
//---------------------Creating layout views 2
@{
    Layout = "~/Views/Shared/_Layout.cshtml"; //It will execute this route, it is possible to assign LAyout = null if there is not shared layout
}
@*Whatever written in here will be replaced in the Layout view in the @renderBody element*@
//---------------------Layout View with multiple views
The idea is to add the views from all the controllers
//---------------------View Data in Layout views
The idea in this lesson is that we can transfer data from any view to the Layout view, in this case we added dynamic title change passing it to the layout view from the other views
//---------------------_ViewStart
_ViewStartrfile is a special file which is executed before of the view and it is used to specify the common layout view for multiple views in the same folder
It ios possible to overide the view by specifying the view
//----------------------Dynamic Layout views
This is about setting a different LAyout view according to what is need it.
//----------------------LayoutViews - sections
Defines the content in the view, to be rendered in a specific place in the layout view
Sections can be rendered as optioinal, by using required: false parameter.
View                             Layout View
@section section_name     ->    @RenderSection("section_name")
{
    section content
}
//-----------------------Nested Layout Views
A layout view that has another layout nested