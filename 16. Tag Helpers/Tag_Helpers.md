//--------------------------------------Tag Helpers Form Tag helpers
can use asp-controller and asp-action
1. in index view we are going to change the hardcoded URL: 
2. We went to view imports to bring the taghelper
3. then we created the same for the create view

//-------------------------------------- 02. Input Tag Helpers - Part 1
This one generates "type", "name", "id", "data-validation", attributes for the <input>, <textarea>, <select> tags all gets replaced with asp-for
1. in create view : we do have to add @model as stronlgy typed view in order to use asp-for
2. We went to the first input and put asp-for
3. we wnt to email email and replaced this:  <input type="email" id="Email" name="Email" class="form-input" /> for <input asp-for="Email" type="email" class="form-input" />
4. IMPORTANT in the previous change it is possible to "sacar" type="email" if we provide the type in the actual personaddrequest like this:[DataType(DataType.EmailAddress)]
5. we have done the same for date
6. and as well for gender
7. We then used instead of this: <input type="radio" asp-for="Gender" value="Male" />
                <label for="Male">Male</label>

                <input type="radio" id="Female" name="Gender" value="Female" class="ml" />
                <label for="Female">Female</label>

                <input type="radio" id="Other" name="Gender" value="Other" class="ml" />
                <label for="Other">Other</label>

                we used this: 
                 @{
                    string[] genders = (string[])Enum.GetNames(typeof(GenderOptions));
                }
                @foreach (string gender in genders)
                {
                    <input type="radio" asp-for="Gender" value="@gender" />
                    <label for="@gender">@gender</label>
                }
8. then we did it with country
9. same as Receive newletters: we can take out the type checkboks if the type in the model is boolean

//-------------------------------------03. Input Tag Helpers - Part 2
instead of creating a foreach to list all the countries, there is another way to do it: 
1. first go to persons controller and modify create
2. we have to import rendering: using Microsoft.AspNetCore.Mvc.Rendering;
3. then in create view I used asp-items to retrieve countries easier

//---------------------------------04. Client Side Validations
there are two types of validation Import JQuery validation Scripts or "data-*" attributes in html tags auto generated with "asp-for" helper
1. we added the jquery scripts (three) at the end of create that will validate the data.
2. we added <span asp-validation-for="PersonName" class="text-red"></span> to show the actual error to the user
3. we added required for personaddrequest
4. We added the summary of all errors at the end with  <div asp-validation-summary="All" class="text-red"></div>

//---------------------------------- 05. Script Tag Helpers
Advantage of the jquery scripts we can cahe, but we can't rely only on jquery
we can use asp-fallback-src and asp-fallback-test
1. So in short we can have the physical file instead of quering the web just in case if the web is not accessible
2. so in this case I copied three js files obtained from the link inside of wwwroot
3. then we added the sections which will organize the scripts imported
4. In the Layout we then added @RenderSection("scripts", required: false) wich means render scripts but they are optional because of false

//----------------------------------06. Image Tag Helpers
so sometimes in some browser when using img, it can be stored in cache so when updating the image might not be loaded in the browser, we can solve this by using asp-append-version
1. we first created a new logo and use the snipping too to stored
2. then we pasted the logo inside of wwwwrootfolder
3. the we added the image inside of Layout
4. in create view we use in w-50 next to personname we used centger-box

//-----------------------------------07. Edit View
we will create the edit view which we did not so in the CRUD section
1. We have created the edit view first (it is a copy of create) 
2. in persons controller we created a new action method for edit
3. in the index view we added at the end this tag  <td style="width:20%"><a asp-controller="Persons" asp-action="Edit" asp-route-personID="@person.PersonID">Edit</a></td>
4. We added the tag options inthe index view 
5. in the controller we added the get and post methods for edit


