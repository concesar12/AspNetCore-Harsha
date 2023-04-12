//-------------------------------Creating partial views
Partial View is a razor markup file (.cshtml) that can't be invoked individually from the controller; but can be invoked form any view within the same web application.
<partial name="partial view name"> this will invoke the content in the partial view
The use is: if I have a html element that I want to repeat in different places then I can create the partial view for that
ALL PARTIAL NAMES START WITH "_" TO BE SAFE and in the shared folder
//This is the way to use it
<partial name="_ListPartialView"></partial> @*This tag helper is necesary to add the partial view /A tag helper is a tag that internally is taken as a c# class*@

Ways of invoking the partial view: 
1. <partial name="_ListPartialView" /> -> Returns the content to parent view
2.  @await Html.PartialAsync("_ListPartialView") -> Returns the content to parent view
3. @{
    await Html.RenderPartialAsync("_ListPartialView"); -> Streams the content to the browser// will be directly streamed so it is a better performance
}

//---------------------------------Partial views with View Data
When view is invoked, it receives a copy of the parent view's ViewData object. So, any changes made in the ViewData in the partial view, do not affect the ViewData of the parent view.
Optionally, you can supply a custom ViewData object to the partial view, if you don't want the partial view to access the entire ViewData of the parent view.
//----------------------------------Strongly typed partial views
Is a partial view that is bound to a specified model class.
So, it gets all the benefits of a strongly typed view.
1. We created a model ListModel we the list title and list model from previous excercise
2. send an objct of that model class to the partial view
3. deleted the piece of code related to Index in homne controller.
4. createt a code block and adding an object of the model created, import namespace
5. Add in the partial tag helper the property model = model="listModel
6. Then make strongly typed view by going to ListPartialView and adding the model
7. change <h3>@ViewBag.ListTitle</h3> for <h3>@ViewBag.ListTitle</h3>
8. copy the list  of countries in about, we saw that if we don't provide the model can be an error
//-----------------------------------Partial views result
from the action method(controller) it is possible to return a partial view
This is generally useful to fetch partial view's content into the browser, by making an asynchronous request (CMLHttpRequest/fetch request) from the browser. whenerver if I want to load additional content from the server this will be useful.
1. create a new action result in the controller
2. the idea is to handle the asyc response with javascript, what was created was a new button the shows when button is clicked
3. added this javascript which fetches and handle the response 
<script>
    document.querySelector("#button-load").addEventListener("click", async function() {
       var response = await fetch("programming-languages");
       var languages = await response.text();
       document.querySelector(".programming-languages-content").innerHTML = languages;
    });
</script>

Example to be used if there is a ecommerce and there is a function or button that says show all orders, then this javascript can be executed to show dinamically what is inside.
